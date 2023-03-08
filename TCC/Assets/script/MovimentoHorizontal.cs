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
    private Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
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
            Debug.Log("Morrer");
        }
    }

    //Minhas fun��es
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
        float movimentoHorizntal = Input.GetAxisRaw("Horizontal");
        float movimentoVertical = Input.GetAxisRaw("Vertical");

        transform.Translate(new Vector3(1 * movimentoHorizntal, 1 * movimentoVertical, 0) * velocidade * Time.deltaTime);

    }

    void OnCollisionEnter2D(Collision2D collisior)
    {
        if (collisior.gameObject.tag == "Ch�o")
        {
            isJumping = true;
        }

    }
    void OnCollisionExit2D(Collision2D collisior)
    {
        if (collisior.gameObject.tag == "Ch�o")
        {
            isJumping = false;
        }
    }


   

    #endregion
}
