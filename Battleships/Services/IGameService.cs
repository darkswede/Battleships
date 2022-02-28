using Battleships.Models;

namespace Battleships.Services
{
    public interface IGameService
    {
        public Game GetOrCreateGame();
    }
}
