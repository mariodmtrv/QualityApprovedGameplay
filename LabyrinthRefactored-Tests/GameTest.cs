﻿namespace LabyrinthRefactoredTests
{
    using LabyrinthRefactored;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.IO;

    [TestClass()]
    public class GameTest
    {
        private TestContext testContextInstance;

        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        [TestMethod()]
        [DeploymentItem("LabyrinthRefactored.exe")]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TryMoveLeft_WhenLeftWalled_ShouldNot()
        {
            string[] rawData = new string[Labyrinth.LabyrinthSize]
                                   {
                                       "XXXXXXX",
                                       "X-X---X",
                                       "X---X-X",
                                       "X---X-X",
                                       "X-X----",
                                       "X-----X",
                                       "XXXXXXX"
                                   };
            bool isGameExited = false;
            Game_Accessor target = new Game_Accessor(
                                    MakeLabyrinthFromRawData(
                                        rawData,
                                        new Cell(4, 1, '*')),
                                        ref isGameExited);
            string directionString = "l";
            bool actual;
            actual = target.TryMove(directionString);
        }

        [TestMethod()]
        [DeploymentItem("LabyrinthRefactored.exe")]
        public void IsGameOverTest()
        {
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
            bool isGameExited = false;
            Game_Accessor target = new Game_Accessor(
                                    MakeLabyrinthFromRawData(
                                        rawData,
                                        new Cell(4, 6, '-')),
                                        ref isGameExited);
            bool expected = true;
            bool actual;
            actual = target.IsGameOver();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [DeploymentItem("LabyrinthRefactored.exe")]
        public void ProccessInputD_WhenDownIsFree_ShouldIncreaseMoves()
        {
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
            bool isGameExited = false;
            Game_Accessor target = new Game_Accessor(
                                    MakeLabyrinthFromRawData(
                                        rawData,
                                        new Cell(4, 1, '-')),
                                        ref isGameExited);
            string input = "d";
            int movesCount = 4;
            int movesCountExpected = 5;
            TopResults highScores = new TopResults();
            target.ProccessInput(input, target.labyrinth, ref movesCount, highScores);
            Assert.AreEqual(movesCountExpected, movesCount);
        }

        [TestMethod()]
        [DeploymentItem("LabyrinthRefactored.exe")]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ProccessInputRandomString_ShouldIncreaseMoves()
        {
            string[] rawData = new string[Labyrinth.LabyrinthSize]
                                   {
                                       "XXXXXXX",
                                       "X-X---X",
                                       "X---X-X",
                                       "X-----X",
                                       "X-X-X--",
                                       "X---X-X",
                                       "XXXXXXX"
                                   };
            bool isGameExited = false;
            Game_Accessor target = new Game_Accessor(
                                    MakeLabyrinthFromRawData(
                                        rawData,
                                        new Cell(4, 1, '-')),
                                        ref isGameExited);
            string input = "sdfsdfsdf";
            int movesCount = 4;
            TopResults highScores = new TopResults();
            target.ProccessInput(input, target.labyrinth, ref movesCount, highScores);
        }

        [TestMethod()]
        //
        // This is a text formatting sensitive test. 
        // Any formatting changes may prevent it from passing.
        //
        [DeploymentItem("LabyrinthRefactored.exe")]
        public void PlayComprehensiveTest_WhenConsoleRedirected_ShouldPass()
        {
            string[] rawData = new string[Labyrinth.LabyrinthSize]
                                   {
                                       "XXXXXXX",
                                       "X-X---X",
                                       "X---X-X",
                                       "X-----X",
                                       "X-X-X--",
                                       "X---X-X",
                                       "XXXXXXX"
                                   };
            string consoleInput = "someboardtest\nr\nd\nr\nd\ntop\nr\nIvan\nexit\n";

            string expectedConsoleOutput =
            @"Welcome to Labyrinth game. Please try to escape. Use 'top' to view the top scoreboard, 'restart' to start a new game and 'exit' to quit the game.
X X X X X X X 
X - X - - - X 
X - - - X - X 
X - - - - - X 
X - X - X - - 
X - - - X - X 
X X X X X X X 
Enter your move (L=left,R-right, U=up, D=down): 
Invalid command!
X X X X X X X 
X - X - - - X 
X - - - X - X 
X - - - - - X 
X - X - X - - 
X - - - X - X 
X X X X X X X 
Enter your move (L=left,R-right, U=up, D=down): 
X X X X X X X 
X - X - - - X 
X - - - X - X 
X - - - * - X 
X - X - X - - 
X - - - X - X 
X X X X X X X 
Enter your move (L=left,R-right, U=up, D=down): 
Invalid move!
X X X X X X X 
X - X - - - X 
X - - - X - X 
X - - - * - X 
X - X - X - - 
X - - - X - X 
X X X X X X X 
Enter your move (L=left,R-right, U=up, D=down): 
X X X X X X X 
X - X - - - X 
X - - - X - X 
X - - - - * X 
X - X - X - - 
X - - - X - X 
X X X X X X X 
Enter your move (L=left,R-right, U=up, D=down): 
X X X X X X X 
X - X - - - X 
X - - - X - X 
X - - - - - X 
X - X - X * - 
X - - - X - X 
X X X X X X X 
Enter your move (L=left,R-right, U=up, D=down): 
The scoreboard is empty.
X X X X X X X 
X - X - - - X 
X - - - X - X 
X - - - - - X 
X - X - X * - 
X - - - X - X 
X X X X X X X 
Enter your move (L=left,R-right, U=up, D=down): 
Congratulations! You escaped in 4 moves.
Please enter your name for the top scoreboard: 


";

            string actualConsoleOutput = ExecutePlay(
                                                    consoleInput,
                                                    rawData,
                                                    new Cell(3, 3, '-'));

            Assert.AreEqual(
                            expectedConsoleOutput,
                            actualConsoleOutput);
        }

        private string ExecutePlay(string consoleInput, string[] rawData, Cell curCell)
        {
            StringReader inputReader = new StringReader(consoleInput);
            StringWriter outputWriter = new StringWriter();
            Console.SetIn(inputReader);
            Console.SetOut(outputWriter);
            bool isGameExited = false;
            Game_Accessor target = new Game_Accessor(
                                                    MakeLabyrinthFromRawData(rawData, curCell),
                                                    ref isGameExited);
            target.Play();
            return outputWriter.ToString();
        }

        private Labyrinth MakeLabyrinthFromRawData(string[] rawData, Cell curCell)
        {
            LabyrinthTest lt = new LabyrinthTest();
            Cell[,] data = lt.LabyrinthDataFromStringArray(rawData);
            Cell current = new Cell(curCell.Row, curCell.Col, curCell.ValueChar);
            Labyrinth lab = new Labyrinth(data, current);
            return lab;
        }
    }
}
