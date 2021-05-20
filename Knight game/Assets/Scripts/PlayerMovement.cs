using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Variables
    [SerializeField] private float moveSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;

    private Vector3 moveDirection; //Used to represent 3D positions  
    private Vector3 velocity; //keep track of gravity by storing (up and down) 3D positions of the player
    //References
    private Animator animator;
    [SerializeField] private bool isGrounded; //Keeping track of player is on ground or not!
    [SerializeField] private float groundCheckDistance; //Check distance of player from the ground (Radius)
    [SerializeField] private LayerMask groundMask; // Making ground's layer by which distance of player will calculate. 
    [SerializeField] private float gravity; //Storing value of gravity which will apply.
    //[SerializeField] private float jumpHeight;

    private CharacterController controller; //Movement happens because of it


    int jumpHash;
    int crouchHash;
    int crouchWalkhash;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
        jumpHash = Animator.StringToHash("isJump");
        crouchHash = Animator.StringToHash("isCrouch");
        crouchWalkhash = Animator.StringToHash("isCrouchWalk"); 
    }

   private void Update()   //Calls on each frame
    {
        Move();
        bool mouseLeftPressed = Input.GetKeyDown(KeyCode.Mouse0);
        
        if (mouseLeftPressed)
        {
            StartCoroutine(Attack());
        }
    }

    private void Move()
    {
       
        bool jumpPressed = Input.GetKeyDown(KeyCode.Space); //Controls for jumping
        bool isJumping = animator.GetBool(jumpHash);

        bool crouchPressed = Input.GetKeyDown(KeyCode.C);
        bool isCrouch = animator.GetBool(crouchHash);

        bool isCrouchWalk = animator.GetBool(crouchWalkhash);

        isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, groundMask); //Use to check whether player is on ground or not!

        if (isGrounded && velocity.y < 0)   //If player is on ground then stop applying gravity
        {
            velocity.y = -2f;
        }
        float moveZ = Input.GetAxis("Vertical");
        float moveX = Input.GetAxis("Horizontal");

        moveDirection = new Vector3(moveX, 0, moveZ);
        moveDirection = transform.TransformDirection(moveDirection); //Fix out the issue of global axis


        if (isGrounded) //If player is ground then apply idle ,walk, and run
        {
            if (moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
            {
                //Walk State
                Walk();
            }

            else if (moveDirection != Vector3.zero && Input.GetKey(KeyCode.LeftShift))
            {
                //Run State
                Run();
            }

            else if (moveDirection == Vector3.zero)
            {
                //Idle State
                Idle();
            }

            moveDirection *= moveSpeed;        //Customizing the moving speed of the player

            if (!isJumping && jumpPressed)
            {
                //Jump state
                //jump();
                animator.SetBool(jumpHash, true);
            }

            else if (isJumping && !jumpPressed)
            {
                animator.SetBool(jumpHash, false);
            }

            if (!isCrouch && crouchPressed)
            {
                animator.SetBool(crouchHash, true);
            }
            else if (isCrouch && crouchPressed)
            {
                animator.SetBool(crouchHash, false);
            }
            
            else if (isCrouch && moveDirection != Vector3.zero && !isCrouchWalk)
            {
                animator.SetBool(crouchWalkhash, true);
            }

            else if (isCrouch && moveDirection == Vector3.zero && isCrouchWalk)
            {
                animator.SetBool(crouchWalkhash, false);
            }

        }
       
        
        //------------------------------------------------------------------------------------
        //Gravity Portion

        controller.Move(moveDirection * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime; //calculating the gravity 
        controller.Move(velocity*Time.deltaTime); //Applying gravity
        //-------------------------------------------------------------------------------------
    }

    private void Idle() 
    {
        animator.SetFloat("speed", 0, 0.1f, Time.deltaTime); //Damp time & Time.deltaTime will make the animation smooth
    }

    private void Walk()
    {
        moveSpeed = walkSpeed;
        animator.SetFloat("speed", 0.5f, 0.1f, Time.deltaTime);
    }

    private void Run()
    {
        moveSpeed = runSpeed;
        animator.SetFloat("speed", 1, 0.1f, Time.deltaTime);
    }

    

    private IEnumerator Attack() 
    {
        animator.SetLayerWeight(animator.GetLayerIndex("Attack Layer"), 1);
        animator.SetTrigger("Attack");
        
        yield return new WaitForSeconds(0.5f);  //Adding wait between the animation
        animator.SetLayerWeight(animator.GetLayerIndex("Attack Layer"), 0);
    }

    private void jump()
    {
        /*
        //Jump equation
        velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        animator.SetTrigger("isJumping");
        animator.SetBool(jumpHash, true);
        */
    }

}

