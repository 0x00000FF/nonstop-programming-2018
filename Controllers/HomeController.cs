using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NonstopCoding.Models;
using System.Data.SQLite;

using NonstopCoding.Models.Multilingual;
using System.Net;
using System.IO;

namespace NonstopCoding.Controllers
{
    public class HomeController : Controller
    {
        private Tuple<SQLiteConnection, SQLiteCommand> GetConnection(string sql, params Tuple<string, object>[] args)
        {
            if (!System.IO.File.Exists("Ncoding.sqlite"))
            {
                SQLiteConnection.CreateFile("Ncoding.sqlite");
                var tableCreate = GetConnection("CREATE TABLE NONSTOPCODING_REPOS ( id INTEGER PRIMARY KEY AUTOINCREMENT, repo varchar(64) UNIQUE )");
                tableCreate.Item2.ExecuteNonQuery();
                tableCreate.Item1.Close();
            }

            var conn = new SQLiteConnection("Data Source=Ncoding.sqlite;Version=3;");
            conn.Open();
            
            var command = new SQLiteCommand(sql, conn);

            foreach ( var arg in args )
            {
                command.Parameters.AddWithValue(arg.Item1, arg.Item2);
            }

            return new Tuple<SQLiteConnection, SQLiteCommand>(conn, command);
        }

        public IActionResult Index(string locale)
        {
            var geo = locale;

            if (locale == null)
            {
                var ip = HttpContext.Request.Headers["X-Forwarded-For"];
                var geoip = new GeoIP(ip);
                var _geo = geoip.GetGeoIP(); // Need to be cleaned

                geo = _geo.countryCode;
            }

            if (geo == "KR")
            {
                ViewBag.Language = new Korean();
            }
            else if (geo == "JP")
            {
                ViewBag.Language = new Japanese();
            }
            else
            {
                ViewBag.Language = new English();
            }

            var totalCounts = GetConnection("SELECT COUNT(*) AS count FROM NONSTOPCODING_REPOS");
            var count = (Int64) totalCounts.Item2.ExecuteScalar();
            totalCounts.Item1.Close();

            return View((int)count);
        }
        
        [HttpGet("/Load/{page}")]
        public List<string> Load(int page = 1)
        {
            if (page < 1) return null;

            var data = GetConnection($"SELECT * FROM NONSTOPCODING_REPOS ORDER BY id DESC LIMIT 5 OFFSET 5 * {page - 1}");
            using (var read = data.Item2.ExecuteReader())
            {
                var list = new List<string>();

                while (read.Read())
                {
                    list.Add(read["repo"].ToString());
                }

                data.Item1.Close();
                return list;
            }
        }

        [HttpPost("/Register")]
        [ValidateAntiForgeryToken]
        public int Register(string repoUrl)
        {
            if (repoUrl.Split('/').Length != 2)
            {
                return -1;
            }

            var apiEndpoint = $"https://api.github.com/repos/{repoUrl}";
            var request = (HttpWebRequest)WebRequest.Create(apiEndpoint);

            request.Host = "api.github.com";
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:64.0) Gecko/20100101 Firefox/64.0";
            request.KeepAlive = true;
            request.Headers["Upgrade-Insecure-Requests"] = "1";

            try
            {
                using (var response = request.GetResponse() as HttpWebResponse)
                {
                    if ( response.StatusCode == HttpStatusCode.OK )
                    {
                        var command = GetConnection("INSERT INTO NONSTOPCODING_REPOS(repo) VALUES (@repo)",
                            new Tuple<string, object>("@repo", repoUrl)
                            );

                        if (command.Item2.ExecuteNonQuery() > 0)
                            return 0;
                        else
                            return 2;
                    }
                    else
                    {
                        return 1;
                    }
                }
            }
            catch (WebException e)
            {
                if ( e.Response is HttpWebResponse response && 
                    response.StatusCode == HttpStatusCode.NotFound )
                {
                    return 404;
                }

                return 500;
            }
        }
    }
}
