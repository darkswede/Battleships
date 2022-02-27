﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Battleships.Models
{
    public class Player
    {
        public string Name { get; set; }
        public Board PlayerBoard { get; }
        public Board EnemyBoard { get; }
        public IEnumerable<Ship> Ships { get; set; }
        public int HP { get; protected set; }
        public bool IsAlive { get; protected set; }

        public Player(string name)
        {
            Name = name;
            Ships = new List<Ship>()
            {
                new Ship(2),
                new Ship(3),
                new Ship(3),
                new Ship(4),
                new Ship(5)
            };
            HP = SetHP(Ships);
            PlayerBoard = new Board(Ships);
            EnemyBoard = new Board();
            IsAlive = true;
        }
        //Coordinates
        public void  Fire()
        {
            var possibleHitsNextToKnownHit = SearchForNotDestroyedShipPart();
            if (possibleHitsNextToKnownHit.Any())
            {
                ShotNextToKnownHit(possibleHitsNextToKnownHit);
            }
            else
            {
                Shot();
            }
        }

        public void PlayerLose()
        {
            IsAlive = false;
        }

        private List<Coordinates> SearchForNotDestroyedShipPart()
        {
            List<Tile> tiles = new List<Tile>();
            var knownHit = EnemyBoard.BoardOfTiles.Where(x => x.Hit);
            foreach (var hit in knownHit)
            {
                tiles.AddRange(GetTilesNextToKnownHitColation(hit.Coordinates).ToList());
            }

            return tiles.Distinct()
                .Where(x => x.Miss == false)
                .Select(x => x.Coordinates)
                .ToList();
        }

        private List<Tile> GetTilesNextToKnownHitColation(Coordinates coordinates)
        {
            int column = coordinates.Column;
            int row = coordinates.Row;
            List<Tile> tiles = new List<Tile>();

            if (column > 1)
            {
                tiles.Add(TileLocation(column - 1, row));
            }
            if (column < 10)
            {
                tiles.Add(TileLocation(column + 1, row));
            }
            if (row > 1)
            {
                tiles.Add(TileLocation(column, row - 1));
            }
            if (row < 10)
            {
                tiles.Add(TileLocation(column, row + 1));
            }

            return tiles;
        }

        private static Tile TileLocation(int column, int row)
        {
            var tiles = new List<Tile>();
            return tiles.Where(x => x.Coordinates.Column == column && x.Coordinates.Row == row).First();
        }

        private Coordinates ShotNextToKnownHit(List<Coordinates> coordinates)
        {
            Random random = new Random();
            var shotAt = random.Next(coordinates.Count);
            return coordinates[shotAt];
        }

        private Coordinates Shot()
        {
            Random random = new Random();
            var targets = EnemyBoard.BoardOfTiles.Where(x => x.Hit == false && x.Miss == false)
                .Select(x => x.Coordinates)
                .ToList();
            var shotAt = random.Next(targets.Count);
            return targets[shotAt];
        }

        private static int SetHP(IEnumerable<Ship> ships)
        {
            var hp = 0;
            var length = ships.Select(x => x.Length);
            foreach (var shipLength in length)
            {
                hp += shipLength;
            }

            return hp;
        }
    }
}