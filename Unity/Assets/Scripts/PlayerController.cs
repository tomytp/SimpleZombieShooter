using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 10;
    [SerializeField] private LayerMask ground;
    [SerializeField] private GameObject gameOverCanvas;
    
    private Animator _animator;
    private Rigidbody _rigidbody;
    private Vector3 _direction;
    private Camera _camera;
    private bool _alive = true;
    
    private static readonly int Moving = Animator.StringToHash("Moving");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
        _camera = Camera.main;
        Time.timeScale = 1;
    }

    private void Update()
    {
        var xAxis = Input.GetAxis("Horizontal");
        var zAxis = Input.GetAxis("Vertical");

        _direction = new Vector3(xAxis, 0, zAxis);

        if (!_alive)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    private void FixedUpdate()
    {
        _rigidbody.MovePosition(_rigidbody.position + (_direction * (movementSpeed * Time.deltaTime)));
        _animator.SetBool(Moving, _direction != Vector3.zero);

        var ray = _camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out var hit, 100, ground))
        {
            var playerPosition = transform.position;
            
            var lookDirection = hit.point - playerPosition;
            lookDirection.y = playerPosition.y;
            
            var lookRotation = Quaternion.LookRotation(lookDirection);
            _rigidbody.MoveRotation(lookRotation);
        }
    }
    public void EndGame()
    {
        _alive = false;
        gameOverCanvas.SetActive(true);
        Time.timeScale = 0;
    }
}