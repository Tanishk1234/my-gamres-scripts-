using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    Vector2 startPos;
    Rigidbody2D playerRB;

    public ParticleSystem DieParticle;
    private void Awake()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        startPos = transform.position;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Obstacle"))
        {
            Die();
            DieParticle.Play();
        }
    }

    void Die()
    {
        StartCoroutine(Respawn(0.5f));
    }

    IEnumerator Respawn(float Duration)
    {
        playerRB.simulated = false;
        playerRB.velocity = new Vector2(0, 0);
        transform.localScale = new Vector3(0, 0, 0);
        yield return new WaitForSeconds(Duration);
        transform.position = startPos;
        transform.localScale = new Vector3(1, 1, 1);
        playerRB.simulated = true;
    }

}
