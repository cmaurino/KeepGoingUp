using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MecanicaDoEstilingue : MonoBehaviour
{
	[HideInInspector] public Rigidbody2D rb;
	[HideInInspector] public CircleCollider2D col;
    [HideInInspector] public SpriteRenderer sr;
	[HideInInspector] public Vector3 pos { get { return transform.position; } }
    public Camera CameraPrincipal;
    private Vector2 screenBounds;
    private float objectWidth;
    public static int pulo;
    public ParticleSystem explosao;
    public ParticleSystem trilha;
    public AudioClip SomExplosao;
    public AudioSource Controlador;

	void Awake ()
	{
		rb = GetComponent<Rigidbody2D> ();
		col = GetComponent<CircleCollider2D> ();
        sr = GetComponent<SpriteRenderer> ();
	}

	public void Push (Vector2 force)
	{
		if (col.IsTouchingLayers() || pulo < 2)
        {    
            rb.AddForce (force, ForceMode2D.Impulse);
            pulo ++;
        } 
	}

    private void OnCollisionEnter2D(Collision2D bolinha) {
        trilha.Play();
        pulo = 0;    
    }

    private void Start () {
        screenBounds = CameraPrincipal.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, CameraPrincipal.transform.position.z));
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x;
    }

    private void Update(){
        var lava = GameObject.FindWithTag("Lavinha");
        var lavaaltura = lava.transform.GetComponent<SpriteRenderer>().bounds.extents.y;
        var bolinhaaltura = transform.GetComponent<SpriteRenderer>().bounds.extents.y;
        Vector3 viewPos = transform.position;
        if (transform.position.x > screenBounds.x)
        {
            viewPos.x = screenBounds.x * -1;                    
        }
        else if (transform.position.x < (screenBounds.x * -1))
        {
            viewPos.x = screenBounds.x;                    
        }
        transform.position = viewPos;

        if (transform.position.y < (lava.transform.position.y + lavaaltura + (bolinhaaltura/2)) && sr.enabled == true)
        {
            FimDeJogo();
            // Time.timeScale = 0f;
        }
    }

    private void OnCollisionStay2D(Collision2D other) {
        rb.angularVelocity = 0f;
    }

    public void FimDeJogo(){
        sr.enabled = false;
        explosao.Play();
        if (PlayerPrefs.GetString("Mutado", "N") == "N") {Controlador.PlayOneShot(SomExplosao);}
        rb.isKinematic = true;
        PlayerPrefs.SetFloat("PlacarAtual", GameManager.pntm);
        StartCoroutine(CongelarRapido(1.5f));
    }

    IEnumerator CongelarRapido(float tempocongelamento){
        yield return new WaitForSeconds(tempocongelamento);
        SceneManager.LoadScene("FimDeJogo");
    }

}