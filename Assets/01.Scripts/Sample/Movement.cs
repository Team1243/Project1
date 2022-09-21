using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _mainThrust;
    [SerializeField] private float _rotationThrust;
    [SerializeField] private AudioClip _mainEngine;

    [SerializeField] private ParticleSystem _mainEngineParticles;

    private Rigidbody _rb;
    private AudioSource _audioSource;

    public bool isBooster = false;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }
    
    private void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            isBooster = true;
            StartThrust();
        }
        else
        {
            isBooster = false;
            StopThrust();
        }
    }


    private void StartThrust()
    {
        _rb.AddRelativeForce(Vector3.up * _mainThrust * Time.deltaTime);
        if (!_audioSource.isPlaying)
            _audioSource.PlayOneShot(_mainEngine);

        if (!_mainEngineParticles.isPlaying)
            _mainEngineParticles.Play();
    }

    private void StopThrust()
    {
        _audioSource.Stop();
        _mainEngineParticles.Stop();
    }

    private void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(_rotationThrust);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-_rotationThrust);
        }
    }

    private void ApplyRotation(float rotationThisFrame)
    {
        _rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        _rb.freezeRotation = false;
    }
}
