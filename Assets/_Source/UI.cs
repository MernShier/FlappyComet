using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UI : MonoBehaviour
{
    private TMP_Text scoreText;
    
    private void OnEnable()
    {
        ScoreManager.Instance.OnScoreChange += UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = $"{ScoreManager.Instance.Score}";
    }
}
