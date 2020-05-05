using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHPContainer : MonoBehaviour
{
    public Sprite heartFullSprite;
    public Sprite heartHalfSprite;
    public Sprite heartEmptySprite;
    public Image heart0;
    public Image heart1;
    public Image heart2;
    public PlayerController player;

    // Update is called once per frame
    void Update()
    {
        //TODO only run this when player is damaged, instead of every frame maybe via 'isUpdateUI' flag?
        switch (player.playerHP)
        {
            case 0:
                heart0.sprite = heartEmptySprite;
                heart1.sprite = heartEmptySprite;
                heart2.sprite = heartEmptySprite;
                break;
            case 1:
                heart0.sprite = heartHalfSprite;
                heart1.sprite = heartEmptySprite;
                heart2.sprite = heartEmptySprite;
                break;
            case 2:
                heart0.sprite = heartFullSprite;
                heart1.sprite = heartEmptySprite;
                heart2.sprite = heartEmptySprite;
                break;
            case 3:
                heart0.sprite = heartFullSprite;
                heart1.sprite = heartHalfSprite;
                heart2.sprite = heartEmptySprite;
                break;
            case 4:
                heart0.sprite = heartFullSprite;
                heart1.sprite = heartFullSprite;
                heart2.sprite = heartEmptySprite;
                break;
            case 5:
                heart0.sprite = heartFullSprite;
                heart1.sprite = heartFullSprite;
                heart2.sprite = heartHalfSprite;
                break;
            case 6:
                heart0.sprite = heartFullSprite;
                heart1.sprite = heartFullSprite;
                heart2.sprite = heartFullSprite;
                break;

        }
    }
}
