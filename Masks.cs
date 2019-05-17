namespace ImageProcessing
{
    public class Masks
    {
        public static int[,] RobertsPoziom =>
            new[,]
            {
                {0, 0, 0},
                {0, 1, 0},
                {0, -1, 0}
            };

        public static int[,] RobertsPion =>
            new int[,]
        {
            {0, 0, 0},
            {0, 1, -1},
            {0, 0, 0}
        };

        public static int[,] PrewittPoziom =>
            new int[,]
        {
            {1, 0, -1},
            {1, 0, -1},
            {1, 0, -1}
        };

        public static int[,] PrewittPion =>
            new int[,]
        {
            {1, 1, 1},
            {0, 0, 0},
            {-1, -1, -1}
        };

        public static int[,] SobelPoziom =>
            new int[,]
        {
            {1, 0, -1},
            {2, 0, -2},
            {1, 0, -1}
        };

        public static int[,] SobelPion =>
            new int[,]
        {
            {1, 2, 1},
            {0, 0, 0},
            {-1, -2, -1}
        };

        public static int[,] LaplaceFirst =>
            new int[,] 
            {
                {0, -1, 0},
                {-1, 4, -1},
                {0, -1, 0}
            };

        public static int[,] LaplaceSecond =>
            new int[,]
            {
                {-1, -1, -1},
                {-1, 8, -1},
                {-1, -1, -1}
            };

        public static int[,] LaplaceThird =>
            new int[,]
            {
                {-2, 1, -2},
                {1, 4, 1},
                {-2, 1, -2}
            };
    }
}