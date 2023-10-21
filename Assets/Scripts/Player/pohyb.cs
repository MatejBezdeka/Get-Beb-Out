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
    private Vector3 movementDirection = Vector3.zero;
    
    private bool playerGrounded;
    private Vector3 inputMovement = Vector3.zero;

    //sounds
    public AudioSource runningSound;
    public AudioSource fallingScream;
    
    float vertical;
    float horizontal;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        //runningSound.Play();

    }
    void Update()
    {
        playerGrounded = characterController.isGrounded;
        vertical = Input.GetAxisRaw("Vertical");
        horizontal = Input.GetAxisRaw("Horizontal");
        //movement
        inputMovement = transform.forward * (movementSpeed * vertical);
        inputMovement += transform.right * (movementSpeed * horizontal);
        model.transform.rotation = Quaternion.LookRotation(inputMovement);
        characterController.Move(inputMovement * Time.deltaTime);
        
        //hit
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("isHitting");
        }

        //move one frame
        movementDirection.y -= gravity * Time.deltaTime;
        characterController.Move(movementDirection * Time.deltaTime);

        //animations
        animator.SetBool("isRunning", vertical != 0 || horizontal != 0); //vertical > 0 || horizontal > 0
        //animator.SetBool("isBackRunning", vertical < 0 || horizontal < 0);
        animator.SetBool("isIdle", vertical == 0 && horizontal == 0);

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
}
//todo comment code