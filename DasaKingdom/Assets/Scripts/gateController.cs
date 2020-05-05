using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gateController : MonoBehaviour
{
    public GameObject bossGate;
    public bool isBlueSocketed;
    public bool isRedSocketed;
    public Vector3 bossGateOpenPosition;
    public float deltaY;
    // Start is called before the first frame update
    void Start()
    {
        bossGateOpenPosition = bossGate.transform.position;
        bossGateOpenPosition.y += deltaY;
    }

    // Update is called once per frame
    void Update()
    {
        if (isBlueSocketed && isRedSocketed)
        {
            bossGate.transform.position = bossGateOpenPosition;
        }
    }
}
