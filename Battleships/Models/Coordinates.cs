namespace Battleships.Models
{
    public class Coordinates
    {
        public int Column { get; set; }
        public int Row { get; set; }

        public Coordinates(int column, int row)
        {
            Column = column;
            Row = row;
        }
    }
}
