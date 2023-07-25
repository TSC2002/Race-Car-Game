using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarContoller : MonoBehaviour
{
    public WheelCollider RuedaIzquierdaDelantera;
    public WheelCollider RuedaDerechaDelantera;
    public WheelCollider RuedaIzquierdaTrasera;
    public WheelCollider RuedaDerechaTrasera;

    public float FuerzaDelMotor;
    public float MaximaFuerzaDelMotor;

    public float GiroDeLasRuedas;
    public float MaximoGiroDeLasRuedas;

    public float Freno;
    public bool EstoyFrenando;

    public Vector3 CentroDeMasas;

    public Vector3 PosicionDeLaRueda;
    public Quaternion RotacionDeLaRueda;

    void Start()
    {
        FuerzaDelMotor = 0.0f;
        MaximaFuerzaDelMotor = 800.0f;
        GiroDeLasRuedas = 0.0f;
        MaximoGiroDeLasRuedas = 25.0f;
        CentroDeMasas = new Vector3(0.0f, 0.0f, 0.0f);
        EstoyFrenando = false;

        this.gameObject.GetComponent<Rigidbody>().centerOfMass = CentroDeMasas;
    }

    void Update()
    {
        FuerzaDelMotor = MaximaFuerzaDelMotor * Input.GetAxis("Vertical");
        GiroDeLasRuedas = MaximoGiroDeLasRuedas * Input.GetAxis("Horizontal");
        if (Input.GetButton("Jump"))
        {
            EstoyFrenando = true;
        }
        else
        {
            EstoyFrenando = false;
        }

        RuedaIzquierdaDelantera.steerAngle = GiroDeLasRuedas;
        RuedaDerechaDelantera.steerAngle = GiroDeLasRuedas;

        RuedaIzquierdaDelantera.motorTorque = FuerzaDelMotor;
        RuedaDerechaDelantera.motorTorque = FuerzaDelMotor;
        RuedaIzquierdaTrasera.motorTorque = FuerzaDelMotor;
        RuedaDerechaTrasera.motorTorque = FuerzaDelMotor;

        if (EstoyFrenando)
        {
            RuedaIzquierdaDelantera.brakeTorque = 400.0f;
            RuedaDerechaDelantera.brakeTorque = 400.0f;
            RuedaIzquierdaTrasera.brakeTorque = 400.0f;
            RuedaDerechaTrasera.brakeTorque = 400.0f;
        }
        else
        {
            RuedaIzquierdaDelantera.brakeTorque = 0.0f;
            RuedaDerechaDelantera.brakeTorque = 0.0f;
            RuedaIzquierdaTrasera.brakeTorque = 0.0f;
            RuedaDerechaTrasera.brakeTorque = 0.0f;
        }

        //Rueda Izquierda Delamtera
        Transform ruedaID = RuedaIzquierdaDelantera.gameObject.transform.GetChild(0);
        RuedaIzquierdaDelantera.GetComponent<WheelCollider>().GetWorldPose(out PosicionDeLaRueda, out RotacionDeLaRueda);
        ruedaID.transform.position = PosicionDeLaRueda;
        ruedaID.transform.rotation = RotacionDeLaRueda;

        //Rueda Derecha Delantera
        Transform ruedaDD = RuedaDerechaDelantera.gameObject.transform.GetChild(0);
        RuedaDerechaDelantera.GetComponent<WheelCollider>().GetWorldPose(out PosicionDeLaRueda, out RotacionDeLaRueda);
        ruedaDD.transform.position = PosicionDeLaRueda;
        ruedaDD.transform.rotation = RotacionDeLaRueda;

        //Rueda Izquierda Trasera
        Transform ruedaIT = RuedaIzquierdaTrasera.gameObject.transform.GetChild(0);
        RuedaIzquierdaTrasera.GetComponent<WheelCollider>().GetWorldPose(out PosicionDeLaRueda, out RotacionDeLaRueda);
        ruedaIT.transform.position = PosicionDeLaRueda;
        ruedaIT.transform.rotation = RotacionDeLaRueda;

        //Rueda Derecha Trasera
        Transform ruedaDT = RuedaDerechaTrasera.gameObject.transform.GetChild(0);
        RuedaDerechaTrasera.GetComponent<WheelCollider>().GetWorldPose(out PosicionDeLaRueda, out RotacionDeLaRueda);
        ruedaDT.transform.position = PosicionDeLaRueda;
        ruedaDT.transform.rotation = RotacionDeLaRueda;

    }
}

