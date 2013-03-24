namespace LabyrinthRefactored
{
    using System;
    using System.Collections.Generic;

    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }

    public class Labyrinth
    {
        public const int LabyrinthSize = 7;
        private readonly int LabyrintStartRow = LabyrinthSize / 2;
        private readonly int LabyrinthStartCol = LabyrinthSize / 2; 

        public Labyrinth()
        {
            this.LabyrinthData = this.GenerateLabyrinth();
            this.CurrentCell = this.LabyrinthData[this.LabyrintStartRow, this.LabyrinthStartCol];
        }

        public Labyrinth(Cell[,] lab, Cell currentCell)
        {
            this.LabyrinthData = new Cell[LabyrinthSize, LabyrinthSize];
            this.LabyrinthData = lab;
            this.CurrentCell = currentCell;
        }

        private Labyrinth(Cell[,] lab)
        {
            this.LabyrinthData = new Cell[LabyrinthSize, LabyrinthSize];
            this.LabyrinthData = lab;
            this.CurrentCell = this.LabyrinthData[this.LabyrintStartRow, this.LabyrinthStartCol];
        }

        public Cell[,] LabyrinthData { get; private set; }  

        public Cell CurrentCell { get; private set; }

        public Cell GetCell(int row, int col)
        {
            return this.LabyrinthData[row, col];
        }

        public bool TryMove(Cell cell, Direction direction)
        {
            int newRow;
            int newCol;
            this.FindNewCellCoordinates(
                cell.Row,
                cell.Col,
                direction,
                out newRow,
                out newCol);

            if (!this.IsInLabyrinth(newRow, newCol))
            {
                return false;
            }

            if (!this.LabyrinthData[newRow, newCol].IsEmpty())
            {
                return false;
            }

            this.LabyrinthData[newRow, newCol].ValueChar = '*';
            this.LabyrinthData[cell.Row, cell.Col].ValueChar = '-';
            this.CurrentCell = this.LabyrinthData[newRow, newCol];

            return true;
        }

        private void FindNewCellCoordinates(
            int row,
            int col,
            Direction direction,
            out int newRow,
            out int newCol)
        {
            newRow = row;
            newCol = col;

            if (direction == Direction.Up)
            {
                newRow = newRow - 1;
            }
            else if (direction == Direction.Down)
            {
                newRow = newRow + 1;
            }
            else if (direction == Direction.Left)
            {
                newCol = newCol - 1;
            }
            else if (direction == Direction.Right)
            {
                newCol = newCol + 1;
            }
        }

        private void PerformMove(
            Cell[,] labyrinth,
            Cell cell,
            Direction direction,
            Queue<Cell> cellsOrder,
            HashSet<Cell> visitedCells)
        {
            int newRow;
            int newCol;
            this.FindNewCellCoordinates(
                cell.Row,
                cell.Col,
                direction,
                out newRow,
                out newCol);

            if (!this.IsInLabyrinth(newRow, newCol))
            {
                return;
            }

            if (visitedCells.Contains(labyrinth[newRow, newCol]))
            {
                return;
            }

            if (labyrinth[newRow, newCol].IsEmpty())
            {
                cellsOrder.Enqueue(labyrinth[newRow, newCol]);
            }
        }

        private bool IsExit(Cell cell)
        {
            if (cell.Row == LabyrinthSize - 1 || cell.Col == LabyrinthSize - 1 ||
                cell.Row == 0 || cell.Col == 0)
            {
                return true;
            }

            return false;
        }

        private bool ExitPathExists(Cell[,] labyrinth)
        {
            var cellsOrder = new Queue<Cell>();
            Cell startCell = labyrinth[LabyrintStartRow, LabyrinthStartCol];
            cellsOrder.Enqueue(startCell);
            var visitedCells = new HashSet<Cell>();

            bool pathExists = false;
            while (cellsOrder.Count > 0)
            {
                Cell currentCell = cellsOrder.Dequeue();
                visitedCells.Add(currentCell);
                if (IsExit(currentCell))
                {
                    pathExists = true;
                    break;
                }

                PerformMove(labyrinth, currentCell, Direction.Down, cellsOrder, visitedCells);
                PerformMove(labyrinth, currentCell, Direction.Up, cellsOrder, visitedCells);
                PerformMove(labyrinth, currentCell, Direction.Left, cellsOrder, visitedCells);
                PerformMove(labyrinth, currentCell, Direction.Right, cellsOrder, visitedCells);
            }

            return pathExists;
        }

        private Cell[,] GenerateLabyrinth()
        {
            Random rand = new Random();
            bool exitPathExists = false;
            Cell[,] labyrinth = new Cell[LabyrinthSize, LabyrinthSize];

            while (!exitPathExists)
            {
                for (int row = 0; row < LabyrinthSize; row++)
                {
                    for (int col = 0; col < LabyrinthSize; col++)
                    {
                        int cellRandomValue = rand.Next(0, 2);

                        char charValue;
                        if (cellRandomValue == 0)
                        {
                            charValue = Cell.CellEmptyValue;
                        }
                        else
                        {
                            charValue = Cell.CellWallValue;
                        }

                        labyrinth[row, col] = new Cell(row, col, charValue);
                    }
                }

                exitPathExists = ExitPathExists(labyrinth);
            }

            labyrinth[LabyrintStartRow, LabyrinthStartCol].ValueChar = '*';
            return labyrinth;
        }

        private bool IsInLabyrinth(int newRow, int newCol)
        {
            if (newRow < 0 || newCol < 0 ||
                newRow >= LabyrinthSize || newCol >= LabyrinthSize)
            {
                return false;
            }

            return true;
        }
    }
}
