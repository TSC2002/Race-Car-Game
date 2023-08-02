using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarContoller : MonoBehaviour
{
    public WheelCollider ColliderRuedaDerechaDelantera;
    public WheelCollider ColliderRuedaIzquierdaDelantera;
    public WheelCollider ColliderRuedaDerechaTrasera;
    public WheelCollider ColliderRuedaIzquierdaTrasera;

    public Transform TransformRuedaDerechaDelantera;
    public Transform TransformRuedaIzquierdaDelantera;

    public int Velocidad;
    public int Frenar;

   
    void Start()
    {
        
    }

    void Update()
    {
        TransformRuedaDerechaDelantera.localEulerAngles = new Vector3(0, ColliderRuedaDerechaTrasera.steerAngle, 0);
        TransformRuedaIzquierdaDelantera.localEulerAngles = new Vector3(0, ColliderRuedaIzquierdaTrasera.steerAngle, 0);
    }


void FixedUpdate()
    {
        ColliderRuedaDerechaDelantera.motorTorque = Velocidad * Input.GetAxis("Vertical");
        ColliderRuedaIzquierdaDelantera.motorTorque = Velocidad * Input.GetAxis("Vertical");
        ColliderRuedaDerechaTrasera.steerAngle = -40 * Input.GetAxis("Horizontal");
        ColliderRuedaIzquierdaTrasera.steerAngle = -40 * Input.GetAxis("Horizontal");

        if(Input.GetAxis("Vertical") == 0)
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

