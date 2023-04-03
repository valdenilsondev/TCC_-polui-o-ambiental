using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inimigo : MonoBehaviour
{
    public float velocidade;
    public float fatorAndar;

    // Start is called before the first frame update
    void Start()
    {
        fatorAndar = 1;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(fatorAndar, 0) * velocidade * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "sensor")
        {
            fatorAndar = fatorAndar * -1;
        }
    }
}
