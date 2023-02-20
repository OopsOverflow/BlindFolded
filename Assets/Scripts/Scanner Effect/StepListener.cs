using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class StepListener : MonoBehaviour
{
    public ActionBasedContinuousMoveProvider provider;

    private float _cooldown = 3f;

    private bool _isCooldownFinished = true;
    // Start is called before the first frame update
    void Start()
    {
        provider.rightHandMoveAction.action.performed += x => StepVisualizer();
    }

    private IEnumerator CooldownStepCoRoutine(float cooldownTime)
    {
        yield return new WaitForSeconds(cooldownTime);
        _isCooldownFinished = true;
    }

    private void StepVisualizer()
    {
        if(!_isCooldownFinished) return;
        SoundWaveEffect.instance.StartScan(gameObject.transform.position, 1.5f);
        _isCooldownFinished = false;
        StartCoroutine(CooldownStepCoRoutine(_cooldown));
    }
}
