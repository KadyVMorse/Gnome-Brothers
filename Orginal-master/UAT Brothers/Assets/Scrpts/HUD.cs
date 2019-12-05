using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
  

    public Sprite[] HeartSprites;

    //Image
    public Image HeartUI;
    
    //Player
    private Player player;

    void Start()
    {
        //finds the player tag 
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void Update()
    {
        //represents the current health of the player with the Heart sprite
        HeartUI.sprite = HeartSprites[player.curHealth];
    }
}


