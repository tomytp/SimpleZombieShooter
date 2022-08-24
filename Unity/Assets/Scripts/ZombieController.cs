using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float movementSpeed = 5;

    private Animator _animator;
    private Rigidbody _rigidbody;
    private static readonly int Attacking = Animator.StringToHash("Attacking");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
    }
    
    private void FixedUpdate()
    {
        var playerPosition = player.transform.position;
        var zombiePosition = transform.position;
        var distance = Vector3.Distance(playerPosition, zombiePosition);
        
        var direction = playerPosition - zombiePosition;
        var rotation = Quaternion.LookRotation(direction);
        _rigidbody.MoveRotation(rotation);
        
        if (distance > 2.5)
        {
            _rigidbody.MovePosition(_rigidbody.position + (direction.normalized * (movementSpeed * Time.deltaTime)));
            _animator.SetBool(Attacking, false);
        }
        else
        {
            _animator.SetBool(Attacking,true);
        }
    }

    private void EnemyAttack()
    {
        player.GetComponent<PlayerController>().EndGame();
    }
}
