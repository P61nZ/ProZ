using UnityEngine;

public class Leaf : MonoBehaviour, IWindAffected
{
    public float swayAmount = 0.1f; // �����ҡ���¢ͧ������
    public float swaySpeed = 1f; // ��������㹡�����

    private Vector3 initialPosition;
    private float swayOffset;

    void Start()
    {
        initialPosition = transform.localPosition; // �ѹ�֡���˹�������鹢ͧ����
    }

    void Update()
    {
        // ���ç��㹡���������
        swayOffset = Mathf.Sin(Time.time * swaySpeed) * swayAmount;
        // ����� Vector3 ����������˹����������С������͹���
        transform.localPosition = initialPosition + new Vector3(swayOffset, 0, 0);
    }

    // Implement ���ʹ�ҡ IWindAffected
    public void ApplyWind(Vector2 windForce)
    {
        // ���ç��㹡�û�Ѻ��Ңͧ swayAmount ��� swaySpeed ��������ç�ͧ��
        swayAmount = Mathf.Clamp(swayAmount + windForce.x * 0.01f, 0, 0.5f);
        swaySpeed = Mathf.Clamp(swaySpeed + windForce.x * 0.01f, 0.5f, 2f);
    }
}