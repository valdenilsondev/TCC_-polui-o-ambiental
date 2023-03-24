using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

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

    public const float runningSpeed = 9;
    public const float defaultSpeed = 6;
    public float Speed = defaultSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();

        spRender = GetComponentInChildren<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {


        Jump();
        movimento();
        slide();
        run();
        Shoot();

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "inimigo")
        {
            // anim.SetTrigger();
            anim.SetTrigger("morrer");

            movimentoHorizntal = 0;
            movimentoVertical = 0;

            velocidade = 0;

            Destroy(gameObject, 2);
        }



    }

    //Minhas funções


    #region 

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isJumping)
        {
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
        }
        


    }
    void movimento()
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

    void run()

    {
        if (Input.GetKey(KeyCode.K)) 
        { 
            Speed = runningSpeed;
        }
        else if (Speed != defaultSpeed)
        {
             
            Speed = defaultSpeed;
        }
    }
   

    #endregion
}