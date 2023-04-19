using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AcherController : MonoBehaviour
{

    public Transform posicaoPlayer;
    public float velocidadeMovimento;
    public float distancia;
    public GameObject projetil;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

        distancia = Vector3.Distance(transform.position, posicaoPlayer.transform.position);

        if(distancia < 8)
        {
            Instantiate(projetil, transform.position, Quaternion.identity);
        }


        transform.position = Vector3.MoveTowards(transform.position, posicaoPlayer.position, velocidadeMovimento * Time.deltaTime);

        

    }

   
}
