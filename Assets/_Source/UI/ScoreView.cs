using ScoreSystem;
using TMPro;
using UnityEngine;
using VContainer;

namespace UI
{
    public class ScoreView : MonoBehaviour
    {
        [SerializeField] private TMP_Text scoreText;
        private Score _score;

        [Inject]
        private void Construct(Score score)
        {
            _score = score;
        }
        
        private void OnEnable()
        {
            _score.OnScoreChange += UpdateScoreText;
        }

        private void OnDisable()
        {
            _score.OnScoreChange -= UpdateScoreText;
        }

        private void UpdateScoreText() =>
            scoreText.text = $"{_score.Value}";
    }
}
