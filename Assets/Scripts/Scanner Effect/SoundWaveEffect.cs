using System.Collections.Generic;
using Scanner_Effect;
using UnityEngine;
using UnityEngine.Serialization;

[ExecuteInEditMode]
public class SoundWaveEffect : MonoBehaviour
{
	public Transform scannerOrigin;
	public Material effectMaterial;
	public static SoundWaveEffect instance;
	public ObjectPooling wavePool;
	
	public void StartScan(Vector3 position, float mass)
	{
		var wave = wavePool.GetSoundWave(position);
		wave.GetComponent<SoundWavePropagator>().pool = wavePool;
		wave.position = position;
		wave.GetComponent<SoundWavePropagator>().maxScanDistance = 15 * mass;
		wave.GetComponent<SoundWavePropagator>().StartScan();
		wave.gameObject.SetActive(true);
	}

	void Awake()
	{
		if (instance==null)
		{
			instance = this;
		}
	}
}
