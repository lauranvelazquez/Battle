using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Texto : MonoBehaviour
{

    public Text txt;
    private string texto;
    public Slider sldProgressBar;

    // Start is called before the first frame update
    void Start()
    {
        this.texto = "Una ciudad CyberPunk fue atacada por un virus maligno que daño todo el sistema" +
                     " solo queda un punto para dañar y es posible que el virus pueda llegar" + 
                     " nuestra misión será evitar que llege y dañe todo asi no se pierda por completo el" +
                    " objetivo del juego";

        StartCoroutine(ditado(texto));
    }

    // Update is called once per frame
    void Update()
    {
        this.sldProgressBar.value += 0.05f;
    }

    IEnumerator ditado(string frase)
    {
        int letra = 0;
        txt.text = "";

        while (letra < frase.Length)
        {
            txt.text += frase[letra];
            letra += 1;
            yield return new WaitForSeconds(0.1f);
        }

    }
}
