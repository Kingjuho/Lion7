using System.Collections.Generic;

namespace PokemonTextRPG.Skills
{
    public static class SkillRepository
    {
        // 기술 딕셔너리
        private static readonly Dictionary<SkillId, Skill> _skilldex = new Dictionary<SkillId, Skill>
        {
            // 물리
            { SkillId.Tackle, new Skill("몸통박치기", MoveType.Physical, 40) },
            { SkillId.Peck, new Skill("쪼기", MoveType.Physical, 35) },
            { SkillId.Scratch, new Skill("할퀴기", MoveType.Physical, 40) },
            { SkillId.FlameWheel, new Skill("화염바퀴", MoveType.Physical, 60) },

            // 특수
            { SkillId.WaterGun, new Skill("물대포", MoveType.Special, 40) },
            { SkillId.Ember, new Skill("불꽃세례", MoveType.Special, 40) },
            { SkillId.FireBlast, new Skill("불대문자", MoveType.Special, 110) },
        };

        // 데이터 조회 메서드
        public static Skill GetData(SkillId id)
        {
            // 조회 실패 시 강제로 몸통박치기로 만듦
            if (!_skilldex.ContainsKey(id)) id = SkillId.Tackle;
            return _skilldex[id];
        }
    }
}
