using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smooth;

    public Vector2 minPosition;
    public Vector2 maxPosition;
    void Start()
    {
    }
    private void LateUpdate()
    {
        if (target != null)
        {
            if (transform.position != target.position)
            {
                Vector3 targetPos = target.position;
                targetPos.x = Mathf.Clamp(targetPos.x, minPosition.x, maxPosition.x);
                targetPos.y = Mathf.Clamp(targetPos.y, minPosition.y, maxPosition.y);

                transform.position = Vector3.Lerp(transform.position, targetPos, smooth);
            }
        }
    }

    public void SetCampPosLimit(Vector2 minPos, Vector2 maxPox)
    {
        minPosition = minPos;
        maxPosition = maxPox;
    }
}
