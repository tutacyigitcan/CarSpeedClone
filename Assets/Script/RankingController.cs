using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class Vehicle
{
    public GameObject gelenObje;
    public int Poz;
    public Vehicle(GameObject disgelenObje,int dispoz)
    {
        gelenObje = disgelenObje;
        Poz = dispoz;
    }
}


public class RankingController : MonoBehaviour
{

    public List<Vehicle> Vehicles = new List<Vehicle>();
    public TextMeshProUGUI ranking;

    public void SendYour(GameObject gelenObje, int aktifyonu)
    {
        Vehicles.Add(new Vehicle(gelenObje,aktifyonu));

        if(Vehicles.Count == 4)
        {
            _RankingController();
        }


    }

    public void RankingUpdate(GameObject gelenaraba, int Pozisyon)
    {
        for (int i = 0; i < Vehicles.Count; i++)
        {
            if(Vehicles[i].gelenObje==gelenaraba)
            {
                Vehicles[i].Poz = Pozisyon;
            }
        }
        _RankingController();
    }

    public void _RankingController()
    {
        Vehicles = Vehicles.OrderBy(w => w.Poz).ToList();
        ranking.text = "";

        for (int i = 0; i < Vehicles.Count; i++)
        {
            switch(i)
            {
                case 0:
                    if (Vehicles[i].gelenObje.name == "You")
                    {
                        ranking.text = "4/4";
                        Vehicles[i].gelenObje.GetComponent<Ranking>().pozisyon = 4;
                    }
                    break;
                case 1:
                    if (Vehicles[i].gelenObje.name == "You")
                    {
                        ranking.text = "3/4";
                        Vehicles[i].gelenObje.GetComponent<Ranking>().pozisyon = 3;
                    }
                    break;
                case 2:
                    if (Vehicles[i].gelenObje.name == "You")
                    {
                        ranking.text = "2/4";
                        Vehicles[i].gelenObje.GetComponent<Ranking>().pozisyon = 2;
                    }
                    break;
                case 3:
                    if (Vehicles[i].gelenObje.name == "You")
                    {
                        ranking.text = "1/4";
                        Vehicles[i].gelenObje.GetComponent<Ranking>().pozisyon = 1;
                    }
                    break;


            }
        }



        /* foreach (var Vehicle in Vehicles)
        {
            ranking.text += Vehicle.gelenObje.name + "=" + Vehicle.Poz + "<br>"; 
        } */
    }


   
}
