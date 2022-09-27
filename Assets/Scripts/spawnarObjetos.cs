using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class spawnarObjetos : MonoBehaviour {
    public float speed = 10.0f;
    private Rigidbody2D rb;
    private Vector2 screenBounds;

    void Start () {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    void Update () {
        var lava = GameObject.FindWithTag("Lavinha");
        if (SceneManager.GetActiveScene().name == "Jogo")
        {
            if(this.transform.position.y < lava.transform.position.y)
            {
                Destroy(this.gameObject);
            }
        }
        else
        {
            if(this.transform.position.y < (screenBounds.y * -1))
            {
                Destroy(this.gameObject);
            }
        }
    }

       private void OnCollisionEnter2D(Collision2D colis) {
        rb = GetComponent<Rigidbody2D>();
        if (colis.collider.gameObject.layer == LayerMask.NameToLayer("Blocos"))
        {
            rb.bodyType = RigidbodyType2D.Static;    
        }
    }
}