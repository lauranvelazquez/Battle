using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputNameAudio : MonoBehaviour
{
    public AudioSource audioKeyBoard;
    public InputField texto;

    void Start()
    {
        audioKeyBoard = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Text_Changed(string text) {
        audioKeyBoard.Play(0);
    }

    
}
