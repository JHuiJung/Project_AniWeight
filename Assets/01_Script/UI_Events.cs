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

    [Space(10),SerializeField]
    bool useParticle = false;
    [SerializeField]
    ParticleSystem ptcSystem = null;

    private void OnEnable()
    {
        if (usePunchSacle)
        {
            this.GetComponent<RectTransform>().DOPunchScale(punchVec, punchTime);
        }

        if(useParticle)
        {
            ptcSystem.Play();
        }
    }


    public void QuitGame()
    {
#if UNITY_EDITOR
        // 에디터에서 게임을 종료할 때는 에디터의 실행을 중지
        UnityEditor.EditorApplication.isPlaying = false;
#else
    // 빌드된 게임에서 애플리케이션 종료
    Application.Quit();
#endif
    }
}
