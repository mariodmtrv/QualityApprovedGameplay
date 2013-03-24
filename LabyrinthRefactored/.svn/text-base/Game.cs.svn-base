namespace LabyrinthRefactored
{
    using System;

    public class Game
    {
        private static TopResults topResults = new TopResults();
        private static bool gameExited = false;
        private Labyrinth labyrinth;

        public Game(ref bool isGameExited)
        {
            this.labyrinth = new Labyrinth();
            this.Play();
            isGameExited = gameExited;
        }

        private Game(Labyrinth preLoadedLabyrinth, ref bool isGameExited)
        {
            this.labyrinth = preLoadedLabyrinth;
            isGameExited = gameExited;
        }

        private static void Escaped(int movesCount)
        {
            UserInterface.DisplayEscapedMessage(movesCount);
            if (topResults.ResultQualifiesForTopResults(movesCount))
            {
                topResults.AddResultToTopResults(movesCount, UserInterface.GetUserName());
            }

            UserInterface.DisplayInstructions("\n");
        }

        private void Play()
        {
            UserInterface.DisplayInstructions(Messages.Welcome);
            int movesCount = 0;
            string input = String.Empty;

                while (!this.IsGameOver() && input != "restart")
                {
                    UserInterface.PrintLabyrinth(this.labyrinth);
                    input = UserInterface.GetInput();
                    try
                    {
                        this.ProccessInput(input, this.labyrinth, ref movesCount, topResults);
                        
                        if (gameExited) 
                        { 
                            return; 
                        }
                    }
                    catch (InvalidOperationException ioe)
                    {
                        UserInterface.DisplayException(ioe.Message);
                    }
                }
               
            if (input != "restart")
            {
                Escaped(movesCount);
            }
        }

        private bool IsGameOver()
        {
            int currentRow = this.labyrinth.CurrentCell.Row;
            int currentCol = this.labyrinth.CurrentCell.Col;

            if (currentRow == 0 || currentCol == 0 ||
                currentRow == Labyrinth.LabyrinthSize - 1 ||
                currentCol == Labyrinth.LabyrinthSize - 1)
            {
                return true;
            }

            return false;
        }

        private bool TryMove(string directionString)
        {
            bool moveDone = false;
            Direction direction = 0;
                switch (directionString)
                {
                    case "u":
                        {
                            direction = Direction.Up;
                            break;
                        }

                    case "d":
                        {
                            direction = Direction.Down;
                            break;
                        }

                    case "l":
                        {
                            direction = Direction.Left;
                            break;
                        }

                    case "r":
                        {
                            direction = Direction.Right;
                            break;
                        }
                }

                moveDone = this.labyrinth.TryMove(this.labyrinth.CurrentCell, direction);
             
                if (moveDone == false)
                {
                    throw new InvalidOperationException(Messages.InvalidMove);
                }

            return moveDone;
        }

        private void ProccessInput(
                                    string input,
                                    Labyrinth labyrinth,
                                    ref int movesCount,
                                    TopResults topResults)
        {
            string inputToLower = input.ToLower();
                switch (inputToLower)
                {
                    case "u":
                    case "d":
                    case "l":
                    case "r":
                        {
                            // fallthrough
                            bool moveDone =
                                this.TryMove(inputToLower);
                            if (moveDone)
                            {
                                movesCount++;
                            }

                            break;
                        }

                    case "top":
                        {
                            TopResults.Display();
                            break;
                        }

                    case "exit":
                        {
                            UserInterface.DisplayInstructions(Messages.GoodBye);
                            gameExited = true;
                            return;
                        }

                    case "restart":
                        {
                            break;
                        }

                    default:
                        {
                            throw new InvalidOperationException(Messages.InvalidCommand);  
                        }
                } 
        }
    }
}
