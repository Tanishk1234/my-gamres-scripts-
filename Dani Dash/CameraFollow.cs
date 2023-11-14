using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform[] playersToFollow;
    public Vector3 offset;
    public float smoothSpeed = 0.125f;

    private Vector3 targetPosition;

    void Update()
    {
        if (playersToFollow.Length == 0)
            return;

        targetPosition = CalculateAveragePosition();
        targetPosition += offset;
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);
    }

    Vector3 CalculateAveragePosition()
    {
        Vector3 sum = Vector3.zero;

        foreach (Transform player in playersToFollow)
        {
            sum += player.position;
        }

        return sum / playersToFollow.Length;
    }
}
