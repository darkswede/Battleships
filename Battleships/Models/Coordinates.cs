namespace Battleships.Models
{
    public class Coordinates
    {
        public int Column { get; }
        public int Row { get; }

        public Coordinates(int column, int row)
        {
            Column = column;
            Row = row;
        }
    }
}
