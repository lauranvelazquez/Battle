using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEditorInternal;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class Hacker : MonoBehaviour
{
    private States _states = new States();

    public ScoreData scoreData;

    public int copyLimit=3;

    public int _damage;
    
    public static Hacker Instance;
    
    [SerializeField] private KeyCode bugKey, copyKey, stealKey;
    
    [SerializeField] private KeyCode _electricityKey, _pixelKey, _LightingKey;

    private void Awake()
    {
        Instance = this;
    }

   /* void Update()
    {
        if (Player.IsHackerPlaying)
        {
            //Debug.Log("Select a hacker action");
                    
            if (Input.GetKeyDown(bugKey))
            {
                _damage = 5;
                StopCoroutine(ChooseVirus());
                StartCoroutine(ChooseVirus());
                _states.Bug();
                Debug.Log("OK");
               BattleMachine.IsPlayerChoosing=false;
               BattleMachine.OnPlayerTurn = false;
               Player.IsHackerPlaying = false;
            }
            else if (Input.GetKeyDown(copyKey)&&copyLimit>0)
            {
                _damage = 10;
                _states.Copy();
                Debug.Log("OK");
                StopCoroutine(ChooseVirus());
                StartCoroutine(ChooseVirus());
                BattleMachine.IsPlayerChoosing=false;
                BattleMachine.OnPlayerTurn = false;
                Player.IsHackerPlaying = false;
                copyKey--;
            }
            else if ( Input.GetKeyDown(stealKey))//añadir condicion 
            {
                _damage = 15;
                _states.Steal();
                Debug.Log("OK");
                StopCoroutine(ChooseVirus());
                StartCoroutine(ChooseVirus());
                BattleMachine.IsPlayerChoosing=false;
                BattleMachine.OnPlayerTurn = false;
                Player.IsHackerPlaying = false;
            }
        }
    }
    IEnumerator ChooseVirus()
    {
        //float timeCounting=30f;
        Debug.Log("Choose a virus to attack");
        
        bool wait = true;
        while (wait)
        {
            if (Input.GetKeyDown(KeyCode.Keypad1))
            {
                Debug.Log("Attack to Virus 1");
                BattleMachine.lifeBattleVirus1 = BattleMachine.lifeBattleVirus1 - _damage;
                wait = false;
                yield return null;
            }
                    
            if (Input.GetKeyDown(KeyCode.Keypad2))
            {
                Debug.Log("Attack to Virus 2");
                BattleMachine.lifeBattleVirus1 = BattleMachine.lifeBattleVirus2 - _damage;
                wait = false;
            }

            yield return null;


        }
    }*/
   

    
}
