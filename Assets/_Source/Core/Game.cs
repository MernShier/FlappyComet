using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core
{
    public static class Game
    {
        public static void ReloadScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
