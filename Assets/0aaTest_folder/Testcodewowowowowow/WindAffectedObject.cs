using UnityEngine;

public class WindAffectedObject : MonoBehaviour, IWindAffected
{
    public float movementSpeed = 1f; // ��������㹡������͹���ͧ�ѵ��
    private Vector2 windVelocity;

    void Update()
    {
        // ���ç��㹡������͹���ͧ�ѵ��
        transform.position += (Vector3)windVelocity * Time.deltaTime;
    }

    // Implement ���ʹ�ҡ IWindAffected
    public void ApplyWind(Vector2 windForce)
    {
        windVelocity = windForce;
    }
}
