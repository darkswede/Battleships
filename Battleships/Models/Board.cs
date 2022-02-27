using System;
using System.Collections.Generic;
using System.Linq;

namespace Battleships.Models
{
    public class Board
    {
        public List<Tile> BoardOfTiles { get; protected set; }

        public Board()
        {
            CreateEmptyBoard();
        }

        public Board(IEnumerable<Ship> ships)
        {
            CreateEmptyBoard();
            PopulateBoardWithShips(ships);
        }

        private List<Tile> CreateEmptyBoard()
        {
            BoardOfTiles = new List<Tile>();

            for (int columntTiles = 1; columntTiles <= 10; columntTiles++)
            {
                for (int rowTiles = 1; rowTiles <= 10; rowTiles++)
                {
                    BoardOfTiles.Add(new Tile(columntTiles, rowTiles));
                }
            }

            return BoardOfTiles;
        }

        private void PopulateBoardWithShips(IEnumerable<Ship> ships)
        {
            var random = new Random();
            var shipsPlaced = false;

            while (!shipsPlaced)
            {
                foreach (var ship in ships)
                {
                    var startColumn = random.Next(1, 11);
                    var endColumn = startColumn;
                    var startRow = random.Next(1, 11);
                    var endRow = startRow;
                    var placeOrientation = random.Next(1, 2) % 2;

                    List<int> tilesForShipPlacement = new List<int>();
                    if (placeOrientation == 0)
                    {
                        for (var i = 1; i < ship.Length; i++)
                        {
                            endColumn++;
                        }
                    }
                    else
                    {
                        for (var i = 1; i < ship.Length; i++)
                        {
                            endRow++;
                        }
                    }

                    if (endColumn > 10 || endRow > 10)
                    {
                        shipsPlaced = false;
                        continue;
                    }

                    var affectedTiles = AddingShipToBoard(startColumn, endColumn, startRow, endRow);
                    if (affectedTiles.Any(x => x.IsOccupied))
                    {
                        shipsPlaced = false;
                        continue;
                    }

                    foreach (var tile in affectedTiles)
                    {
                        tile.IsOccupied = true;
                    }

                    shipsPlaced = true;
                }
            }

        }

        private List<Tile> AddingShipToBoard(int startColumn, int endColumn, int startRow, int endRow)
        {
            var tiles = new List<Tile>();
            return tiles.Where(x => x.Coordinates.Column >= startColumn
                                    && x.Coordinates.Column <= endColumn
                                    && x.Coordinates.Row >= startRow
                                    && x.Coordinates.Row <= endRow)
                                    .ToList();
        }
    }
}
