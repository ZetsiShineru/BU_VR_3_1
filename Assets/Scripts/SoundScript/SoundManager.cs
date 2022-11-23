using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class SoundManager : MonoBehaviour
    {
        public static SoundManager instance;
    
        [SerializeField] private Sound[] sounds;
        public enum SoundName
        {
            BGM1,
            BGM2,
            BGM3,
            BGM4,
            Chasing,
            Dialog1,
            Dialog2,
            Dialog3,
            EnemyWalk,
            EnemyRun,
            Hit1,
            Hit2,
            Collect,
        }

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(this);
                return;
            }
        
            DontDestroyOnLoad(gameObject);
        }


        public void Play(SoundName name)
        {

            Sound sound = GetSound(name);
            if (sound.audioSource!= null)
            {
                sound.audioSource.Play();
            }
            else if (sound.audioSource == null)
            {
                sound.audioSource = gameObject.AddComponent<AudioSource>();

                sound.audioSource.clip = sound.clip;
                sound.audioSource.loop = sound.loop;
                sound.audioSource.mute = sound.mute;
                sound.audioSource.volume = sound.volume;
            }
            sound.audioSource.Play();
            sound.audioSource.mute = false;
        }

        private Sound GetSound(SoundName name)
        {
            return Array.Find(sounds,s => s.soundName == name);
        }

        public void Stop(SoundName name)
        {
            Sound sound = GetSound(name);
            sound.audioSource.mute = true;
            sound.audioSource.loop = false;
        }

        public void Loop(SoundName name)
        {
            Sound sound = GetSound(name);
            sound.audioSource.loop = true;
        }
        // Update is called once per frame
        void Update()
        {
        
        }
    }
}

