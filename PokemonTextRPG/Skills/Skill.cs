namespace PokemonTextRPG.Skills
{
    // 기술 클래스
    public class Skill
    {
        public string Name { get; set; }
        public MoveType Type { get; set; }
        public int Power { get; set; }

        public Skill(string name, MoveType type, int power)
        {
            Name = name;
            Type = type;
            Power = power;
        }
    }
}
