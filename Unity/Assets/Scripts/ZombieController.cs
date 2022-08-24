using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float movementSpeed = 5;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>(); 
    }
    
    private void FixedUpdate()
    {
        var playerPosition = player.transform.position;
        var zombiePosition = transform.position;
        var distance = Vector3.Distance(playerPosition, zombiePosition);
        
        if (distance > 2.5)
        {
            var direction = playerPosition - zombiePosition;
            _rigidbody.MovePosition(_rigidbody.position + (direction.normalized * (movementSpeed * Time.deltaTime)));

            var rotation = Quaternion.LookRotation(direction);
            _rigidbody.MoveRotation(rotation);
        }
    }
}
