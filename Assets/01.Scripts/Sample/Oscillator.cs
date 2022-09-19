using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    [SerializeField] [Range(0, 1)] private float _movementFactor;
    [SerializeField] private Vector3 _movementVector;
    [SerializeField] private float _period = 2f;

    private Vector3 _startingPosition;
    
    private void Start()
    {
        _startingPosition = transform.position;
    }
    
    private void Update()
    {
        if (_period <= Mathf.Epsilon) { return; }
        float cycles = Time.time / _period;

        const float tau = Mathf.PI * 2;
        float rawSinWave = Mathf.Sin(cycles * tau);

        _movementFactor = (rawSinWave + 1f) / 2f;

        Vector3 offset = _movementVector * _movementFactor;
        transform.position = _startingPosition + offset;
    }
}
