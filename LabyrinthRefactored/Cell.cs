namespace LabyrinthRefactored
{
    public class Cell
    {
        public const char CellEmptyValue = '-';

        public const char CellWallValue = 'X';

        public Cell(int row, int col, char value)
        {
            this.Row = row;
            this.Col = col;
            this.ValueChar = value;
        }

        public int Row { get; set; }

        public int Col { get; set; }

        public char ValueChar { get; set; }

        public bool IsEmpty()
        {
            return this.ValueChar == CellEmptyValue;
        }
    }
}
