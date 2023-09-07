using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class Collectible : MonoBehaviour, IMove, IHaveLifeTime
{
    [SerializeField] private CollectibleType collectibleType;
    [SerializeField] private int value;
    [field:SerializeField] public float MoveSpeed { get; set; }
    [field:SerializeField] public float LifeTime { get; set; }
    
    private void Awake()
    {
        StartCoroutine(StartLifeTimer(LifeTime));
    }

    private void Update()
    {
        Move();
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
    
    public void Move()
    {
        transform.position += Vector3.left * (MoveSpeed * Time.deltaTime);
    }

    private void OnPickUp()
    {
        Destroy(gameObject);
    }
    
    public IEnumerator StartLifeTimer(float lifeTime)
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }
}
