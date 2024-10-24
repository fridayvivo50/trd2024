using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject Text;
    public void PlayGame()
    {
        FadeManager.InstanceF.FadeIn();
        Text.SetActive(true);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
