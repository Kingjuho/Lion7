using System;

namespace DesignPatternStudy.Creational
{
    internal class Singleton
    {
        /*
         * Singleton
         * 
         * - 이 클래스의 인스턴스는 프로그램 전체를 통틀어 단 하나뿐이어야 함을 보장
         * - 어떤 클래스, 어떤 스크립트에서든 접근 가능
         * 
         * 장점
         * 1. 생성 비용이 큰 객체의 중복 생성 방지 가능(메모리 절약)
         * 2. 데이터 일관성 유지
         * 
         * 단점
         * 1. 결합도 증가
         * 2. 싱글톤 객체 내 값을 변경하는 코드가 많아지면 테스트가 매우 어려워짐
         * */

        // 핵심: static(메모리에 딱 하나 존재, 정적 객체) 키워드가 없으면 Singleton이 아님
        static Singleton _instance;

        Singleton() { Console.WriteLine("성배 생성"); }

        static Singleton Instance
        {
            get 
            {
                // 현재 인스턴스가 없을 때만 새로 생성, 아닐 땐 그냥 인스턴스 반환
                if (_instance == null) _instance = new Singleton(); 
                return _instance;
            }
        }

        public void GrantWish() { Console.WriteLine("성배 사용"); }

        public static void Run()
        {
            // 아 예시 작성하기가 어렵네 이거..
            Instance.GrantWish();
        }
    }
}
