using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour
{
    void Start()
    {
        var AnuncioCount = PlayerPrefs.GetInt("ContagemAnuncio", 0);
        if (PlayerPrefs.GetInt("ContagemAnuncio", 0) == 2)
        {
            if (!Advertisement.isInitialized)
            {
                Advertisement.Initialize("4048979", false);
            }
            else
            {
                Advertisement.Show("Interstitial_Android");
                PlayerPrefs.SetInt("ContagemAnuncio", 0);
            }
        }
        else
        {
            PlayerPrefs.SetInt("ContagemAnuncio", AnuncioCount + 1);
        }
    }
}
