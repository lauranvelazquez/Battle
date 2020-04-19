using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject  virus1, virus2;
    public static bool IsVirus1Playing=false;
    
    
    private int c = 0;

    // Update is called once per frame
    
   /* void Update()
    {
        if (BattleMachine.IsEnemyChoosing)
        {
            if (c % 2 == 0)
            {
                Debug.Log("Enemy 1 Selected");
                Virus1 virus1Controller = virus1.GetComponent<Virus1>();
                IsVirus1Playing = true;
                BattleMachine.IsEnemyChoosing = false;

            }
            else
            {
                Debug.Log("Enemy 2 Selected");
                Virus1 virus2Controller = virus2.GetComponent<Virus1>();
                IsVirus1Playing = true;
                BattleMachine.IsEnemyChoosing = false;
            }
        }
        c++;
    }*/
}
