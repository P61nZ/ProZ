using UnityEngine;

public class GrassSlow : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        // ��Ǩ�ͺ��� Collider �������� Trigger �� tag ��� "Player" �������
        if (other.CompareTag("Player"))
        {
            // ����觷���ͧ�������� Player ����㹾�鹷�� Trigger
            Debug.Log("Player is staying in the trigger area!");

            // ������ҧ��á�з� ��: Ŵ��ѧ���Ե, ������ṹ, ��������¹ʶҹ�
            // Example: Reduce player health
            // other.GetComponent<PlayerHealth>().ReduceHealth(1);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
