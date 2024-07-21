using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace pong
{
    internal static class Pong
    {
        public static int RefreshRate { get; private set; } = 37;
        public static void Game()
        {
            Table.DrawTable();
            Task botsMovementtask = Task.Run(() => BotPlayer.GetBotsMovement());
            Task updatingTableTask = Task.Run(() => Table.UpdateTable());
            Task movingTheBallTask = Task.Run(() => Ball.MoveBall());
            Task usersMovementTask = Task.Run(() => HumanPlayer.GetUsersMovement());

            Task.WaitAll(botsMovementtask, updatingTableTask, movingTheBallTask); // usersMovementTask); not waiting for this guy because of readkey
            Console.Clear();
            if (HumanPlayer.Score > BotPlayer.Score)
            {
                SoundEffects.WinningAudio.Play();
                Console.WriteLine("You Won!");
                Console.WriteLine("Press esc to quit");
                ConsoleKeyInfo key;
                key = Console.ReadKey();
                while (key.Key != ConsoleKey.Escape)
                {
                    key = Console.ReadKey();
                }
            }
            else
            {
                SoundEffects.LosingAudio.Play();
                Console.WriteLine("You Lost!");
                Console.WriteLine("Press esc to quit");
                ConsoleKeyInfo key;
                key = Console.ReadKey();
                while (key.Key != ConsoleKey.Escape)
                {
                    key = Console.ReadKey();
                }
            }
        }
    }
}
