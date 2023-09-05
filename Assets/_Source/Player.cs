using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private KeyCode moveUpKey;
    [SerializeField] private float playerAcceleration;
    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKey(moveUpKey) || Input.GetKey(KeyCode.Mouse0))
        {
            _rb.AddForce(Vector2.up * playerAcceleration);
        }
    }
}
