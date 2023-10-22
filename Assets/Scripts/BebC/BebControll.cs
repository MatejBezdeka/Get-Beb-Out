using System;
using System.Collections;
using System.Collections.Generic;
using Beb;
using Beb.States;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;
using MouseButton = UnityEngine.UIElements.MouseButton;

[RequireComponent(typeof(NavMeshAgent))]
public class BebControll : MonoBehaviour {
    [SerializeField, Range(1, 10)] public float followStartDistance = 5;
    [SerializeField, Range(0.1f, 25)] public float mineTime = 5;
    [SerializeField, Range(0.1f, 5f)] public float speed = 2.5f;
    [SerializeField] private Camera mainCam;
    public Animator animator;
    public NavMeshAgent agent;
    BebStatesController states;
    private RaycastHit hit;
    private int next;
    private void Start() {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        states = new IdleBeb(this, GameManager.manager.Player);
    }

    public Texture2D MineCursor;
    public Texture2D DefaultCursor;

    public float carryCapacity;
    public float crystalCount;
    public float maxBebHealth;
    public float currentBebHealth;
    public float bebSpeed;    //nasobitel movement speedu
    public float miningSpeed; //nasobitel mining speedu


    private void Update() {
        //Debug.Log(agent.isStopped);
        if (agent.isStopped)
        {
            animator.SetBool("isWalking", false);
        }
        else
        {
            animator.SetBool("isWalking", true);
        }
        hit = CursorRaycastHit();
        next = 0;
        agent.angularSpeed = 999;
        agent.acceleration = 999;
        agent.autoBraking = true;
        if (hit.transform) {
            switch (hit.transform.tag) {

                case "Floor":
                    next = 1;
                    //go to
                    break;
                case "Player":
                    next = 2;
                    //follow
                    break;
                case "Crystal":
                    next = 3;
                    Debug.Log("crystal");
                    Cursor.SetCursor(MineCursor, Vector2.zero, CursorMode.Auto);
                    break;
                case "Portal":
                    Debug.Log("po");

                    next = 4;
                    break;
                case "Stone":
                    Debug.Log("stone");

                    next = 5;
                    break;
                default:
                    Cursor.SetCursor(DefaultCursor, Vector2.zero, CursorMode.Auto);
                    break;
            }
            if (Input.GetMouseButtonDown(1)) {
                switch (next) {
                    case 1:
                        states.ChangeState(new GoTo(this, GameManager.manager.Player, hit.point));
                        break;
                    case 2:
                        states.ChangeState(new FollowState(this, GameManager.manager.Player));
                        break;
                    case 3:
                        states.ChangeState(new MineState(this, GameManager.manager.Player, hit.point,hit.transform.gameObject));
                        break;
                    case 4:
                        Debug.Log("portal");
                        states.ChangeState(new ShopState(this, GameManager.manager.Player, hit.point));
                        break;
                    case 5:
                        states.ChangeState(new StoneState(this, GameManager.manager.Player, hit.point, hit.transform.gameObject));
                        break;
                }
            }
        }
        states = states.Process();
    }

    RaycastHit CursorRaycastHit() {
        Physics.Raycast(mainCam.ScreenPointToRay(Input.mousePosition), out RaycastHit hit,  1000);
        return hit;
    }
}

