using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameObject mago, hacker;
    public static bool IsHackerPlaying=false;
    public static bool IsMagoPlaying=false;
    public Text dialogText;
    /*void Update()
    {
        if (BattleMachine.Instance.states==BattleStates.PlayerTurn)
        {

            if (Input.GetKeyDown(KeyCode.H))
            {
                Hacker hackerController = hacker.GetComponent<Hacker>();
                IsHackerPlaying = true;
                dialogText.text = "You selected hacker";
                Debug.Log("You selected hacker");
                BattleMachine.IsPlayerChoosing = false;
                
                return;
            }
                                                            
            else if (Input.GetKeyDown(KeyCode.E))
            {
                Mago magoController = mago.GetComponent<Mago>();
                dialogText.text = "You selected mago";
                Debug.Log("You selected mago");
                IsMagoPlaying = true;
                BattleMachine.IsPlayerChoosing = false;
                return;
            }
        
    }*/
    

    // Update is called once per frame
    
    
}
