using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class Collectible : MonoBehaviour, IMovable
{
    [SerializeField] private CollectibleType collectibleType;
    [SerializeField] private int value;
    public float MoveSpeed { get; set; }

    private void Update()
    {
        transform.position += Vector3.left * (MoveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            if (collectibleType == CollectibleType.Coin)
            {
                ScoreManager.Instance.AddScore(1);
            }
            
            OnPickUp();
        }
    }

    private void OnPickUp()
    {
        Destroy(gameObject);
    }
}
