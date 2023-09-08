using Core;
using ScoreSystem;
using TMPro;
using UnityEngine;
using Zenject;

namespace UI
{
    public class UIView : MonoBehaviour
    {
        [SerializeField] private TMP_Text scoreText;
        [SerializeField] private TMP_Text pauseText;
        [Inject] private Score _score;
    
        private void OnEnable()
        {
            Score.OnScoreChange += UpdateScoreText;
            Game.OnPauseChange += UpdatePauseObject;
        }
    
        private void OnDisable()
        {
            Score.OnScoreChange -= UpdateScoreText;
            Game.OnPauseChange -= UpdatePauseObject;
        }

        private void UpdateScoreText()
        {
            scoreText.text = $"{_score.Value}";
        }
    
        private void UpdatePauseObject(bool value)
        {
            pauseText.gameObject.SetActive(value);
        }
    }
}
