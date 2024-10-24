using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class good1 : MonoBehaviour
{
    private CircleCollider2D thing;
    [SerializeField] private GameObject Text;
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
        // 判断碰撞的对象是否是标签为"Player"的对象
        if (collision.gameObject.CompareTag("Player"))
        {
            if(Text!= null)
            {
                Text.SetActive(true);
            }
            // 设置当前物体为不可见或无效
            gameObject.SetActive(false);  // 将自身设为无效
        }
    }
}
