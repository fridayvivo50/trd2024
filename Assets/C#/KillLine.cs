using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillLine : MonoBehaviour
{
    [SerializeField] private float MaxDis;
    [SerializeField] private float MinDis;
    private float MaxSpeed;
    private float MinSpeed;


    private Rigidbody2D rb;
    private GameObject Player;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        MaxSpeed = Player.GetComponent<Player>().runSpeed;
        MinSpeed = MaxSpeed * 0.5f;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float dis = Player.transform.position.x - transform.position.x;
        if(dis >= MaxDis)
        {
            rb.velocity = new Vector2(MaxSpeed, 0f);
        }
        else if (dis < MaxDis && dis >= MinDis)
        {
            float temppersent = (dis - MinDis) / (MaxDis - MinDis);
            float tempAddSpeed = (MaxSpeed - MinSpeed) * temppersent;
            rb.velocity = new Vector2(MinSpeed + tempAddSpeed, 0f);
        }
        else if(dis <MinDis && dis >= 0)
        {
            rb.velocity = new Vector2(MinSpeed, 0f);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
 

    }
}
