using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text pauseText;
    
    private void OnEnable()
    {
        ScoreManager.Instance.OnScoreChange += UpdateScoreText;
        Game.OnPauseChange += UpdatePauseObject;
    }
    
    private void OnDisable()
    {
        ScoreManager.Instance.OnScoreChange -= UpdateScoreText;
        Game.OnPauseChange -= UpdatePauseObject;
    }

    private void UpdateScoreText()
    {
        scoreText.text = $"{ScoreManager.Instance.Score}";
    }
    
    private void UpdatePauseObject(bool value)
    {
        pauseText.gameObject.SetActive(value);
    }
}
