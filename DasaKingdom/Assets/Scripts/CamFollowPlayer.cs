using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollowPlayer : MonoBehaviour
{
    public Transform target;
    public Vector3 distance;

    void Update()
    {
        transform.position = new Vector3(
            target.position.x - distance.x, 
            target.position.y - distance.y, 
            target.position.z - distance.z);
    }
}
