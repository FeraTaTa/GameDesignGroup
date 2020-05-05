using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerInventoryContainer : MonoBehaviour
{
    public PlayerController player;
    public Image redContainer;
    public Image blueContainer;

    private Color normal = new Color(1,1,1);
    private Color greyed;
    private float brightness = 0.15f;
    // Start is called before the first frame update
    void Start()
    {
        greyed = new Color(brightness, brightness, brightness);
    }

    // Update is called once per frame
    void Update()
    {
        //display normal colours if player had the gem otherwise darken the colour
        if (player.isHoldingBlueGem)
        {
            blueContainer.color = normal;
        }
        else
        {
            blueContainer.color = greyed;
        }
        //display normal colours if player had the gem otherwise darken the colour
        if (player.isHoldingRedGem)
        {
            redContainer.color = normal;
        }
        else
        {
            redContainer.color = greyed;
        }
    }
}
