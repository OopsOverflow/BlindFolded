using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundWavePooling : MonoBehaviour
{
    public GameObject wavePrefab;

    public Queue<Transform> soundWavePool = new Queue<Transform>();

    public Transform GetSoundWave(Vector3 position)
    {
        return soundWavePool.Count>0 ? soundWavePool.Dequeue() : Instantiate(wavePrefab, position, Quaternion.identity).GetComponent<Transform>();
    }
}
