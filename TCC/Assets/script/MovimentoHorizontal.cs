using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoHorizontal : MonoBehaviour
{

    public float velocidade;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float movimentoHorizntal = Input.GetAxisRaw("Horizontal");
        float movimentoVertical = Input.GetAxisRaw("Vertical");
        transform.Translate(new Vector3(1 * movimentoHorizntal, 1 * movimentoVertical, 0) * velocidade);
    }
}
