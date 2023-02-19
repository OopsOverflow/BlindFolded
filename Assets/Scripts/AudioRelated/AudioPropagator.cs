using System;
using UnityEngine;

namespace AudioRelated
{
    public class AudioPropagator : MonoBehaviour
    {
        public AudioSourcePooling pool;

        private AudioSource _audioSource;

        private void Start()
        {
            _audioSource = gameObject.GetComponent<AudioSource>();
        }

        private void Update()
        {
            if (_audioSource.isPlaying) return;
            pool.AudioPool.Enqueue(transform);
            gameObject.SetActive(false);

        }
    }
}