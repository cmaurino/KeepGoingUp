using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Placares : MonoBehaviour
{
    public Text pontuacaoatual;
    public Text recorde;
    void Start()
    {
        Pontuacao();    
    }

    void Pontuacao()
    {
        pontuacaoatual.text = PlayerPrefs.GetFloat("PlacarAtual", 0).ToString() + "m";
        if (PlayerPrefs.GetFloat("Recorde", 0) < PlayerPrefs.GetFloat("PlacarAtual", 0))
        {
            PlayerPrefs.SetFloat("Recorde", PlayerPrefs.GetFloat("PlacarAtual", 0));    
        }
        recorde.text = PlayerPrefs.GetFloat("Recorde", 0).ToString() + "m";
    }
}
