using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseCharacter : MonoBehaviour
{
    private BiowareController _biowareController;
    private HackerController _hackerController;
    private MagoController _magoController;

   public static GameObject _currentCharacter; 

    [SerializeField] protected KeyCode _bioButton;
    [SerializeField] protected KeyCode _hackerButton;
    [SerializeField] protected KeyCode _magoButton;
    // Start is called before the first frame update
    void Start()
    {
        Choose();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("P"))
        {
            Choose();
        }
    }

    void Choose()
    {
        GameObject Bioware=GameObject.FindObjectOfType<GameObject>();
        GameObject Mago=GameObject.FindObjectOfType<GameObject>();
        GameObject Hacker=GameObject.FindObjectOfType<GameObject>();


        if (Input.GetKey(_bioButton))
        {
            Instantiate(Bioware, new Vector3(0 ,0,0), Quaternion.identity);
            _currentCharacter = Bioware;
        }

        if (Input.GetKey(_hackerButton))
        {
            Instantiate(Hacker, new Vector3(5 ,0,0), Quaternion.identity);
            _currentCharacter = Hacker;
        }

        if (Input.GetKey(_magoButton))
        {
            Instantiate(Mago, new Vector3(10 ,0,0), Quaternion.identity);
            _currentCharacter = Mago; 
        }
    }
}
