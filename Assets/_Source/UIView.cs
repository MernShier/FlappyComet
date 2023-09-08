using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UIView : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text pauseText;
    
    private void OnEnable()
    {
        Score.Instance.OnScoreChange += UpdateScoreText;
        Game.OnPauseChange += UpdatePauseObject;
    }
    
    private void OnDisable()
    {
        Score.Instance.OnScoreChange -= UpdateScoreText;
        Game.OnPauseChange -= UpdatePauseObject;
    }

    private void UpdateScoreText()
    {
        scoreText.text = $"{Score.Instance.Value}";
    }
    
    private void UpdatePauseObject(bool value)
    {
        pauseText.gameObject.SetActive(value);
    }
}
