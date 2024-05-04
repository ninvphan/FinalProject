using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.UI;

public class ScavengerButtonController : MonoBehaviour
{
    public GameObject[] virtualButtons;
    public GameObject[] sections;
    public GameObject errorMessage;

    private int counterStep = 1;
    // Start is called before the first frame update
    void Start()
    {
        foreach(var section in sections) {
            section.SetActive(false);
            errorMessage.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        bool anyButtonPressed = false;
        int pressedButtonIndex = -1;
        int numPressed = 0;

        for (int i =0; i < virtualButtons.Length; i++) {
            if (virtualButtons[i].GetComponent<VirtualButtonBehaviour>().Pressed) {
                anyButtonPressed = true;
                pressedButtonIndex = i;
                numPressed++;
            }
        }

        if(anyButtonPressed) {
            if (numPressed > 1) {
                foreach (var section in sections) {
                    section.SetActive(false);
                } 
            }
            else if (numPressed == 1) {
                if (pressedButtonIndex == (counterStep - 1)) {
                    sections[pressedButtonIndex].SetActive(true);
                }
                else if (pressedButtonIndex == (counterStep)){
                    sections[pressedButtonIndex].SetActive(true);
                    counterStep++;
                }
                else {
                    errorMessage.SetActive(true);
                }
            }
            
        }
        else {
            foreach (var section in sections) {
                section.SetActive(false);
                errorMessage.SetActive(false);
            }
        }
    }
}
