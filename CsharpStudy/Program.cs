using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CsharpStudy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /***************************/
            /* 2025/12/31 C# Study #1 */
            /*************************/

            /*
            int posX = 0, posY = 50, posZ = 100;
            Console.WriteLine("X = {0}, Y = {1}, Z = {2}", posX, posY, posZ);
            Console.WriteLine("X = " + posX + ", Y = " + posY + ", Z = " + posZ);
            Console.WriteLine($"X = {posX}, Y = {posY}, Z = {posZ}");

            //int red = 255, green = 128, blue = 0;
            //Console.WriteLine("R = {0}, G = {1}, B = {2}", red, green, blue);
            //Console.WriteLine("R = " + red + ", G = " + green + ", B = " + blue);
            //Console.WriteLine($"R = {red}, G = {green}, B = {blue}");

            Console.WriteLine("┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓");
            Console.WriteLine("┃  * CONTINUE                            ┃");
            Console.WriteLine("┃            * Edd                       ┃");
            Console.WriteLine("┃            * Team Flare Secret HQ      ┃");
            Console.WriteLine("┃  * Badges:   7      Pokedex:  261      ┃");
            Console.WriteLine("┃  * Time:          25 : 20              ┃");
            Console.WriteLine("┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛");
            Console.WriteLine();
            Console.WriteLine("┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓");
            Console.WriteLine("┃ MYSTERY GIFT                           ┃");
            Console.WriteLine("┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛");
            Console.WriteLine("┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓");
            Console.WriteLine("┃ LIVE COMPETITION                       ┃");
            Console.WriteLine("┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛");
            */


            /***************************/
            /* 2026/01/05 C# Study #2 */
            /*************************/

            //const double Pi = 3.14159;
            //const int MaxScore = 100;

            //Console.WriteLine($"Pi: {Pi}");
            //Console.WriteLine($"MaxScore: {MaxScore}");


            //const int MaxPlayers = 4;
            //const int Gold = 1000;
            //const string Version = "1.0.0";

            //Console.WriteLine($"=== 게임 설정 ===");
            //Console.WriteLine($"최대 플레이어: {MaxPlayers}명");
            //Console.WriteLine($"시작 골드: {Gold}G");
            //Console.WriteLine($"버전: {Version}");


            //int integerNum = 10;
            //float floatNum = 3.14f;
            //double doubleNum = 3.14159;

            //Console.WriteLine($"{integerNum}");
            //Console.WriteLine($"{floatNum}");
            //Console.WriteLine($"{doubleNum}");


            //byte level = 50;  // 정수형 타입
            //short attack = 1500;
            //int gold = 1234567;
            //long experience = 99999999L;

            //Console.WriteLine("=== 캐릭터 정보 ===");
            //Console.WriteLine($"레벨: {level}");
            //Console.WriteLine($"공격력: {attack}");
            //Console.WriteLine($"소지금: {gold:N0}골드");     // N0: 천 단위 구분기호 표시
            //Console.WriteLine($"경험치: {experience:N0}");

            //// 타입별 최대값
            //Console.WriteLine("\n=== 타입별 최대값 ===");
            //Console.WriteLine($"byte 최대값: {byte.MaxValue}");
            //Console.WriteLine($"short 최대값: {short.MaxValue}");
            //Console.WriteLine($"int 최대값: {int.MaxValue:N0}");
            //Console.WriteLine($"long 최대값: {long.MaxValue:N0}");


            //float singlePrecision = 3.14f;                              // 단정밀도 실수(4바이트)
            //double doublePrecision = 3.1415926535;                      // 배정밀도 실수(8바이트)
            //decimal highPrecision = 3.1415926535897932384626433833m;    // 고정밀도 실수(16바이트)

            //Console.WriteLine(singlePrecision);
            //Console.WriteLine(doublePrecision);
            //Console.WriteLine(highPrecision);

            // 리터럴(접미사)
            //int integerValue = 100;         // 기본 정수형
            //long longValue = 100L;          // 롱 정수형
            //double doubleValue = 3.14;      // 기본 실수형
            //float floatValue = 3.14f;       // 단정밀도 실수형
            //decimal decimalValue = 3.14m;   // 고정밀도 실수형

            //Console.WriteLine(integerValue);
            //Console.WriteLine(longValue);
            //Console.WriteLine(doubleValue);
            //Console.WriteLine(floatValue);
            //Console.WriteLine(decimalValue);


            //char letter = 'A';
            //char symbol = '#';
            //char number = '9';

            //Console.WriteLine(letter);
            //Console.WriteLine(symbol);
            //Console.WriteLine(number);


            //float moveSpeed = 5.5f;
            //double attackSpeed = 1.25;
            //decimal itemPrice = 12.99m;

            //Console.WriteLine("==== 캐릭터 능력치 ====");
            //Console.WriteLine($"이동속도: {moveSpeed}");
            //Console.WriteLine($"공격속도: {attackSpeed}");
            //Console.WriteLine($"아이템 가격: {itemPrice}");


            //string greeting = "Hello, World!";
            //string name = "Alice";

            //Console.WriteLine(greeting);
            //Console.WriteLine(name);


            //char grade = 'A';
            //char symbol = '★';
            //string playerName = "홍길동";
            //string welcomeMessage = "게임에 오신 것을 환영합니다!";

            //Console.WriteLine("=== RPG 게임 ===");
            //Console.WriteLine($"플레이어: {playerName}");
            //Console.WriteLine($"등급: {grade}등급 {symbol}");
            //Console.WriteLine($"{welcomeMessage}");


            //bool isRunning = true;
            //bool isFinished = false;

            //Console.WriteLine(isRunning);
            //Console.WriteLine(isFinished);


            //bool isRunning = true;
            //bool isPaused = false;
            //bool isKeyCollected = false;
            //bool isDoorOpen = false;
            //bool isPlayerAlive = true;

            //int health = 80;
            //bool isHealthy = true;
            //bool isDangerous = false;

            //Console.WriteLine("=== 게임 상태 ===");
            //Console.WriteLine($"게임 실행 중: {isRunning}");
            //Console.WriteLine($"일시정지: {isPaused}");
            //Console.WriteLine($"열쇠 소지: {isKeyCollected}");
            //Console.WriteLine($"문 열림: {isDoorOpen}");
            //Console.WriteLine($"플레이어 생존: {isPlayerAlive}");
            //Console.WriteLine("\n=== 캐릭터 상태 ===");
            //Console.WriteLine($"체력: {health}");
            //Console.WriteLine($"건강 상태: {isHealthy}");
            //Console.WriteLine($"위험 상태: {isDangerous}");


            //int number = 123;
            //string numberAsString = number.ToString();

            //bool flag = true;
            //string flagAsString = flag.ToString();

            //Console.WriteLine($"숫자: {numberAsString}");
            //Console.WriteLine($"논리값: {flagAsString}");


            Console.Write("안");
            Thread.Sleep(1000);
            Console.Write("녕");
            Thread.Sleep(1000);
            Console.Write("하");
            Thread.Sleep(1000);
            Console.Write("세");
            Thread.Sleep(1000);
            Console.Write("요");
        }
    }
}
