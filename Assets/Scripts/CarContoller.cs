using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarContoller : MonoBehaviour
{
    [SerializeField] private Transform RuedaIzquierdaTraseraTransform; //Con el SerializeField que se usa para modificar varias clases, uso el Transform que se usa para la Posicion, Rotacion y Escala//
    [SerializeField] private Transform RuedaDerechaTraseraTransform;
    [SerializeField] private Transform RuedaDerechaDelanteraTransform;
    [SerializeField] private Transform RuedaIzquierdaDelanteraTransform;

    [SerializeField] private WheelCollider RuedaIzquierdaTraseraCollider;
    [SerializeField] private WheelCollider RuedaDerechaTraseraCollider;
    [SerializeField] private WheelCollider RuedaDerechaDelanteraCollider;
    [SerializeField] private WheelCollider RuedaIzquierdaDelanteraCollider;

    private Rigidbody AutoRigidbody;

    public float Fuerza; //El float se usa para los numeros decimales//
    public float MaximoAngulo;
    public int MaximaVelocidad; //EL int se usa para los numeros enteros//
    public int MaximaVelocidadDeRetroceso;
    public int Freno;
    private void Start()
    {
        AutoRigidbody = GetComponent<Rigidbody>(); //El auto arranca con el Rigidbody que se le asigno//
    }

    private void FixedUpdate() //Se quiere con el FixedUpdate hacer cambios en el tiempo y que estos cambios se apliquen en intervalos regulares// 
    {
        RuedaIzquierdaTraseraCollider.motorTorque = Fuerza * Input.GetAxis("Vertical"); // Las ruedas traseras van a tener una fuerza de impulso de manera vertical al presionar la tecla//
        RuedaDerechaTraseraCollider.motorTorque = Fuerza * Input.GetAxis("Vertical");// Las ruedas traseras van a tener una fuerza de impulso de manera vertical al presionar la tecla//

        RuedaDerechaDelanteraCollider.motorTorque = MaximoAngulo * Input.GetAxis("Horizontal"); //Las ruedas delanteras van a tener un maximo angulo de manera horizontal al presionar la tecla//
        RuedaIzquierdaDelanteraCollider.motorTorque = MaximoAngulo * Input.GetAxis("Horizontal");

        if (Input.GetKey(KeyCode.Space))//Si se presiona la tecla espacio las ruedas traseras frenan
        {
            RuedaIzquierdaTraseraCollider.brakeTorque = Freno;
            RuedaDerechaTraseraCollider.brakeTorque = Freno;
        }

        else
        {
            RuedaIzquierdaTraseraCollider.brakeTorque = 0;
            RuedaDerechaTraseraCollider.brakeTorque = 0;
        }

        RotacionDelaRueda(RuedaIzquierdaTraseraCollider, RuedaIzquierdaTraseraTransform);
        RotacionDelaRueda(RuedaDerechaTraseraCollider, RuedaDerechaTraseraTransform);
        RotacionDelaRueda(RuedaDerechaDelanteraCollider, RuedaDerechaDelanteraTransform);
        RotacionDelaRueda(RuedaIzquierdaDelanteraCollider, RuedaIzquierdaDelanteraTransform);
    }

    private void RotacionDelaRueda(WheelCollider collider, Transform transform) //Se hizo este void para que este activo los colliders y los transforms//
    {
        Vector3 Posicion; //Se quiere ver la posicion en 3 dimensiones//
        Quaternion Rotacion; // Representa al Vector3 para codificar las rotaciones tridimensionales//

        collider.GetWorldPose(out Posicion, out Rotacion); //Configura la Posicion y la Rotacion a las ruedas//

        transform.rotation = Rotacion;
        transform.position = Posicion;
    }

}

