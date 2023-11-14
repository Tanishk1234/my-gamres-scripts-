using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    seen Seen;
    public Transform respawnPoint;

    SpriteRenderer spriteRenderer;
    public Sprite pasive, active;
    private void Awake()
    {
        Seen = GameObject.FindGameObjectWithTag("Player").GetComponent<seen>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Seen.UpdateCheckPoint(respawnPoint.position);
            spriteRenderer.sprite = active;
        }
    }
}
