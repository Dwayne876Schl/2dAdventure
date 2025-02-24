using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class KeyBehaviour : MonoBehaviour
{
    public ItemNameDict myPlayer;
    public CharacterMovement playerMov;

    private void Start()
    {
        myPlayer = FindObjectOfType<ItemNameDict>();
        playerMov = FindObjectOfType<CharacterMovement>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (playerMov.powerCount >= 3 && collision.gameObject.tag =="Key")
        {
                    myPlayer.AddItem("key");
                    Destroy(gameObject);
        }
                else
                {
                    Debug.Log("Not enough power to collect the key!");
                }
    }
}
