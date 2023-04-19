using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo1 : MonoBehaviour
{

    public Transform posicaoPlayer;
    public float velocidadeMovimento;
    public float distancia;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distancia = Vector3.Distance(transform.position, posicaoPlayer.transform.position);

        
        



    }
}
