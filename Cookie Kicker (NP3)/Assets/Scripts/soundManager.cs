using UnityEngine.Audio;
using UnityEngine;
using System;

public class soundManager : MonoBehaviour
{
    public static soundManager Instance;
    [SerializeField] private AudioSource _musicSource,_effectsSource;
    void Awake(){
        if(Instance==null) {
            Instance=this;
            DontDestroyOnLoad(gameObject);
        }else{
            Destroy(gameObject);
        }
    }
    public void Start(){
        AudioListener.volume=0.5f;
    }
    
    public void PlaySound(AudioClip clip) {
        _effectsSource.PlayOneShot(clip);
    }
    public void PlayMusic(AudioClip clip) {
        print("music playing");
        _effectsSource.loop=true;
        _effectsSource.PlayOneShot(clip);
    }

    public void ChangeMasterVolume(float value){
        AudioListener.volume=value;
    }
}
