using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public static event Action<bool> OnPauseChange;
    void Awake()
    {
        Pause(true);
    }
    
    void Update()
    {
        if (Time.timeScale == 1) return;
        
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Mouse0))
        {
            Pause(false);
        }
    }

    private void Pause(bool pause)
    {
        Time.timeScale = pause ? 0 : 1;
        OnPauseChange?.Invoke(pause);
    }
}
