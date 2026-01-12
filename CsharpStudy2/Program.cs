using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CsharpStudy2
{
    internal class Program
    {
        /*
        [DllImport("msvcrt.dll")]

        // getch() 함수: 콘솔에서 키 입력을 받는 함수 (비표준, Windows 전용)
        public static extern int _getch();
        */

        static void Main(string[] args)
        {
            /**********************************************************
              * 2026/01/09                                            *
              **********************************************************/

            #region 배열(Array)

            /*
             * 배열(Array)
             * 
             * 1. 선언 시 크기 결정, 변경 불가
             * 2. 인덱스로 접근 가능
             * 3. 모든 요소가 동일한 타입이어야 함
             * */

            //// 선언 1
            //int[] scores = new int[5];  // new 키워드로 배열 생성, 크기 지정 필수, c#에서는 기본값 초기화 해줌(숫자형:0, 문자열:null, 논리형:false)

            //// 선언 2
            //string[] names = new string[] { "홍길동", "김철수" }; // 초기값으로 크기 자동 지정

            //// 선언 3
            //int[] values = { 10, 20, 30, 40, 50 }; // new 키워드 생략 가능

            //// 인덱스로 접근
            //scores[0] = 1;
            //scores[1] = 2;
            //// scores[5] = 3;  // 범위 초과(0~4)
            //Console.WriteLine("첫 번째 학생의 점수: " + scores[0]);

            //// for문으로 배열 순회
            //for (int i = 0; i < scores.Length; i++)
            //{
            //    Console.WriteLine($"scores[{i}]: {scores[i]}");
            //}

            #endregion

            #region 예제 1: 배열을 이용한 인벤토리 구현

            //string[] inventory = new string[]
            //{
            //      "회복 포션"
            //    , "마나 포션"
            //    , "강철 검"
            //    , "가죽 갑옷"
            //    , "마법 반지"
            //};

            //Console.WriteLine("=== 인벤토리 ===");
            //for (int i = 0; i < inventory.Length; i++)
            //{
            //    Console.WriteLine($"{i + 1}. {inventory[i]}");
            //}

            //// 아이템 사용
            //Console.WriteLine($"{inventory[0]}을 사용했습니다.");
            //inventory[0] = "비어 있음"; // 아이템 사용 후 제거

            #endregion

            #region 예제 2: 배열을 이용한 플레이어 스탯 구현

            //int[] playerStats = new int[]
            //{
            //      100       // 체력
            //    , 50        // 마나
            //    , 80        // 공격력
            //    , 60        // 방어력
            //    , 40        // 민첩
            //};

            //Console.WriteLine("=== 캐릭터 스탯 ===");
            //Console.WriteLine($"체력: {playerStats[0]}");
            //Console.WriteLine($"마나: {playerStats[1]}");
            //Console.WriteLine($"공격력: {playerStats[2]}");
            //Console.WriteLine($"방어력: {playerStats[3]}");
            //Console.WriteLine($"민첩: {playerStats[4]}");

            #endregion

            #region 예제 3: 배열을 이용한 일일 퀘스트 구현

            //int[] currentQuests = new int[]
            //{
            //      5     // 고블린
            //    , 3     // 오크
            //    , 8     // 슬라임
            //    , 2     // 드래곤
            //    , 7     // 좀비
            //};
            //int[] targetQuests = new int[]
            //{
            //      5     // 고블린
            //    , 5     // 오크
            //    , 5    // 슬라임
            //    , 5     // 드래곤
            //    , 5     // 좀비
            //};
            //string[] monsterNames = { "고블린", "오크", "슬라임", "드래곤", "좀비" };

            //Console.WriteLine("=== 일일 퀘스트 진행도 ===");

            //bool isCompleted = false;
            //for (int i = 0; i < currentQuests.Length; i++)
            //{
            //    isCompleted = false;
            //    if (currentQuests[i] >= targetQuests[i]) isCompleted = true;

            //    Console.WriteLine($"{monsterNames[i]}: {currentQuests[i]} / {targetQuests[i]}  {(isCompleted ? "완료" : "진행중")}");
            //}

            #endregion

            #region 예제 4: 배열을 이용한 점수 계산기 구현

            //int[] scores = new int[] { 85, 90, 78, 92, 88 };

            //// 총합 계산
            //int sum = 0;
            //for (int i = 0; i < scores.Length; i++)
            //{
            //    sum += scores[i];
            //}

            //// 평균 계산
            //float average = sum / scores.Length;

            //// 최고점 찾기
            //int maxScore = scores[0];
            //for (int i = 1; i < scores.Length; i++)
            //{
            //    if (scores[i] > maxScore) maxScore = scores[i];
            //}

            //// 최저점 찾기
            //int minScore = scores[0];
            //for (int i = 1; i < scores.Length; i++)
            //{
            //    if (scores[i] < minScore) minScore = scores[i];
            //}

            //Console.WriteLine("=== 점수 출력 ===");
            //Console.WriteLine($"총합: {sum}");
            //Console.WriteLine($"평균: {average}");
            //Console.WriteLine($"최고점: {maxScore}");
            //Console.WriteLine($"최저점: {minScore}");

            #endregion

            #region 예제 5: Array 메소드 활용

            //Console.WriteLine("=== Array 메소드 ===");

            //int[] numbers = { 5, 2, 8, 1, 4 };

            //// 복제
            //int[] copyNumbers = (int[]) numbers.Clone();
            //Console.WriteLine($"원본 배열: {String.Join(", ", numbers)}");
            //Console.WriteLine($"복제된 배열: {String.Join(", ", copyNumbers)}");


            //// 정렬
            //Array.Sort(copyNumbers);
            //Console.WriteLine($"정렬된 배열: {String.Join(", ", copyNumbers)}");

            //// 역순
            //Array.Reverse(copyNumbers);
            //Console.WriteLine($"역순 배열: {String.Join(", ", copyNumbers)}");

            //// foreach문으로 순회
            //Console.Write("foreach 순회: ");
            //foreach (int num in copyNumbers)
            //{
            //    Console.Write($"{num} ");
            //}

            //// 인덱스 검색
            //int index = Array.IndexOf(copyNumbers, 1);
            //Console.WriteLine($"\n1의 인덱스: {index}");

            #endregion

            #region 예제 6: 2차원 배열

            //int[,] array = new int[3, 4];   // 3행 4열

            //// 전체 요소 개수
            //int totalElements = array.Length;   // 12

            //// 특정 차원의 길이
            //int rows = array.GetLength(0);      // 3
            //int cols = array.GetLength(1);      // 4

            //// 배열의 차원 수
            //int dimensions = array.Rank;        // 2

            #endregion

            #region 예제 7: 2차원 배열을 이용한 좌석 배치도 구현

            //int[,] seats = new int[3, 3];
            //char[] seatNames = { 'A', 'B', 'C' };

            //for (int i = 0; i < seats.GetLength(0); i++)
            //{
            //    for (int j = 0; j < seats.GetLength(1); j++)
            //    {
            //        Console.Write($"[{seatNames[i]}{j + 1}]");
            //    }
            //    Console.WriteLine();
            //}

            #endregion

            #region 예제 8: 2차원 배열을 이용한 간단한 게임 맵 구현

            //int[,] map = new int[5, 5]  // 0: 빈칸, 1: 벽, 2: 몬스터, 3: 적, 9: 출구
            //{
            //    { 0, 0, 1, 0, 0 },
            //    { 0, 2, 1, 0, 3 },
            //    { 0, 0, 1, 0, 0 },
            //    { 1, 1, 1, 0, 0 },
            //    { 0, 0, 0, 0, 9 }
            //};

            //Console.WriteLine("=== 던전 맵 ===");

            //for(int i = 0; i < map.GetLength(0); i++)
            //{
            //    for (int j = 0; j < map.GetLength(1); j++)
            //    {
            //        char symbol = ' ';
            //        switch (map[i, j])
            //        {
            //            case 0:
            //                symbol = '.'; // 빈칸
            //                break;
            //            case 1:
            //                symbol = '#'; // 벽
            //                break;
            //            case 2:
            //                symbol = 'M'; // 몬스터
            //                break;
            //            case 3:
            //                symbol = 'E'; // 적
            //                break;
            //            case 9:
            //                symbol = 'X'; // 출구
            //                break;
            //        }
            //        Console.Write(symbol + " ");
            //    }
            //    Console.WriteLine();
            //}

            #endregion

            #region 예제 9: 2차원 배열을 이용한 성적표 구현

            //int[, ] scoreLists = 
            //{
            //      { 85, 90, 88, 92}
            //    , { 78, 85, 90, 87}
            //    , { 92, 88, 95, 90}
            //};
            //string[] studentNames = { "김철수", "이영희", "박민수" };
            //string[] subjectLists = { "국어", "영어", "수학", "과학" };

            //int maxStudents = studentNames.Length;
            //int maxSubjects = subjectLists.Length;
            //float[] subjectSum = new float[maxSubjects];

            //Console.WriteLine("=== 성적표 ===");
            //Console.WriteLine($"이름\t국어\t영어\t수학\t과학\t평균");
            //Console.WriteLine($"━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");

            //for (int i = 0; i < maxStudents; i++)
            //{
            //    Console.Write($"{studentNames[i]}\t");

            //    int sum = 0;
            //    for (int j = 0; j < maxSubjects; j++)
            //    {
            //        Console.Write($"{scoreLists[i, j]}\t");

            //        sum += scoreLists[i, j];
            //        subjectSum[j] += scoreLists[i, j];
            //    }

            //    float average = (float) sum / maxSubjects;
            //    Console.WriteLine($"{average:F1}");
            //}

            //Console.WriteLine("\n=== 과목별 평균 ===");

            //for (int i = 0; i < maxSubjects; i++)
            //{
            //    Console.WriteLine($"{subjectLists[i]}: {(subjectSum[i] / maxStudents):F1}점");
            //}

            #endregion

            #region 예제 10: 가변 배열(Jagged Array)

            //string[][] raid = new string[3][];

            //raid[0] = new string[] { "전사", "힐러", "마법사", "궁수" };
            //raid[1] = new string[] { "도적", "전사", "힐러" };
            //raid[2] = new string[] { "마법사", "궁수", "힐러", "전사", "탱커" };

            //Console.WriteLine("=== 레이드 파티 구성 ===");
            //foreach (var party in raid)     // foreach문 순회 가능
            //{
            //    Console.WriteLine($"파티원 수: {party.Length}");
            //    foreach (var member in party)
            //    {
            //        Console.Write(member + " ");
            //    }
            //    Console.WriteLine();
            //    Console.WriteLine();
            //}

            #endregion


            #region 동적 배열(List<T>)

            /*
             * 동적 배열(List<T>)
             * 
             * 1. 선언 시 크기가 자동 조절됨
             * 2. 크기가 가변적
             * 3. 모든 요소가 동일한 타입이어야 함
             * 4. System.Collections.Generic 네임스페이스 필요
             * */

            // 선언
            //List<int> numbers = new List<int>();
            //List<string> names = new List<string>();
            //List<float> prices = new List<float>();

            //// 선언과 동시에 초기화
            //List<int> scores = new List<int>() { 85, 90, 78 };
            //List<string> items = new List<string>() { "검", "방패", "포션" };

            //// 간단한 초기화
            //List<char> grades = new List<char> { 'A', 'B', 'C', 'D' };

            //// 끝 부분에 요소 추가
            //numbers.Add(10);
            //numbers.Add(20);

            #endregion

            #region 예제 1: 리스트를 이용한 인벤토리 구현

            //List<string> inventory = new List<string>();

            //inventory.Add("회복 포션");
            //inventory.Add("마나 포션");
            //inventory.Add("강철 검");

            //Console.WriteLine("=== 인벤토리 ===");
            //Console.WriteLine($"총 아이템 개수: {inventory.Count}");
            //foreach (var item in inventory)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine();

            //// 요소 교체
            //inventory[0] = "초록 포션"; // 특정 인덱스의 요소 교체
            //Console.WriteLine("=== 인벤토리 (수정 후) ===");
            //foreach (var item in inventory)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine();

            //// 요소 삽입
            //inventory.Insert(1, "은 반지"); // 특정 인덱스에 요소 삽입
            //Console.WriteLine("=== 인벤토리 (삽입 후) ===");
            //foreach (var item in inventory)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine();

            //// 요소 제거
            //inventory.Remove("마나 포션"); // 특정 값의 요소 제거
            //Console.WriteLine("=== 인벤토리 (제거 후) ===");
            //foreach (var item in inventory)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine();

            //// 인덱스로 요소 제거
            //inventory.RemoveAt(0); // 특정 인덱스의 요소 제거
            //Console.WriteLine("=== 인벤토리 (인덱스로 제거 후) ===");
            //foreach (var item in inventory)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine();

            /*
             * 주의! 0번째 인덱스에 있는 요소를 삭제할 경우 모든 요소가 한 칸씩 앞으로 이동해야 하므로 O(n)의 시간이 소요됨. FIFO는 Queue를 사용할 것
             * */

            #endregion


            #region 딕셔너리(Dictionary<TKey, TValue>)

            /*
             * 딕셔너리(Dictionary<TKey, TValue>)
             * 
             * 1. 키-값 쌍으로 요소 저장
             * 2. 키는 중복 불가, 값은 중복 가능
             * 3. System.Collections.Generic 네임스페이스 필요
             * */

            //Dictionary<string, int> stats = new Dictionary<string, int>();

            //stats.Add("체력", 100);
            //stats.Add("마나", 50);
            //stats.Add("공격력", 80);

            //Console.WriteLine("=== 캐릭터 스탯 ===");
            //foreach (KeyValuePair<string, int> stat in stats)
            //{
            //    Console.WriteLine($"{stat.Key}: {stat.Value}");
            //}

            //// 키 검색
            //string searchStat = "마나";
            //if (stats.ContainsKey(searchStat))
            //{
            //    Console.WriteLine($"\n{searchStat} 스탯 발견: {stats[searchStat]}");
            //}
            //else
            //{
            //    Console.WriteLine($"\n{searchStat} 스탯 없음");
            //}

            #endregion

            #region 예제 1: 딕셔너리를 이용한 아이템 상점 구현

            //Dictionary<string, int> shopItems = new Dictionary<string, int>()
            //{
            //      { "회복 포션", 500 }
            //    , { "마나 포션", 400 }
            //    , { "강철 검", 500 }
            //    , { "가죽 갑옷", 300 }
            //    , { "마법 반지", 1000 }
            //};

            //Console.WriteLine("=== 상점 아이템 ===");
            //foreach (var item in shopItems)
            //{
            //    Console.WriteLine($"{item.Key}: {item.Value}골드");
            //}

            //int playerGold = 600;
            //Console.WriteLine();
            //Console.Write($"구매할 아이템을 입력하세요(현재 골드: {playerGold}): ");
            //string selectedItem = Console.ReadLine();

            //if (shopItems.ContainsKey(selectedItem))
            //{
            //    int itemPrice = shopItems[selectedItem];
            //    if (playerGold >= itemPrice)
            //    {
            //        playerGold -= itemPrice;
            //        Console.WriteLine($"{selectedItem} 구매 성공!");
            //        Console.WriteLine($"남은 골드: {playerGold}");
            //    }
            //    else
            //    {
            //        Console.WriteLine("골드가 부족합니다.");
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("해당 아이템은 상점에 없습니다.");
            //}

            #endregion


            #region 간단한 슈팅게임 구현

            // 콘솔 세팅
            //Console.SetWindowSize(80, 25);
            //Console.SetBufferSize(80, 25);
            //Console.CursorVisible = false;

            //string[] player = new string[]      // 플레이어 모양
            //{
            //      "->"
            //    , ">>>"
            //    , "->"
            //};
            //int playerX = 0, playerY = 12;      // 플레이어 좌표
            //int pressKey = -1;                  // 플레이어 키 입력

            //int[, ] bullet = new int[10, 2] ;   // 총알 좌표 (최대 10발)
            //for (int i = 0; i < bullet.GetLength(0); i++)
            //{
            //    bullet[i, 0] = -1;  // X 좌표 초기화
            //    bullet[i, 1] = -1;  // Y 좌표 초기화
            //}

            //// Sleep(1000) 대체 코드 (예: 1초 대기, 쿨타임 계산 등)
            //int dwTime = Environment.TickCount;
            //while (true)
            //{
            //    if (dwTime + 1 < Environment.TickCount)
            //    {
            //        // 현재 시간 세팅
            //        dwTime = Environment.TickCount;
            //        Console.Clear();

            //        // 키 입력
            //        if (Console.KeyAvailable)
            //        {   
            //            // 키 입력 초기화
            //            pressKey = _getch();
            //            if (pressKey == 224) pressKey = _getch();

            //            switch (pressKey)
            //            {
            //                case 72: // 위쪽
            //                    if (playerY > 0)
            //                        playerY--;
            //                    break;
            //                case 75: // 왼쪽
            //                    playerX--;
            //                    if (playerX < 0)
            //                        playerX = 0;
            //                    break;
            //                case 77: // 오른쪽
            //                    playerX++;
            //                    if (playerX > 75)
            //                        playerX = 75;
            //                    break;
            //                case 80: // 아랫쪽
            //                    playerY++;
            //                    if (playerY > 21)
            //                        playerY = 21;
            //                    break;
            //                case 32: // 스페이스
            //                    for (int i = 0; i < bullet.GetLength(0); i++)
            //                    {
            //                        if (bullet[i, 0] == -1 && bullet[i, 1] == -1)
            //                        {
            //                            bullet[i, 0] = playerX + 3;
            //                            bullet[i, 1] = playerY + 1;
            //                            break;
            //                        }
            //                    }
            //                    break;
            //            }
            //        }
            //        else
            //        {
            //            pressKey = -1;
            //        }

            //        // 플레이어 출력
            //        for (int i = 0; i < player.Length; i++)
            //        {
            //            Console.SetCursorPosition(playerX, playerY + i);
            //            Console.Write(player[i]);
            //        }

            //        // 총알 출력
            //        for (int i = 0; i < bullet.GetLength(0); i++)
            //        {
            //            if (bullet[i, 0] >= 0 && bullet[i, 1] >= 0)
            //            {
            //                Console.SetCursorPosition(bullet[i, 0], bullet[i, 1]);
            //                Console.Write("-");
            //                bullet[i, 0]++; // 총알 이동
            //                // 화면 밖으로 나가면 초기화
            //                if (bullet[i, 0] > 79)
            //                {
            //                    bullet[i, 0] = -1;
            //                    bullet[i, 1] = -1;
            //                }
            //            }
            //        }
            //    }
            //}

            #endregion



            /**********************************************************
              * 2026/01/12                                            *
              **********************************************************/

            #region 함수(Function/Method)

            /*
             * 함수(Function/Method)
             * 
             * - 특정 작업을 수행하는 코드 블록, 필요할 때마다 호출 가능
             * 
             * 장점
             * 1. 코드 재사용성 증가
             * 2. 코드 가독성 향상
             * 3. 유지보수 용이
             * */

            //// 선언
            //void SayHello()
            //{
            //    Console.WriteLine("안녕하세요, 용사님!");
            //    Console.WriteLine("모험을 시작합니다.");
            //}

            //// 호출
            //Console.WriteLine("SayHello 함수를 실행합니다.");
            //SayHello();

            /*
             * ***함수 설계 원칙***
             * 
             * 1. 단일 책임 원칙(SRP): 하나의 함수는 하나의 작업만 수행
             * 2. 명확한 이름 짓기: 함수 이름은 기능을 명확히 나타내야 함
             * 3. 적절한 크기: 함수는 너무 길지 않고, 한 눈에 이해할 수 있을 정도로 간결해야 함
             * 4. 매개변수 최소화: 필요한 매개변수만 사용, 너무 많으면 구조체나 클래스로 묶기
             * 5. 재사용성 고려: 다른 곳에서도 사용할 수 있도록 일반화
             * 6. 명확한 반환값: 함수가 값을 반환할 경우, 반환값의 의미가 명확해야 함
             * */

            #endregion

            #region 예제 1: 매개변수와 반환값이 없는 함수

            //void ShowGameStart()
            //{
            //    Console.WriteLine("╔═══════════════════════════════════╗");
            //    Console.WriteLine("║ ⚔ RPG 게임 시작 ⚔ ║");
            //    Console.WriteLine("╚═══════════════════════════════════╝");
            //}

            //void PrintSeparator()
            //{
            //    Console.WriteLine("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
            //}

            //ShowGameStart();
            //PrintSeparator();

            #endregion

            #region 예제 2: 매개변수가 있는 함수

            //void Attack(int att, int def)
            //{
            //    Console.WriteLine($"플레이어가 {att}의 데미지로 공격했습니다!");
            //    Console.WriteLine($"방어력: {def}");
            //}

            //Attack(100, 20); // 함수 호출 시 매개변수 전달

            #endregion

            #region 예제 3: 함수로 플레이어 정보 출력

            //void PrintPlayerInfo(string name, int att, int def, int dex, int luck)
            //{
            //    Console.WriteLine($"이름: {name}");
            //    Console.WriteLine($"공격력: {att}");
            //    Console.WriteLine($"방어력: {def}");
            //    Console.WriteLine($"민첩: {dex}");
            //    Console.WriteLine($"운: {luck}");
            //}

            //PrintPlayerInfo("홍길동", 200, 100, 50, 100);

            #endregion

            #region 예제 4: 매개변수가 있는 함수 예제 2

            //void GreetPlayer(string playerName)
            //{
            //    Console.WriteLine($"환영합니다, {playerName}님!");
            //}

            //void ShowPlayerInfo(string job, int level)
            //{
            //    Console.WriteLine($"직업: {job}");
            //    Console.WriteLine($"레벨: {level}");
            //}

            //void ShowDamage(string attacker, string defender, int damage)
            //{
            //    Console.WriteLine($"{attacker}가 {defender}에게 {damage}의 데미지를 입혔습니다!");
            //}

            //void DrawHealthBar(int current, int max, int barLength)
            //{
            //    float ratio = (float)current / (float)max;
            //    int filledLength = (int)(barLength * ratio);
            //    string bar = new string('■', filledLength) + new string('□', barLength - filledLength);
            //    Console.WriteLine($"체력: [{bar}] {current}/{max}");
            //}

            //GreetPlayer("홍길동");
            //ShowPlayerInfo("전사", 15);
            //DrawHealthBar(75, 100, 20);
            //DrawHealthBar(30, 100, 20);
            //DrawHealthBar(100, 100, 20);
            //ShowDamage("홍길동", "슬라임", 25);

            #endregion

            #region 예제 5: 반환값이 있는 함수

            //int GetNumber()
            //{
            //    return 42;  // 정수형 반환
            //}

            //string ConnectMessage(string name)
            //{
            //    return $"{name}님이 접속하였습니다."; // 문자열 반환
            //}

            //Console.WriteLine($"반환된 숫자: {GetNumber()}"); // 함수 호출 및 반환값 출력
            //Console.WriteLine(ConnectMessage("홍길동")); // 함수 호출 및 반환값 출력

            #endregion

            #region 예제 6: 디폴트 매개변수

            //void CastFireBall(string target, int damage = 100, int cost = 30)
            //{
            //    Console.WriteLine($"{target}에게 {damage}의 화염구를 시전했습니다! {cost}의 마나를 소모했습니다.");
            //}

            //CastFireBall("오크족");                    // damage와 cost는 기본값 사용
            //CastFireBall("고블린", 150);               // cost는 기본값 사용
            //CastFireBall("드래곤", 300, 80);           // 모든 매개변수 직접 지정
            //CastFireBall("드래곤", cost:80);           // 위치 지정 매개변수 사용

            #endregion

            #region 예제 7: 디폴트 매개변수를 이용한 간단한 게임 구현

            //void usePotion(string itemName, int targetDamage, bool isHeal = true)
            //{
            //    Console.WriteLine($"{itemName} 사용!");
            //    Console.WriteLine(isHeal ? $"회복량: {targetDamage} HP" : $"데미지: {targetDamage} HP");
            //}

            //void summonMonster(string monsterName, int level, int number = 1)
            //{
            //    Console.WriteLine($"{monsterName} 소환!");
            //    Console.WriteLine($"레벨: {level}");
            //    Console.WriteLine($"수량: {number}마리");
            //}

            //Console.WriteLine("=== 아이템 사용 ===");
            //usePotion("회복 포션", 50);
            //usePotion("고급 회복 포션", 100);

            //Console.WriteLine("\n=== 소환 마법 ===");
            //summonMonster("슬라임", 1);
            //summonMonster("고블린", 5);
            //summonMonster("드래곤", 50, 3);

            #endregion

            #region 예제 8: 재귀 함수

            //// 1부터 n까지의 합을 계산하는 재귀 함수
            //int SumUpToN(int n)
            //{
            //    if (n <= 0) return 0;
            //    else if (n == 1) return 1;
            //    else if (n == 2) return 3;
            //    else return n + SumUpToN(n - 1);
            //}

            //// 동일한 기능을 반복문으로 구현한 함수
            //int SumUpToN_Loop(int n)
            //{
            //    int sum = 0;
            //    for (int i = 1; i <= n; i++)
            //    {
            //        sum += i;
            //    }
            //    return sum;
            //}

            //Console.WriteLine("=== 재귀 ===");
            //Console.WriteLine(SumUpToN(5));
            //Console.WriteLine(SumUpToN(6));
            //Console.WriteLine(SumUpToN(10));

            //Console.WriteLine("\n=== 반복문 ===");
            //Console.WriteLine(SumUpToN_Loop(5));
            //Console.WriteLine(SumUpToN_Loop(6));
            //Console.WriteLine(SumUpToN_Loop(10));

            /*
             * 중요
             * 1. 재귀 함수는 반드시 종료 조건이 필요
             * 2. 종료 조건이 없으면 무한 호출로 인해 스택 오버플로우 발생
             * 3. 재귀 함수는 반복문으로도 구현 가능
             * */

            #endregion


            #region 오버로딩(Overloading)

            /*
             * 오버로딩(Overloading)
             * 
             * 1. 동일한 이름의 함수를 여러 개 정의하는 것
             * 2. 매개변수의 타입, 개수, 순서가 다르면 가능
             * 3. 반환값만 다른 경우는 불가능
             * 
             * 장점
             * 1. 가독성, 유지보수성 향상
             * 2. 관련 기능 그룹화
             * */

            // 현재 사용중인 visual studio 버전에서는 지역 함수의 오버로딩이 지원되지 않음
            // main 함수 밖에서 선언해야 함
            //void Attack()
            //{
            //    Console.WriteLine("기본 공격을 수행했습니다.");
            //}

            //void Attack(string target)
            //{
            //    Console.WriteLine($"{target}에게 기본 공격을 수행했습니다.");
            //}

            //void Attack(string target, int damage)
            //{
            //    Console.WriteLine($"{target}에게 {damage}의 기본 공격을 수행했습니다.");
            //}

            //Attack();
            //Attack("슬라임");
            //Attack("슬라임", 50);

            #endregion

            #region 예제 1: 오버로딩을 이용해 함수 고치기

            //void Attack(string target, int damage, string skillName)
            //{
            //    Console.WriteLine($"✨ 스킬 발동: {skillName}");
            //    Console.WriteLine($"⚔️ {target}에게 {damage} 데미지!");
            //}

            //void Attack(string target, int damage)
            //{
            //    Attack(target, damage, "기본 공격");
            //}

            //void Attack(int damage)
            //{
            //    Attack("적", damage, "기본 공격");
            //}

            #endregion


            #region ref 키워드(Call by Reference)

            /*
             * ref 키워드
             * 
             * 1. 매개변수를 참조로 전달 = 원본 변수의 주소를 전달
             * 2. 함수 내에서 매개변수 값을 변경하면 원본 변수에도 반영
             * 3. 함수 호출 시 반드시 초기화된 변수를 전달해야 함
             * */

            //void Heal(ref int health, int amount)
            //{
            //    health += amount;
            //    Console.WriteLine($"회복 후 체력: {health}");
            //}

            //void Heal(int health, int amount)
            //{
            //    health += amount;
            //    Console.WriteLine($"회복 후 체력(복사본): {health}");
            //}

            //int playerHealth = 50;
            //Console.WriteLine($"회복 전 체력: {playerHealth}");

            //Heal(ref playerHealth, 30);                                 // ref 키워드 사용하여 참조로 전달
            //Console.WriteLine($"원본 체력: {playerHealth}");            // 호출한 쪽에도 변경된 값 반영

            //Heal(playerHealth, 30);                                     // ref 키워드 없이 값으로 전달
            //Console.WriteLine($"원본 체력(복사본): {playerHealth}");    // 호출한 쪽에는 영향 없음

            #endregion

            #region 예제 1: Swap 함수

            //// 기본 예제
            //int x = 10, y = 20;
            //void Swap(int a, int b)
            //{
            //    int temp2 = a;
            //    a = b;
            //    b = temp2;
            //}
            //Console.WriteLine($"변경 전: {x} {y}");
            //Swap(x, y);
            //Console.WriteLine($"변경 후: {x} {y}");    // Call by Value이므로 변경되지 않음


            //// ref 키워드 사용 예제
            //x = 10;
            //y = 20;
            //void Swap2(ref int a, ref int b)
            //{
            //    int temp2 = a;
            //    a = b;
            //    b = temp2;
            //}
            //Console.WriteLine($"변경 전: {x} {y}");
            //Swap2(ref x, ref y);
            //Console.WriteLine($"변경 후: {x} {y}");    // Call by Reference이므로 변경됨

            #endregion


            #region out 키워드

            /*
             * out 키워드
             * 
             * 1. 매개변수를 참조로 전달
             * 2. 함수 내에서 반드시 값을 할당해야 함
             * 3. 함수 호출 시 초기화되지 않은 변수를 전달 가능
             * 4. 주로 여러 개의 값을 반환할 때 사용
             * */

            //void Attack(int a, int b, out int atk, out int def)
            //{
            //    atk = a + 10;  // 공격력 계산
            //    def = b + 5;   // 방어력 계산
            //    Console.WriteLine($"함수 내 계산된 공격력: {atk}, 방어력: {def}");
            //}

            //int playerAttack;
            //int playerDefense;

            //Attack(10, 20, out playerAttack, out playerDefense); // out 키워드 사용하여 참조로 전달
            //Console.WriteLine($"함수 호출 후 공격력: {playerAttack}, 방어력: {playerDefense}");

            #endregion


            #region 2026/01/12 복습 문제

            // 문제 1: 평균 계산 함수
            float CalculateAverage(int[] numList)
            {
                int sum = 0;
                for (int i = 0; i < numList.Length; i++)
                {
                    sum += numList[i];
                }

                return (float)sum / numList.Length;
            }

            // 문제 2: 등급 판별 함수
            char CalculateGrade(float score)
            {
                if (score >= 90) return 'A';
                else if (score >= 80) return 'B';
                else if (score >= 70) return 'C';
                else if (score >= 60) return 'D';
                else return 'F';
            }

            // 문제 3: 소수 판별 함수
            bool isPrime(int num)
            {
                if (num <= 1) return false;
                for (int i = 2; i <= Math.Sqrt(num); i++)
                {
                    if (num % i == 0) return false;
                }
                return true;
            }

            // 문제 4: 경험치 시스템 함수
            int addExp(ref int exp, int gain)
            {
                exp += gain;
                int levelUpCount = 0;

                while (exp >= 100)
                {
                    exp -= 100;
                    levelUpCount += 1;
                }

                return levelUpCount;
            }

            // 문제 5: 아이템 강화 시스템
            bool isUpgrade(int level)
            {
                Random rand = new Random();
                int randInt = rand.Next(1, 101);

                // 초기 확률: 1%, 1레벨이 오를 수록 1%씩 강화 확률 증가, 100레벨 이상일 시 무조건 성공
                if (level - randInt >= 0) return true;
                return false;
            }



            Console.WriteLine($"=== 문제 1 ===");
            Console.WriteLine($"숫자: 15, 20, 25, 30, 35");
            int[] numbers = { 15, 20, 25, 30, 35 };
            Console.WriteLine($"평균: {CalculateAverage(numbers)}");

            Console.WriteLine($"\n=== 문제 2 ===");
            Console.WriteLine($"점수: 85.5");
            Console.WriteLine($"등급: {CalculateGrade(85.5f)}");

            Console.WriteLine($"\n=== 문제 3 ===");
            Console.WriteLine($"숫자: 17");
            Console.WriteLine($"소수 여부: {isPrime(17)}");

            Console.WriteLine($"\n=== 문제 4 ===");
            Console.WriteLine($"현재 경험치: 70");
            Console.WriteLine($"획득 경험치: 150");
            int userExp = 70;
            Console.WriteLine($"레벨업 횟수: {addExp(ref userExp, 150)}");
            Console.WriteLine($"현재 경험치: {userExp}");

            Console.WriteLine($"\n=== 문제 5 ===");
            Console.WriteLine($"현재 강화 레벨: 50(1~100)");
            Console.WriteLine($"강화 성공 여부: {isUpgrade(50)}");

            #endregion
        }
    }
}