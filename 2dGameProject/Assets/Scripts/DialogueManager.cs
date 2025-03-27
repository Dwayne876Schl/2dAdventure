using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueDisplay;
    public string[] dialogue = new string[5];
    public int currentIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        dialogueDisplay.text = dialogue[currentIndex];
    }

    // Update is called once per frame
    void Update()
    {
      /*  dialogueDisplay.text = dialogue[currentIndex];
        if (Input.GetKey(KeyCode.Space))
        {
            currentIndex = 0;
        }*/
    }
}
