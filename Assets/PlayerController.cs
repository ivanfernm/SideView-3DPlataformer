using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float _moveSpeed = 5;
    public  IS_Player _playerControls;

    //create the input action 
    private InputAction move;


    private Vector2 moveDirection = Vector2.zero;


    private void Awake()
    {
        _playerControls = new IS_Player();
    }   

    private void OnEnable()
    {
        //initialize the input action
        move = _playerControls.Player.Move;
        //Enable the variable
        move.Enable();

    }

    private void OnDisable()
    {
        //disable the variable
        move.Disable();

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = move.ReadValue<Vector2>();

    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(moveDirection.x * _moveSpeed,0, 0);
    }

 

}
