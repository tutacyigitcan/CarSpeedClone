using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class Ranking : MonoBehaviour
{

    public int AktifYonSırası = 1;
    RankingController Rankings;
    LapController LapController;
    GeneralSettings GeneralSettings;
    public int pozisyon;
    public int LapStep;




    void Start()
    {
        LapStep = 1;
        GeneralSettings = GameObject.FindWithTag("GameController").GetComponent<GeneralSettings>();
        GeneralSettings.SendYour(gameObject);


        if(GeneralSettings.MapTypee.ToString() == "Tur")
        {
            LapController = GameObject.FindWithTag("GameController").GetComponent<LapController>();
         
        }
        else
        {
            Rankings = GameObject.FindWithTag("GameController").GetComponent<RankingController>();
            Rankings.SendYour(gameObject, AktifYonSırası);
        }   
    }




    private void OnTriggerEnter(Collider other)
    {

        if (GeneralSettings.MapTypee.ToString() == "Race")
        {
            if (other.CompareTag("GidisYonuObje"))
            {
                AktifYonSırası = int.Parse(other.transform.gameObject.name);
                Rankings.RankingUpdate(gameObject, AktifYonSırası);
            }

        }
       
       
        if(gameObject.name =="You")
        {
            if (other.CompareTag("Finish"))
            {
                if (GeneralSettings.MapTypee.ToString() == "Tur")
                {
                    GetComponentInParent<CarController>().YonGidisIndex = 0;
                    AktifYonSırası = 1;

                    if(LapStep<3)
                    {
                        LapStep++;
                        LapController.LapControlet(LapStep);
                    }
                    else
                    {
                        LapController.LepYour(gameObject);
                        GeneralSettings.EndGame(pozisyon);
                    }


                   

                }
                else
                {
                    GeneralSettings.EndGame(pozisyon);
                }
               
            }
        }  
    }

  
}
