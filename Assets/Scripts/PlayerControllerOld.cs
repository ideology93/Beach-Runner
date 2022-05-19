using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerControllerOld : MonoBehaviour
{
    public CharacterController controller;
    public Animator animate;
    private Vector3 moveDirection;
    private float verticalInput;
    Vector3 velocity;
    [SerializeField] LayerMask groundMask;
    public float moveSpeed;
    [SerializeField] private float jumpHeight = 3f;
    [SerializeField] private float gravity;
    [SerializeField] public bool isGrounded;
    [SerializeField] private float groundCheckDistance;
    private float verticalVelocity;
    private float groundedTimer;
    private bool isJumping;
    private bool isMoving;
    public float jumpTimer;
    public bool isDead;
    private Vector3 playerPosition;
    public float rotationSpeed = 720;
    public PauseMenu pause;
    private float[] lanes = { -2, 0, 2 };
    float screenCenterX;
    float horizontalInput;
    float leftSide;
    float rightSide;
    public GameObject completeLevelUI;


    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        animate = GetComponent<Animator>();
        screenCenterX = Screen.width * 0.5f;
        leftSide = screenCenterX - screenCenterX / 2.8f;
        rightSide = screenCenterX + screenCenterX / 2.8f;
        Debug.Log("Left" + leftSide + " right:" + rightSide);

    }
    public static bool IsPointerOverGameObject()
    {
        //check mouse
        if (EventSystem.current.IsPointerOverGameObject())
            return true;

        //check touch
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            if (EventSystem.current.IsPointerOverGameObject(Input.touches[0].fingerId))
                return true;
        }

        return false;
    }
    private void Update()
    {

       if(IsPointerOverGameObject()){
           return;
       }
        if (transform.position.y < 1.6)
        {
            isGrounded = true;
        }
        if (!PauseMenu.isPaused && !isDead)
        {
            Move();
        }
        if (isDead)
        {
            velocity.y += gravity * Time.deltaTime;
            //falling
            controller.Move(velocity * Time.deltaTime);

        }

    }
    private void Move()
    {
        isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        if (isJumping && !isGrounded)
        {
            animate.SetFloat("Speed", 0.4f);
        }
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if (completeLevelUI.activeSelf)
        {

            moveSpeed = 0;
            animate.SetFloat("Speed", 0f);
            return;
        }

        if (isDead)
        {

            animate.SetBool("isDead", true);
            moveSpeed = 0;
            animate.SetFloat("Speed", 0.5f);
            return;
        }


        //forward force
        moveDirection = new Vector3(0, 0, 1);




        jumpTimer -= Time.deltaTime;


        if (isGrounded && jumpTimer <= 0)
        {
            isJumping = false;
            animate.SetBool("isJumping", false);
            animate.SetFloat("Speed", 1f);

        }
        if (Input.touchCount > 0 || Input.GetMouseButton(0))
        {
            // get the first one
            Touch firstTouch = Input.GetTouch(0);
            // if it began this frame
            if (firstTouch.phase == TouchPhase.Began)
            {
                if (firstTouch.position.x > rightSide)
                {
                    horizontalInput = firstTouch.pressure / 1.2f;
                }
                else if (firstTouch.position.x < leftSide)
                {
                    horizontalInput = -firstTouch.pressure / 1.2f;
                }
                else if (isGrounded)
                {
                    Jump();
                }
            }
        }
        else horizontalInput = Input.GetAxis("Horizontal");
        Vector3 movementDirection = new Vector3(horizontalInput, 0, 1);
        float magnitude = Mathf.Clamp01(movementDirection.magnitude * moveSpeed);
        movementDirection.Normalize();
        controller.Move(movementDirection * magnitude * moveSpeed * Time.deltaTime);
        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime * 500);
        }
        //movement

        //gravity

        //falling
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);


    }
    private void Jump()
    {
        jumpTimer = 0.7f;
        isJumping = true;
        animate.SetBool("isJumping", true);
        velocity.y += Mathf.Sqrt(jumpHeight * -2 * gravity);
    }


}

