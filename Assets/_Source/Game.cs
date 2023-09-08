using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Game
{
    public static event Action<bool> OnPauseChange;

    public static void Pause(bool pause)
    {
        Time.timeScale = pause ? 0 : 1;
        OnPauseChange?.Invoke(pause);
    }

    public static void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
