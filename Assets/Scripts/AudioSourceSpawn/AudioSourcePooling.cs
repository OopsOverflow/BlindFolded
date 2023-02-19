using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace AudioSourceSpawn
{
    public class AudioSourcePooling : MonoBehaviour
    {
        public GameObject audioPrefab;

        public Queue<Transform> AudioPool = new Queue<Transform>();

        public Transform GetAudioSource(Vector3 position)
        {
            return AudioPool.Count>0 ? AudioPool.Dequeue() : Instantiate(audioPrefab, position, Quaternion.identity).GetComponent<Transform>();
        }
    }
}