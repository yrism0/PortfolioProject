using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioControl : MonoBehaviour
{// Sam Speirs - Audio Controls - Created using multiple tutorials for foundation and adjustments to fit within my game

    // Variables

    public AudioMixer masterMixer;
    public Slider masterSlider;
    public Slider musicSlider;
    public AudioClip backgroundMusic; 
    public AudioSource musicSource;
    float savedVol;

    public void SetSFXVolume(float sliderVolume)
    {
        float sfxvolume = masterSlider.value;
         masterMixer.SetFloat("SFX", Mathf.Log10(sfxvolume) * 20);
        
        PlayerPrefs.SetFloat("Volume", masterSlider.value); // Attempts to save the volume to carry between scenes - was unable to get it working in time
    }
    public void SetmusicVolume(float sliderVolume)
    {
        float musicVolume = musicSlider.value;
        masterMixer.SetFloat("Music", Mathf.Log10(musicVolume) * 20);

       // PlayerPrefs.SetFloat("Musicvolume", savedVol); // Attempts to save the volume to carry between scenes - was unable to get it working in time
    }



    void Start()
    {
        PlayMusic();

        


       // masterSlider.value = PlayerPrefs.GetFloat("Volume", savedVol); // Attempts to set the volume to the saved volume on start - was unable to get it working in time
        masterMixer.SetFloat("SFXVolume", masterSlider.value);
        masterMixer.SetFloat("MusicVolume", musicSlider.value);// Attempts to save the volume to carry between scenes - was unable to get it working in time
    }

    public void PlayMusic()
    {
        musicSource.clip = backgroundMusic;
        musicSource.loop = true;
        musicSource.Play();
    }

    // Enum 
    public enum SoundType // Collection of all the sound clip types - can be selected from dropdown in unity
    {
        // These are left overs from my last game, each relates to an action, so we just make a soundtype for everything we need - SS
        // When calling these use example below which called the jump sound.
        // AudioControl.Instance.Play(AudioControl.SoundType.Jump);    
        Movement,
        DoorOpen,
        PlayerDie,
        EnemyDie,
        PlayerShot1,
        PlayerShot2,
        Portal,
        MenuOpen,
        MenuClose,
        BackgroundMusic,
        MenuButton
    }

    [System.Serializable]

    public class Sound // Class of variables that are found in the unity engine
    {
        public SoundType Type;
        public AudioClip Clip;

        [Range(0f, 1f)]
        public float Volume = 1f;


        [HideInInspector]
        public AudioSource Source;

    }

    public static AudioControl Instance;

    public Sound[] AllSounds;

    // Still not too sure how the dictionary stuff fully works but it kinda seems like an array that mashes the Soundtype with the sound
    // So it would be like { "Checkpoint", [1] } so it can check if sounds are on the list later? will need to come back and do more work on it
    private Dictionary<SoundType, Sound> _soundDictionary = new Dictionary<SoundType, Sound>();

    private void Awake()
    {
        Instance = this;

        foreach (var s in AllSounds)
        {
            _soundDictionary[s.Type] = s;
        }
    }

    public SoundType SelectedSound;

    public void Play(SoundType type)
    {
        if (!_soundDictionary.TryGetValue(type, out Sound s))
        {
            Debug.LogWarning($"Sound Type {type} not found.");
            return;
        }


        // Creates a new game object to generate the sound
        var soundObj = new GameObject($"Sound_{type}");
        var audioSrc = soundObj.AddComponent<AudioSource>();

        // Bases the sound that is create on the selected audio clip and volume set in the unity engine
        audioSrc.clip = s.Clip;
        audioSrc.volume = s.Volume;
        audioSrc.outputAudioMixerGroup = masterMixer.FindMatchingGroups("SFX")[0];

        audioSrc.Play();

        // Destroys the game object after it plays the sound
        Destroy(soundObj, s.Clip.length);
    }



}
