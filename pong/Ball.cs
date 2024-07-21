using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace pong
{
    internal static class Ball
    {
        private static int[] RandomVelocities { get; set; } = TwoRandoms();
        public static int PosX { get; set; } = (int)Math.Floor((double)Table.HorizontalLength / 2);
        public static int PosY { get; set; } = (int)Math.Floor((double)Table.VerticalLength / 2);
        public static int VelX { get; private set; } = RandomVelocities[0];
        public static int VelY { get; private set; } = RandomVelocities[1];
        //public static double E { get; private set; } = 1.1;
        public static char TheBall { get; private set; } = '■';
        public static void OnHit()
        {

        }
        public static int Hits { get; set; } = 0;
        public static void MoveBall()
        {
            while (BotPlayer.Score < 5 && HumanPlayer.Score < 5)
            {
                Thread.Sleep(Pong.RefreshRate);
                if (HelperClass.BetterRound(PosX + VelX * (double)Pong.RefreshRate / 100, VelX >= 0) <= BotPlayer.PaddlePosX 
                    && Math.Abs(HelperClass.BetterRound(PosY + VelY * (double)Pong.RefreshRate / 100, VelY >= 0) - BotPlayer.PaddlePosY) <= BotPlayer.PaddleSizeOnEachSide)
                {
                    ChangeVelY(HelperClass.BetterRound(PosY + VelY * (double)Pong.RefreshRate / 100, VelY >= 0) - BotPlayer.PaddlePosY);
                    VelX = -VelX;
                }
                else if (HelperClass.BetterRound(PosX + VelX * (double)Pong.RefreshRate / 100, VelX >= 0) >= HumanPlayer.PaddlePosX
                    && Math.Abs(HelperClass.BetterRound(PosY + VelY * (double)Pong.RefreshRate / 100, VelY >= 0) - HumanPlayer.PaddlePosY) <= HumanPlayer.PaddleSizeOnEachSide)
                {
                    ChangeVelY(HelperClass.BetterRound(PosY + VelY * (double)Pong.RefreshRate / 100, VelY >= 0) - HumanPlayer.PaddlePosY);
                    VelX = -VelX;
                }
                else if (HelperClass.BetterRound(PosX + VelX * (double)Pong.RefreshRate / 100, VelX >= 0) < 0)
                {
                    int[] randomVelocities = TwoRandoms();
                    VelX = randomVelocities[0];
                    VelY = randomVelocities[1];
                    PosX = (int)Math.Floor((double)Table.HorizontalLength / 2);
                    PosY = (int)Math.Floor((double)Table.VerticalLength / 2);
                    HumanPlayer.AddScore();
                }
                else if (HelperClass.BetterRound(PosX + VelX * (double)Pong.RefreshRate / 100, VelX >= 0) >= Table.HorizontalLength)
                {
                    int[] randomVelocities = TwoRandoms();
                    VelX = randomVelocities[0];
                    VelY = randomVelocities[1];
                    PosX = (int)Math.Floor((double)Table.HorizontalLength / 2);
                    PosY = (int)Math.Floor((double)Table.VerticalLength / 2);
                    BotPlayer.AddScore();
                }
                else if (HelperClass.BetterRound(PosY + VelY * (double)Pong.RefreshRate / 100, VelY >= 0) < Table.VerticalLength && HelperClass.BetterRound(PosY + VelY * (double)Pong.RefreshRate / 100, VelY >= 0) >= 0)
                {
                    PosX = HelperClass.BetterRound(PosX + VelX * (double)Pong.RefreshRate / 100, VelX >= 0);
                    PosY = HelperClass.BetterRound(PosY + VelY * (double)Pong.RefreshRate / 100, VelY >= 0);
                } else
                {
                    //int random = new Random().Next(1, 101);
                    //if (random % 5 == 0 && random > 50) VelX += 1;
                    //else if (random % 5 == 0 && random < 51) VelX -= 1;
                    VelY = -VelY;
                }
            }
        }

        private static void ChangeVelY(int num)
        {
            if (num < 0)
            {
                if (VelY > 0) VelY = -VelY;
                int random = new Random().Next(1,101);
                if (random % 5 == 0) VelY -= 1;
            }
            else if (num > 0)
            {
                if (VelY < 0) VelY = -VelY;
                int random = new Random().Next(1, 101);
                if (random % 5 == 0) VelY += 1;
            } else
            {
                int random = new Random().Next(1, 101);
                if (random % 2 == 0 && random > 50) VelY += 1;
                else if (random % 2 == 0 && random < 51) VelY -= 1;
            }
        }
        private static int[] TwoRandoms()
        {
            Random random = new Random();
            int[] result = new int[2];
            result[1] = random.Next(-3, 4);
            do
            {
                result[0] = random.Next(-3, 4);
            } while (result[0] == 0);
            return result;
        }
    }
}
