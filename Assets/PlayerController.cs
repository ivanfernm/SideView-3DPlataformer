using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float _moveSpeed = 5;
    public float _jumpForce = 10;
    public  IS_Player _playerControls;
    public float slashDuration;

    //create the input action 
    private InputAction move;
    private InputAction jump;
    private InputAction fire;

    private Vector2 moveDirection = Vector2.zero;

    public EntityCollisionBox collisionBox;
    public GameObject slash;

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
        fire = _playerControls.Player.Shoot;
        //Enable the variable
        move.Enable();
        fire.Enable();
        fire.performed += FirePerformed;

    }

    private void OnDisable()
    {
        //disable the variable
        move.Disable();
        fire.Disable();
    
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
        rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        _OnFloor = false;
    }

    private void FirePerformed(InputAction.CallbackContext context) 
    {
        StartCoroutine(TurnOff(slash, slashDuration));
    }

    //create a corrutine that turn on and off a gameobject based in time
    IEnumerator TurnOff(GameObject obj, float time)
    {
        yield return new WaitForSeconds(time);
        obj.SetActive(false);
    }


 

}
