using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class panelOpened : MonoBehaviour
{

    public GameObject Panel, Panel2;


    public void OpenPanel()
    {
        if(Panel != null)
        {
            bool isActive = Panel.activeSelf;
            Panel.SetActive(true);
            Panel2.SetActive(false);
        }
    }
}
