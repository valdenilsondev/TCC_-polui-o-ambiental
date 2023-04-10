using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menuprincipal : MonoBehaviour
{
    [SerializeField] private string nomeDoLeveDeJogo;
    public void Jogar()
    {
        SceneManager.LoadScene(nomeDoLeveDeJogo); 
    }

    public void SairJogo()
    {
        Debug.Log("sair do jogo");
        Application.Quit();
    }







   









    void Start()
    {
        
    }

 
    void Update()
    {
        
    }
}
