using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeToNextScene : MonoBehaviour
{
    [SerializeField] GameObject Text;
    [SerializeField] GameObject LoseText;
    [SerializeField] int AimBookNum = 3;
    Player Player;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if (Player.clarityLevel > Player.confusionLevel && Player.book >= AimBookNum)
            {
                ChangeScene();
            }
            else
            {
                Lose();
            }
        }
    }
    void ChangeScene()
    {
        FadeManager.InstanceF.FadeIn();
        Invoke(nameof(SetTextTrue), 1f);
    }

    void Lose()
    {
        FadeManager.InstanceF.FadeIn();
        Invoke(nameof(SetLoseTextTrue), 1f);
    }

    void SetTextTrue()
    {
        if (Text != null)
        {
            Text.SetActive(true);
        }
    }void SetLoseTextTrue()
    {
        if (LoseText != null)
        {
            LoseText.SetActive(true);
        }
    }

}
