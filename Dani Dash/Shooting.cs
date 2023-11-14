using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject playerBullet;
    public Transform GunPoint;
    private void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Instantiate(playerBullet, GunPoint.position, Quaternion.identity);
        }
    }
}