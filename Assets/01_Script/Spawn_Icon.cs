using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Spawn_Icon : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private RectTransform rectTransform;
    private Canvas canvas;
    private CanvasGroup canvasGroup;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        canvasGroup = GetComponent<CanvasGroup>();

        if (canvasGroup == null)
        {
            canvasGroup = gameObject.AddComponent<CanvasGroup>();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // 클릭 시 실행되는 로직
        Debug.Log("아이콘 클릭됨");
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // 드래그가 시작될 때 실행되는 로직
        canvasGroup.alpha = 0.6f;  // 투명도 조절
        canvasGroup.blocksRaycasts = false;  // 드래그 중 다른 UI와 상호작용 방지
    }

    public void OnDrag(PointerEventData eventData)
    {
        // 드래그 중에 아이콘의 위치를 업데이트
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // 드래그가 끝날 때 실행되는 로직
        canvasGroup.alpha = 1f;  // 원래 투명도로 복귀
        canvasGroup.blocksRaycasts = true;  // 상호작용 가능하게 설정
    }
}
