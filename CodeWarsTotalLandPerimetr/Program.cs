namespace CodeWarsTotalLandPerimetr
{
    internal class Program
    {
        private const int perimeterFourSides = 4;
        private const int perimeterThreeSides = 3;
        private const int perimeterTwoSides = 2;
        private const int perimeterOneSides = 1;
        static void Main(string[] args)
        {
            Console.WriteLine(CalculatePerimeter(new string[] { "XOOO", "XOXO", "XOXO", "OOXX", "OOOO" }));
        }
        public static string CalculatePerimeter(string[] map)
        {
            if (map.Length == 0)
                return $"Total land perimeter: 0";
            string[,] newMap = new string[map.Length, map[0].Length];
            for (int i = 0; i < newMap.GetLength(0); i++)
            {
                for (int j = 0; j < newMap.GetLength(1); j++)
                {
                    newMap[i, j] = map[i][j].ToString();
                }
            }

            int perimeter = 0;
            for (int i = 0; i < newMap.GetLength(0); i++)
            {
                for (int j = 0; j < newMap.GetLength(1); j++)
                {
                    if (i != 0 && i != newMap.GetLength(0) - 1 && j != 0 && j != newMap.GetLength(1) - 1)
                        perimeter += CalculatePerimeter(newMap, i, j);
                    else if (i == 0 && !(i == 0 || j == newMap.GetLength(1) - 1))
                        perimeter += CalculatePerimeterForUpperBorder(newMap, i, j);
                    else if (i == newMap.GetLength(0) - 1 && !(j == 0 || j == newMap.GetLength(1) - 1))
                        perimeter += CalculatePerimeterForLowerBorder(newMap, i, j);
                    else if (j == 0 && !(i == 0 || i == newMap.GetLength(0) - 1))
                        perimeter += CalculatePerimeterForLeftBorder(newMap, i, j);
                    else if (j == newMap.GetLength(1) - 1 && !(i == 0 || i == newMap.GetLength(0) - 1))
                        perimeter += CalculatePerimeterForRightBorder(newMap, i, j);
                    else if (i == 0 && i == j)
                        perimeter += CalculateUpperLeftCorner(newMap, i, j);
                    else if (i == newMap.GetLength(0) - 1 && j == 0)
                        perimeter += CalculateLowerLeftCorner(newMap, i, j);
                    else if (i == 0 && j == newMap.GetLength(1) - 1)
                        perimeter += CalculateUpperRightCorner(newMap, i, j);
                    else if (i == newMap.GetLength(0) - 1 && j == newMap.GetLength(1) - 1)
                        perimeter += CalculateLowerRightCorner(newMap, i, j);
                }
            }
            return $"Total land perimeter: {perimeter}";
        }
        private static int CalculatePerimeter(string[,] map, int i, int j)
        {
            int perimeter = 0;
            if (map[i - 1, j] != "X" && map[i, j - 1] != "X" && map[i + 1, j] != "X" && map[i, j + 1] != "X")
                perimeter += perimeterFourSides;
            else if (map[i - 1, j] != "X" && map[i, j - 1] != "X" && map[i, j + 1] != "X")
                perimeter += perimeterThreeSides;
            else if (map[i, j - 1] != "X" && map[i + 1, j] != "X" && map[i, j + 1] != "X")
                perimeter += perimeterThreeSides;
            else if (map[i, j - 1] != "X" && map[i, j + 1] != "X")
                perimeter += perimeterTwoSides;
            else if (map[i - 1, j] != "X" && map[i + 1, j] != "X")
                perimeter += perimeterTwoSides;
            else if (map[i - 1, j] != "X")
                perimeter += perimeterOneSides;
            else if (map[i, j - 1] != "X")
                perimeter += perimeterOneSides;
            else if (map[i + 1, j] != "X")
                perimeter += perimeterOneSides;
            else if (map[i, j + 1] != "X")
                perimeter += perimeterOneSides;
            return perimeter;
        }

        private static int CalculatePerimeterForUpperBorder(string[,] map, int i, int j)
        {
            int perimeter = 1;
            if (map[i, j - 1] != "X" && map[i + 1, j] != "X" && map[i, j + 1] != "X")
                perimeter += perimeterFourSides - 1;
            else if (map[i, j - 1] != "X" && map[i, j + 1] != "X")
                perimeter += perimeterThreeSides - 1;
            else if (map[i, j - 1] != "X" && map[i + 1, j] != "X" && map[i, j + 1] != "X")
                perimeter += perimeterThreeSides;
            else if (map[i, j - 1] != "X" && map[i, j + 1] != "X")
                perimeter += perimeterTwoSides;
            else if (map[i + 1, j] != "X")
                perimeter += perimeterTwoSides - 1;
            else if (map[i, j - 1] != "X")
                perimeter += perimeterOneSides;
            else if (map[i + 1, j] != "X")
                perimeter += perimeterOneSides;
            else if (map[i, j + 1] != "X")
                perimeter += perimeterOneSides;
            return perimeter;
        }

        private static int CalculatePerimeterForLowerBorder(string[,] map, int i, int j)
        {
            int perimeter = 1;
            if (map[i - 1, j] != "X" && map[i, j - 1] != "X" && map[i, j + 1] != "X")
                perimeter += perimeterFourSides - 1;
            else if (map[i - 1, j] != "X" && map[i, j - 1] != "X" && map[i, j + 1] != "X")
                perimeter += perimeterThreeSides;
            else if (map[i, j - 1] != "X" && map[i, j + 1] != "X")
                perimeter += perimeterThreeSides - 1;
            else if (map[i, j - 1] != "X" && map[i, j + 1] != "X")
                perimeter += perimeterTwoSides;
            else if (map[i - 1, j] != "X")
                perimeter += perimeterTwoSides - 1;
            else if (map[i - 1, j] != "X")
                perimeter += perimeterOneSides;
            else if (map[i, j - 1] != "X")
                perimeter += perimeterOneSides;
            else if (map[i, j + 1] != "X")
                perimeter += perimeterOneSides;
            return perimeter;
        }
        private static int CalculatePerimeterForLeftBorder(string[,] map, int i, int j)
        {
            int perimeter = 1;
            if (map[i - 1, j] != "X" && map[i + 1, j] != "X" && map[i, j + 1] != "X")
                perimeter += perimeterFourSides - 1;
            else if (map[i - 1, j] != "X" && map[i, j + 1] != "X")
                perimeter += perimeterThreeSides - 1;
            else if (map[i + 1, j] != "X" && map[i, j + 1] != "X")
                perimeter += perimeterThreeSides - 1;
            else if (map[i, j + 1] != "X")
                perimeter += perimeterTwoSides - 1;
            else if (map[i - 1, j] != "X" && map[i + 1, j] != "X")
                perimeter += perimeterTwoSides;
            else if (map[i - 1, j] != "X")
                perimeter += perimeterOneSides;
            else if (map[i + 1, j] != "X")
                perimeter += perimeterOneSides;
            else if (map[i, j + 1] != "X")
                perimeter += perimeterOneSides;
            return perimeter;
        }
        private static int CalculatePerimeterForRightBorder(string[,] map, int i, int j)
        {
            int perimeter = 1;
            if (map[i - 1, j] != "X" && map[i, j - 1] != "X" && map[i + 1, j] != "X")
                perimeter += perimeterFourSides - 1;
            else if (map[i - 1, j] != "X" && map[i, j - 1] != "X")
                perimeter += perimeterThreeSides - 1;
            else if (map[i, j - 1] != "X" && map[i + 1, j] != "X")
                perimeter += perimeterThreeSides - 1;
            else if (map[i, j - 1] != "X")
                perimeter += perimeterTwoSides - 1;
            else if (map[i - 1, j] != "X" && map[i + 1, j] != "X")
                perimeter += perimeterTwoSides;
            else if (map[i - 1, j] != "X")
                perimeter += perimeterOneSides;
            else if (map[i, j - 1] != "X")
                perimeter += perimeterOneSides;
            else if (map[i + 1, j] != "X")
                perimeter += perimeterOneSides;
            return perimeter;
        }
        private static int CalculateUpperLeftCorner(string[,] map, int i, int j)
        {
            int perimeter = 2;
            if (map[i + 1, j] != "X" && map[i, j + 1] != "X")
                perimeter += perimeterTwoSides;
            else if (map[i + 1, j] != "X")
                perimeter += perimeterOneSides;
            else if (map[i , j + 1] != "X")
                perimeter += perimeterOneSides;
            return perimeter;
        }
        private static int CalculateLowerLeftCorner(string[,] map, int i, int j)
        {
            int perimeter = 2;
            if (map[i - 1, j] != "X" && map[i, j + 1] != "X")
                perimeter += perimeterTwoSides;
            else if (map[i - 1, j] != "X")
                perimeter += perimeterOneSides;
            else if (map[i, j + 1] != "X")
                perimeter += perimeterOneSides;
            return perimeter;
        }
        private static int CalculateUpperRightCorner(string[,] map, int i, int j)
        {
            int perimeter = 2;
            if (map[i + 1, j] != "X" && map[i, j - 1] != "X")
                perimeter += perimeterTwoSides;
            else if (map[i + 1, j] != "X")
                perimeter += perimeterOneSides;
            else if (map[i, j - 1] != "X")
                perimeter += perimeterOneSides;
            return perimeter;
        }
        private static int CalculateLowerRightCorner(string[,] map, int i, int j)
        {
            int perimeter = 2;
            if (map[i - 1, j] != "X" && map[i, j - 1] != "X")
                perimeter += perimeterTwoSides;
            else if (map[i - 1, j] != "X")
                perimeter += perimeterOneSides;
            else if (map[i, j - 1] != "X")
                perimeter += perimeterOneSides;
            return perimeter;
        }
    }
}