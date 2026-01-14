namespace PokemonTextRPG.Map
{
    public abstract class MapBase
    {
        public string Name { get; set; }    // 맵 이름
        protected char[,] _grid;          // 맵 좌표계, 이모지는 전각 문자이므로 char 사용 금지

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
            _grid = new char[h, w];

            for (int y = 0; y < h; y++)
                for (int x = 0; x < w; x++) 
                    _grid[y, x] = design[y][x];
        }

        // 특정 좌표의 타일 정보 가져오기
        public Tile GetTileInfo(int x, int y)
        {
            // 맵 밖은 'X'
            if (x < 0 || x >= Width || y < 0 || y >= Height)
                return TileRepository.Get('X');

            char code = _grid[y, x];
            return TileRepository.Get(code);
        }

        // 이동 가능 여부
        public bool IsWalkable(int x, int y)
        {
            return GetTileInfo(x, y).IsWalkable;
        }

        // 풀숲 체크(포켓몬 조우)
        public bool IsBush(int x, int y)
        {
            if (x < 0 || x >= Width || y < 0 || y >= Height) return false;
            return _grid[y, x] == 'G';
        }
    }
}