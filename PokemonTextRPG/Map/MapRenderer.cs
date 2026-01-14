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
                        Console.Write("＠");
                    }
                    else
                    {
                        // 타일 정보 가져와서 출력
                        Tile tile = map.GetTileInfo(x, y);
                        Console.ForegroundColor = tile.Color;
                        Console.Write(tile.Symbol);
                    }
                }
                Console.WriteLine();
            }

            Console.ResetColor();
        }
    }
}