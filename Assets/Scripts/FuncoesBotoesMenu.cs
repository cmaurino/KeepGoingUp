using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FuncoesBotoesMenu : MonoBehaviour
{
    public Animator transicao;
    public void Jogar(string cena)
    {
        StartCoroutine(FazerTransicao(cena));  
    }

    IEnumerator FazerTransicao(string cena){
        transicao.SetTrigger("SairTela");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(cena);  
    }
}
