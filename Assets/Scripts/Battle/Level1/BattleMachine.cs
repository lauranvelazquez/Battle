using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

public enum BattleStates{Start, PlayerSelection, SkillSelection, EnemySelection,  Enemyturn, EnemySelect, EnemySelectPlayer, Won, Lost }
//start=comienza la batalla
//player selection= para elegir con cual atacar
//skillselection= para elegir ataque 
//enemyselection= para elegir virus a atacar 
//enemy tur= virus elije ccn cual atacar 
//enemy select= Virus elije ataque 
//enemy select player = elije a que jugador atacar 
public class BattleMachine : MonoBehaviour
{
    public GameObject mago, hacker, virus1, virus2;

    private Player _player;
    public static BattleMachine Instance;

    public static bool OnPlayerTurn = true;

    public BattleStates states;
     
    private bool _battle = true;
    
    public ScoreData scoreData;

    private Virus1 _virus1System;
    private Hacker _hackerSystem;
    private Mago _magoSystem;
    
    public Text dialogText;
    
    private int _scoreBattleEnemy = 100;
    private int _damage;

    public static bool IsPlayerChoosing=false;
    public static bool IsEnemyChoosing=false;

    public GameObject collisionZone2;
    private StartLevel2 _startLevel2;

    private CharacterController1 _characterController1;
    public static int lifeBattleVirus1=100;
    public static int lifeBattleVirus2=100;

