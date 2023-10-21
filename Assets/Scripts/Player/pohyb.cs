//Jan Kopejtko, 2022

using Unity.VisualScripting;
using UnityEngine;

public class pohyb : MonoBehaviour
{
    private CharacterController characterController;
    [SerializeField] private Animator animator;
    public Rigidbody rb;

    [SerializeField] private float movementSpeed, rotationSpeed, gravity;
    private Vector3 movementDirection = Vector3.zero;
    private bool playerGrounded;
    private Vector3 inputMovement = Vector3.zero;

    //sounds
    public AudioSource runningSound;
    public AudioSource fallingScream;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        //runningSound.Play();

    }
    void Update()
    {
        playerGrounded = characterController.isGrounded;
        //movement
        if (playerGrounded)
        {
            inputMovement = transform.forward * movementSpeed * Input.GetAxisRaw("Vertical");
        }
        characterController.Move(inputMovement * Time.deltaTime);
        transform.Rotate(Vector3.up * Input.GetAxisRaw("Horizontal") * rotationSpeed);

        //hit
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("isHitting");
        }

        //move one frame
        movementDirection.y -= gravity * Time.deltaTime;
        characterController.Move(movementDirection * Time.deltaTime);

        //animations
        animator.SetBool("isRunning", Input.GetAxisRaw("Vertical") > 0);
        animator.SetBool("isBackRunning", Input.GetAxisRaw("Vertical") < 0);
        animator.SetBool("isIdle", Input.GetAxisRaw("Vertical") == 0);

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