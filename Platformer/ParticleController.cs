using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    [Header("Movement Particle")]
    [SerializeField] ParticleSystem movementParticle;

    [Range(0,10)]
    [SerializeField] int occurAfterVelocity;

    [Range(0, 0.2f)]
    [SerializeField] float dustFormationPeriod;

    [SerializeField] Rigidbody2D playerRB;

    float counter;
    bool isOnGround;

    [Header("Fall and Touch Particles")]
    [SerializeField] ParticleSystem FallParticle;
    [SerializeField] ParticleSystem TouchParticle;

    private void Start()
    {
        TouchParticle.transform.parent = null;
    }

    private void Update()
    {
        counter += Time.deltaTime;

        if(isOnGround && Mathf.Abs(playerRB.velocity.x) > occurAfterVelocity)
        {
            if(counter > dustFormationPeriod)
            {
                movementParticle.Play();
                counter = 0;
            }
        }
    }

    public void PlayTouchParticle(Vector2 pos)
    {
        TouchParticle.transform.position = pos;
        TouchParticle.Play();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            FallParticle.Play();
            isOnGround = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Ground"))
        {
            isOnGround = false;
        }
    }
}
