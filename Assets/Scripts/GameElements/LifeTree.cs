using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTree : MonoBehaviour
{
    private int contador = 0;
    public ScoreData scoreData;


    void OnCollisionEnter(Collision col)
    {
        if (!col.gameObject.CompareTag("Player")) return;
        Debug.Log("Tree");
        scoreData.score++;
    }
}
