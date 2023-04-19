using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;


public class ComandosBasicos : MonoBehaviour
{ private CharacterController controller;
    private Animator anim;
    public float velocidade;
    private Vector2 movimento;
    private Vector3 direcao;
    private bool isAnim;
    private float direcaoMovimento;
    private int pontos;
    public TextMeshProUGUI txtpontos;
    public GameObject transicao;
    public GameObject cameraPrimcipal;


    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        direcao = new Vector3(movimento.x, 0, movimento.y);


        controller.Move(direcao * velocidade * Time.deltaTime);


        isAnim = false;

        if (direcao.magnitude > 0)
        {
            direcaoMovimento = Mathf.Atan2(movimento.x, movimento.y) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0,direcaoMovimento,0 );
            isAnim = true;
        }

        anim.SetBool("Run", isAnim);

        


    }

    public void Move(InputAction.CallbackContext value)
    {
        movimento = value.ReadValue < Vector2 > ();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "coletavel")

        {

            pontos += 1;
            Destroy(other.gameObject);
        }

        txtpontos.text = pontos.ToString();

        if (other.gameObject.tag == "coletavel2") 
        {
            pontos += 3;
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "coletavel3") 
        {
            pontos -= 1;
            Destroy(other.gameObject);
        }
        txtpontos.text = pontos.ToString();


        if (other.gameObject.tag == "transicao")
        {
            transicao.SetActive(true);
            cameraPrimcipal.SetActive(false);
        }




    }












}
