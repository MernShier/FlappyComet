using System;

namespace ScoreSystem
{
    public class Score
    {
        public int Value { get; private set; }
        public event Action OnScoreChange;

        public void AddScore(int value)
        {
            Value += value;
            OnScoreChange?.Invoke();
        }
    }
}