using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour //돌아가는거, 스피드 정해주고 어느방향으로 돌아갈지 정해주면 됩니다.
{
    [SerializeField] private float _rotateSpeed;
    private Vector3 _rotateDirection = Vector3.forward;

    private void Update()
    {
        transform.Rotate(_rotateDirection * _rotateSpeed * Time.deltaTime);
    }
}
