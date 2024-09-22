using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMusic : MonoBehaviour
{
    public string clipName;

    private void Start()
    {
        SoundManager.Instance.ChangeMusicWithFade(clipName);
    }
}
