using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform player;
    public float smoothing = 5f;
    public Vector3 offset;
    public Vector3 angleOffset;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }


    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, player.position + offset, smoothing * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(player.eulerAngles + angleOffset), Time.deltaTime * 5);

    }
}
