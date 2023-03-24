using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rbPlayer;
    private Animator anim;
    public float velociddedoplayer;
    public float pulo;
    public float movImentacaoHorinzontal;

    // Start is called before the first frame update
    void Start()
    {
        rbPlayer = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void inputPlayer()
    {
        movImentacaoHorinzontal = Input.GetAxisRaw("Horizontal");
    }






}
