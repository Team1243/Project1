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

    [SerializeField] private Rotation _rotation = Rotation.pc; //���̷ν������� ������ �������� Ű����� �������� ����

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

        if (_rotation == Rotation.pc) //PC �����϶�
        {
            ProcessRotation();
            ProcessThrust();
        }
        else if (_rotation == Rotation.gyroscope) //����� �����϶�
        {
            GyroscopeRotation();
            ProcessThrustMobile();
        }
        else
            Debug.LogError("���� ���������� Rotation�� ��� �ֽ��ϴ�.");
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
    private void GyroscopeRotation() //���̷ν������� �̿��Ͽ� ������ ������ �����մϴ� (���� ���� �� 
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
