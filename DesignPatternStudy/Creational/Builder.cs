using System;

namespace DesignPatternStudy.Creational
{
    /*
     * Builder
     * 
     * - 객체의 생성과 표현을 분리
     * 
     * 장점
     * 1. 필요한 데이터만 설정 가능
     * 2. 객체 생성의 유연성 확보
     * */

    internal class Builder
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
            // 외부에서 수정 불가능
            public string TrueName { get; }
            public string ClassName { get; }

            // 핵심: 생성자가 'private'
            // 오직 내부의 Builder만이 이 생성자를 호출 가능
            private Servant(Builder builder)
            {
                TrueName = builder.TrueName;
                ClassName = builder.ClassName;
            }

            // 내부(Nested) 클래스로 빌더 정의
            public class Builder
            {
                // 빌더 내부에서 임시로 저장할 멤버 변수
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

        public static void Run()
        {
            Console.WriteLine("\n=== Builder ===");

            // 함수에 인자를 추가할 일이 생길 경우 해당 객체를 생성하는 부분을 전부 고쳐야함
            Servant_NoBuilder servant1 = new Servant_NoBuilder("잔 다르크", "룰러");

            // 이제 함수에 인자가 추가될 일이 생겨도 안전함
            Servant servant2 = new Servant.Builder()
                .SetTrueName("잔 다르크")
                .SetClass("룰러")
                .Build();

            Console.WriteLine(servant2.TrueName);
            Console.WriteLine(servant2.ClassName);

            // 내부값 변경 시도
            // 1차 시도
            //servant2.Builder().SetTrueName("잔 다르크 얼터").Build();
            // 2차 시도
            //servant2.TrueName = "잔 다르크 얼터";
            // 3차 시도(덮어쓰기)
            servant2 = new Servant.Builder().SetTrueName("잔 다르크 얼터").Build(); // 동작하지만, 새 객체를 생성한 거라 논외
        }
    }
}
