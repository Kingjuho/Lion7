using System;

namespace PokemonTextRPG
{
    // 상수
    public class Constants
    {
        public const string TITLE = "Pokemon RPG";
        public const int SCREEN_WIDTH = 42;
        public const int SCREEN_HEIGHT = 25;
        public const int APPEAR_PERCENTAGE = 25;

        // 전역 공유
        public static Random random = new Random();
    }
}
