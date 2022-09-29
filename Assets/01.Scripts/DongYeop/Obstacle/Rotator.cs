using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour //���ư��°�, ���ǵ� �����ְ� ����������� ���ư��� �����ָ� �˴ϴ�.
{
    [SerializeField] private float _rotateSpeed;
    private Vector3 _rotateDirection = Vector3.forward;

    private void Update()
    {
        transform.Rotate(_rotateDirection * _rotateSpeed * Time.deltaTime);
    }
}
