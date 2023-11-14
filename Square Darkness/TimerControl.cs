using UnityEngine;
using UnityEngine.UI;

public class TimerControl : MonoBehaviour
{
    public float countdownTime = 10.0f;
    public GameObject objectToControl;
    public Text countdownText;

    private float timeRemaining;
    private bool isActivated = false;

    void Start()
    {
    }

    void Update()
    {
        if (isActivated)
        {
            return;
        }

        timeRemaining -= Time.deltaTime;
        countdownText.text = "Time Remaining: " + timeRemaining.ToString("F1");

        if (timeRemaining <= 0)
        {
            ActivateObject();
        }
    }

    public void ActivateObject()
    {
        timeRemaining = countdownTime;
        countdownText.text = "Time Remaining: " + timeRemaining.ToString("F1");
        objectToControl.SetActive(true);
        isActivated = true;
        countdownText.text = "Object Activated!";
    }
}