using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leafdown : MonoBehaviour
{
    public float fallSpeed = 2f;  // 下落速度
    public float horizontalSpeed = 1f;  // 向左移动的速度
    public float targetHeight = -5f;  // 达到这个高度时消失
    public float respawnDelay = 2f;  // 重新下落前的冷却时间
    private Vector3 startPosition;  // 物体初始位置
    private SpriteRenderer spriteRenderer;  // 控制物体显示/隐藏

    void Start()
    {
        // 记录物体的初始位置
        startPosition = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
        // 开始协程
        StartCoroutine(FallAndRespawn());
    }

    IEnumerator FallAndRespawn()
    {
        while (true)
        {
            // 让物体向左下方飘落
            while (transform.position.y > targetHeight)
            {
                Vector3 movement = new Vector3(-horizontalSpeed * Time.deltaTime, -fallSpeed * Time.deltaTime, 0);
                transform.Translate(movement);
                yield return null;  // 等待下一帧
            }

            // 隐藏物体
            spriteRenderer.enabled = false;

            // 等待冷却时间
            yield return new WaitForSeconds(respawnDelay);

            // 恢复物体到初始位置并重新显示
            transform.position = startPosition;
            spriteRenderer.enabled = true;
        }
    }
}
