using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CsharpStudy3
{
    /**********************************************************
      * 2026/01/13                                            *
      **********************************************************/

    #region 클래스(Class)

    /*
     * 클래스(Class)
     * 
     * - 객체를 만들기 위한 설계도
     * 
     * 장점
     * 1. 데이터와 기능의 결합 가능
     * 2. 재사용성이 뛰어나 유지보수에 유리
     * */

    class Character
    {
        public string name; // public: 외부에서 접근 가능
        public int level;   
        public int hp;
        public int maxHP;
        public int mp;
        public int maxMP;

        int userId;         // private: 외부에서 접근 불가(디폴트)
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Character player = new Character();
           
            player.name = "홍길동";
            player.level = 1;
            player.hp = 100;
            player.maxHP = 100;
            player.mp = 100;
            player.maxMP = 100;
            // player.userId = "dong1";     // 에러

            Console.WriteLine($"이름: {player.name}");
            Console.WriteLine($"레벨: {player.level}");
            Console.WriteLine($"체력: {player.hp}");
            Console.WriteLine($"최대 체력: {player.maxHP}");
            Console.WriteLine($"마나: {player.mp}");
            Console.WriteLine($"최대 마나: {player.maxMP}");
        }
    }

    #endregion
}
