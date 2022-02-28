namespace Battleships.Models
{
    public class Tile
    {
        public Coordinates Coordinates { get; }
        public bool IsOccupied { get; }
        public bool Hit { get; private set; }
        public bool Miss { get; private set; }

        public Tile(int column, int row)
        {
            Coordinates = new Coordinates(column, row);
            IsOccupied = false;
            Hit = false;
            Miss = false;
        }

        public void ChangeToHit()
        {
            Hit = true;
        }

        public void ChangeToMiss()
        {
            Miss = true;
        }
    }
}
