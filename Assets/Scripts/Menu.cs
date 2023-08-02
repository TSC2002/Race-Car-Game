using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void EmpezarJuego(string Juego)
    {
        SceneManager.LoadScene(Juego);
    }

    public void Salir()
    {
        Application.Quit();
        Debug.Log("Se cierra el juego");
    }
}
