using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NonstopCoding.Models.Multilingual
{
    public class Japanese : Multilingual
    {
        public Japanese()
        {
            Title = "無休息プログラミング!";
            Subtitle = "雪が溶ける前! 完成してみましょう!";
            SubMessage = "完成するまで,<b>キーボードから手を離せません!</b>";

            Header = "これ、なに？";
            Introduction_1 = $"『無休息プログラミング」とは、{GetUserTag("0x00000FF", "PKnowledge(0x00000FF)")}が主催したプログラミングイベントです。  クリスマスに皆様のプロジェクトのためにコーディングするだけです! そうなので, 無休息プログラミングです！";
            Introduction_2 = "参加に必要なものはありません! 一緒にコーディングしましょう!";
            Introduction_3 = "共有したいプロジェクトのGitHubのURLをここに!";

            Contributor = $"* このページの日本語版は{GetUserTag("official_LuisK", "ルイスK")}さんが作成しました。";
            ContributionMessage = "If you want to fix error or submit translations, please DM to @0x00000FF!";
        }
    }
}
