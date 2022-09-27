using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransicaoMenu : MonoBehaviour
{
    public Animator transicao;
    // Start is called before the first frame update
    void Start()
    {
        transicao.SetTrigger("EntrarTela");     
    }
}
