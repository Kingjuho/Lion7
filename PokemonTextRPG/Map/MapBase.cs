namespace PokemonTextRPG.Map
{
    public abstract class MapBase
    {
        public string Name { get; set; }    // 맵 이름
        protected string[,] _grid;          // 맵 좌표계, 이모지는 전각 문자이므로 char 사용 금지

        // 맵 크기
        public int Height => _grid.GetLength(0);
        public int Width => _grid.GetLength(1);

        // 플레이어 시작 위치
        public int StartX { get; protected set; }
        public int StartY { get; protected set; }

        // 맵 렌더링
        protected void Initialize(string[] design)
        {
            int h = design.Length;
            int w = design[0].Length;
            _grid = new string[h, w];

            for (int y = 0; y < h; y++)
                for (int x = 0; x < w; x++) _grid[y, x] = ConvertCharToTile(design[y][x]);
        }

        // 문자 - 이모지 변환
        private string ConvertCharToTile(char c)
        {
            switch(c)
            {
                case 'T':
                    return "🌳"; // 나무
                case 'G':
                    return "☘️"; // 풀숲
                case 'F':
                    return "💐"; // 꽃
                case '#':
                    return "🚧"; // 울타리/벽
                case 'S':
                    return "📫"; // 표지판
                case 'H':
                    return "🏠"; // 집
                default:
                    return "  ";   // 기본(공백 2칸)
            };
        }

        // 특정 좌표의 타일 모양 가져오기
        public string GetTileIcon(int x, int y)
        {
            if (x < 0 || x >= Width || y < 0 || y >= Height) return "🌳";

            return _grid[y, x];
        }

        // 이동 가능 여부
        public virtual bool IsWalkable(int x, int y)
        {
            if (x < 0 || x >= Width || y < 0 || y >= Height) return false;

            string tile = _grid[y, x];
            // 공백(2칸), 풀숲, 꽃
            return tile == "  " || tile == "☘️" || tile == "💐";
        }

        // 풀숲 체크(포켓몬 조우)
        public bool IsBush(int x, int y)
        {
            if (x < 0 || x >= Width || y < 0 || y >= Height) return false;

            return _grid[y, x] == "☘️";
        }
    }
}