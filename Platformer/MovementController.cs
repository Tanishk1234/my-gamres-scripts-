using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementController : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField] int speed;
    float speedMultiplier;

    [Range(0f, 10f)]
    [SerializeField] float acceleration;

    bool isWallTouch;
    public LayerMask wallLayer;
    public Transform wallCheckPoint;

    Vector2 relativeTransform;

    public bool isOnPlatform;
    public Rigidbody2D platformRB;

    public ParticleController particleController;

    bool btnPressed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();  
    }
    private void Start()
    {
        UpdateRelativeTransform();
    }

    private void FixedUpdate()
    {
        UpdateSpeedMultiplier();
        float targetSpeed = speed * speedMultiplier * relativeTransform.x;

        if(isOnPlatform)
        {
            rb.velocity = new Vector2(targetSpeed+platformRB.velocity.x , rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(targetSpeed, rb.velocity.y);
        }
    }

    void UpdateRelativeTransform()
    {
        relativeTransform = transform.InverseTransformVector(Vector2.one);
    }
   
    public void Flip()
    {
        particleController.PlayTouchParticle(wallCheckPoint.position);
        transform.Rotate(0, 180, 0);
        UpdateRelativeTransform();
    }
    public void Move(InputAction.CallbackContext value)
    {
        if (value.started)
        {
            btnPressed = true;
            speedMultiplier = 1;
        }
        else if (value.canceled)
        {
            btnPressed = false;
            speedMultiplier = 0;
        }
        isWallTouch = Physics2D.OverlapBox(wallCheckPoint.position, new Vector2(0.05f, 0.6f), 0, wallLayer);

        if (isWallTouch)
        {
            Flip();
        }
    }

    void UpdateSpeedMultiplier()
    {
        if(btnPressed && speedMultiplier < 1)
        {
            speedMultiplier += Time.deltaTime * acceleration;
        }
        else if(!btnPressed && speedMultiplier > 0)
        {
            speedMultiplier -= Time.deltaTime;
            if (speedMultiplier < 0) speedMultiplier = 0 * acceleration;
        }
    }
}
