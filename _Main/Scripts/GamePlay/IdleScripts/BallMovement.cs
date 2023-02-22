using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public int index;
    public Transform followedCube;
    Vector3 velocity = Vector3.zero;

    private void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, new Vector3(followedCube.position.x, transform.position.y, followedCube.position.z), ref velocity, index * 3 * Time.fixedDeltaTime);
    }
}