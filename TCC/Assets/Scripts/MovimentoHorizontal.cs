using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Security.Cryptography;

public class MovimentoHorizontal : MonoBehaviour
{
    public float velocidade;
    public float JumpForce;
    public bool isJumping;
    private Rigidbody2D rig;

    public GameObject projetil;
    public Transform posicaoProjetil;

    private bool abaixar;
    public Animator anim;
    public float movimentoHorizntal;
    public float movimentoVertical;

    public SpriteRenderer spRender;

    public GameObject bullet;
    const float lifeTime = 2;
    public float speed;

    public Image vida1;
    public Image vida2;
    public Image vida3;
    public Image vida4;
    public Image vida5;

    public int qntVidaAtual;
    public int qntVida;
    public int coins;

    public TextMeshProUGUI textoMoedas;

    private AudioSource sound;
    public AudioClip somMoeda;
    public AudioClip somPulo;
    public AudioClip atirar;
    
    public TextMeshProUGUI timetext;
    public int tempo;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();

        spRender = GetComponentInChildren<SpriteRenderer>();
        qntVidaAtual = 5;
        qntVida = qntVidaAtual;
        sound = GetComponent<AudioSource>();
        
    }
    
    // Update is called once per frame
    void Update()
    {
        tempo = (int)Time.time;
        timetext.text = tempo.ToString();
        textoMoedas.text = coins.ToString();

        Jump();
        Movimento();
        slide();
        Shoot();        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "inimigo")
        {
            // anim.SetTrigger();

            /*
            anim.SetTrigger("morrer");

            movimentoHorizntal = 0;
            movimentoVertical = 0;

            velocidade = 0;

            Destroy(gameObject, 2);
            */

            qntVida -= 1;

            if(qntVida <= 4)
            {
                vida1.enabled = false;
                vida2.enabled = true;
                vida3.enabled = true;
                vida4.enabled = true;
                vida5.enabled = true;

            }
            if (qntVida <= 3)
            {
                vida1.enabled = false;
                vida2.enabled = false;
                vida3.enabled = true;
                vida4.enabled = true;
                vida5.enabled = true;

            }
            if (qntVida <= 2)
            {
                vida1.enabled = false;
                vida2.enabled = false;
                vida3.enabled = false;
                vida4.enabled = true;
                vida5.enabled = true;

            }
            if (qntVida <= 1)
            {
                vida1.enabled = false;
                vida2.enabled = false;
                vida3.enabled = false;
                vida4.enabled = false;
                vida5.enabled = true;

            }
            if (qntVida <= 0)
            {
                vida1.enabled = false;
                vida2.enabled = false;
                vida3.enabled = false;
                vida4.enabled = false;
                vida5.enabled = false;
                qntVida = 0;
                anim.SetTrigger("morrer");

                movimentoHorizntal = 0;
                movimentoVertical = 0;

                velocidade = 0;

                Destroy(gameObject, 2);
            }           
        }

        if (col.gameObject.tag == "coins") 
        {
            coins++;
            sound.PlayOneShot(somMoeda);
            Destroy(col.gameObject);
        }
    }

    //Minhas funções
    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isJumping)
        {
            sound.PlayOneShot(somPulo);
            rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
        }
    }

    void slide()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) )
        {
            anim.SetTrigger("slide");
        }
        else
        {
            spRender.flipX = false;
        }
    }

    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(projetil, posicaoProjetil.position, Quaternion.identity);
            sound.PlayOneShot(atirar);
        }
    }

    void Movimento()
    {
        movimentoHorizntal = Input.GetAxisRaw("Horizontal");
        movimentoVertical = Input.GetAxisRaw("Vertical");

        transform.Translate(new Vector3(1 * movimentoHorizntal, 1 * movimentoVertical, 0) * velocidade * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collisior)
    {
        if (collisior.gameObject.tag == "Chão")
        {
            isJumping = true;
        }
        if (collisior.gameObject.tag == "inimigo")
        {
           
        }
    }

    void OnCollisionExit2D(Collision2D collisior)
    {
        if (collisior.gameObject.tag == "Chão")
        {
            isJumping = false;
        }
    }
}