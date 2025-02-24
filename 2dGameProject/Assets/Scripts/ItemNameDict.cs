using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;
public class ItemNameDict : MonoBehaviour
{
    public string itemName;
    public int itemIndex;
    public CharacterMovement myPlayer;
    public DialogueManager dialogueManager;
    public int powerCount = 0;

    private bool hasKey = false;


    // Start is called before the first frame update
    void Start()
    {
        myPlayer = FindObjectOfType<CharacterMovement>();
        dialogueManager = FindObjectOfType<DialogueManager>();
    }
    // Update is called once per frame
    void Update()
    {
    }
    public void CollectPower()
    {
        powerCount++;

        Debug.Log("Power Collected! Current Power Count: " + powerCount);
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            Interact();
            AddItem(itemName);
            Destroy(gameObject);
        }
        AddItem(itemName);
        Destroy(gameObject);
    }
    public void AddItem(string itemName)
    {
        if (myPlayer.myInventory.ContainsKey(itemName))
        {
            myPlayer.myInventory[itemName]++;
        }
        else
        {
            myPlayer.myInventory.Add(itemName, 1);
        }
        if (itemName == "key")
        {
            hasKey = true;
        }
        myPlayer.DisplayInventory();
    }
    public int GetPowerCount()
    {
        return powerCount;
    }
    public bool HasKey()
    {
        return hasKey;
    }
    public void Interact()
    { 
    dialogueManager.currentIndex = itemIndex;
    }

    private void OnCollisionEnter2D(Collision2D collision)
 
    {
    if (collision.gameObject.tag =="Power")
    {powerCount++;
    Destroy(collision.gameObject);
    }
    }
}