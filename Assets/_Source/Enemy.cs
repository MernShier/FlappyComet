using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public abstract class Enemy : MonoBehaviour, IHaveLifeTime
{
    [field:SerializeField] public float LifeTime { get; set; }

    protected Rigidbody2D Rb;

    protected virtual void Awake()
    {
        Rb = GetComponent<Rigidbody2D>();
        StartCoroutine(StartLifeTimer(LifeTime));
    }

    public IEnumerator StartLifeTimer(float lifeTime)
    {
        yield return new WaitForSeconds(lifeTime);
        Death();
    }

    private void Death()
    {
        Destroy(gameObject);
    }
}
