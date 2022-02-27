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

        public void RunGame()
        {
            while (Player.IsAlive == true && NPCPlayer.IsAlive == true)
            {
                PlayTurn();
            }

            if (Player.IsAlive == false)
            {
                Console.WriteLine($"{NPCPlayer.Name} won the game.");
            }
            else if (NPCPlayer.IsAlive == false)
            {
                Console.WriteLine($"{Player.Name} won the game.");
            }
        }

        private void PlayTurn()
        {

        }
    }
}
