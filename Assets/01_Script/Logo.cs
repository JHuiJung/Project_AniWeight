using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Logo : MonoBehaviour
{
    public float scaleAmount = 1.5f;
    public float scaleTime = 1f;
    // Start is called before the first frame update
    void Start()
    {
        // RectTransform�� ũ�⸦ 1.5��� �����ϸ鼭 ���� ��� �ִϸ��̼�
        this.GetComponent<RectTransform>().DOScale(scaleAmount, scaleTime)
            .SetLoops(-1, LoopType.Yoyo); // ���� ����, ��� ���
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
