using UnityEngine;

namespace SingletonDemo
{
    // 로비
    // 1. UI
    //  - 게임 시작 씬
    //  - 로비 우측 상단에 보유 코인 표시
    //  - 게임 종료 시 보유 코인은 리셋됨
    //  - 일반 던전과 이벤트 던전 버튼을 누르면 Game 씬으로 이동
    //  - 게임에서 로비로 돌아오면 게임에서 획득한 코인이 보유 코인에 추가됨
    
    // 게임
    // 1. UI
    //  - 우측 상단에 보유 코인 표시
    //  - 나가기 버튼을 클릭하면 Lobby 씬으로 이동
    // 2. 일반 던전
    //  - 입장 제한 없음
    //  - 코인 획득 1개씩 얻고, 잃음
    // 3. 이벤트 던전
    //  - 마지막 입장 시간을 기준으로 1분 뒤 입장 가능
    //  - 코인 획득은 1~100개씩 얻고, 잃음

    public enum DungenType
    {
        Normal,
        Event,
    }

    public class PlayManager
    {
        static private PlayManager Instance = null;
        public int coin { get; private set; }
        public DungenType dungenType { private get; set; }

        public static PlayManager GetInstance()
        {
            if ( Instance == null )
            {
                Instance = new PlayManager();
            }
            return Instance;
        }

        private PlayManager(){}

        public void GainCoin()
        {
            var isNormal = dungenType == DungenType.Normal;
            coin += isNormal ? 1 : Random.Range(1, 100);
        }

        public void LooseCoin()
        {
            var isNormal = dungenType == DungenType.Normal;
            coin -= isNormal ? 1 : Random.Range(1, 100);
        }
    }
}