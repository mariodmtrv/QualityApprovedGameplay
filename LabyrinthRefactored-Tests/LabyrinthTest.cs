namespace LabyrinthRefactoredTests
{
    using System;
    using LabyrinthRefactored;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass()]
    public class LabyrinthTest
    {
        private TestContext testContextInstance;

        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }

            set
            {
                testContextInstance = value;
            }
        }

        public Cell[,] LabyrinthDataFromStringArray(string[] rawData)
        {
            Cell[,] result = new Cell[Labyrinth.LabyrinthSize, Labyrinth.LabyrinthSize];

            for (int i = 0; i < Labyrinth.LabyrinthSize; i++)
            {
                for (int j = 0; j < Labyrinth.LabyrinthSize; j++)
                {
                    result[i, j] = new Cell(i, j, rawData[i][j]);
                }
            }

            return result;
        }

        [TestMethod()]
        [DeploymentItem("LabyrinthRefactored.exe")]
        public void IsInLabyrinth_WhenRowAndColAreLargerThanLabyrinthSize()
        {
            Labyrinth_Accessor target = new Labyrinth_Accessor();
            int newRow = 9;
            int newCol = 9;
            bool expected = false;
            bool actual;
            actual = target.IsInLabyrinth(newRow, newCol);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [DeploymentItem("LabyrinthRefactored.exe")]
        public void ExitPathExists_WhenBoardersWalled_ShouldNot()
        {
            Labyrinth_Accessor target = new Labyrinth_Accessor();
            string[] rawData = new string[Labyrinth.LabyrinthSize]
                                   {
                                       "XXXXXXX",
                                       "X-----X",
                                       "X-----X",
                                       "X-----X",
                                       "X-----X",
                                       "X-----X",
                                       "XXXXXXX"
                                   };
            Cell[,] labyrinth = LabyrinthDataFromStringArray(rawData);
            bool expected = false;
            bool actual;
            actual = target.ExitPathExists(labyrinth);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [DeploymentItem("LabyrinthRefactored.exe")]
        public void ExitPathExists_WhenNotWalled_Should()
        {
            Labyrinth_Accessor target = new Labyrinth_Accessor();
            string[] rawData = new string[Labyrinth.LabyrinthSize]
                                   {
                                       "XXXXXXX",
                                       "X-X---X",
                                       "X---X-X",
                                       "X-----X",
                                       "X-X----",
                                       "X-----X",
                                       "XXXXXXX"
                                   };
            Cell[,] labyrinth = LabyrinthDataFromStringArray(rawData);
            bool expected = true;
            bool actual;
            actual = target.ExitPathExists(labyrinth);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void TryMoveLeft_WhenLeftWalled_ShouldNot()
        {
            string[] rawData = new string[Labyrinth.LabyrinthSize]
                                   {
                                       "X-----X",
                                       "X-----X",
                                       "X--X--X",
                                       "X-X-X-X",
                                       "X-----X",
                                       "X-----X",
                                       "X-----X"
                                   };
            Cell[,] labyrinth = LabyrinthDataFromStringArray(rawData);

            Labyrinth_Accessor target = new Labyrinth_Accessor(labyrinth);
            Cell cell = new Cell(3, 3, '*');
            Direction direction = Direction.Left;
            bool expected = false;
            bool actual;
            actual = target.TryMove(cell, direction);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void TryMoveDown_WhenDownFree_Should()
        {
            string[] rawData = new string[Labyrinth.LabyrinthSize]
                                   {
                                       "X-----X",
                                       "X-----X",
                                       "X--X--X",
                                       "X-X-X-X",
                                       "X-----X",
                                       "X-----X",
                                       "X-----X"
                                   };
            Cell[,] labyrinth = LabyrinthDataFromStringArray(rawData);

            Labyrinth_Accessor target = new Labyrinth_Accessor(labyrinth);
            Cell cell = new Cell(3, 3, '*');
            Direction direction = Direction.Down;
            bool expected = true;
            bool actual;
            actual = target.TryMove(cell, direction);
            Assert.AreEqual(expected, actual);
        }
    }
}
