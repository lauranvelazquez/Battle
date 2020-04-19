using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Virus4Controller : Virus
{
    private Vector3 _initialPosition;
    
    private bool _isNear; //cercania
    private bool _playerAttack; // algún ataque fuerte
    
    [SerializeField] private MovementVirus2 _movementVirus2;

    private readonly IddleState _iddle = new IddleState();
    private readonly ShootingState _shooting = new ShootingState();
    private readonly DieState _die = new DieState();
    private readonly BlockingState _blocking = new BlockingState();
    private readonly StealingState _stealing = new StealingState();
    private readonly AttackingState _attacking = new AttackingState();
    private readonly FightingState _fighting = new FightingState();
    private readonly ScannerState _scanner = new ScannerState();
    private readonly CopyingState _copying = new CopyingState();
    private readonly LightningState _lightning = new LightningState();
    private readonly BuggingState _bugging = new BuggingState();
    private readonly InvisibilityState _invisibility = new InvisibilityState();
    private readonly DoublingState _doubling = new DoublingState();
    private  readonly PixelingState _pixeling = new PixelingState();
    private readonly ElectricityState _electricity = new ElectricityState();

    private float _initialTime;

    private float _currentTime;

    private bool _isDead = false;

    [SerializeField] private Vector3 initialPosition;

    // Start is called before the first frame update
    void Start()
    {
        SwitchState(_iddle, _movementVirus2);
        this.transform.position = _initialPosition;
        _initialTime = 0.0f;
        _initialTime = _currentTime;
    }
    
    // Update is called once per frame
    protected override void Update()
    {
        switch (_currentTime)
        {
            case 0.0f:
                RandomState.StateLimits = 3;
                break;
            case 1.0f:
                RandomState.StateLimits = 6;
                break;
            case 2.0f:
                RandomState.StateLimits = 9;
                break;
            case 3.0f:
                RandomState.StateLimits = 12;
                break;
            case 4.0f:
                RandomState.StateLimits = 15;
                break;
            default:
                Debug.Log("Error. The sistem has been broken");
                break;
        }

        if (_isDead = true)
        {
            SwitchState(new DieState());
            //hacer script para recibir el daño y usar la bandera
        }

        _currentTime = Time.deltaTime;

        switch (RandomState.StateE)
        {
            case 1:
                SwitchState(_attacking, _movementVirus2);
                Debug.Log("Virus4 - case1");
                Battle.ChangeTurn();
                CanAttack = false;
                break;
            case 2:
                SwitchState(_fighting, _movementVirus2);
                Debug.Log("Virus4 - case2");
                Battle.ChangeTurn();
                CanAttack = false;
                break;
            case 3:
                SwitchState(_scanner, _movementVirus2);
                Debug.Log("Virus4 - case3");
                Battle.ChangeTurn();
                CanAttack = false;
                break;
            case 4:
                SwitchState(_copying, _movementVirus2);
                Debug.Log("Virus4 - case4");
                Battle.ChangeTurn();
                CanAttack = false;
                break;
            case 5:
                SwitchState(_bugging, _movementVirus2);
                Debug.Log("Virus4 - case5");
                Battle.ChangeTurn();
                CanAttack = false;
                break;
            case 6:
                SwitchState(_lightning, _movementVirus2);
                Debug.Log("Virus4 - case6");
                Battle.ChangeTurn();
                CanAttack = false;
                break;
            case 7:
                SwitchState(_blocking, _movementVirus2);
                Debug.Log("Virus4 - case7");
                Battle.ChangeTurn();
                CanAttack = false;
                break;
            case 8:
                SwitchState(_doubling, _movementVirus2);
                Debug.Log("Virus4 - case8");
                CanAttack = false;
                Battle.ChangeTurn();
                break;
            case 9:
                SwitchState(_stealing, _movementVirus2);
                Debug.Log("Virus4 - case9");
                CanAttack = false;
                Battle.ChangeTurn();
                break;
            case 10:
                SwitchState(_invisibility, _movementVirus2);
                Debug.Log("Virus4 - case10");
                CanAttack = false;
                Battle.ChangeTurn();
                break;
            case 11:
                SwitchState(_pixeling, _movementVirus2);
                Debug.Log("Virus4 - case11");
                Battle.ChangeTurn();
                CanAttack = false;
                break;
            case 12:
                SwitchState(_electricity, _movementVirus2);
                Debug.Log("Virus4 - case12");
                Battle.ChangeTurn();
                CanAttack = false;
                break;
            case 13:
                SwitchState(_shooting, _movementVirus2);
                CanAttack = false;
                Debug.Log("Virus4 - case13");
                Battle.ChangeTurn();
                break;
            default:
                SwitchState(_iddle, _movementVirus2);
                Debug.Log("Error. The sistem has been broken");
                Battle.ChangeTurn();
                CanAttack = false;
                break;
        }
    }
}
