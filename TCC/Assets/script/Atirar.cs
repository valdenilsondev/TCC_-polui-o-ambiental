using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atirar : MonoBehaviour
{

    public float speed;


    void Start()
    {
        transform.Translate(new Vector2(1, 0) * Time.deltaTime * speed);

    }
   


    

    


   


// Update is called once per frame
void Update()
    {
        transform.Translate(new Vector2(1, 0) * speed * Time.deltaTime);

    }
}

