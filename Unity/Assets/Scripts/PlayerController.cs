using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 10;
    
    private Animator _animator;
    private Rigidbody _rigidbody;
    private Vector3 _direction;
    
    private static readonly int Moving = Animator.StringToHash("Moving");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        var xAxis = Input.GetAxis("Horizontal");
        var zAxis = Input.GetAxis("Vertical");

        _direction = new Vector3(xAxis, 0, zAxis);
        
        
    }

    private void FixedUpdate()
    {
        _rigidbody.MovePosition(_rigidbody.position + (_direction * (movementSpeed * Time.deltaTime)));
        _animator.SetBool(Moving, _direction != Vector3.zero);
        
    }
}