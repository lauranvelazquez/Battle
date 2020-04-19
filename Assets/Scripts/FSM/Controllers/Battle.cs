using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class Battle : MonoBehaviour
{
    public GameObject pointer; //señala el personaje
    public static Battle PlayerBattle; //para acceder desde otros scripts
    public static bool goAttack = false;
    public bool canAttack = true;
    public Vector3 ePosition, originalPosition;
    public static int myTurn=1, actions=0;
    
    // Start is called before the first frame update
    void Start()
    {
        PlayerBattle = this.GetComponent<Battle>();
        originalPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (myTurn != TManager.tmanager.turn)
        {
            pointer.gameObject.SetActive(false);
            return;
            //si no es mi turno
        }
        else if (myTurn == TManager.tmanager.turn)
        {
            pointer.gameObject.SetActive(true); 
        }

        if (goAttack)
        {
            transform.position = Vector2.MoveTowards(transform.position, ePosition, 5f * Time.deltaTime);
            //el personaje se mueve hacia el enemigo
        }

        if (!goAttack)
        {
            transform.position = Vector2.MoveTowards(transform.position, originalPosition, 5f * Time.deltaTime);
            if (transform.position == originalPosition && myTurn == TManager.tmanager.turn && actions > 0)
            {
                actions = 0;
                TManager.tmanager.turn++;  
            }
            
        }

    }

    public void Attack()
    {
        pointer.gameObject.SetActive(true);
    }

    public static void ChangeTurn()
    { 
        goAttack = true;
        GoBack();
        //golpear, es una funcion
    }
    public static void GoBack()
    {
        actions++;
        goAttack = false;
    }
}

public class TurnManager: MonoBehaviour
{
    public static CharacterController _character;
    public static Virus _virus;

    private void Start()
    {
        _character.CanPlay = true;
    }

    public static void ChangeTurn()
    {

        if (_character.CanPlay = true)
        {
            _virus.CanAttack = false;
        }

        if (_character.CanPlay = false)
        {
            _virus.CanAttack = true;
        }
    }

}
