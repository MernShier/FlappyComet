using Core.StateMachine.States;
using TMPro;
using UnityEngine;
using VContainer;

namespace UI
{
    public class PauseView : MonoBehaviour
    {
        [SerializeField] private TMP_Text pauseText;
        private LevelStartState _levelStartState;

        [Inject]
        private void Construct(LevelStartState levelStartState)
        {
            _levelStartState = levelStartState;
        }

        private void OnEnable()
        {
            _levelStartState.OnLevelStartStatePauseChange += PauseTextSetActive;
        }

        private void OnDisable()
        {
            _levelStartState.OnLevelStartStatePauseChange -= PauseTextSetActive;
        }

        private void PauseTextSetActive(bool value) =>
            pauseText.gameObject.SetActive(value);
    }
}