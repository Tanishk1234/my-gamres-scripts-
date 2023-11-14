using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.WSA;

public class GameManager : MonoBehaviour
{
    [Header("Players")]
    public GameObject whitePlayer;
    public GameObject blackPlayer;

    //[Header("UI Objects")]
    //public GameObject DieMenu;
    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("whiteChanger"))
        {
            PlayerActivated();
        }
        else if (collision.CompareTag("Obstacle"))
        {
            Die();
            //DieParticle.Play();
        }
    }

    private void OnTrigerExit2D(Collider2D collision)
    {
       if (collision.CompareTag("whiteChanger"))
        {
            PlayerDeActivated();
        }
    }
    void PlayerActivated()
    {
        whitePlayer.SetActive(true);
        blackPlayer.SetActive(false);

    }

    void  PlayerDeActivated()
    {
        whitePlayer.SetActive(false);
        blackPlayer.SetActive(true);
    }
    void Die()
    {
        Destroy(gameObject);
        //DieMenu.SetActive(true);
    }
}
