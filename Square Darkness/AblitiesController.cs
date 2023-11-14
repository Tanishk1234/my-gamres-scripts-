using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.UI;

public class AblitiesController : MonoBehaviour
{
    [Header("Gather Objects")]
    public GameObject Obstacles;
    public GameObject eyes;
    public GameObject PlatformAi;
    public GameObject FallingSquares;
    public GameObject AllThings;

    [Header("Ui Text Objects")]
    public Text CountDownTxt;

   
    [Header("Time Duration")]
    public float ObstaclesdownDuration = 10f; // Set the countdown duration in seconds
    public float eyesCountDown = 10f;
    public float platformAICountDown = 10f;
    public float SquareCountDown = 10f;
    public float AllthingsCountDown;

    [Header("Time Remaininh")]
    private float ObstacletimeRemaining;
    private float eyestimeRemaining;
    private float platformAItimeRemaining;
    private float SquaretimeRemaining;
    private float AllthingsTimeRemaining;

    public void DisableObstacle()
    {
        ObstacletimeRemaining = ObstaclesdownDuration;
        Update();
        Obstacles.SetActive(false);
    }
    public void DisableEyes()
    {
        eyestimeRemaining = eyesCountDown;
        Update();
        Obstacles.SetActive(false);
    }
    public void DisableSquares()
    {
        SquaretimeRemaining = SquareCountDown;

        Update();
        Obstacles.SetActive(false);
    }
    public void DistroyEyes()
    {

    }
    public void DisablePlatformAi()
    {
        platformAItimeRemaining = platformAICountDown;
        Update();
        PlatformAi.SetActive(false);
    }
    public void DisableAllThings()
    {
        AllthingsTimeRemaining = AllthingsCountDown;
        Update();
        AllThings.SetActive(false);
    }


    public void Update()
    {
        ObstacletimeRemaining -= Time.deltaTime;
        eyestimeRemaining -= Time.deltaTime;
        platformAItimeRemaining -= Time.deltaTime;
        SquaretimeRemaining -= Time.deltaTime;
        AllthingsTimeRemaining -= Time.deltaTime;
        //CountDownTxt.text = "Time Remaining: " + timeRemaining.ToString("F1");

        if (ObstacletimeRemaining <= 0)
        {
            // Deactivate the object
            Obstacles.SetActive(true);
        }


        if (eyestimeRemaining <= 0)
        {
            // Deactivate the object

            eyes.SetActive(true);
        }

        if (platformAItimeRemaining <= 0)
        {
            // Deactivate the object
            PlatformAi.SetActive(true);
        }

        if (SquaretimeRemaining <= 0)
        {
            // Deactivate the object
            FallingSquares.SetActive(true);
        }

        if (AllthingsTimeRemaining <= 0)
        {
            // Deactivate the object
            AllThings.SetActive(true);
        }

    }
}
