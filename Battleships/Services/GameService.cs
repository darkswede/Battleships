using Battleships.Models;

namespace Battleships.Services
{
    public class GameService : IGameService
    {
        private Game _game;

        public Game GetOrCreateGame()
        {
            if (_game == null)
            {
                _game = new Game();
            }

            return _game;
        }
    }
}
