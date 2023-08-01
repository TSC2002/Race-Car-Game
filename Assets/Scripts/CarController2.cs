using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController2 : MonoBehaviour
{

    public WheelCollider ColliderRuedaDerechaDelantera;
    public WheelCollider ColliderRuedaIzquierdaDelantera;
    public WheelCollider ColliderRuedaDerechaTrasera;
    public WheelCollider ColliderRuedaIzquierdaTrasera;

    public Transform TransformRuedaDerechaDelantera;
    public Transform TransformRuedaIzquierdaDelantera;

    public int Velocidad;
    public int Frenar;


    void Update()
    {
        TransformRuedaDerechaDelantera.localEulerAngles = new Vector3(0, ColliderRuedaDerechaTrasera.steerAngle, 0);
        TransformRuedaIzquierdaDelantera.localEulerAngles = new Vector3(0, ColliderRuedaIzquierdaTrasera.steerAngle, 0);



    }


    void FixedUpdate()
    {
        ColliderRuedaDerechaDelantera.motorTorque = Velocidad * Input.GetAxis("Vertical2");
        ColliderRuedaIzquierdaDelantera.motorTorque = Velocidad * Input.GetAxis("Vertical2");
        ColliderRuedaDerechaTrasera.steerAngle = -40 * Input.GetAxis("Horizontal2");
        ColliderRuedaIzquierdaTrasera.steerAngle = -40 * Input.GetAxis("Horizontal2");

        if (Input.GetAxis("Vertical2") == 0)
        {
            ColliderRuedaDerechaDelantera.brakeTorque = Frenar;
            ColliderRuedaIzquierdaDelantera.brakeTorque = Frenar;
        }
        else
        {
            ColliderRuedaDerechaDelantera.brakeTorque = 0;
            ColliderRuedaIzquierdaDelantera.brakeTorque = 0;
        }


    }
}

