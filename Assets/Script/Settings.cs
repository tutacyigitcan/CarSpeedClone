using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public Slider menuSoundsSlider;
    public Slider gameSoundsSlider;
    AudioSource menusesi;
    public Dropdown KaliteSecenekleri;

    void Start()
    {
        menusesi = GameObject.Find("GameController").GetComponent<AudioSource>();
        menuSoundsSlider.value = PlayerPrefs.GetFloat("menuses");
        gameSoundsSlider.value = PlayerPrefs.GetFloat("oyunses");
        KaliteSecenekleri.value = PlayerPrefs.GetInt("Kalite");
    }

    
    void Update()
    {
        
    }

    public void MenuSoundsChange()
    {
        PlayerPrefs.SetFloat("menuses", menuSoundsSlider.value);
        menusesi.volume = PlayerPrefs.GetFloat("menuses");
    }

    public void GameSoundsChange()
    {
        PlayerPrefs.SetFloat("oyunses", gameSoundsSlider.value);
    }

    public void GraphicoOptions(int secilmiskalite)
    {
        PlayerPrefs.SetInt("Kalite", secilmiskalite);

        QualitySettings.SetQualityLevel(secilmiskalite);

    }


}
