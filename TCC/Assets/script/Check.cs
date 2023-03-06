using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check : MonoBehaviour
{
    MovimentoHorizontal Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = gameObject.transform.parent.gameObject.GetComponent<MovimentoHorizontal>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collisior)
    {
        if(collisior.gameObject.tag == "Chão")
        {
            Player.isJumping = false;
        }

    }
     void OnCollisionExit2D(Collision2D collisior)
    {
        if (collisior.gameObject.tag == "Chão")
        {
            Player.isJumping = true;
        }
    }
}
