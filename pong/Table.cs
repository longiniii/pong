using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace pong
{
    internal static class Table
    {
        public static char HorizontalChar { get; private set; } = '─';
        public static char VerticalChar { get; private set; } = '│';
        public static char LeftUpChar { get; private set; } = '┌';
        public static char RightUpChar { get; private set; } = '┐';
        public static char LeftDownChar { get; private set; } = '└';
        public static char RightDownChar { get; private set; } = '┘';
        public static int HorizontalLength { get; private set; } = 91;
        public static int VerticalLength { get; private set; } = 23;

        public static void DrawTable()
        {
            StringBuilder theTable = new StringBuilder("");
            Console.Clear();
            theTable.Append(LeftUpChar);
            theTable.Append(new string(HorizontalChar, HorizontalLength));
            theTable.Append(RightUpChar);
            for (int i = 0; i < VerticalLength; i++)
            {
                theTable.Append("\n");
                theTable.Append(VerticalChar.ToString());
                theTable.Append(new string(' ', HorizontalLength));
                theTable.Append(VerticalChar);
            }
            theTable.Append("\n");
            theTable.Append(LeftDownChar.ToString());
            theTable.Append(new string(HorizontalChar, HorizontalLength));
            theTable.Append(RightDownChar);
            Console.WriteLine(theTable.ToString());
            for (int i = 0; i < VerticalLength; i++)
            {
                Console.SetCursorPosition((int)Math.Floor((double)HorizontalLength / 2) + 1 + 1, i + 1);
                Console.Write("\b");
                Console.Write("|");
            }
        }

        public static List<List<int[]>> OldPositions { get; set; } = new List<List<int[]>>() { new List<int[]> {}, new List<int[]> {} };

        public static void UpdateTable()
        {
            while (BotPlayer.Score < 5 && HumanPlayer.Score < 5)
            {
                Console.CursorVisible = false;
                for (int i = 0; i < OldPositions[1].Count; i++)
                {
                    Console.SetCursorPosition(OldPositions[1][i][0], OldPositions[1][i][1]);
                    Console.Write("\b");
                    Console.Write(" ");
                }
                OldPositions[1] = OldPositions[0];
                OldPositions[0].Clear();

                if (Ball.PosX + 1 + 1 != (int)Math.Floor((double)HorizontalLength / 2) + 1 + 1)
                {
                    Console.SetCursorPosition(Ball.PosX + 1 + 1, Ball.PosY + 1);
                    Console.Write("\b");
                    Console.Write(Ball.TheBall);
                    OldPositions[0].Add(new int[] { Ball.PosX + 1 + 1, Ball.PosY + 1 });
                }


                for (int i = 0; i <= HumanPlayer.PaddleSizeOnEachSide * 2; i++)
                {
                    Console.SetCursorPosition(HumanPlayer.PaddlePosX + 2, HumanPlayer.PaddlePosY - HumanPlayer.PaddleSizeOnEachSide + i + 1);
                    Console.Write("\b");
                    Console.Write('▐');
                    OldPositions[0].Add(new int[] { HumanPlayer.PaddlePosX + 2, HumanPlayer.PaddlePosY - HumanPlayer.PaddleSizeOnEachSide + i + 1 });
                }
                for (int i = 0; i <= BotPlayer.PaddleSizeOnEachSide * 2; i++)
                {
                    Console.SetCursorPosition(BotPlayer.PaddlePosX + 2, BotPlayer.PaddlePosY - BotPlayer.PaddleSizeOnEachSide + i + 1);
                    Console.Write("\b");
                    Console.Write('▐');
                    OldPositions[0].Add(new int[] { BotPlayer.PaddlePosX + 2, BotPlayer.PaddlePosY - BotPlayer.PaddleSizeOnEachSide + i + 1 });
                }
                Thread.Sleep(Pong.RefreshRate);
            }
        }
    }
}
