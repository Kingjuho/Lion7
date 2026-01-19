using System;

namespace DesignPatternStudy.Creational
{
    /*
     * Abstract Factory
     * 
     * - 서로 연관된 클래스들을 그룹화해서 생성하기 위한 패턴
     * - Fectory Method를 여러 개 묶어놓으면 이 패턴이 될 수 있음
     * 
     * 장점
     * 1. 일관성이 유지되는 안전한 객체 생성 가능
     * 2. 캡슐화된 객체 생성 가능
     * */

    internal class AbstractFactory
    {
        // 패시브 스킬
        public interface IPassiveSkill { void ApplyPassive(); }
        // 액티브 스킬
        public interface IActiveSkill { void CastActive(); }

        // 제품(팩토리 메소드가 뱉어낼 결과물 클래스들)
        // 대마력 : 패시브 스킬
        public class MagicResistance : IPassiveSkill 
        { 
            public void ApplyPassive() => Console.WriteLine("[패시브] 대마력: 약한 마술을 무효화합니다.");
        }
        // 단독행동 : 패시브 스킬
        public class IndependentAction : IPassiveSkill
        {
            public void ApplyPassive() => Console.WriteLine("[패시브] 단독행동: 마스터 없이도 현계가 가능합니다.");
        }
        // 진지작성 : 패시브 스킬
        public class CreationTerritory : IPassiveSkill
        {
            public void ApplyPassive() => Console.WriteLine("[패시브] 진지작성: 마술공방을 형성합니다.");
        }

        // 엑스칼리버 : 액티브 스킬
        public class Excalibur : IActiveSkill
        {
            public void CastActive() => Console.WriteLine("[보구] '엑스칼리버'를 사용합니다.");
        }
        // 무한의 검제 : 액티브 스킬
        public class UnlimitedBladeWorks : IActiveSkill
        {
            public void CastActive() => Console.WriteLine("[보구] '무한의 검제'를 사용합니다.");
        }
        // 룰 브레이커 : 액티브 스킬
        public class RuleBreaker : IActiveSkill
        {
            public void CastActive() => Console.WriteLine("[보구] '룰 브레이커'를 사용합니다.");
        }

        // 반드시 패시브 스킬 하나와 액티브 스킬 하나를 세트로 제공하는 팩토리
        public interface ISkillFactory
        {
            IPassiveSkill CreatePassive();
            IActiveSkill CreateActive();
        }

        // 팩토리 메소드
        // 세이버
        public class SaberSkillFactory : ISkillFactory
        {
            public IPassiveSkill CreatePassive() => new MagicResistance();
            public IActiveSkill CreateActive() => new Excalibur();
        }
        // 아처
        public class ArcherSkillFactory : ISkillFactory
        {
            public IPassiveSkill CreatePassive() => new IndependentAction();
            public IActiveSkill CreateActive() => new UnlimitedBladeWorks();
        }
        // 캐스터
        public class CasterSkillsFactory : ISkillFactory
        {
            public IPassiveSkill CreatePassive() => new CreationTerritory();
            public IActiveSkill CreateActive() => new RuleBreaker();
        }

        // 서번트 클래스
        public class Servant
        {
            private string _name;           // 이름
            private IPassiveSkill _passive; // 패시브 스킬
            private IActiveSkill _active;   // 액티브 스킬

            // 핵심: 서번트 생성자는 자기가 무슨 스킬을 갖는지 직접적으로 모름
            public Servant(string name, ISkillFactory factory)
            {
                _name = name;
                _passive = factory.CreatePassive();
                _active = factory.CreateActive();
            }

            // 정보 출력
            public void ShowStatus()
            {
                Console.WriteLine($"\n=== 서번트 {_name}의 능력 ===");
                _passive.ApplyPassive();
                _active.CastActive();
            }
        }

        public static void Run()
        {
            Console.WriteLine("\n=== Abstract Factory ===");

            // 아르토리아 소환
            Servant artoria = new Servant("아르토리아", new SaberSkillFactory());
            // 에미야 소환
            Servant emiya = new Servant("에미야", new ArcherSkillFactory());
            // 메데이아 소환
            Servant Medea = new Servant("메데이아", new CasterSkillsFactory());

            artoria.ShowStatus();
            emiya.ShowStatus();
            Medea.ShowStatus();

            // 팩토리 메소드에 비해 작성은 좀 더 귀찮아지지만, 안전성 확보
        }
    }
}
