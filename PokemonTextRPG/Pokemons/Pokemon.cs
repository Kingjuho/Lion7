using System.Collections.Generic;

using PokemonTextRPG.Skills;

namespace PokemonTextRPG.Pokemons
{
    // 포켓몬 클래스
    public class Pokemon
    {
        // 기본 정보
        public string Name { get; set; }        // 이름
        public int Level { get; set; }          // 레벨
        public int MaxHp { get; set; }          // 최대 체력
        public int CurrentHp { get; set; }      // 현재 체력
        public int MaxExp { get; private set; } // 현재 레벨의 최대 경험치
        public int Exp { get; private set; }    // 현재 레벨의 현재 경험치

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

            UpdateStats();
            CurrentHp = MaxHp;

            Exp = 0;
            MaxExp = Level * 100;
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

        // 경험치 계산
        public bool GainExp(int amount)
        {
            Exp += amount;
            bool isLevelUp = false;

            while (Exp >= MaxExp)
            {
                Exp -= MaxExp;
                LevelUp();
                MaxExp = Level * 100;
                isLevelUp = true;
            }

            return isLevelUp;
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

        // 힐(인자 없으면 풀피로)
        public void Heal()
        {
            CurrentHp = MaxHp;
        }
        public void Heal(int amount)
        {
            CurrentHp += amount;
            if (CurrentHp > MaxHp) CurrentHp = MaxHp;
        }
    }
}
