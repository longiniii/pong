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
        public static int RefreshRate { get; private set; } = 40;
        public static void Game()
        {
            Table.DrawTable();
            Task botsMovementtask = Task.Run(() => BotPlayer.GetBotsMovement());
            Task updatingTableTask = Task.Run(() => Table.UpdateTable());
            Task movingTheBallTask = Task.Run(() => Ball.MoveBall());
            Task usersMovementTask = Task.Run(() => HumanPlayer.GetUsersMovement());

            Task.WaitAll(botsMovementtask, updatingTableTask,  movingTheBallTask, usersMovementTask);
            Console.Clear();
            if (HumanPlayer.Score > BotPlayer.Score) Console.WriteLine("You Won!");
            else Console.WriteLine("You Lost!");
        }
    }
}
