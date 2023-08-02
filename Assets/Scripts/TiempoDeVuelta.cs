using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TiempoDeVuelta : MonoBehaviour
{
    public static int ContadorDeMinutos;
    public static int ContadorDeSegundos;
    public static float ContadorDeMilisegundos;
    public static string PantallaDeNumeracion;

    public GameObject Minutos;
    public GameObject Segundos;
    public GameObject Milisegundos;

    // Update is called once per frame
    void Update()
    {
        ContadorDeMilisegundos += Time.deltaTime * 10;
        PantallaDeNumeracion = ContadorDeMilisegundos.ToString("F0");
        Milisegundos.GetComponent<Text>().text = "" + PantallaDeNumeracion;
        
        if(ContadorDeMilisegundos >= 10) { 
        
            ContadorDeMilisegundos = 0;
            ContadorDeSegundos += 1;
        }

        if(ContadorDeSegundos <= 9) { 
        
            Segundos.GetComponent<Text> ().text = "0" + ContadorDeSegundos + ".";

        } else {
        
                Segundos.GetComponent<Text> ().text = "" + ContadorDeSegundos + ".";
            }

        if (ContadorDeSegundos >= 60) { 
        
            ContadorDeSegundos = 0;
            ContadorDeMinutos += 1;
        }

        if (ContadorDeMinutos <= 9) {
            Minutos.GetComponent<Text>() .text = "0" + ContadorDeMinutos + ":";
        } else {
            Minutos.GetComponent<Text>().text = "" + ContadorDeMinutos + ":";

    }

    
   }
}

