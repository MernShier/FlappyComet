using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private Player.Player player;
    
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Mouse0))
        {
            player.MoveUp();
            
            if (Time.timeScale == 1) return;
            Game.Pause(false);
        }
    }
}
