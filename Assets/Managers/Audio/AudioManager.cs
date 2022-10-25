using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AudioManager : Singleton<AudioManager>
{

    public List<SoundType> audioSources = new List<SoundType>();

    public void PlayAudioClip(SoundType sound, float volume)
    {


      if(audioSources.Contains(sound))
        {
            if (sound.clips == null) return;
            AudioSource source = sound.clips[Random.Range(0, sound.clips.Count)];
            source.volume = volume;
            source.Play();
        }
    }

   
}
