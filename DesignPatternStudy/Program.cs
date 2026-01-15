using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternStudy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Builder.Program.Run();
        }
    }
}

/*
 * Builder
 * 
 * - 객체의 생성과 표현을 분리
 * 
 * 장점
 * 1. 필요한 데이터만 설정 가능
 * 2. 객체 생성의 유연성 확보
 * 3. 변경 가능성 최소화
 * 
 * */
namespace Builder
{
    public class Servant_NoBuilder
    {
        public string TrueName { get; }
        public string ClassName { get; }

        public Servant_NoBuilder(string trueName, string className)
        {
            TrueName = trueName;
            ClassName = className;
        }
    }

    public class Servant
    {
        // 1. 속성은 여전히 외부에서 수정 불가
        public string TrueName { get; }
        public string ClassName { get; }

        // 2. 핵심: 생성자가 'private'
        // 오직 내부의 Builder만이 이 생성자를 호출 가능
        private Servant(Builder builder)
        {
            TrueName = builder.TrueName;
            ClassName = builder.ClassName;
        }

        // 3. 내부(Nested) 클래스로 정의된 빌더
        public class Builder
        {
            // 빌더 내부에서 임시로 저장할 변수
            internal string TrueName;
            internal string ClassName;

            public Builder SetTrueName(string name)
            {
                TrueName = name;
                return this;
            }

            public Builder SetClass(string className)
            {
                ClassName = className;
                return this;
            }

            // 4. 빌드
            public Servant Build()
            {
                // 여기서 유효성 검사 수행
                return new Servant(this);
            }
        }
    }

    class Program
    {
        public static void Run()
        {
            // 함수에 인자를 추가할 일이 생길 경우 해당 객체를 생성하는 부분을 전부 고쳐야함
            Servant_NoBuilder servant = new Servant_NoBuilder("잔 다르크", "룰러");

            // 이제 함수에 인자가 추가될 일이 생겨도 안전함
            Servant myServant = new Servant.Builder()
                .SetTrueName("잔 다르크")
                .SetClass("룰러")
                .Build();

            Console.WriteLine(myServant.TrueName);
            Console.WriteLine(myServant.ClassName);

            // 내부값 변경 시도
            // 1차 시도
            //myServant.Builder().SetTrueName("잔 다르크 얼터").Build();
            // 2차 시도
            //myServant.TrueName = "잔 다르크 얼터";
            // 3차 시도
            //myServant = new Servant.Builder().SetTrueName("잔 다르크 얼터").Build();
        }
    }
}
