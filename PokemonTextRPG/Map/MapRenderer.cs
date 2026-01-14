using System;

namespace PokemonTextRPG.Map
{
    public static class MapRenderer
    {
        public static void Draw(MapBase map, int playerX, int playerY)
        {
            // 화면 깜빡임 방지
            Console.SetCursorPosition(0, 0);

            // 상단 정보 출력
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"[ 현재 위치: {map.Name} ]");
            Console.WriteLine("----------------------------------------------------");

            for (int y = 0; y < map.Height; y++)
            {
                for (int x = 0; x < map.Width; x++)
                {
                    // 플레이어 출력
                    if (x == playerX && y == playerY)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("🚶");
                    }
                    else
                    {
                        string tile = map.GetTileIcon(x, y);
                        SetColorByTile(tile);
                        Console.Write(tile);
                    }
                }
                Console.WriteLine();
            }

            Console.ResetColor();
        }

        // 타일에 따른 색상 설정
        private static void SetColorByTile(string tile)
        {
                 if (tile == "🌳") Console.ForegroundColor = ConsoleColor.Green;
            else if (tile == "☘️") Console.ForegroundColor = ConsoleColor.DarkGreen;
            else if (tile == "💐") Console.ForegroundColor = ConsoleColor.Magenta;
            else if (tile == "🚧") Console.ForegroundColor = ConsoleColor.DarkGray;
            else if (tile == "📫") Console.ForegroundColor = ConsoleColor.Yellow;
            else if (tile == "🏠") Console.ForegroundColor = ConsoleColor.DarkRed;
            else Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}