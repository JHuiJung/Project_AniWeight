using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
{
    public float detectionRadius = 3f; // 탐지할 반경
    public LayerMask detectionLayer;   // 탐지할 레이어 (필요 시 설정)
    public float Total_Weight = 0f;
    void Update()
    {
        // A 오브젝트의 현재 위치
        Vector2 currentPosition = transform.position;

        // 3미터 반경 내에 있는 콜라이더들을 가져옴
        
        Collider2D[] nearbyObjects = Physics2D.OverlapCircleAll(currentPosition, detectionRadius, detectionLayer);
        
        float totalWeight = 0f;
        
        // 탐지된 오브젝트들이 있는지 확인하고 출력
        foreach (Collider2D obj in nearbyObjects)
        {
            if (obj.gameObject != gameObject) // 자기 자신을 제외
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

    // Gizmos를 사용해 3미터 탐지 범위를 시각적으로 표시 (씬에서 확인 가능)
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
