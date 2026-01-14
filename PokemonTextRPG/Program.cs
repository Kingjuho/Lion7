using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonTextRPG
{
    public class Constants
    {
        public const int SCREEN_WIDTH = 100;
        public const int SCREEN_HEIGHT = 30;
    }

    // 게임의 현재 상태
    public enum GameState
    {
        MainMenu,   // 메인 메뉴
        Field,      // 필드
        Battle,     // 배틀
        GameOver    // 게임 오버
    }

    // 기술 타입
    public enum MoveType
    {
        Physical,   // 물리
        Special     // 특수
    }

    // 기술 클래스
    public class Skill
    {
        public string Name { get; set; }    // 이름
        public MoveType Type { get; set; } // 기술 타입
        public int Power { get; set; }      // 위력

        public Skill(string name, MoveType type, int power)
        {
            Name = name;
            Type = type;
            Power = power;
        }
    }

    // 포켓몬 클래스
    public class Pokemon
    {
        public string Name { get; set; }    // 이름
        public int Level { get; set; }      // 레벨
        public int MaxHp { get; set; }      // 최대 체력
        public int CurrentHp { get; set; }  // 현재 체력

        // 기술 목록
        public List<Skill> Skills { get; set; } = new List<Skill>();

        // 종족값 (HP, 공격, 방어, 특공, 특방, 스피드)
        public int[] BaseStats { get; set; }

        // 실제 능력치
        public int Atk { get; set; }
        public int Def { get; set; }
        public int SpAtk { get; set; }
        public int SpDef { get; set; }
        public int Spd { get; set; }

        public Pokemon(string name, int level, int[] baseStats)
        {
            Name = name;
            Level = level;
            BaseStats = baseStats;
        }

        // 실능치 갱신
        private void UpdateStats()
        {
            MaxHp = CalculateHP(BaseStats[0], Level);
            Atk = CalculateStat(BaseStats[1], Level);
            Def = CalculateStat(BaseStats[2], Level);
            SpAtk = CalculateStat(BaseStats[3], Level);
            SpDef = CalculateStat(BaseStats[4], Level);
            Spd = CalculateStat(BaseStats[5], Level);
        }

        // 레벨 업
        public void LevelUp()
        {
            Level++;

            // 능력치 재계산
            int oldMaxHp = MaxHp;
            UpdateStats();

            // 늘어난 최대 체력만큼 현재 체력 회복
            CurrentHp += MaxHp - oldMaxHp;
        }

        // 체력 계산
        private int CalculateHP(int baseStat, int level)
        {
            int core = 2 * baseStat;
            return (core * level / 100) + level + 10;
        }

        // 스탯 계산(개체치 6Z, 노력치 0, 성격보정 1.0)
        private int CalculateStat(int baseStat, int level)
        {
            int core = 2 * baseStat;
            return (core * level / 100) + 5;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Pokemon RPG";
            Console.CursorVisible = false;

            try
            {
                Console.SetWindowSize(Constants.SCREEN_WIDTH, Constants.SCREEN_HEIGHT);
                Console.SetBufferSize(Constants.SCREEN_WIDTH, Constants.SCREEN_HEIGHT);
            }
            catch (Exception e)
            {
                Console.WriteLine("해상도 설정 실패. 콘솔 폰트 크기를 줄인 후 다시 실행해주세요.");
            }
        }
    }
}
