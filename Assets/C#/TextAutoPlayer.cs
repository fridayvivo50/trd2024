using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class TextAutoPlayer : MonoBehaviour
{
    public Text textDisplay;
    public TextAsset textFile;
    public float displayDuration = 3f; // 每段文字显示的时间  
    public float fadeDuration = 0.5f;  // 渐入/渐出效果的持续时间  
    private string[] textLines;
    private int currentIndex = -1; // 初始化为-1，以便在第一次时触发渐入  
    private bool isFading = false;
    private bool isDisplaying;
    private bool isFirstRun = true; // 标记是否是首次运行  
    private bool allTextPlayed = false; // 标记是否所有文字都已播放完毕  

    private void OnEnable()
    {
        if (textFile != null && textDisplay != null)
        {
            textLines = textFile.text.Split('\n').Where(line => !string.IsNullOrWhiteSpace(line)).ToArray();
            if (textLines.Length > 0)
            {
                StartCoroutine(DisplayText());
            }
            else
            {
                //Debug.LogError("TextAsset is empty or contains only whitespace lines!");
            }
        }
        else
        {
            //Debug.LogError("TextAsset or Text component is not assigned!");
        }
    }

    private IEnumerator DisplayText()
    {
        while (currentIndex < textLines.Length - 1 || !allTextPlayed) 
        {
            if (!isFading)
            {
                if (isFirstRun && currentIndex == -1)
                {
                    // 首次运行时，从第一段文字开始渐入  
                    StartCoroutine(FadeInText(textLines[0]));
                    currentIndex = 0;
                    isFirstRun = false;
                }
                else
                {
                    // 非首次运行或已经渐入过第一段文字后，等待显示时间  
                    float displayTimeElapsed = 0f;
                    while (displayTimeElapsed < displayDuration && !isFading)
                    {
                        displayTimeElapsed += Time.deltaTime;
                        yield return null;
                    }

                    // 显示时间结束后，开始渐出效果  
                    if (!isFading)
                    {
                        StartCoroutine(FadeOutText());
                    }
                }
            }

            // 等待渐出效果完成  
            while (isFading)
            {
                yield return null;
            }

            // 渐出效果完成后，如果是最后一段文字，则设置allTextPlayed为true并结束循环  
            if (currentIndex < textLines.Length - 1)
            {
                StartCoroutine(FadeInText(textLines[currentIndex + 1]));
                currentIndex++;
            }
            else
            {
                // 最后一段文字，只渐入不显示下一段  
                StartCoroutine(FadeInText(textLines[currentIndex]));
                allTextPlayed = true; 
                gameObject.SetActive(false);  

            }
        }
    }

    private IEnumerator FadeOutText()
    {
        isFading = true;
        Color fadeColor = textDisplay.color;
        float elapsed = 0f;

        while (fadeColor.a > 0f)
        {
            elapsed += Time.deltaTime;
            fadeColor.a = Mathf.Lerp(1f, 0f, elapsed / fadeDuration);
            textDisplay.color = fadeColor;

            yield return null;
        }

        textDisplay.color = new Color(fadeColor.r, fadeColor.g, fadeColor.b, 0f); // 确保最终透明度为0  
        isFading = false;
        isDisplaying = false; // 重置显示状态  
    }

    private IEnumerator FadeInText(string text)
    {
        textDisplay.text = text;
        Color fadeColor = textDisplay.color;
        fadeColor.a = 0f; // 设置初始透明度为0  
        textDisplay.color = fadeColor;

        float elapsed = 0f;

        while (fadeColor.a < 1f)
        {
            elapsed += Time.deltaTime;
            fadeColor.a = Mathf.Lerp(0f, 1f, elapsed / fadeDuration);
            textDisplay.color = fadeColor;

            yield return null;
        }

        textDisplay.color = new Color(fadeColor.r, fadeColor.g, fadeColor.b, 1f); // 确保最终透明度为1  
        isFading = false; // 渐入完成  
    }
}
