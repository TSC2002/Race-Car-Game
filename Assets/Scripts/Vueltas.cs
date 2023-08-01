using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vueltas : MonoBehaviour
{
    public GameObject VueltaCompleta;
    public GameObject MediaVuelta;

    private void OnTriggerEnter()
    {
        VueltaCompleta.SetActive(true);
        MediaVuelta.SetActive(false);

     

 
    }
}
