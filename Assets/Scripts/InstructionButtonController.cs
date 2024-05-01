using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionButtonController : MonoBehaviour
{
    public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void appear() {
        panel.SetActive(true);
    }

    public void hide() {
        panel.SetActive(false);
    }
}
