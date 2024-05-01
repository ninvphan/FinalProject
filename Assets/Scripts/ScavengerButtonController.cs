using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.UI;

public class ScavengerButtonController : MonoBehaviour
{
    public GameObject[] virtualButtons;
    public GameObject[] sections;
    // Start is called before the first frame update
    void Start()
    {
        foreach(var section in sections) {
            section.SetActive(false);
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
                for (int i = 0; i < sections.Length; i++) {
                    if (i == pressedButtonIndex) {
                        sections[i].SetActive(true);
                    }
                    else {
                        sections[i].SetActive(false);
                    }
                }
            }
            
        }
        else {
            foreach (var section in sections) {
                section.SetActive(false);
            }
        }
    }
}
