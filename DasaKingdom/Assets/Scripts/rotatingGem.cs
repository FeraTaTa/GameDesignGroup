using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatingGem : MonoBehaviour
{
    public float rotateSpeed;
    Vector3 rotationVector = new Vector3(0, 0, 0);
    // Start is called before the first frame update
    void Start()
    {
        rotateSpeed = 35;
    }

    // Update is called once per frame
    void Update()
    {
        rotationVector.y += rotateSpeed * Time.deltaTime;
        gameObject.transform.localEulerAngles = rotationVector;
    }
}
