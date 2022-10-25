using UnityEngine;

using System.Collections.Generic;

[CreateAssetMenu(fileName ="New Sound Clip", menuName ="Audio")]
public class SoundType : ScriptableObject
{
    public List<AudioSource> clips;
    public string soundName;
}