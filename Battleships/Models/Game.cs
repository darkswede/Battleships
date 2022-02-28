namespace Battleships.Models
{
    public class Game
    {
        public Player Player { get; }
        public Player NPCPlayer { get; }

        public Game()
        {
            Player = new Player("me");
            NPCPlayer = new Player("PC");
        }

        public void PlayTurn(Coordinates coordinates)
        {
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
