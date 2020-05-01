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

    public float startButtonYPos;
    public float optionsButtonYPos;
    public float quitButtonYPos;

    Vector3 focusStartVector;
    Vector3 focusOptionsVector;
    Vector3 focusQuitVector;

    // Start is called before the first frame update
    void Start()
    {
        //get the pointer
        pointer = GetComponentInChildren<Flashing>().gameObject;
        pointerYPosition = pointer.transform.localPosition.y;
        //get the buttons and their y positions
        //listButtons = GetComponentsInChildren<Button>();
        //startButton = listButtons[0].gameObject;
        //optionsButton = listButtons[1].gameObject;
        //quitButton = listButtons[2].gameObject;

        startButtonYPos = startButton.transform.localPosition.y;
        optionsButtonYPos = optionsButton.transform.localPosition.y;
        quitButtonYPos = quitButton.transform.localPosition.y;

        focusStartVector = new Vector3(pointer.transform.localPosition.x,
                                        startButton.transform.localPosition.y,
                                        pointer.transform.localPosition.z);
        focusOptionsVector = new Vector3(pointer.transform.localPosition.x,
                                        optionsButton.transform.localPosition.y,
                                        pointer.transform.localPosition.z);
        focusQuitVector = new Vector3(pointer.transform.localPosition.x,
                                        quitButton.transform.localPosition.y,
                                        pointer.transform.localPosition.z);

        //startButtonYPos = listButtons[0].transform.localPosition.y;
        //optionsButtonYPos = listButtons[1].transform.localPosition.y;
        //quitButtonYPos = listButtons[2].transform.localPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        //detect if the button has focus
        //TODO mouse or joypad
        //change the pointer y position to the y position of the focussed button
        //pointerYPosition = quitButtonYPos;
        //pointerYPosition = pointer.transform.localPosition.y;
        //pointer.transform.localPosition = new Vector3(pointer.transform.localPosition.x, 50, pointer.transform.localPosition.z);
        pointer.transform.localPosition = focusStartVector;
    }
}
