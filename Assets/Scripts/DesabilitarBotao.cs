using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DesabilitarBotao : MonoBehaviour
{
    private Button bt; 
    void Start()
    {
        bt = GetComponent<Button>();
        if (PlayerPrefs.GetInt("ComprouAds", 0) == 1)
        {
            bt.interactable = false;
        }    
    }

    public void AceitarCompra()
    {
        bt.interactable = false;
        PlayerPrefs.SetInt("ComprouAds", 1);
    }
}
