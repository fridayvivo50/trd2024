using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialongSys : MonoBehaviour
{
    public Text textTable;
    public TextAsset textfile;
    public float fadeDuration = 0.5f; // 渐入效果的持续时间  
    private int index = 0;
    private List<string> textList = new List<string>();
    private bool isFadingIn = false; 
    private Color initialColor;

    [Header("AboutScene")]
    [SerializeField] private bool changescene;
    [SerializeField] private int sceneNum;


    private void Awake()
    {
        GetText(textfile);
        index = 0;
        initialColor = textTable.color; 
    }

    private void OnEnable()
    {
        StartCoroutine(FadeInText(textList[index]));
        index++;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && index < textList.Count)
        {
            StopAllCoroutines();   
            textTable.color = new Color(initialColor.r, initialColor.g, initialColor.b, 0f);  
            StartCoroutine(FadeInText(textList[index]));
            index++;
        }
        else if (Input.GetKeyDown(KeyCode.F) && index == textList.Count)
        {
            if(changescene) { SceneManager.LoadScene(sceneNum); }
            FadeManager.InstanceF.FadeOut();
            gameObject.SetActive(false);
            index = 0;
        }
    }

    IEnumerator FadeInText(string text)
    {
        textTable.text = text;
        Color fadeColor = textTable.color;
        fadeColor.a = 0f; // 设置初始透明度为0  
        textTable.color = fadeColor;

        float elapsed = 0f;

        while (fadeColor.a < 1f)
        {
            elapsed += Time.deltaTime;
            fadeColor.a = Mathf.Lerp(0f, 1f, elapsed / fadeDuration);
            textTable.color = fadeColor;

            yield return null;
        }

        textTable.color = new Color(fadeColor.r, fadeColor.g, fadeColor.b, 1f); // 确保最终透明度为1  
        isFadingIn = false; // 渐入完成  
    }

    void GetText(TextAsset file)
    {
        textList.Clear();
        string[] linData = file.text.Split('\n');

        foreach (var line in linData)
        {
            textList.Add(line.Trim());
        }
    }

}
