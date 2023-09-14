using Core;
using UnityEngine;
using VContainer;

namespace PlayerSystem
{
    public class InputHandler : MonoBehaviour
    {
        [Inject] private Player _player;
    
        void Update()
        {
            if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Mouse0))
            {
                _player.MoveUp();
            
                if (Time.timeScale == 1) return;
                Game.Pause(false);
            }
        }
    }
}