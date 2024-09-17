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
        // RectTransform의 크기를 1.5배로 변경하면서 무한 요요 애니메이션
        this.GetComponent<RectTransform>().DOScale(scaleAmount, scaleTime)
            .SetLoops(-1, LoopType.Yoyo); // 무한 루프, 요요 모드
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
