using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MapController : MonoBehaviour
{
    string SecilmisOlanHarita;
    public Button StartButton;
    public GameObject LoadingPanel;
    public Slider LoadingSlider;

    public void SelectedMap(string MapName)
    {
        SecilmisOlanHarita = MapName;
        Debug.Log(MapName);
    }

    private void Update()
    {
        if(SecilmisOlanHarita != null) 
        {
            StartButton.interactable = true;
        }
    }


    public void Startt()
    {
        StartCoroutine(LoadingScene(SecilmisOlanHarita));

        SceneManager.LoadScene(SecilmisOlanHarita);
    }

    IEnumerator LoadingScene(string MapName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(MapName);
        LoadingPanel.SetActive(true);
        while(!operation.isDone)
        {
            float ilerleme = Mathf.Clamp01(operation.progress / .9f);
            LoadingSlider.value = ilerleme;
            yield return null;
        }
    }


}
