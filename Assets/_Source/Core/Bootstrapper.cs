using UnityEngine;
using VContainer.Unity;

namespace Core
{
    public class Bootstrapper : IStartable
    {
        public void Start()
        {
            Game.Pause(true);
        }
    }
}