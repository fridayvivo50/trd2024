using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;  
    public float smooth;
    public Vector2 minPosition; 
    public Vector2 maxPosition; 
    private float fixedY; 


    void Start()
    {
        fixedY = transform.position.y;
    }

    private void LateUpdate()
    {
        if (target != null)
        {
            // 如果相机位置与目标位置不同，进行平滑跟随
            if (transform.position.x != target.position.x)
            {
                Vector3 targetPos = new Vector3(target.position.x, fixedY, transform.position.z);

                targetPos.x = Mathf.Clamp(targetPos.x, minPosition.x, maxPosition.x);

                transform.position = Vector3.Lerp(transform.position, targetPos, smooth);
            }
        }
    }

    //边界
    public void SetCampPosLimit(Vector2 minPos, Vector2 maxPox)
    {
        minPosition = minPos;
        maxPosition = maxPox;
    }
}
