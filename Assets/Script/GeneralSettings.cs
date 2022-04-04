using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;
using TMPro;


public enum MapType
{
    Race,
    Tur
}

public class GeneralSettings : MonoBehaviour
{
    public MapType MapTypee = MapType.Race;
    public GameObject[] Vehicles;
    public GameObject SpawnPoint;
    public GameObject[] AISpawnPoint;
    public GameObject[] AIVehicles;
    public AudioSource[] Sources;
    public GameObject EndGamePanel;
    

    List<GameObject> CreatedCar = new List<GameObject>();
    public TextMeshProUGUI GeriSayým;
    float second = 3f;
    bool sayac = true;
    Coroutine sayacim;

    void Start()
    {
        GettingStarted();
        sayacim = StartCoroutine(SayasController());
        Sources[0].volume = PlayerPrefs.GetFloat("menuses");
    }

    void GettingStarted()
    {
        GeriSayým.text = second.ToString();
        GameObject MyCar = Instantiate(Vehicles[PlayerPrefs.GetInt("SelectedVehicle")], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
        GameObject.FindWithTag("MainCamera").GetComponent<kameraKontrol>().target[0] = MyCar.transform.Find("PozisyonAl");
        GameObject.FindWithTag("MainCamera").GetComponent<kameraKontrol>().target[1] = MyCar.transform.Find("Pivot");
        GameObject.FindWithTag("GameController").GetComponent<KameraGecisKontrol>().kameralar[1] = MyCar.transform.Find("Kameralar/OnKaput").gameObject;
        GameObject.FindWithTag("GameController").GetComponent<KameraGecisKontrol>().kameralar[2] = MyCar.transform.Find("Kameralar/Aracici").gameObject;

        for (int i = 0; i < 3; i++)
        {
            int RandomValue = Random.Range(0, AIVehicles.Length - 1);
            GameObject ComposedVehicle = Instantiate(AIVehicles[RandomValue], AISpawnPoint[i].transform.position, AISpawnPoint[i].transform.rotation);
            ComposedVehicle.GetComponent<YapayZekaController>().SpawnPointIndex = i;
        }
    }


    public void SendYour(GameObject gelenObje)
    {       
        CreatedCar.Add(gelenObje);   
    }


    public void EndGame(int pozisyon)
    {     
        EndGamePanel.SetActive(true);
        EndGamePanel.transform.Find("Panel/sira").GetComponent<TextMeshProUGUI>().text = pozisyon.ToString() + ". Finished";
    }


    IEnumerator SayasController()
    {
        while(sayac)
        {
            yield return new WaitForSeconds(1f);
            second--;
            GeriSayým.text = Mathf.Round(second).ToString();
            Sources[1].Play();
            if (second < 0)
            {
                foreach (var vehicle in CreatedCar)
                {
                    if (vehicle.gameObject.name == "You")
                    {
                        vehicle.GetComponentInParent<CarUserControl>().enabled = true;
                    }
                    else
                    {
                        vehicle.GetComponentInParent<CarAIControl>().m_Driving = true;
                    }
                }
                GeriSayým.enabled = false;
                sayac = false;
                StopCoroutine(sayacim);
            }
        }
    }



}
