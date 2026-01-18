using System;

namespace PokemonTextRPG
{ 
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Managers.GameManager.Instance.Initialize();
            Managers.GameManager.Instance.Run();
        }
    }
}