namespace LabyrinthRefactored
{
    using System.Collections.Generic;
    using System.Linq;

    public class TopResults
    {
        private const int TopResultsCapacity = 5;
        private static List<PlayerResult> topResults;

        public TopResults()
        {
            topResults = new List<PlayerResult>();
            topResults.Capacity = TopResultsCapacity;
        }

        public static void Display()
        {
            UserInterface.TopResults(topResults);
        }

        public bool ResultQualifiesForTopResults(int result)
        {
            if (topResults.Count < TopResultsCapacity)
            {
                return true;
            }

            if (result < topResults.Max().MovesCount)
            {
                return true;
            }

            return false;
        }

        public void AddResultToTopResults(int movesCount, string playerName)
        {
            PlayerResult result = new PlayerResult(movesCount, playerName);

            if (topResults.Count == topResults.Capacity)
            {
                topResults[topResults.Count - 1] = result;
            }
            else
            {
                topResults.Add(result);
            }

            topResults.Sort();
        }
    }
}