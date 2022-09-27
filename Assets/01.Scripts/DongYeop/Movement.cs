using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum Rotation { pc, gyroscope }

public class Movement : MonoBehaviour
{
    [SerializeField] private float _mainThrust;
    [SerializeField] private float _rotationThrust;
    [SerializeField] private AudioClip _mainEngine;

    [SerializeField] private ParticleSystem _mainEngineParticles;

    [SerializeField] private Rotation _rotation = Rotation.pc; //자이로스코프로 방향을 조절할지 키보드로 조절할지 선택

    private UseBooster _useBooster;

    private Rigidbody _rb;
    private AudioSource _audioSource;

    public bool isBooster = false;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();
        _useBooster = GetComponent<UseBooster>();
    }

    private void Update()
    {
        if (_useBooster.nowBooster < 0)
        {
            StopThrust();
            isBooster = false;
            return;
        }

        if (_rotation == Rotation.pc) //PC 상태일때
        {
            ProcessRotation();
            ProcessThrust();
        }
        else if (_rotation == Rotation.gyroscope) //모바일 상태일때
        {
            GyroscopeRotation();
            ProcessThrustMobile();
        }
        else
            Debug.LogError("현재 열거형변수 Rotation이 비어 있습니다.");
    }

    #region PC
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
    #endregion

    #region Mobile
    private void GyroscopeRotation() //저이로스코프를 이용하여 로켓의 방향을 조절합니다 (아직 구현 안 
    {
        float zRotation;
        zRotation = Input.acceleration.x * _rotationThrust;
        gameObject.transform.rotation = Quaternion.Euler(0, 0, -zRotation);
        ThrustAudio();
    }

    private void ProcessThrustMobile()
    {
        if (Input.touchCount > 0)
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
    #endregion

    private void StartThrust()
    {
        _rb.AddRelativeForce(Vector3.up * _mainThrust * Time.deltaTime);

        ThrustAudio();
    }

    private void ThrustAudio()
    {
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
}
