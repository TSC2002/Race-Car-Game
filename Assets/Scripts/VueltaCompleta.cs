using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VueltaCompleta : MonoBehaviour
{
    public GameObject VueltaCompletada;
    public GameObject MediaVuelta;

    public GameObject PantallaDeMilisegundos;
    public GameObject PantallaDeSegundos;
    public GameObject PantallaMinutos;

    public GameObject TdeVuelta;

    void OnTriggerEnter()
    {
        if(TiempoDeVuelta.ContadorDeSegundos <= 9)
        {
            PantallaDeSegundos.GetComponent<Text>().text = "0" + TiempoDeVuelta.ContadorDeSegundos + ":";
        }
        else
        {
            PantallaDeSegundos.GetComponent<Text>().text = "" + TiempoDeVuelta.ContadorDeSegundos + ":";
        }

        if(TiempoDeVuelta.ContadorDeMinutos <= 9)
        {
            PantallaMinutos.GetComponent<Text>().text = "0" + TiempoDeVuelta.ContadorDeMinutos + ":";
        }
        else
        {
            PantallaMinutos.GetComponent<Text>().text = "" + TiempoDeVuelta.ContadorDeMinutos + ":";
        }

        PantallaDeMilisegundos.GetComponent<Text>().text = "" + TiempoDeVuelta.ContadorDeMilisegundos;

        TiempoDeVuelta.ContadorDeMinutos = 0;
        TiempoDeVuelta.ContadorDeSegundos = 0;
        TiempoDeVuelta.ContadorDeSegundos = 0;

        MediaVuelta.SetActive(true);
        VueltaCompletada.SetActive(false);
    }
}
