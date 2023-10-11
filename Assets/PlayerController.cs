using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    [Header("--------Player Settings--------")]
    [Space(10)]
    [Header("Player Movement")]
    public  IS_Player _playerControls;
    
    public float _moveSpeed = 5;
    public float _dashforce;

    [Space(10)]
    public EntityCollisionBox collisionBox;
    public float jumpSpeed = 10;
    public float jumpXLenght;
    public float _jumpForce = 10;
    public JumpGizmo jumpGizmo;
    public float maxHeightLimit;
    
    private Vector2 moveDirection = Vector2.zero;

    [Space(10)]
    [Header("Player States")]
    [Space(10)]

    [SerializeField] private bool _OnFloor = true;


    [Space(10)]
    [Header("Player Slash")]
    [Space(10)]
    public GameObject slash;

    public float slashDuration;
    //create the input action 


    public float lineLenght = 10;

    #region UnityStates
    private void Awake()
    {

        //instantiate the warpper(the c# script from the input system) class
        _playerControls = new IS_Player(); 

        _playerControls.Player.Jump.performed += JumpPerformed; 

        _playerControls.Player.Shoot.performed += FirePerformed;    

        _playerControls.Player.Dash.performed += DashPerformed;
   
        
    }
    void Start()
    {
        jumpGizmo.playerController = this;

        _playerControls.Player.Move.performed += move =>
        {
            moveDirection = move.ReadValue<Vector2>(); 
        };
    }
    void Update()
    {
        moveDirection = _playerControls.Player.Move.ReadValue<Vector2>();
       
        if (collisionBox.inCollision && collisionBox.type == EntityCollisionBox.collisionType.floor)
        { _OnFloor = collisionBox.inCollision;}

    }

    private void FixedUpdate()
    {
        transform.position += new Vector3(moveDirection.x, 0, 0) * _moveSpeed * Time.deltaTime;
        var jumpDistance = new Vector2(jumpXLenght, transform.position.y);
        jumpGizmo.UpdateJumpGizmo(jumpDistance);
       
        if (_OnFloor) _playerControls.Player.Jump.Enable(); else _playerControls.Player.Jump.Disable();
    }
    #endregion

    #region InputAction
    private void OnEnable()
    {

        _playerControls.Enable();

    }

    private void OnDisable()
    {

        _playerControls.Disable();
    
    }

    #endregion

    #region PerformedActions
    private void JumpPerformed(InputAction.CallbackContext context) 
    {
        var jumpDesire = jumpGizmo.transform.position;
        StartCoroutine(LerpPostitions(transform.position,jumpDesire,jumpSpeed));
        Debug.Log("Jump");
    }

    private void FirePerformed(InputAction.CallbackContext context) 
    {
        StartCoroutine(TurnOff(slash, slashDuration));
        Debug.Log("Fire");
    }
    private void DashPerformed(InputAction.CallbackContext context) 
    {
        Debug.Log("Dash");
        transform.position += new Vector3(moveDirection.x * (_dashforce * Time.deltaTime) * 10, 0, 0);
    }
    #endregion
    
    IEnumerator TurnOff(GameObject obj, float time)
    {
        obj.SetActive(true);
        yield return new WaitForSeconds(time);
        obj.SetActive(false);
    }
  
    IEnumerator LerpPostitions(Vector3 startPos, Vector3 endPos, float duration)
    {
        float startTime = Time.time;
        float endTime = startTime + duration;

        while (Time.time <= endTime)
        {
            transform.position = Vector3.Slerp(startPos, endPos, (Time.time - startTime) / duration); 
            yield return null;
        }

        transform.position = endPos;
    }

   
}
