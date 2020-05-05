using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUp : MonoBehaviour
{
    public PlayerController player;

    public GameObject gem;
    // Start is called before the first frame update
    void Start()
    {
        gem = transform.GetChild(0).gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("gem trigger");
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("gem trigger with player");
            //add gem to the players inventory
            if(gem.name == "redKEY")
            {
                player.isHoldingRedGem = true;
            }
            else if(gem.name == "blueKEY")
            {
                player.isHoldingBlueGem = true;
            }
            //disable the gem
            gameObject.SetActive(false);
        }
    }
}
