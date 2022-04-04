using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager: MonoBehaviour
{
    public Animator GecisAnimator;


   public void ChangeScene (int deger)
    {
        StartCoroutine(GecisYap(deger));
    }

    public void Quit()
    {
        Application.Quit();
    }

    IEnumerator GecisYap (int deger)
    {
        GecisAnimator.SetTrigger("gecis");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(deger);
    }
}
