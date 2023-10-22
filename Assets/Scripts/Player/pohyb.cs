//Jan Kopejtko, 2022

using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class pohyb : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private float movementSpeed, rotationSpeed, gravity;
    [SerializeField] private GameObject model;
    [SerializeField] private Collider hitArea;

    private Vector3 movementDirection = Vector3.zero;
    private Vector3 lastMovementDirection = Vector3.forward;
    private Vector3 inputMovement = Vector3.zero;

    private bool playerGrounded;
    public Rigidbody rb;
    private CharacterController characterController;
    private List<GameObject> enemiesInHitArea;

    //sounds
    public AudioSource runningSound;
    public AudioSource fallingScream;
    
    float vertical;
    float horizontal;
    public float hp;
    public float maxHp;
    public float damage = 50;
    public float damageModifier = 1; // nasobitel dmg
    public float attackSpeedModifier; //nasobitel attack speedu
    private float hpRegen = 5;
    public float hpRegenModifier; //nasobitel regenu
    public float movementSpeedModifier; //nasobitel movement speedu
    private float currentHeal = 0;
    public float stoneCount = 0;
    private float currentAttackCooldown = 0;
    private float attackCooldown = 2;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        enemiesInHitArea = new List<GameObject>();
    }

    void Update()
    {
        Move();
        RegenHealth();
        Attack(); 
    }

    void Attack() {
        currentAttackCooldown += Time.deltaTime;
        if (Input.GetMouseButtonDown(0)) {
            if (currentAttackCooldown >= attackCooldown) {
                animator.SetTrigger("isHitting");
                Invoke("AttackReal", 0.8f);
                currentAttackCooldown = 0;
            }
        }
    }

    void AttackReal() {
        foreach (var gameObj in Physics.OverlapBox(transform.position, new Vector3(1, 1, 1), transform.rotation)) {
            if (gameObj.gameObject.CompareTag("Enemy")) {
                Enemy comp = gameObj.gameObject.GetComponent<Enemy>();
                comp.Hit((int) (damage * damageModifier));

            }
        }
    }

    /*
    void OnCollisionEnter(Collision other) {
        enemiesInHitArea.Add(other.gameObject);
        Debug.Log(other.transform.name);
    }

    private void OnCollisionExit(Collision other) {
        enemiesInHitArea.Remove(other.gameObject);
    }
    */
    void RegenHealth() {
        currentHeal += hpRegen;
        if (hpRegen >= 1) {
            hp += (int) hpRegen;
            hpRegen -= (int) hpRegen;
            if (hp > maxHp) {
                hp = maxHp;
            }
        }
    }
    void Move() {
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