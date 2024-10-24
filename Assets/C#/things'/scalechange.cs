using UnityEngine;

public class ScaleUpDown : MonoBehaviour
{
    public float scaleMinX = 0.3f; // X����С���ű���  
    public float scaleMaxX = 0.6f; // X��������ű���  
    public float speed = 20f;       // �����ٶ�  

    private float currentScaleX = 0.4f; // X�ᵱǰ���ű�������ʼ��Ϊ123  
    private bool isScalingUp = true;     // �Ƿ����ڷŴ�  

    void Update()
    {
        // �������ŷ���ı䵱ǰ���ű�������X�ᣬ����Y��ͬ���仯��  
        if (isScalingUp)
        {
            currentScaleX += speed * Time.deltaTime;
            if (currentScaleX >= scaleMaxX)
            {
                isScalingUp = false; // �ﵽ������ű���ʱ��ʼ��С  
            }
        }
        else
        {
            currentScaleX -= speed * Time.deltaTime;
            if (currentScaleX <= scaleMinX)
            {
                isScalingUp = true; // �ﵽ��С���ű���ʱ��ʼ�Ŵ�  
            }
        }

        // ����Y����X��ͬ���仯��������Ը�����Ҫ����Y���ֵ��  
        float currentScaleY = currentScaleX * (121f / 123f); // ���Ա��ֳ�ʼ���������ⲻ�Ǳ����  

        // ��Ϊ�˼���������ǿ�����Y��ֱ�Ӹ���X��仯���������Ҫ�����ϸ������  
        // float currentScaleY = currentScaleX;  

        // Ӧ���µ����ű����������Transform���  
        transform.localScale = new Vector3(currentScaleX, currentScaleY, 1f);
    }
}