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


            //Console.Write("안");
            //Thread.Sleep(1000);
            //Console.Write("녕");
            //Thread.Sleep(1000);
            //Console.Write("하");
            //Thread.Sleep(1000);
            //Console.Write("세");
            //Thread.Sleep(1000);
            //Console.Write("요");



            /***************************/
            /* 2026/01/06 C# Study #3 */
            /*************************/

            //Console.Write("이름을 입력하세요: ");
            //string userName = Console.ReadLine();

            //Console.WriteLine($"안녕하세요, {userName}님!");


            //Console.Write("나이를 입력하세요: ");
            //int age = int.TryParse(Console.ReadLine(), out age) ? age : 1;

            //Console.WriteLine($"내년에는 {age + 1}살이 되겠군요!");


            // 2진수 -> 10진수 변환
            //Console.Write("2진수를 입력하세요: ");
            //string binaryValue = Console.ReadLine();
            //int decimalValue = Convert.ToInt32(binaryValue, 2);

            //Console.WriteLine($"2진수 값: {binaryValue}");
            //Console.WriteLine($"10진수 값: {decimalValue}");


            // 10진수 -> 2진수 변환
            //Console.Write("\n10진수를 입력하세요: ");
            //int decimalInput = int.TryParse(Console.ReadLine(), out decimalInput) ? decimalInput : 0;
            //string binaryOutput = Convert.ToString(decimalInput, 2);

            //Console.WriteLine($"10진수 값: {decimalInput}");
            //Console.WriteLine($"2진수 값: {binaryOutput}");


            //Console.WriteLine("=== 캐릭터 생성 ===");
            //Console.Write("캐릭터 이름을 입력하세요: ");
            //string name = Console.ReadLine();
            //Console.WriteLine($"환영합니다, {name}님!");
            //Console.Write("시작 레벨을 입력하세요: ");
            //string level = Console.ReadLine();
            //Console.WriteLine($"{name}님의 시작 레벨은 {level}입니다.");


            //var name = "Alice";
            //var age = 25;
            //var isStudent = true;

            //Console.WriteLine($"이름: {name}, 나이: {age}, 학생 여부: {isStudent}");


            // 1. 암시적 변환
            //int smallNumber = 100;      // int (4바이트)
            //long bigNumber = smallNumber; // int -> long (8바이트)
            //double doubleNumber = smallNumber; // int -> double (8바이트)

            //Console.WriteLine("=== 암시적 변환 ===");
            //Console.WriteLine($"int: {smallNumber.GetType()}");
            //Console.WriteLine($"long: {bigNumber.GetType()}");
            //Console.WriteLine($"double: {doubleNumber.GetType()}");

            // 2. 명시적 변환
            //double pi = 3.14159;
            //int intPi = (int) pi; // double -> int

            //Console.WriteLine("\n=== 명시적 변환 ===");
            //Console.WriteLine($"double: {pi}");
            //Console.WriteLine($"int: {intPi}");


            // 연산자
            //int a = 5, b = 3;
            //Console.WriteLine($"합: {a + b}");
            //Console.WriteLine($"a = b?: {a == b}");

            //a = 10;
            //Console.WriteLine($"{a + b}, {a - b}, {a * b}, {a / b}, {a % b}");      // 산술 연산자


            //int a = 5, b = 4;
            //Console.WriteLine(a += b);
            //a = 5;
            //Console.WriteLine(a -= b);
            //a = 5;
            //Console.WriteLine(a *= b);
            //a = 5;
            //Console.WriteLine(a /= b);
            //a = 5;
            //Console.WriteLine(a %= b);


            //int baseAttack = 50;
            //int weaponBonus = 30;

            //Console.WriteLine("=== 공격력 계산 ===");
            //Console.WriteLine($"기본 공격력: {baseAttack}");
            //Console.WriteLine($"무기 데미지: {weaponBonus}");
            //Console.WriteLine($"총 공격력: {baseAttack + weaponBonus}");

            //int playerHealth = 100;
            //int damage = 25;

            //Console.WriteLine("\n=== 데미지 계산 ===");
            //Console.WriteLine($"받은 데미지: {damage}");
            //Console.WriteLine($"남은 체력: {playerHealth -= damage}");

            //int monsterSkilled = 5;
            //int expPerMonster = 100;

            //Console.WriteLine("\n=== 경험치 계산 ===");
            //Console.WriteLine($"처치한 몬스터 수: {monsterSkilled}마리");
            //Console.WriteLine($"획득한 경험치: {monsterSkilled * expPerMonster}");

            //int totalGold = 1000;
            //int playerCount = 4;

            //Console.WriteLine("\n=== 골드 분배 ===");
            //Console.WriteLine($"총 골드: {totalGold}G");
            //Console.WriteLine($"플레이어 수: {playerCount}명");
            //Console.WriteLine($"1인당 골드: {totalGold / playerCount}G");
            //Console.WriteLine($"남은 골드: {totalGold % playerCount}G");


            //int b = 3;
            //Console.WriteLine(b++);
            //Console.WriteLine(b);
            //Console.WriteLine(--b);
            //Console.WriteLine(b);


            //int kills = 0;
            //Console.WriteLine("=== 몬스터 처치 ===");
            //Console.WriteLine($"고블린 처치! (킬 카운트: {++kills})");
            //Console.WriteLine($"오크 처치! (킬 카운트: {++kills})");
            //Console.WriteLine($"드래곤 처치! (킬 카운트: {++kills})");
            //Console.WriteLine($"총 처치 수: {kills}마리");

            //int bullets = 30;
            //Console.WriteLine("\n=== 사격 ===");
            //Console.WriteLine($"남은 탄약: {bullets}");
            //Console.WriteLine($"발사! 남은 탄약: {--bullets}");
            //Console.WriteLine($"발사! 남은 탄약: {--bullets}");
            //Console.WriteLine($"발사! 남은 탄약: {--bullets}");

            //int count = 3;
            //Console.WriteLine("\n=== 카운트다운 ===");
            //Console.WriteLine(count);
            //Console.WriteLine(--count);
            //Console.WriteLine(--count);
            //Console.WriteLine("발사!");


            //int x = 5, y = 10;
            //Console.WriteLine($"x < y: {x < y}");   // 참
            //Console.WriteLine($"x > y: {x > y}");   // 거짓
            //Console.WriteLine($"x <= y: {x <= y}"); // 참
            //Console.WriteLine($"x >= y: {x >= y}"); // 거짓
            //Console.WriteLine($"x == y: {x == y}");   // 거짓
            //Console.WriteLine($"x != y: {x != y}");   // 참

            //// AND
            //Console.WriteLine(false && true);
            //Console.WriteLine(true && false);
            //Console.WriteLine(false && false);
            //Console.WriteLine(true && true);
            //Console.WriteLine();
            //// OR
            //Console.WriteLine(false || true);
            //Console.WriteLine(true || false);
            //Console.WriteLine(false || false);
            //Console.WriteLine(true || true);
            //// 비트 연산자
            //Console.WriteLine(5 & 3);   // 0101 & 0011 = 0001 (1)
            //Console.WriteLine(5 | 3);   // 0101 | 0011 = 0111 (7)
            //Console.WriteLine(5 ^ 3);   // 0101 ^ 0011 = 0110 (6)
            //Console.WriteLine(~5);      // ~0101 = 1010 (-6)
            //// 시프트 연산자
            //Console.WriteLine(5 << 1); // 0101 << 1 = 1010 (10)
            //Console.WriteLine(5 >> 1); // 0101 >> 1 = 0010 (2)


            // 문제 1
            int currentHp = 80;
            int maxHp = 100;

            Console.WriteLine("=== 문제 1 ===");
            Console.WriteLine($"초기 체력: {currentHp}/{maxHp}");
            Console.WriteLine($"데미지 -25: {currentHp -= 25}/{maxHp}");
            Console.WriteLine($"회복 +30: {currentHp += 30}/{maxHp}");
            Console.WriteLine($"독 데미지 -5: {currentHp -= 5}/{maxHp}");


            // 문제 2
            int expPerMonster = 150;
            int monstersKilled = 3;
            int expForLevelUp = 500;

            Console.WriteLine("\n=== 문제 2 ===");
            Console.WriteLine($"처치한 몬스터: {monstersKilled}마리");
            Console.WriteLine($"획득 경험치: {expPerMonster * monstersKilled}");
            Console.WriteLine($"처치한 몬스터: {expForLevelUp - expPerMonster * monstersKilled}");


            // 문제 3
            int totalGold = 1234;
            int partyMembers = 5;

            Console.WriteLine("\n=== 문제 3 ===");
            Console.WriteLine($"총 골드: {totalGold}");
            Console.WriteLine($"파티원: {partyMembers}명");
            Console.WriteLine($"1인당 골드: {totalGold / partyMembers}");
            Console.WriteLine($"남은 골드: {totalGold % partyMembers}");


            // 문제 4
            int playerLevel = 35;
            int requiredLevel = 30;
            bool hasKey = true;
            int currentHp2 = 60;
            int maxHp2 = 100;

            Console.WriteLine("\n=== 문제 4, 던전 입장 조건 ===");
            Console.WriteLine($"레벨 조건 (30 이상): {playerLevel >= requiredLevel}");
            Console.WriteLine($"열쇠 보유: {hasKey}");
            Console.WriteLine($"체력 조건 (50% 이상): {currentHp2 >= (maxHp2 / 2)}");
            Console.WriteLine($"입장 가능: {playerLevel >= requiredLevel && hasKey && currentHp2 >= (maxHp2 / 2)}");


            // 문제 5
            int originalPrice = 5000;
            bool isVIP = true;
            bool hasCoupon = true;

            Console.WriteLine("\n=== 문제 5 ===");
            Console.WriteLine($"원가: {originalPrice}골드");
            Console.WriteLine($"VIP 할인 (20%): {(isVIP ? originalPrice -= (int) (originalPrice * 0.2) : originalPrice)}골드");
            Console.WriteLine($"쿠폰 할인 (-500): {(hasCoupon ? originalPrice -= 500 : originalPrice)}골드");
        }
    }
}
