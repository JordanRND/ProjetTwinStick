using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    private bool isShaking;
    private Vector3 originaPosition;
    [SerializeField] private CamManager camManager;
    [SerializeField] private float duration = 0.3f;
    private float shakeTime;
    [SerializeField] private float shakeMagnitude = 0.3f;

    [ContextMenu("StartShake")]
    public void StartShake()
    {
        isShaking = true;
        originaPosition = transform.position;
        camManager.enabled = false;
        shakeTime = duration;
    }

    private void Shake()
    {
        if (isShaking)
        {
            transform.position = originaPosition + Random.insideUnitSphere * shakeMagnitude;
            shakeTime -= Time.deltaTime;
        }
        if (shakeTime <= 0)
        {
            transform.position = originaPosition;
            isShaking = false;
            camManager.enabled = true;
        }
    }

    private void FixedUpdate()
    {
        if (!isShaking) return;
        Shake();
    }
}
