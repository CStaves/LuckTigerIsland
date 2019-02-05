/*
Have one audio master object per scene using the prefab. Create sounds in the audio master object inspector. 
Reference the audio manager script using the audio manager object in other objects to access and play sounds.
*/
using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    public string soundName;
    public AudioClip audioClip;
    public AudioMixerGroup audioMixer;

    [Range(0f, 1f)]
    public float volume = 1f;

    [Range(-3f, 3f)]
    public float pitch = 1f;

    public bool loop = false;
    public bool mute = false;

    private AudioSource m_audioSource;

    //Functions
    public void Play()
    {
        m_audioSource.outputAudioMixerGroup = audioMixer;
        m_audioSource.volume = volume;
        m_audioSource.pitch = pitch;
        m_audioSource.loop = loop;
        m_audioSource.mute = mute;
        m_audioSource.Play();
    }

    public void Stop()
    {
        m_audioSource.Stop();
    }

    //Mute, Change Volume, and Change Pitch are used to change sound settings during runtime.
    public void Mute(bool _mute)
    {
        m_audioSource.mute = _mute;
    }

    public void ChangeVolume(float _volume)
    {
        m_audioSource.volume = _volume;
    }

    public void ChangePitch(float _pitch)
    {
        m_audioSource.pitch = _pitch;
    }

    public void SetAudioSource(AudioSource _source)
    {
        m_audioSource = _source;
        m_audioSource.clip = audioClip;
    }
}

public class AudioManager : MonoBehaviour {

    public static AudioManager instance;

    [SerializeField]
    Sound[] sounds;

    //To make sure there is only one AudioManager per scene.
    void Awake()
    {
        if (instance != null) {
            Debug.LogError("Only one audio manager can be present per scene.");
        } else
        {
            instance = this;
        } 
    }

    void Start()
    {
        for(int i = 0; i < sounds.Length; i++) { 
            //To stop duplicates in sound name.
            for(int j = i+1; j < sounds.Length; j++)
            {
                if(sounds[i].soundName == sounds[j].soundName)
                {
                    throw new System.Exception("Error! Sound " + i + " and sound " + j + " have the same name.");
                }
            }

            //Create Sound Objects from array.
            GameObject _so = new GameObject("Sound " + i + ": " + sounds[i].soundName);
            _so.transform.SetParent(this.transform);
            sounds[i].SetAudioSource(_so.AddComponent<AudioSource>());
        }
    }

    public void PlaySound (string _name) 
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if(sounds[i].soundName == _name)
            {
                sounds[i].Play();
                return;
            }
        }
        //Reaching here means no sound with the name was found.
        Debug.LogError(_name + " sound does not exist!");
    }

    public void StopSound(string _name)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].soundName == _name)
            {
                sounds[i].Stop();
                return;
            }
        }
        Debug.LogError(_name + " sound does not exist!");
    }

    public void MuteSound(string _name, bool _mute)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].soundName == _name)
            {
                sounds[i].Mute(_mute);
                return;
            }
        }
        Debug.LogError(_name + " sound does not exist!");
    }

    public void ChangeSoundVolume(string _name, float _volume)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].soundName == _name)
            {
                sounds[i].ChangeVolume(Mathf.Clamp(_volume, 0f, 1f));
                return;
            }
        }
        Debug.LogError(_name + " sound does not exist!");
    }

    public void ChangeSoundPitch(string _name, float _pitch)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].soundName == _name)
            {
                sounds[i].ChangePitch(Mathf.Clamp(_pitch, -3f, 3f));
                return;
            }
        }
        Debug.LogError(_name + " sound does not exist!");
    }
}

/*Info on Sound Import Settings
 * Music / Ambiance:
 *  Load Type: Use either "Streaming" or "Compressed in Memory"
 *  Streaming uses less memory but requires higher CPU power and disk I/O.
 *  Compressed in Memory uses less disk I/O but higher memory. If using this option, change sound quality to around 70.
 *  Compression Format: Vorbis
 * 
 * Sound Effects:
 *  Frequently Played and short clips should use Load Type "Decompress on Load" and Compression Format "PCM".
 *  Frequently Played and medium clips should use Load Type "Compressed in Memory" and Compression Format "ADPCM".
 *  Rarely Played and short clips should use Load Type "Compressed in Memory" and Compression Format "ADPCM".
 *  Rarely Played and medium clips should use Load Type "Compressed In Memeory" and Compression Format "Vorbis".
*/