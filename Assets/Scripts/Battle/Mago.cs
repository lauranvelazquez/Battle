using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Xml.Schema;
using UnityEngine;
using Object = UnityEngine.Object;

public class Mago : MonoBehaviour
{
    [SerializeField] private KeyCode _electricityKey, _pixelKey, _LightingKey;
    public int  _electricityLimit;

    public ScoreData scoreData;
    
    private States _states = new States();

    private int _damage;

    public static Mago Instance;

    private void Awake()
    {
        Instance = this;
    }

    /* void Update()
    {
        if (Player.IsMagoPlaying)
        {
            //Debug.Log("Choose an Action to Mago");
            
            if (Input.GetKeyDown(_pixelKey))
            {
                _damage = 5;
                StopCoroutine(ChooseVirus());
                StartCoroutine(ChooseVirus());
                _states.Pixeling();
                Debug.Log("pixel");
                BattleMachine.IsPlayerChoosing=false;
                Player.IsMagoPlaying = false;
                BattleMachine.OnPlayerTurn = false;
            }
            else if (Input.GetKeyDown(_electricityKey) && _electricityLimit > 0)
            {
                _damage = 10;
                StopCoroutine(ChooseVirus());
                StartCoroutine(ChooseVirus());
                _states.Electricity();
                Debug.Log("Electricity");
                BattleMachine.IsPlayerChoosing=false;
                Player.IsMagoPlaying = false;
                BattleMachine.OnPlayerTurn = false;
                _electricityLimit--;
            }
            else if (Input.GetKeyDown(_LightingKey)&&scoreData.shootingPoints==100)
            {
                _damage = 15;
                StopCoroutine(ChooseVirus());
                StartCoroutine(ChooseVirus());
                _states.Light();
                Debug.Log("Light");
                BattleMachine.IsPlayerChoosing=false;
                Player.IsMagoPlaying = false;
                BattleMachine.OnPlayerTurn = false;
                scoreData.shootingPoints = 0;
            }
        }
    }
    IEnumerator ChooseVirus()
    {
        float timeCounting=30f;
        Debug.Log("Choose a virus to attack");
        while (timeCounting>0)
        {
            if (Input.GetKeyDown(KeyCode.Keypad1))
            {
                Debug.Log("Attack to Virus 1");
                BattleMachine.lifeBattleVirus1 = BattleMachine.lifeBattleVirus1 - _damage;
                yield return null;
            }
         
            if (Input.GetKeyDown(KeyCode.Keypad2))
            {
                Debug.Log("Attack to Virus 2");
                 BattleMachine.lifeBattleVirus1 = BattleMachine.lifeBattleVirus2 - _damage;
                 yield return null;
            }
            
            timeCounting -= Time.deltaTime;
        }
        
    }*/

   



}
