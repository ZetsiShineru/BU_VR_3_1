using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class SoundController : MonoBehaviour
    {
        [SerializeField] private GameObject player;

        public void Start()
        {
            Debug.Log("BGM1 Play");
            SoundManager.instance.Play(SoundManager.SoundName.BGM4);
            SoundManager.instance.Loop(SoundManager.SoundName.BGM4);
        }

        void Update()
        {
            if (player == null)
            {
                Debug.Log("BGM1 Mute");
                SoundManager.instance.Stop(SoundManager.SoundName.BGM4);
            }
        }
    }
}
