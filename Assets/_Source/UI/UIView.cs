using Core;
using Core.StateMachine.States;
using ScoreSystem;
using TMPro;
using UnityEngine;
using VContainer;

namespace UI
{
    public class UIView : MonoBehaviour
    {
        [SerializeField] private TMP_Text scoreText;
        [SerializeField] private TMP_Text pauseText;
        [Inject] private Score _score;
        [Inject] private LevelStartState _levelStartState;

        private void OnEnable()
        {
            _score.OnScoreChange += UpdateScoreText;
            _levelStartState.OnLevelStartPauseChange += UpdatePauseObject;
        }
    
        private void OnDisable()
        {
            _score.OnScoreChange -= UpdateScoreText;
            _levelStartState.OnLevelStartPauseChange -= UpdatePauseObject;
        }

        private void UpdateScoreText() =>
            scoreText.text = $"{_score.Value}";

        private void UpdatePauseObject(bool value) =>
            pauseText.gameObject.SetActive(value);
    }
}
