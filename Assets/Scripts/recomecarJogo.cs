using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class recomecarJogo : MonoBehaviour
{

    public Animator transicao;

    public void Recomecar(string cena)
    {
        StartCoroutine(FazerTransicao(cena));  
    }

    IEnumerator FazerTransicao(string cena){
        transicao.SetTrigger("SairTela");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(cena);  
    }
}
