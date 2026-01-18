using System;
using System.Threading;

namespace PokemonTextRPG.Managers
{
    public static class UIManager
    {
        // 구분자 그리기 헬퍼
        public static void DrawSeparator(char c)
        {
            Console.WriteLine(new string(c, Constants.SCREEN_WIDTH - 1));
        }
        public static void DrawSeparator(char c, int y)
        {
            Console.SetCursorPosition(0, y);
            Console.Write(new string(c, Constants.SCREEN_WIDTH - 1));
        }

        // 하단 메시지 출력
        public static void ShowMessage(string message, int uiY = Constants.MESSAGE_LOCATION)
        {
            // 해당 줄 초기화
            Console.SetCursorPosition(0, uiY);
            DrawSeparator(' ', uiY);

            // 메시지 출력
            Console.SetCursorPosition(0, uiY);
            Console.Write($" [알림] {message}");

            Thread.Sleep(1000);
        }

        // 한글 너비를 고려한 출력
        public static void PrintFixedLine(string text)
        {
            int currentLength = GetDisplayLength(text);
            int padding = Math.Max(0, Constants.SCREEN_WIDTH - 1 - currentLength);
            Console.WriteLine(text + new string(' ', padding));
        }

        // 한글(2바이트) 헬퍼
        public static int GetDisplayLength(string str)
        {
            int length = 0;
            foreach (char c in str)
            {
                if (c >= '\uAC00' && c <= '\uD7A3') length += 2;
                else length += 1;
            }
            return length;
        }
    }
}