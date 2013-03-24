namespace LabyrinthRefactored
{
    using System;

    public class PlayerResult : IComparable<PlayerResult>
    {
        public PlayerResult(int movesCount, string playerName)
        {
            this.MovesCount = movesCount;
            this.PlayerName = playerName;
        }

        public int MovesCount { get; private set; }

        public string PlayerName { get; private set; }

        public int CompareTo(PlayerResult other)
        {
            return this.MovesCount.CompareTo(other.MovesCount);
        }
    }
}
