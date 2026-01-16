using System;
using System.Collections.Generic;

namespace DesignPatternStudy.Creational
{
    /*
     * Factory Method
     * 
     * - 자식 클래스가 어떤 객체를 생성할 지 위임하는 것
     * 
     * 장점
     * 1. 클래스 생성, 클래스 로직 수정의 유연성 향상
     * 2. OCP(개방-폐쇄 원칙)를 만족하는 코드 작성 가능
     * */

    internal class FactoryMethod
    {
        // 스킬 인터페이스(서번트마다 패시브 스킬이 다름)
        public interface IClassSkill { void Activate(); }

        // 대마력 : 스킬
        public class MagicResistance : IClassSkill { public void Activate() => Console.WriteLine(">> [패시브] 대마력: 약한 마술을 무효화합니다."); }
        // 단독행동 : 스킬
        public class IndependentAction : IClassSkill { public void Activate() => Console.WriteLine(">> [패시브] 단독행동: 마스터 없이도 현계가 가능합니다."); }
        // 진지작성 : 스킬
        public class CreationTerritory : IClassSkill { public void Activate() => Console.WriteLine(">> [패시브] 진지작성: 마술공방을 형성합니다."); }

        // 서번트 통합 클래스
        public abstract class Servant
        {
            // 클래스명
            public abstract string ClassName { get; }
            
            // 보유 스킬 목록
            protected List<IClassSkill> Skills { get; } = new List<IClassSkill>();

            // 정보 출력(기본 제공 함수)
            public void ShowInfo()
            {
                Console.WriteLine($"\n--- 소환된 서번트: {ClassName} ---");
                foreach (var skill in Skills) skill.Activate();
            }
        }

        // 핵심: 각 클래스는 생성자에서 자신에게 필요한 스킬을 스스로 조립
        // 세이버 클래스
        public class Saber : Servant
        {
            public override string ClassName => "세이버(Saber)";

            public Saber()
            {
                // 대마력 스킬 추가
                Skills.Add(new MagicResistance());
            }
        }

        // 아처 클래스
        public class Archer : Servant
        {
            public override string ClassName => "아처(Archer)";

            public Archer()
            {
                // 대마력, 단독행동 스킬 추가
                Skills.Add(new MagicResistance());
                Skills.Add(new IndependentAction());
            }
        }

        // 캐스터 클래스
        public class Caster : Servant
        {
            public override string ClassName => "캐스터(Caster)";

            public Caster()
            {
                // 진지작성 스킬 추가
                Skills.Add(new CreationTerritory());
            }
        }

        // 소환 통합 클래스
        public abstract class SummonSystem
        {
            // 핵심: 팩토리 메소드
            protected abstract Servant CreateServant();

            // 소환
            public void Summon()
            {
                // 구체적인 서번트 생성은 자식 클래스에 위임
                Servant servant = CreateServant();

                // 공통 로직
                Console.WriteLine("성정석을 소비합니다...");
                Console.WriteLine("소환진이 빛납니다!");

                servant.ShowInfo();
            }
        }

        // 세이버 클래스 소환
        public class SummonSaber : SummonSystem
        {
            protected override Servant CreateServant()
            {
                // '세이버'를 만드는 복잡한 과정을 캡슐화.
                // 만약 세이버 생성 시에만 필요한 추가 설정(검 데이터 로드 등)이 있다면 여기에 삽입
                return new Saber();
            }
        }

        // 아처 클래스 소환
        public class SummonArcher : SummonSystem
        {
            protected override Servant CreateServant()
            {
                return new Archer();
            }
        }

        // 캐스터 클래스 소환
        public class SummonCaster : SummonSystem
        {
            protected override Servant CreateServant()
            {
                return new Caster();
            }
        }

        public static void Run()
        {
            Console.WriteLine("\n=== Factory Method ===");
            
            SummonSystem gacha;

            Random random = new Random();
            switch(random.Next(0, 3))
            {
                case 0:
                    gacha = new SummonSaber();
                    break;
                case 1:
                    gacha = new SummonArcher();
                    break;
                default:
                    gacha = new SummonCaster();
                    break;
            }
            // 새로운 클래스(예시: 라이더)가 추가될 시 라이더의 보유 스킬인 기승(Riding) 클래스, Rider 클래스, SummonRider 클래스를 작성하면 됨
            // 새 클래스를 작성해도 기존의 코드를 훼손하지 않음(Run()의 소환 방식은 랜덤 소환을 대충 구현한 것이므로 예외로 한다)
            // 만약 팩토리 메소드 패턴을 사용하지 않았다면 if else 활용으로 괴상한 코드를 짜야 함

            gacha.Summon();
        }
    }
}