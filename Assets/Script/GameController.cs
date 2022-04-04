using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    AudioSource menusesi;
    private static GameController gameControllerinstance;


    private void Awake()
    {
        DontDestroyOnLoad(this);

        if(gameControllerinstance == null)
        {
            gameControllerinstance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }


    void Start()
    {
        menusesi = GetComponent<AudioSource>();

        if (PlayerPrefs.HasKey("menuses"))
        {
            menusesi.volume = PlayerPrefs.GetFloat("menuses");
            QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("Kalite"));
        }
        else
        {
            // The game opens for the first time
            PlayerPrefs.SetFloat("menuses", 1);
            PlayerPrefs.SetFloat("oyunses", 1);
            PlayerPrefs.SetInt("Kalite", 3);
        }
    }

    
    void Update()
    {
        
    }
}