    public bool isEnemySelected;
    public bool virus1Choosed=false;
    public bool virus2Choosed=false;
    private int c=2;
    [SerializeField] private KeyCode bugKey, copyKey, stealKey;
    [SerializeField] private KeyCode _electricityKey, _pixelKey, _LightingKey;
    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        _characterController1 = GetComponent<CharacterController1>();
        states = BattleStates.Start; 
        _startLevel2 = collisionZone2.GetComponent<StartLevel2>();
        StartCoroutine(SetUpBattle());
        
    }

    void Update() 
    {
        switch (states)
        {
            case BattleStates.Start:
                break;
            case BattleStates.PlayerSelection:
                Debug.Log("Select Hacker o E");

                if (Input.GetKeyDown(KeyCode.H))
                {
                    Player.IsHackerPlaying = true;
                    dialogText.text = "You selected hacker";
                    states = BattleStates.EnemySelection;

                }
                else if (Input.GetKeyDown(KeyCode.E))
                {
                    dialogText.text = "You selected mago";
                    Player.IsMagoPlaying = true;
                    states = BattleStates.EnemySelection;
                }
                
                break;
            case BattleStates.SkillSelection:
                Debug.Log("Select an action");
                if (Player.IsMagoPlaying)
                {
                    if (Input.GetKeyDown(_pixelKey))
                    {
                        _damage = 5;
                        // _states.Pixeling();
                        Debug.Log("pixel");
                        Player.IsMagoPlaying = false;
                        RestScore();
                        states = BattleStates.Enemyturn;
                    }
                    else if (Input.GetKeyDown(_electricityKey) && Mago.Instance._electricityLimit > 0)
                    {
                        _damage = 10;
                        //_states.Electricity();
                        Debug.Log("Electricity");
                        Player.IsMagoPlaying = false;
                        Mago.Instance._electricityLimit--;
                        RestScore();
                        states = BattleStates.Enemyturn;
                    }
                    else if (Input.GetKeyDown(_LightingKey)&&scoreData.shootingPoints==100)
                    {
                        _damage = 15;
                        //_states.Light();
                        Debug.Log("Light");
                        Player.IsMagoPlaying = false;
                        RestScore();
                        states = BattleStates.Enemyturn;
                        scoreData.shootingPoints = 0;
                    }
                    if (lifeBattleVirus1<=0 & lifeBattleVirus2<=0)
                    {
                        states = BattleStates.Won;
                    }
                }
                else if (Player.IsHackerPlaying)
                {
                    if (Input.GetKeyDown(bugKey))
                    {
                        _damage = 5;
                        Debug.Log("1");
                        states = BattleStates.Enemyturn;

                    }
                    else if (Input.GetKeyDown(copyKey))
                    {
                        _damage = 10;
                        Debug.Log("2");
                        Hacker.Instance._damage = 10;
                        states = BattleStates.Enemyturn;
                    }
                    else if ( Input.GetKeyDown(stealKey))//añadir condicion 
                    {
                        _damage = 15;
                        Debug.Log("3");
                        states = BattleStates.Enemyturn;
                    }
                }
                break;
            case BattleStates.EnemySelection:
                Debug.Log("Select an anemy to attack");
               if (Input.GetKeyDown(KeyCode.Keypad1))
                {
                    Debug.Log("Attack to Virus 1");
                    virus1Choosed = true;
                    states = BattleStates.SkillSelection;
                }
                    
                else if (Input.GetKeyDown(KeyCode.Keypad2))
                {
                    Debug.Log("Attack to Virus 2");
                    virus2Choosed = true;
                    states = BattleStates.SkillSelection;
                }
                if (lifeBattleVirus1<=0 & lifeBattleVirus2<=0)
                {
                    states = BattleStates.Won;
                    EndBattle();
                }
                break;
            
            case BattleStates.Enemyturn:
                
                dialogText.text = "Enemy Turn";
                
                if (c % 2 == 0)
                {
                    Debug.Log("Enemy 1 Selected");
                    dialogText.text = "Virus 1 Attacking!";
                    Virus1 virus1Controller = virus1.GetComponent<Virus1>();
                    Enemy.IsVirus1Playing = true;
                    states =BattleStates.EnemySelect;
                }
                else
                {
                    Debug.Log("Enemy 2 Selected");
                    dialogText.text = "Virus 2 Attacking!";
                    Virus1 virus2Controller = virus2.GetComponent<Virus1>();
                    Enemy.IsVirus1Playing = true;
                    states =BattleStates.EnemySelect;
                }
                c++;

                break;
            case BattleStates.EnemySelect:
                
                RandomState.StateLimits =3 ;
                RandomState.RandomStateMethod();
                Debug.Log("Virus is choosing");
                switch (RandomState.StateE)
                {
                    case 1:
                        //_states.Attack();
                        _damage = 5;
                        Debug.Log("2-Invisibility");
                        Enemy.IsVirus1Playing = false;
                        states = BattleStates.EnemySelectPlayer;
                        break;
                    case 2:
                        //_states.Attack();
                        _damage = 10;
                        Debug.Log("2-Attack");
                        Enemy.IsVirus1Playing = false;
                        states = BattleStates.EnemySelectPlayer;
                        break;
                    case 3:
                        //_states.Scanner();
                        _damage = 15;
                        Debug.Log("2-Scanner");
                        Enemy.IsVirus1Playing = false;
                        states = BattleStates.EnemySelectPlayer;
                        break;
                    default:
                        Debug.Log("No anda el virus");
                        Enemy.IsVirus1Playing = false;
                        break;
                }
                break;
            case BattleStates.EnemySelectPlayer:
                if (RandomState.StateE%2==0)
                {
                    Debug.Log("Attack to Hacker");
                    scoreData.hLife = scoreData.hLife - _damage;
                    states = BattleStates.PlayerSelection;
                }
                else
                {
                    Debug.Log("Attack to Electroquinetic");
                    scoreData.mLife = scoreData.mLife - Virus1.Instance._damage;
                    states = BattleStates.PlayerSelection;
                }
                if (scoreData.hLife<=0 & scoreData.mLife<=0) //el score es la vida de los players
                {
                    states = BattleStates.Lost;
                    EndBattle();
                }
                break;
            default:
                break;
        }
      /*  if (OnPlayerTurn)
        {
            states = BattleStates.PlayerTurn;
            StartCoroutine(PlayerTurn());
        }
        else if (!OnPlayerTurn)
        {
            states = BattleStates.Enemyturn;
            StartCoroutine(EnemyTurn());
        }*/
    }

    IEnumerator SetUpBattle()
    {
        dialogText.text = "SetUp Battle";
        yield return new WaitForSeconds(1f);
        
        dialogText.text = "Battle 1";
        yield return new WaitForSeconds(1f);

        states = BattleStates.PlayerSelection;
    }

    /*IEnumerator EnemyTurn()
    {
        dialogText.text = "Enemy Turn";
        
        //Choose State
        IsEnemyChoosing = true;
        
        if (scoreData.hLife<=0 & scoreData.mLife<=0) //el score es la vida de los players
        {
            states = BattleStates.Lost;
            EndBattle();
        }
        yield return new WaitForSeconds(2f);
    }*/

   /* IEnumerator PlayerTurn()
    {
        yield return new WaitForSeconds(2f);
        
        if (states != BattleStates.PlayerTurn)
                 {
                     yield break;
                 }
        dialogText.text = "Choose a Player";
        
        //Choose a Player and Attack 
        
        IsPlayerChoosing = true;

        if (lifeBattleVirus1<=0 & lifeBattleVirus2<=0)
        {
            states = BattleStates.Won;
            EndBattle();
        }

        yield return new WaitForSeconds(2f);
    }*/
    
    void EndBattle()
    
    {
        if (states == BattleStates.Won)
        {
            dialogText.text = "You won the battle!";
            _characterController1.GoBackCity();
            _startLevel2.enabled = true;
            
        }
        else if (states == BattleStates.Lost)
        {
            dialogText.text = "You loose";
        }
    }

    void RestScore()
    {

        if (virus1Choosed)
        {
            lifeBattleVirus1 = lifeBattleVirus1 - _damage;
            virus1Choosed = false;
        }
        else if (virus2Choosed)
        {
            lifeBattleVirus2 = lifeBattleVirus2 - _damage;
            virus2Choosed = false;
        }
    }

    
}
