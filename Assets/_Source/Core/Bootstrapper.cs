using UnityEngine;

namespace Core
{
    public class Bootstrapper : MonoBehaviour
    {
        private void Awake()
        {
            Game.Pause(true);
        }
    }
}