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

    public Animator anim;
    float movimentoHorizntal;
    float movimentoVertical;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       

        Jump();
        movimento();
       
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


   

    #endregion
}
