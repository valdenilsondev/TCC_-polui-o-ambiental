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

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       

        Jump();
        movimento();
        
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

<<<<<<< HEAD
    void movimento()
    {
        float movimentoHorizntal = Input.GetAxisRaw("Horizontal");
        float movimentoVertical = Input.GetAxisRaw("Vertical");

        transform.Translate(new Vector3(1 * movimentoHorizntal, 1 * movimentoVertical, 0) * velocidade * Time.deltaTime);

    }
=======
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
>>>>>>> b2afdbc053a776f87b12f2b6e7628d7360f9c3d6

    #endregion
}
