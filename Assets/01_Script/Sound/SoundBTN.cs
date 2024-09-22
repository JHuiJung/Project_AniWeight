using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundBTN : MonoBehaviour
{
    public GameObject sp_SoundOn;
    public GameObject sp_SoundOff;

    public void ToggleMute()
    {
        SoundManager.Instance.ToggleMute();
        ChangeImg();
    }

    void ChangeImg()
    {
        if (SoundManager.Instance.isMuted)
        {
            sp_SoundOn.SetActive(false);
            sp_SoundOff.SetActive(true);
        }
        else
        {
            sp_SoundOn.SetActive(true);
            sp_SoundOff.SetActive(false);
        }
    }

    private void Start()
    {
        ChangeImg();
    }
}
