using System;
using UnityEngine;

namespace Scanner_Effect
{
    public class SoundWavePropagator : MonoBehaviour
    {
        public float scanDistance;
        public float maxScanDistance;
        public float scanVelocity = 50;
        private bool _scanning = false;
        public ObjectPooling pool;

        private void Update()
        {
            if (!_scanning) return;
            if (scanDistance < maxScanDistance)
            {
                scanDistance += Time.deltaTime * scanVelocity;
                transform.localScale = Vector3.one * scanDistance;
            }
            else
            {
                EndScan();
            }
        }

        public void StartScan()
        {
            _scanning = true;
            scanDistance = 0;
        }

        public void EndScan()
        {
            _scanning = false;
            pool.soundWavePool.Enqueue(transform);
            gameObject.SetActive(false);
        }
    }
}