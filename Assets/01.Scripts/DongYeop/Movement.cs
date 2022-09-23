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

    [SerializeField] private TextMeshProUGUI _tmp;

    private Rigidbody _rb;
    private AudioSource _audioSource;

    private Vector3 _gyroscopeAngle;

    public bool isBooster = false;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
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

        _tmp.text = _gyroscopeAngle.ToString();
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
        _gyroscopeAngle.z += Input.gyro.rotationRate.x;
        gameObject.transform.rotation = Quaternion.Euler(_gyroscopeAngle);
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
