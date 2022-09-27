using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnarObjetosCamera : MonoBehaviour {
    public GameObject quadrado;
    public GameObject retangulo;
    private Vector2 screenBounds;
    private int FormaAleatoria;
    private GameObject a;

    // Use this for initialization
    void Start () {
        new WaitForSeconds(1.0f);
        StartCoroutine(spawn());
    }
    private void spawnEnemy(){
        FormaAleatoria = Random.Range (0, 2);
        switch(FormaAleatoria)
        {
            case 0: a = Instantiate(quadrado) as GameObject; break;
            case 1: a = Instantiate(retangulo) as GameObject; break;
        }
        
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        a.transform.position = new Vector2(Random.Range(screenBounds.x * -1, screenBounds.x), screenBounds.y * 2);
    }
    IEnumerator spawn(){
        while(true){
            yield return new WaitForSeconds(1.5f);
            spawnEnemy();
        }
    }
}