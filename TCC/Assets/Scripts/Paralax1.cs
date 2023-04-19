using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Paralax1 : MonoBehaviour
{
    public Transform background;
    private Transform cam;
    public float velocidadeBg;
    private Vector3 posicaoInicialCamera;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.transform;
        posicaoInicialCamera = cam.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void LateUpdate()
    {
        float parallax = posicaoInicialCamera.x - cam.position.x;
        float bgAcrescimo = background.position.x + parallax;

        Vector3 bgPosicao = new Vector3(bgAcrescimo, background.position.y, background.position.z);
        background.position = Vector3.Lerp(background.position, bgPosicao, velocidadeBg );

        posicaoInicialCamera = cam.position;
    }
}
