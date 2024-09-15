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
        // Ŭ�� �� ����Ǵ� ����
        Debug.Log("������ Ŭ����");
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // �巡�װ� ���۵� �� ����Ǵ� ����
        canvasGroup.alpha = 0.6f;  // ���� ����
        canvasGroup.blocksRaycasts = false;  // �巡�� �� �ٸ� UI�� ��ȣ�ۿ� ����
    }

    public void OnDrag(PointerEventData eventData)
    {
        // �巡�� �߿� �������� ��ġ�� ������Ʈ
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // �巡�װ� ���� �� ����Ǵ� ����
        canvasGroup.alpha = 1f;  // ���� ������ ����
        canvasGroup.blocksRaycasts = true;  // ��ȣ�ۿ� �����ϰ� ����
    }
}
