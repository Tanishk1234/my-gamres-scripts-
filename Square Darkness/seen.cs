using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class seen : MonoBehaviour
{
    Vector2 checkPos;
    Rigidbody2D playerRB;

    public ParticleSystem DieParticle;
    private void Awake()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        checkPos = transform.position;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            Die();
            DieParticle.Play();
        }
    }

 

    void Die()
    {
        StartCoroutine(Respawn(0.5f));
    }

    public void UpdateCheckPoint(Vector2 pos)
    {
        checkPos = pos;
    }

    IEnumerator Respawn(float Duration)
    {
        playerRB.simulated = false;
        playerRB.velocity = new Vector2(0, 0);
        transform.localScale = new Vector3(0, 0, 0);
        yield return new WaitForSeconds(Duration);
        transform.position = checkPos;
        transform.localScale = new Vector3(1, 1, 1);
        playerRB.simulated = true;
    }

}
