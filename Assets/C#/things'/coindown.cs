using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coindown : MonoBehaviour
{
    public float fallSpeed = 2f;  // �����ٶ�
    public float targetHeight = -7f;  // �ﵽ����߶�ʱ��ʧ
    public float respawnDelay = 3f;  // ��������ǰ����ȴʱ��
    private Vector3 startPosition;  // �����ʼλ��
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        // ��¼����ĳ�ʼλ��
        startPosition = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
        // ��ʼ����Э��
        StartCoroutine(FallAndRespawn());
    }

    IEnumerator FallAndRespawn()
    {
        while (true)
        {
            // �����建������
            while (transform.position.y > targetHeight)
            {
                transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);
                yield return null;  // �ȴ���һ֡
            }

            // ������������ǽ�����
            spriteRenderer.enabled = false;

            // �ȴ���ȴʱ��
            yield return new WaitForSeconds(respawnDelay);

            // �ָ����嵽��ʼλ�ò�������ʾ
            transform.position = startPosition;
            spriteRenderer.enabled = true;
        }
    }
}
