using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;



public class LapController : MonoBehaviour
{

    public List<GameObject> Vehicles = new List<GameObject>();
    public TextMeshProUGUI ranking;

    private void Start()
    {
        ranking.text =  "1/3";
    }


    public void LepYour(GameObject gelenObje)
    {
        if(gelenObje.name == "You")
        {
            gelenObje.GetComponent<Ranking>().pozisyon = Vehicles.Count() + 1;
        } 
        else
        {
            Vehicles.Add((gelenObje));
        }

    }



    public void LapControlet(int lapstep)
    {
        ranking.text = lapstep + "/3";
    }
   
}
