using System;

namespace Battleships.Models
{
    public class Game
    {
        public Player Player { get; set; }
        public Player NPCPlayer { get; set; }

        public Game()
        {
            Player = new Player("me");
            NPCPlayer = new Player("PC");
        }

        //public void RunGame()
        //{
        //    while (Player.IsAlive == true && NPCPlayer.IsAlive == true)
        //    {
        //        Player.ManualShot(coordinates);
        //        PlayTurn(coordinates);
        //    }

        //    if (Player.IsAlive == false)
        //    {
        //        Console.WriteLine($"{NPCPlayer.Name} won the game.");
        //    }
        //    else if (NPCPlayer.IsAlive == false)
        //    {
        //        Console.WriteLine($"{Player.Name} won the game.");
        //    }
        //}

        public void PlayTurn(Coordinates coordinates)
        {
            Player.ManualShot(coordinates);
            var shotResult = NPCPlayer.ProcessShot(coordinates);
            Player.ProcessShotResult(shotResult);

            if (NPCPlayer.IsAlive)
            {
                var shotAt = NPCPlayer.Fire();
                shotResult = Player.ProcessShot(shotAt);
                NPCPlayer.ProcessShotResult(shotResult);
            }
        }
    }
}
