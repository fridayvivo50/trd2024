using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coindown : MonoBehaviour
{
    public float fallSpeed = 2f;  // 下落速度
    public float targetHeight = -7f;  // 达到这个高度时消失
    public float respawnDelay = 3f;  // 重新下落前的冷却时间
    private Vector3 startPosition;  // 物体初始位置
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        // 记录物体的初始位置
        startPosition = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
        // 开始下落协程
        StartCoroutine(FallAndRespawn());
    }

    IEnumerator FallAndRespawn()
    {
        while (true)
        {
            // 让物体缓慢下落
            while (transform.position.y > targetHeight)
            {
                transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);
                yield return null;  // 等待下一帧
            }

            // 隐藏物体而不是禁用它
            spriteRenderer.enabled = false;

            // 等待冷却时间
            yield return new WaitForSeconds(respawnDelay);

            // 恢复物体到初始位置并重新显示
            transform.position = startPosition;
            spriteRenderer.enabled = true;
        }
    }
}
