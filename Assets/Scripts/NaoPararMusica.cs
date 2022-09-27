using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NaoPararMusica : MonoBehaviour
{
    public Sprite imgSom;
    public Sprite imgSemSom;
    public GameObject imagem;
    private bool msc;

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "MenuPrincipal")
        {
            imagem = GameObject.FindWithTag("Som");
            AtualizarImagem();
        }
    }

    void Awake()
    {
        if (PlayerPrefs.GetString("Mutado", "N") == "S")
        {
            this.GetComponent<AudioSource>().mute = true;
            AtualizarImagem();
        }
        else
        {
            this.GetComponent<AudioSource>().mute = false;
            AtualizarImagem();
        }

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void Mutar()
    {
        if (PlayerPrefs.GetString("Mutado", "N") == "S")
        {
            this.GetComponent<AudioSource>().mute = false;
            PlayerPrefs.SetString("Mutado", "N");
        }
        else
        {
            this.GetComponent<AudioSource>().mute = true;
            PlayerPrefs.SetString("Mutado", "S");
        }
        AtualizarImagem();
    }

    public void AtualizarImagem()
    {
        if (PlayerPrefs.GetString("Mutado", "N") == "S")
        {
            imagem.GetComponent<Image>().sprite = imgSemSom;
        }
        else
        {
            imagem.GetComponent<Image>().sprite = imgSom; 
        }    
    }  

}