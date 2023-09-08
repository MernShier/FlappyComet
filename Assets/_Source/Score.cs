using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score
{
    public static Score Instance = new();
    public int Value { get; private set; }
    public event Action OnScoreChange;

    public void AddScore(int value)
    {
        Value += value;
        OnScoreChange.Invoke();
    }
}
