using UnityEngine;

public class WindManager : MonoBehaviour
{
    public Vector2 windDirection = new Vector2(1, 0); // ��ȷҧ�ͧ��
    public float windStrength = 5f; // �����ç�ͧ��

    void Update()
    {
        // �� FindObjectsOfType<T>() ᷹ FindObjectsByType<T>()
        foreach (var windAffected in UnityEngine.Object.FindObjectsOfType<MonoBehaviour>())
        {
            if (windAffected is IWindAffected)
            {
                IWindAffected affectedObject = (IWindAffected)windAffected;
                affectedObject.ApplyWind(windDirection * windStrength * Time.deltaTime);
            }
        }
    }
}