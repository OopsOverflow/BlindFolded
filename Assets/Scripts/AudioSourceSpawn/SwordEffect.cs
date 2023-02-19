using System;
using UnityEngine;

namespace AudioSourceSpawn
{
    public class SwordEffect : MonoBehaviour
    {
        public static SwordEffect instance;
        
        public AudioSourcePooling pool;


        public void SpawnSound(Vector3 position)
        {
            var audio = pool.GetAudioSource(position);
            audio.GetComponent<AudioPropagator>().pool = pool;
            audio.position = position;
            audio.GetComponent<AudioSource>().Play();
            audio.gameObject.SetActive(true);
        }
        
        void Awake()
        {
            if (instance==null)
            {
                instance = this;
            }
        }
    }
    
}