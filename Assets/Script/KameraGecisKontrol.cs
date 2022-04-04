using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraGecisKontrol : MonoBehaviour
{
    public GameObject[] kameralar;
    int aktifkamera=0;
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            KameralariKapat();
            aktifkamera++;     
            
            if (aktifkamera > kameralar.Length-1)
            {
                aktifkamera = 0;
               
            }            

            kameralar[aktifkamera].SetActive(true);
                     

        }
        
    }

    void KameralariKapat()
    {

        foreach (var cam in kameralar)
        {
            cam.SetActive(false);
        }

    }
}
