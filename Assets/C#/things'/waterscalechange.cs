using UnityEngine;

public class ScaleUpDown : MonoBehaviour
{
    public float scaleMinX = 0.3f; // X轴最小缩放比例  
    public float scaleMaxX = 0.6f; // X轴最大缩放比例  
    public float speed = 20f;       // 缩放速度  

    private float currentScaleX = 0.4f; // X轴当前缩放比例，初始化为123  
    private bool isScalingUp = true;     // 是否正在放大  

    void Update()
    {
        // 根据缩放方向改变当前缩放比例（仅X轴，假设Y轴同步变化）  
        if (isScalingUp)
        {
            currentScaleX += speed * Time.deltaTime;
            if (currentScaleX >= scaleMaxX)
            {
                isScalingUp = false; // 达到最大缩放比例时开始缩小  
            }
        }
        else
        {
            currentScaleX -= speed * Time.deltaTime;
            if (currentScaleX <= scaleMinX)
            {
                isScalingUp = true; // 达到最小缩放比例时开始放大  
            }
        }

        // 假设Y轴与X轴同步变化（但你可以根据需要调整Y轴的值）  
        float currentScaleY = currentScaleX * (121f / 123f); // 尝试保持初始比例，但这不是必需的  

        // 但为了简单起见，我们可以让Y轴直接跟随X轴变化（如果不需要保持严格比例）  
        // float currentScaleY = currentScaleX;  

        // 应用新的缩放比例到物体的Transform组件  
        transform.localScale = new Vector3(currentScaleX, currentScaleY, 1f);
    }
}