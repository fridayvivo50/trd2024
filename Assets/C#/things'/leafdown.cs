using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leafdown : MonoBehaviour
{
    public float fallSpeed = 2f;  // �����ٶ�
    public float horizontalSpeed = 1f;  // �����ƶ����ٶ�
    public float targetHeight = -5f;  // �ﵽ����߶�ʱ��ʧ
    public float respawnDelay = 2f;  // ��������ǰ����ȴʱ��
    private Vector3 startPosition;  // �����ʼλ��
    private SpriteRenderer spriteRenderer;  // ����������ʾ/����

    void Start()
    {
        // ��¼����ĳ�ʼλ��
        startPosition = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
        // ��ʼЭ��
        StartCoroutine(FallAndRespawn());
    }

    IEnumerator FallAndRespawn()
    {
        while (true)
        {
            // �����������·�Ʈ��
            while (transform.position.y > targetHeight)
            {
                Vector3 movement = new Vector3(-horizontalSpeed * Time.deltaTime, -fallSpeed * Time.deltaTime, 0);
                transform.Translate(movement);
                yield return null;  // �ȴ���һ֡
            }

            // ��������
            spriteRenderer.enabled = false;

            // �ȴ���ȴʱ��
            yield return new WaitForSeconds(respawnDelay);

            // �ָ����嵽��ʼλ�ò�������ʾ
            transform.position = startPosition;
            spriteRenderer.enabled = true;
        }
    }
}
