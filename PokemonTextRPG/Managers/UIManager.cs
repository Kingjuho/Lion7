using System;
using System.Threading;
using static System.Net.Mime.MediaTypeNames;

namespace PokemonTextRPG.Managers
{
    public static class UIManager
    {
        // 메인 화면 그리기
        public static void DrawMainMenu()
        {
            Console.Clear();

            string title = @"
  ___     _                      
 | _ \___| |_____ _ __  ___ _ _  
 |  _/ _ \ / / -_) '  \/ _ \ ' \ 
 |_| \___/_\_\___|_|_|_\___/_||_|
         | _ \ _ \/ __|          
         |   /  _/ (_ |          
         |_|_\_|  \___|   
";

            // 아스키아트 출력 위치
            int titleY = Constants.SCREEN_HEIGHT / 5;
            Console.SetCursorPosition(0, titleY);

            // 줄바꿈 문자로 쪼개기
            string[] lines = title.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
            
            // 가장 긴 줄의 길이 찾기
            int maxWidth = 0;
            foreach (string line in lines)
            {
                int len = GetDisplayLength(line);
                if (len > maxWidth) maxWidth = len;
            }

            // 전체 그림을 가운데로
            int padding = Math.Max(0, (Constants.SCREEN_WIDTH - maxWidth) / 2);
            if (padding % 2 == 0) ++padding;
            
            string paddingStr = new string(' ', padding);

            // 아스키아트 출력
            foreach (string line in lines) Console.WriteLine(paddingStr + line);

            // 시작 문구 출력
            int messageY = (Constants.SCREEN_HEIGHT / 5) * 3;
            Console.SetCursorPosition(0, messageY);
            PrintCenteredText("Press [Enter] Key to Start");
        }

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

        // 메시지 출력(기본값 = 하단)
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

        // 2바이트 문자 길이 계산
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

        // 가운데 정렬 출력 헬퍼
        public static void PrintCenteredText(String message)
        {
            // 가운데 정렬 패딩 계산
            int padding = Math.Max(0, (Constants.SCREEN_WIDTH - GetDisplayLength(message)) / 2);
            Console.WriteLine(new string(' ', padding) + message);
        }

        // 오른쪽 정렬 출력 헬퍼
        public static void PrintRightAlignedText(string message)
        {
            // 오른쪽 정렬 패딩 계산(-1은 줄바꿈 방지)
            int padding = Math.Max(0, Constants.SCREEN_WIDTH - 1 - GetDisplayLength(message));
            Console.WriteLine(new string(' ', padding) + message);
        }
    }
}