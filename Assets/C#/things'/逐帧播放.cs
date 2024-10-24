using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tengman : MonoBehaviour
{
    public Sprite[] textures; // 存储所有纹理的数组  
    private SpriteRenderer spriteRenderer;
    private float timer = 0.0f; // 计时器  
    public float changeInterval = 1.0f; // 纹理更换的时间间隔  
    private int currentIndex = 0; // 当前纹理的索引  

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // 获取SpriteRenderer组件  
        if (textures.Length == 0)
        {
            Debug.LogError("No textures assigned to the coin!");
            return;
        }
        spriteRenderer.sprite = textures[currentIndex]; // 设置初始纹理  
    }

    void Update()
    {
        timer += Time.deltaTime; // 更新计时器  
        if (timer >= changeInterval)
        {
            currentIndex++; // 增加纹理索引  
            if (currentIndex >= textures.Length) // 如果索引超出数组长度，重置为0  
            {
                currentIndex = 0;
            }
            spriteRenderer.sprite = textures[currentIndex]; // 更换纹理  
            timer = 0.0f; // 重置计时器  
        }
    }

    /*void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            this.gameObject.SetActive(false);
        }
    }*/

}
