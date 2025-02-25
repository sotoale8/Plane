using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;


public class AudioManager : MonoBehaviour
{   
    public static AudioManager Instance {get; private set;}
    [SerializeField] AudioSource sfxAudio, musicAudio;
     [SerializeField] AudioMixer master;
    public AudioClip initialMusic;
    public bool isMuted=false;

    public Slider musicSlider,sfxSlider;

    private void Awake() {
        if(Instance == null)
        {
            Instance = this;
            
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    void Start()
    {
        sfxAudio = transform.GetChild(0).GetComponent<AudioSource>();
        musicAudio = transform.GetChild(1).GetComponent<AudioSource>();
        InitialPlayMusic(initialMusic);
    }

   

    public void PlaySFX(AudioClip clip)
    {
        sfxAudio.PlayOneShot(clip);
    }
    public void StopSFX()
    {
        sfxAudio.Stop();
    }

    public bool IsPlayingSFX()
    {
        return sfxAudio.isPlaying;
    }
    public void PlayMusic(AudioClip clip)
    {
        musicAudio.Stop();
        musicAudio.clip = clip;
        musicAudio.Play();
        musicAudio.loop = true;
    }
    void InitialPlayMusic(AudioClip clip)
    {
        musicAudio.clip = clip;
        musicAudio.Play();
        musicAudio.loop = true;
    }

    public void Mute()
    {   
        musicAudio.mute=isMuted;
        sfxAudio.mute=isMuted;
        isMuted =!isMuted;
    }

    public void PauseMusic(bool isPaused)
    {
        
        switch (isPaused)
            { 
                case true:
                musicAudio.Pause();    
                break;
              case false:
                musicAudio.Play();
                break;
        
            }
    

    }

      
    public void MusicVolumeControl()
    {
        
        master.SetFloat("Music", Mathf.Log10(musicSlider.value)*20);
    }

    public void SFXVolumeControl()
    {
        master.SetFloat("Sfx", Mathf.Log10(sfxSlider.value)*20);
    }
    
}