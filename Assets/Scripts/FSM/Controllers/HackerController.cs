
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HackerController : CharacterController
{
    private int _copyLimit=3;

    private ScoreData _scoreData;

    private GameData _gameData;

    private State _currentState;
    
    private Hacker _hacker;
    
    [SerializeField] private KeyCode bugKey, copyKey, stealKey;
    
    private readonly BuggingState _bugging = new BuggingState();
    private readonly CopyingState _copying = new CopyingState();
    private readonly StealingState _stealing = new StealingState();
    private readonly IddleState _iddle = new IddleState();
    private readonly DieState _die = new DieState();

    private SimpleMovement _movement;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        SwitchState(_iddle, _movement);  
        Debug.Log("Hacker-Iddle");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(bugKey)) BugOnClick();
        else if(Input.GetKey(copyKey)&& _copyLimit<=0) CopyOnClick();
        else if (_scoreData.shootingPoints == 100 && Input.GetKey(stealKey)) StealOnClick();
        else
        {
            SwitchState(_iddle, _movement);  
            Debug.Log("Hacker-Iddle");
        }
    }
    void BugOnClick(){
        SwitchState(_bugging, _movement);
        Debug.Log("Hacker - case1");
        //Battle.ChangeTurn();
        _gameData.actualState=new BuggingState();
        CanPlay = false;
    }

    void CopyOnClick()
    {
        _currentState = _gameData.actualState;
        SwitchState(_currentState, _movement );
        Debug.Log("Hacker - case2");
        _copyLimit--;
       // Battle.ChangeTurn();
        _gameData.actualState=_currentState;
        CanPlay = false;
    }

    void StealOnClick()
    {
        SwitchState(_stealing, _movement);
        Debug.Log("Hacker - case3");
        _scoreData.shootingPoints = 0;
        //Battle.ChangeTurn();
        CanPlay = false;
        _gameData.actualState=new StealingState();
    }
}
