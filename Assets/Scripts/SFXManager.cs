using UnityEngine;
using UnityEngine.UI;

public class SFXManager : MonoBehaviour
{
    public static SFXManager Instance;

    [Header("Audio Sources")]
    public AudioSource sfxSource;

    [Header("SFX Clips")]
    public AudioClip dead;
    public AudioClip dash;
    public AudioClip showScore;
    public AudioClip bomb;
    public AudioClip hole;
    public AudioClip stun;
    public AudioClip click;
    public AudioClip hold;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }

    public void PlaySFX(string clipName)
    {
        switch (clipName)
        {
            case "Dead":
                PlaySFX(dead);
                break;
            case "Dash":
                PlaySFX(dash);
                break;
            case "ShowScore":
                PlaySFX(showScore);
                break;
            case "Click":
                PlaySFX(click);
                break;
            case "Hold":
                PlaySFX(hold);
                break;
            case "Bomb":
                PlaySFX(bomb);
                break;
            case "Hole":
                PlaySFX(hole);
                break;
            case "Stun":
                PlaySFX(stun);
                break;
            default:
                Debug.LogWarning("SFX not found: " + clipName);
                break;
        }
    }

    public void Click()
    {
        PlaySFX("Click");
    }
    public void Hold()
    {
        PlaySFX("Hold");
    }
}