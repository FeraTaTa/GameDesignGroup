using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flashing : MonoBehaviour
{
    public float offTime = 2;
    public float onTime = 2;
    Image pointerMat;

    // Start is called before the first frame update
    void Start()
    {
        pointerMat = GetComponent<Image>();
        Color solidc = new Color(1.0f, 1.0f, 1.0f, 0.0f);
        float solid = 1;
        float clear = 0;

        Sequence mySequence = DOTween.Sequence();
        mySequence.SetLoops(-1, LoopType.Restart);
        mySequence.Append(pointerMat.DOFade(solid, onTime));
        mySequence.Append(pointerMat.DOFade(clear, offTime));
        
    }
}
