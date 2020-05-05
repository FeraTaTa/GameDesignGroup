using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class socketGem : MonoBehaviour
{
    public GameObject childGem;
    public PlayerController player;
    public bool isRedStone;
    public bool isBlueStone;
    public gateController gate;

    // Start is called before the first frame update
    void Start()
    {
        foreach(Transform tr in transform)
        {
            Debug.Log(tr.name+" in "+transform.name );
            if(tr.tag == "gem")
            {
                childGem = tr.gameObject;
            }
        }
        if(childGem.name == "redKEY (1)")
        {
            isRedStone = true;
            isBlueStone = false;
        }
        else if(childGem.name == "blueKEY (1)")
        {
            isBlueStone = true;
            isRedStone = false;
        }
        childGem.SetActive(false);
    }

    //// Update is called once per frame
    //void Update()
    //{
        
    //}

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("stone trigger");
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("stone trigger with player");
            if(player.isHoldingBlueGem && isBlueStone)
            {
                //enable the gem
                childGem.SetActive(true);
                //remove gem from inventory
                player.isHoldingBlueGem = false;
                gate.isBlueSocketed = true;
            }
            if (player.isHoldingRedGem && isRedStone)
            {
                //enable the gem
                childGem.SetActive(true);
                //remove gem from inventory
                player.isHoldingRedGem = false;
                gate.isRedSocketed = true;
            }
        }
    }

}
