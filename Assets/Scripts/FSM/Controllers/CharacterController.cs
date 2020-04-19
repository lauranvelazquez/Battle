using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterController : FSM
{
    public bool CanPlay { set; get; }

    // Start is called before the first frame update
    void Start()
    {
        ChooseCharacter();

        //if (_scoreData.score == 0) { Loose(); ChangeScene(); } else if (virus == 0) { EndGame(); ChangeScene(); } }

        // Update is called once per frame
        void Update()
        {

        }

        void ChooseCharacter()
        {
            //si hay alguno antes eliminarlo 

        }

        void EndGame()
        {
        }

        void Loose()
        {

        }

        void ChangeScene()
        {

        }
    }
}


