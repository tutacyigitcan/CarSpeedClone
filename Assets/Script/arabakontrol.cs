using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum Axel
{
    Front,
    Rear

}

[Serializable]
public struct Wheel
{

    public GameObject model;
    public WheelCollider collider;
    public Axel axel;

}

public class arabakontrol : MonoBehaviour
{
    [SerializeField]
    private float MaksimumHizlanma = 200f;
    [SerializeField]
    private float donusHassasiyeti = 1f;
    [SerializeField]
    private float MaksimumDonusAcisi = 45f;
    [SerializeField]
    private int FrenGucu;
    [SerializeField]
    private int HizlanmaDerecesi;   
    private Vector3 centerOfMass = new Vector3(0f,0.13f,0f);
    [SerializeField]
    private List<Wheel> wheels;   

    private float inputX, inputY;

    

   /* public GameObject ArkaFar;
    public Material[] ArkaFarMateryaller;*/

    public GameObject[] ArkaFarisiklari;
    public GameObject[] OnFarisiklari;
    bool OnfarAcikmi;


    void Start()
    {
        OnfarAcikmi = false;
        GetComponent<Rigidbody>().centerOfMass = centerOfMass;
    }
    private void LateUpdate()
    {
        Move();
        Turn();
        FrenYap();
    }


   
    void Update()
    {

        Tekerlerindonusu();
        HareketYonu();

        if (Input.GetKeyDown(KeyCode.Q))
        {
            OnfarAcikmi = !OnfarAcikmi;

           /* OnFarisiklari[0].SetActive(OnfarAcikmi);
            OnFarisiklari[1].SetActive(OnfarAcikmi);*/
            foreach (var isiklar in OnFarisiklari)
            {
                isiklar.SetActive(OnfarAcikmi);
            }

        }
    }

    void HareketYonu()
    {

        inputX = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Vertical");
    }

    private void Move()
    {

        foreach (var wheel in wheels)
        {
            wheel.collider.motorTorque = inputY * MaksimumHizlanma * HizlanmaDerecesi * Time.deltaTime;
        }
        
    }

    void Turn()
    {

        foreach (var wheel in wheels)
        {

            if (wheel.axel == Axel.Front)
            {
                var _steerAngle = inputX * donusHassasiyeti * MaksimumDonusAcisi;

                wheel.collider.steerAngle = Mathf.Lerp(wheel.collider.steerAngle, _steerAngle, .1f);


            }

           


        }
    }

    void Tekerlerindonusu()
    {
        foreach (var wheel in wheels)
        {

            Quaternion _rot;
            Vector3 _pos;
            wheel.collider.GetWorldPose(out _pos, out _rot);
            wheel.model.transform.position = _pos;
            wheel.model.transform.rotation = _rot;

        }
    }

    void FrenYap()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //  ArkaFar.GetComponent<MeshRenderer>().material = ArkaFarMateryaller[1];

           foreach (var isiklar in ArkaFarisiklari)
            {
                isiklar.SetActive(true);
            }

            foreach (var wheel in wheels)
            {
                wheel.collider.brakeTorque = FrenGucu;
            }

        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            //   ArkaFar.GetComponent<MeshRenderer>().material = ArkaFarMateryaller[0];
            foreach (var isiklar in ArkaFarisiklari)
            {
                isiklar.SetActive(false);
            }
            foreach (var wheel in wheels)
            {
                wheel.collider.brakeTorque = 0;
            }

        }
    }
}
