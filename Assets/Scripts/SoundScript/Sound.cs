using System;
using UnityEngine;

namespace DefaultNamespace
{
    [Serializable] public class Sound
    {
        public SoundManager.SoundName soundName;
        public AudioClip clip;
        [Range(0f,1f)] public float volume;
        public bool loop;
        public bool mute;
        [HideInInspector] public AudioSource audioSource;
    }
}
