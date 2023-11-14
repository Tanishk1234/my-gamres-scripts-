using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class MovingPlatform : MonoBehaviour
{
    [Header("Speed")]
    public float speed;
    Vector3 targetPos;

    MovementController movementController;
    Rigidbody2D rb;
    Vector3 moveDirection;

    Rigidbody2D playerRB;

    public GameObject Ways;
    public Transform[] wayPoints;
    int pointIndex;
    int pointCount;
    int Direction = 1;

    [Header("Delay")]
    public float waitDuration;

    private void Awake()
    {
        movementController = GameObject.FindGameObjectWithTag("Player").GetComponent<MovementController>();
        rb = GetComponent<Rigidbody2D>();
        playerRB = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();


        wayPoints = new Transform[Ways.transform.childCount];
        for (int i = 0; i < Ways.gameObject.transform.childCount; i++)
        {
            wayPoints[i] = Ways.transform.GetChild(i).gameObject.transform;
        }
    }

    private void Start()
    {
        pointIndex = 1;
        pointCount = wayPoints.Length;
        targetPos = wayPoints[1].transform.position;
        DirectionCalculate();
    }

    private void Update()
    {
       if(Vector2.Distance(transform.position , targetPos) < 0.05f)
        {
            NextPoint();
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = moveDirection * speed;
    }

    void NextPoint()
    {
        transform.position = targetPos;
        moveDirection = Vector3.zero;
        if (pointIndex == pointCount - 1)  // arrived last point 
        {
            Direction = -1;
        }

        if(pointIndex == 0) // Arrived first point
        {
            Direction = 1;
        }

        pointIndex += Direction;
        targetPos = wayPoints[pointIndex].transform.position;
        StartCoroutine(WaitforNextPoint());

    }

    IEnumerator WaitforNextPoint()
    {
        yield return new WaitForSeconds(waitDuration);
        DirectionCalculate();
    }

    void DirectionCalculate()
    {
        moveDirection = (targetPos - transform.position).normalized;
    }    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            movementController.isOnPlatform = true;
            movementController.platformRB = rb;
            playerRB.gravityScale = playerRB.gravityScale * 50;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            movementController.isOnPlatform = false;
            playerRB.gravityScale = playerRB.gravityScale / 50;
        }
    }

}

