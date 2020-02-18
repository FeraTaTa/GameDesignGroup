using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tweenTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.DOMove(new Vector3(20, 2.2f, 20), 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
