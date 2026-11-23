using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Fuentes")]
    public AudioSource BackSource;
    public AudioSource SFXsource;

    [Header("Música")]
    public AudioClip musicaFondo;

    [Header("Efectos")]
    public AudioClip recogerGema;
    public AudioClip recogerPiedra;
    public AudioClip golpeBola;      
    public AudioClip golpeEnemigo;

    void Awake()
    {
        
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        BackSource.clip = musicaFondo;
        BackSource.loop = true;     
        BackSource.Play();
    }

    public void PlaySFX(AudioClip audioClip)
    {
        if (audioClip != null)
            SFXsource.PlayOneShot(audioClip);
    }

    public void ControlarMusica()
    {
        if (BackSource.isPlaying)
        {
            BackSource.Pause();
            Debug.Log("Música pausada");
        }
        else
        {
            BackSource.UnPause();
            Debug.Log("Música reanudada");
        }
    }
}