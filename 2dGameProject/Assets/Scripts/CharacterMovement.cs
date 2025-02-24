using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class CharacterMovement : MonoBehaviour
{
    public static CharacterMovement Instance;
    public GameObject player;
    public float speed = 0.5f;
    public Dictionary<string, int> myInventory = new Dictionary<string, int>();
    public TextMeshProUGUI inventoryDisplay;
    public int powerCount = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject); //don't destroy the player when a new scene loads
            Instance = this; //set this specific player object as the Instance
        }
        else
        {
            Destroy(gameObject); //if there is already a player assigned as the Instance, delete any other players so we only have one
        }
    }
    void Start()
    {
        //add any items you can possibly obtain in the game, with quantity at zero if you do not start with this item in your inventory
        myInventory.Add("life", 1);
        DisplayInventory();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            //find the player game object, find that object's transform and position, increase the Y value by adding Vector3.up, multiplied by speed to determine rate of increase
            player.transform.position += Vector3.up * speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            player.transform.position += Vector3.down * speed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            player.transform.position += Vector3.left * speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            player.transform.position += Vector3.right * speed;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //when colliding with a game object tagged as "enemy", destroy the player
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Power")
        {
            powerCount++;
            Destroy(collision.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        //when entering a trigger destroy the player
        if (other.tag == "Death")
        {
            Destroy(gameObject);
        }
    }
    public void DisplayInventory()
    {
        inventoryDisplay.text = "Inventory\n\n";
        foreach (var item in myInventory)
        {
            inventoryDisplay.text += "Item: " + item.Key + ", Quantity: " + item.Value + "\n";
        }
    }
}