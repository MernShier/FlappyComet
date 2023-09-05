using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public abstract class Enemy : MonoBehaviour, IMovable
{
    public float MoveSpeed { get; set; }
    
    private void Move()
    {
        
    }
}
