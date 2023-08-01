using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CuentaKM : MonoBehaviour
{
    public Rigidbody RB;
    public Image Imagen;

    // Update is called once per frame
    void Update()
    {
        float velocidad = RB.velocity.magnitude;
        Imagen.transform.eulerAngles = new Vector3(0, 0, velocidad * -4 + 150);
    }
}
