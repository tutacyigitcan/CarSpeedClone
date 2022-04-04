using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Vehicleselection : MonoBehaviour
{

    public GameObject[] Vehicles;
    public Text VehicleName;
    int ActiveVehicleIndex = 0;
    public ParticleSystem TransitionEffect;

    void Start()
    {
        Vehicles[ActiveVehicleIndex].SetActive(true);
        VehicleName.text = Vehicles[ActiveVehicleIndex].GetComponent<VehicleInformation>().VehicleName;
    }

    
    public void Forward()
    {
        if(ActiveVehicleIndex != Vehicles.Length - 1)
        {
            Vehicles[ActiveVehicleIndex].SetActive(false);
            ActiveVehicleIndex++;
            Vehicles[ActiveVehicleIndex].SetActive(true);
            VehicleName.text = Vehicles[ActiveVehicleIndex].GetComponent<VehicleInformation>().VehicleName;
            TransitionEffect.Play();
        } 
        else
        {
            Vehicles[ActiveVehicleIndex].SetActive(false);
            ActiveVehicleIndex = 0;
            Vehicles[ActiveVehicleIndex].SetActive(true);
            VehicleName.text = Vehicles[ActiveVehicleIndex].GetComponent<VehicleInformation>().VehicleName;
            TransitionEffect.Play();
        }
    }

    public void Back()
    {
        if (ActiveVehicleIndex != 0)
        {
            Vehicles[ActiveVehicleIndex].SetActive(false);
            ActiveVehicleIndex--;
            Vehicles[ActiveVehicleIndex].SetActive(true);
            VehicleName.text = Vehicles[ActiveVehicleIndex].GetComponent<VehicleInformation>().VehicleName;
            TransitionEffect.Play();
        }
        else
        {
            Vehicles[ActiveVehicleIndex].SetActive(false);
            ActiveVehicleIndex = Vehicles.Length - 1;
            Vehicles[ActiveVehicleIndex].SetActive(true);
            VehicleName.text = Vehicles[ActiveVehicleIndex].GetComponent<VehicleInformation>().VehicleName;
            TransitionEffect.Play();
        }
    }

    public void Startt()
    {
        PlayerPrefs.SetInt("SelectedVehicle", ActiveVehicleIndex);
        SceneManager.LoadScene("HaritaSecim");
    }
}
