using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NonstopCoding.Models.Multilingual
{
    public class Korean : Multilingual
    {
        public Korean()
        {
            Title = "논스톱 프로그래밍!";
            Subtitle = "크리스마스에 24시간동안 진행되는 논스톱 프로그래밍";
            SubMessage = "끝날 때 까지 절대 <b>키보드에서 떨어지지 마세요</b>!";

            Header = "이게 뭔가요?";
            Introduction_1 = $"\"논스톱 프로그래밍\" 은 {GetUserTag("0x00000FF", "PKnowledge(0x00000FF)")}가 개최한 이벤트입니다. " +
                             $"참가자들은 그저 자신이 완수하고자 하는 프로젝트를 하나 붙잡고 끝까지 물고 늘어지시면 됩니다. 끝까지 시도해보세요!";
            Introduction_2 = "참가에 제한은 없습니다! 다같이 열심히 불타보아요!";
            Introduction_3 = "만약 자신의 프로젝트를 공유하고 싶다면, GitHub 저장소를 등록해보세요!";

            ContributionMessage = "번역에 기여하고 싶나요? @0x00000FF로 DM을 남겨주세요!";
        }
    }
}
