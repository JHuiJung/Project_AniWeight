using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UI_Events : MonoBehaviour
{
    [SerializeField]
    bool usePunchSacle = false;
    [SerializeField]
    Vector3 punchVec = Vector3.zero;
    [SerializeField]
    float punchTime = 0.125f;

    private void OnEnable()
    {
        if (usePunchSacle)
        {
            this.GetComponent<RectTransform>().DOPunchScale(punchVec, punchTime);
        }
    }


    public void QuitGame()
    {
#if UNITY_EDITOR
        // �����Ϳ��� ������ ������ ���� �������� ������ ����
        UnityEditor.EditorApplication.isPlaying = false;
#else
    // ����� ���ӿ��� ���ø����̼� ����
    Application.Quit();
#endif
    }
}
