//Jan Kopejtko, 2022

using Unity.VisualScripting;
using UnityEngine;

public class pohyb : MonoBehaviour
{
    private CharacterController characterController;
    [SerializeField] private Animator animator;
    public Rigidbody rb;

    [SerializeField] private float movementSpeed, rotationSpeed, gravity;
    [SerializeField] private GameObject model;
    [SerializeField] private Collider HitArea;
    private Vector3 movementDirection = Vector3.zero;

    private bool playerGrounded;
    private Vector3 inputMovement = Vector3.zero;

    //sounds
    public AudioSource runningSound;
    public AudioSource fallingScream;
    
    float vertical;
    float horizontal;

    private Vector3 lastMovementDirection = Vector3.forward;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        playerGrounded = characterController.isGrounded;

        float vertical = Input.GetAxisRaw("Vertical");
        float horizontal = Input.GetAxisRaw("Horizontal");

        // Calculate the movement vector based on input
        inputMovement = transform.forward * (movementSpeed * vertical);
        inputMovement += transform.right * (movementSpeed * horizontal);
        model.transform.rotation = Quaternion.LookRotation(inputMovement);


        // If there is input, set the last movement direction
        if (inputMovement != Vector3.zero)
        {
            lastMovementDirection = inputMovement.normalized;
        }

        // Rotate the model to face the last movement direction
        model.transform.rotation = Quaternion.LookRotation(lastMovementDirection);

        // Move the character using the CharacterController
        characterController.Move(inputMovement * Time.deltaTime);

        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("isHitting");
        }

        movementDirection.y -= gravity * Time.deltaTime;
        characterController.Move(movementDirection * Time.deltaTime);

        animator.SetBool("isRunning", vertical != 0 || horizontal != 0);
        animator.SetBool("isIdle", vertical == 0 && horizontal == 0);

    }
    //sound
    //if (!animator.GetBool("isRunning") && runningSound.isPlaying == true)
    //{
    //    runningSound.Stop();
    //}
    //else if (animator.GetBool("isRunning") && runningSound.isPlaying == false)
    //{
    //    runningSound.Play();
    //}

    //player died
    //if ((int)rb.position.y == -15f)
    //{
    //    if (!fallingScream.isPlaying)
    //    {
    //        //fallingScream.Play();
    //    }
    //}
    //if (rb.position.y <= -15f)
    //{
    //    if (!fallingScream.isPlaying)
    //    {
    //        FindObjectOfType<event_manager>().EndGame();
    //    }
    //}
}
//todo comment code