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
    private InputAction jump;  

    private Vector2 moveDirection = Vector2.zero;

    public EntityCollisionBox collisionBox;

    [SerializeField] private bool _OnFloor = true;

    private void Awake()
    {
        _playerControls = new IS_Player();
        _playerControls.Enable(); 
    }   

    private void OnEnable()
    {
        //initialize the input action
        move = _playerControls.Player.Move; 
        jump = _playerControls.Player.Jump;
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
        jump.performed += JumpPerformed;
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = move.ReadValue<Vector2>();
        if (collisionBox.inCollision && collisionBox.type == EntityCollisionBox.collisionType.floor)
        { _OnFloor = collisionBox.inCollision;}

    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(moveDirection.x * _moveSpeed,0, 0);

        if (_OnFloor)
            jump.Enable(); else jump.Disable();
    }

    private void JumpPerformed(InputAction.CallbackContext context) 
    {
        rb.AddForce(Vector3.up * 15f, ForceMode.Impulse);
        _OnFloor = false;
    }

 

}
