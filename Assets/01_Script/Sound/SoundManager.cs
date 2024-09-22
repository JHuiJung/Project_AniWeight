using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SoundInfo
{
    public string nameSound;
    public AudioClip soundClip;

}

public class SoundManager : MonoBehaviour
{
    // �̱��� �ν��Ͻ�
    public static SoundManager Instance { get; private set; }

    public List<SoundInfo> soundInfos = new List<SoundInfo>();
    public string currentSoundName = "";
    public AudioSource musicSource; // ��� ���� �ҽ�
    public float fadeDuration = 0.5f;
    private bool m_isMuted = false;   // ���Ұ� ����
    public bool isMuted { get { return m_isMuted; } private set { m_isMuted = value;} }
    private void Awake()
    {
        // �̱��� ����
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  // �� ��ȯ �ÿ��� ����
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        ChangeMusicWithFade(currentSoundName);
    }
    // ���� ���̵� �ƿ� �Լ�
    public IEnumerator FadeOutMusic()
    {
        float startVolume = musicSource.volume;

        while (musicSource.volume > 0)
        {
            musicSource.volume -= startVolume * Time.deltaTime / fadeDuration;
            yield return null;
        }

        musicSource.Stop();
        musicSource.volume = startVolume;  // ���� �������� ����
    }

    // ���� ���̵� �� �Լ�
    public IEnumerator FadeInMusic(AudioClip newClip)
    {
        musicSource.clip = newClip;
        musicSource.Play();
        musicSource.volume = 0f;

        while (musicSource.volume < 1f)
        {
            musicSource.volume += Time.deltaTime / fadeDuration;
            yield return null;
        }
    }

    // ���Ұ� ��� �Լ�
    public void ToggleMute()
    {
        isMuted = !isMuted;
        AudioListener.volume = isMuted ? 0 : 1; // ��ü ���� ����
    }

    // ��� ���� ��ü �� ���̵� ��/�ƿ� ����
    public void ChangeMusicWithFade(string clipName)
    {
        if(currentSoundName == clipName)
        {
            return;
        }


        StartCoroutine(FadeOutAndChangeMusic(GetAudioClip(clipName), fadeDuration));
    }

    AudioClip GetAudioClip(string _name)
    {
        foreach(SoundInfo info in soundInfos)
        {
            if(info.nameSound == _name)
            {
                currentSoundName = info.nameSound;
                return info.soundClip;
            }
        }

        return null;
    }

    private IEnumerator FadeOutAndChangeMusic(AudioClip newClip, float fadeDuration)
    {
        // ���� ���� ���̵� �ƿ�
        yield return StartCoroutine(FadeOutMusic());
        // �� ���� ���̵� ��
        yield return StartCoroutine(FadeInMusic(newClip));
    }
}
