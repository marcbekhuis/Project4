using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;

    [Range(0, 1)] public float smoothSpeed;

    float timer;

    void Start()
    {
        // set offset
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // set desired position
        Vector3 desiredPosition = player.transform.position + offset;
        // smoothly moves the camera to player location
        Vector3 smoothPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothPosition;
        timer = 0;
    }
}
