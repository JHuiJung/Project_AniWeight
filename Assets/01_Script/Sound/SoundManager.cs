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
    // 싱글톤 인스턴스
    public static SoundManager Instance { get; private set; }

    public List<SoundInfo> soundInfos = new List<SoundInfo>();
    public string currentSoundName = "";
    public AudioSource musicSource; // 배경 음악 소스
    public float fadeDuration = 0.5f;
    private bool m_isMuted = false;   // 음소거 상태
    public bool isMuted { get { return m_isMuted; } private set { m_isMuted = value;} }
    private void Awake()
    {
        // 싱글톤 구현
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  // 씬 전환 시에도 유지
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
    // 음악 페이드 아웃 함수
    public IEnumerator FadeOutMusic()
    {
        float startVolume = musicSource.volume;

        while (musicSource.volume > 0)
        {
            musicSource.volume -= startVolume * Time.deltaTime / fadeDuration;
            yield return null;
        }

        musicSource.Stop();
        musicSource.volume = startVolume;  // 원래 볼륨으로 복구
    }

    // 음악 페이드 인 함수
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

    // 음소거 토글 함수
    public void ToggleMute()
    {
        isMuted = !isMuted;
        AudioListener.volume = isMuted ? 0 : 1; // 전체 볼륨 조절
    }

    // 즉시 음악 교체 후 페이드 인/아웃 예시
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
        // 현재 음악 페이드 아웃
        yield return StartCoroutine(FadeOutMusic());
        // 새 음악 페이드 인
        yield return StartCoroutine(FadeInMusic(newClip));
    }
}
