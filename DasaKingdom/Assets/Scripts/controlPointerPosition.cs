using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class controlPointerPosition : MonoBehaviour
{
    public GameObject pointer;
    public float pointerYPosition;
    public Button[] listButtons;
    public GameObject startButton;
    public GameObject optionsButton;
    public GameObject quitButton;
    private RectTransform selectedTransform;
    private MainMenu _menu;
    int index = 1;
    // Start is called before the first frame update
    void Start()
    {
        _menu = FindObjectOfType<MainMenu>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && !_menu.isSettingOpen)
        {
            prevSelection();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow)&&!_menu.isSettingOpen)
        {
            nextSelection();
        }
        else if (Input.GetKeyDown(KeyCode.Space)){
            if (index == 0)
            {
                _menu.StartGame();
            }
            if (index == 1)
            {
                if (_menu.isSettingOpen)
                {
                    _menu.CloseSettings();
                }else
                {
                    _menu.OpenSettings();
                }
            }
            if (index == 2)
            {
                _menu.ExitGame();
            }

        }
        //detect if the button has focus
        //TODO mouse or joypad
        //change the pointer y position to the y position of the focussed button
        //pointerYPosition = quitButtonYPos;
        //pointerYPosition = pointer.transform.localPosition.y;
        //pointer.transform.localPosition = new Vector3(pointer.transform.localPosition.x, 50, pointer.transform.localPosition.z);

        if (index == 0)
        {
            selectedTransform = startButton.GetComponent<RectTransform>();
        }
        if (index == 1)
        {
            selectedTransform = optionsButton.GetComponent<RectTransform>();
        }
        if (index == 2)
        {
            selectedTransform = quitButton.GetComponent<RectTransform>();
        }
        pointer.transform.position = new Vector3(pointer.transform.position.x,
                                    selectedTransform.position.y, 0);
        
    }

    private void prevSelection()
    {
        index--;
        if (index < 0)
        {
            index = 0;
        }
    }

    private void nextSelection()
    {
        index++;
        if (index > 2)
        {
            index = 2;
        }
    }
}
