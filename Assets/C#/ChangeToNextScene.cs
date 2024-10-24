using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeToNextScene : MonoBehaviour
{
    [SerializeField] GameObject Text;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            ChangeScene();
        }
    }
    void ChangeScene()
    {
        FadeManager.InstanceF.FadeIn();
        Invoke(nameof(SetTextTrue), 1f);
    }

    void SetTextTrue()
    {
        if (Text != null)
        {
            Text.SetActive(true);
        }
    }
}
