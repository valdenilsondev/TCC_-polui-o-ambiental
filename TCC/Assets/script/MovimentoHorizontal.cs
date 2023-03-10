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
    private bool abaixar;
    public Animator anim;
   public float movimentoHorizntal;
   public float movimentoVertical;

    public SpriteRenderer spRender;

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

    }
    void OnCollisionExit2D(Collision2D collisior)
    {
        if (collisior.gameObject.tag == "Chão")
        {
            isJumping = false;
        }
    }


    #endregion
}