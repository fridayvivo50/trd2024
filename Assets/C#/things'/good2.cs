using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class good2 : MonoBehaviour
{
    private CircleCollider2D thing;
    // Start is called before the first frame update
    void Start()
    {
        thing = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collide");
        // �ж���ײ�Ķ����Ƿ��Ǳ�ǩΪ"Player"�Ķ���
        if (collision.gameObject.CompareTag("Player"))
        {
            // ���õ�ǰ����Ϊ���ɼ�����Ч
            gameObject.SetActive(false);  // ��������Ϊ��Ч
        }
    }
}
