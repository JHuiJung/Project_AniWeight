using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
{
    public float detectionRadius = 3f; // Ž���� �ݰ�
    public LayerMask detectionLayer;   // Ž���� ���̾� (�ʿ� �� ����)
    public float Total_Weight = 0f;
    void Update()
    {
        // A ������Ʈ�� ���� ��ġ
        Vector2 currentPosition = transform.position;

        // 3���� �ݰ� ���� �ִ� �ݶ��̴����� ������
        
        Collider2D[] nearbyObjects = Physics2D.OverlapCircleAll(currentPosition, detectionRadius, detectionLayer);
        
        float totalWeight = 0f;
        
        // Ž���� ������Ʈ���� �ִ��� Ȯ���ϰ� ���
        foreach (Collider2D obj in nearbyObjects)
        {
            if (obj.gameObject != gameObject) // �ڱ� �ڽ��� ����
            {
                AniBall ani = obj.gameObject.GetComponent<AniBall>();

                if (ani != null)
                {
                    totalWeight += ani.Weight;
                }

            }
        }

        Total_Weight = totalWeight;
    }

    // Gizmos�� ����� 3���� Ž�� ������ �ð������� ǥ�� (������ Ȯ�� ����)
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
