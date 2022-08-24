using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 10;
    private Animator _animator;
    private static readonly int Moving = Animator.StringToHash("Moving");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        var xAxis = Input.GetAxis("Horizontal");
        var zAxis = Input.GetAxis("Vertical");

        var direction = new Vector3(xAxis, 0, zAxis);
        
        transform.Translate(direction * (movementSpeed * Time.deltaTime));

        _animator.SetBool(Moving, direction != Vector3.zero);
    }
}