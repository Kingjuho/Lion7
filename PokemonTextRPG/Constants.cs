using System;

namespace PokemonTextRPG
{
    // 상수
    public class Constants
    {
        public const string TITLE = "Pokemon RPG";  // 제목
        public const int SCREEN_WIDTH = 42;         // 가로 해상도
        public const int SCREEN_HEIGHT = 25;        // 세로 해상도
        public const int MESSAGE_LOCATION = 23;     // 콘솔 메시지 출력 위치
        public const int APPEAR_PERCENTAGE = 25;    // 야생 조우 확률

        // 전역 공유
        public static Random random = new Random();
    }
}
