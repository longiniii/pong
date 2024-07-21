﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace pong
{
    internal static class BotPlayer
    {
        public static int Score { get; private set; } = 0;
        public static int PaddleSizeOnEachSide { get; set; } = 2;
        public static int PaddlePosX { get; set; } = 1;
        public static int PaddlePosY { get; set; } = (int)Math.Floor((double)Table.VerticalLength / 2);
        public static char PaddleChar { get; private set; } = '|';
        public static int PaddleSpeed { get; set; } = 2;

        public static void GetBotsMovement()
        {
            while (BotPlayer.Score < 5 && HumanPlayer.Score < 5)
            {
                if (Ball.PosY > PaddlePosY)
                {
                    for (int i = 0; i < PaddleSpeed; i++)
                    {
                        if (PaddlePosY + PaddleSizeOnEachSide < Table.VerticalLength - 1)
                        {
                            PaddlePosY++;
                            Thread.Sleep(30);
                        }
                        else break;
                    }
                }
                else if (Ball.PosY < PaddlePosY)
                {
                    for (int i = 0; i < PaddleSpeed; i++)
                    {
                        if (PaddlePosY - PaddleSizeOnEachSide > 0)
                        {
                            PaddlePosY--;
                            Thread.Sleep(30);
                        }
                        else break;
                    }
                }
                Thread.Sleep(30);
            }
        }
        public static void AddScore()
        {
            Score++;
        }
    }
}
