using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour //왔다갔다 하는거, Delta에서 얼만큼 움직일지 적고, Spped에서 속도 정해주면됨. X나 Y하나만 해줘도 작동합니다
{
    [Header("Horizontal Movement")]
    [SerializeField] private float _xDelta;
    [SerializeField] private float _xMoveSpeed;

    [Header("Vertical Movement")]
    [SerializeField] private float _yDelta;
    [SerializeField] private float _yMoveSpeed;

    private Vector3 _startPosition;

    private void Start()
    {
        _startPosition = transform.position;
    }

    private void FixedUpdate()
    {
        if (_xMoveSpeed != 0)
        {
            float x = _startPosition.x + _xDelta * Mathf.Sin(Time.time * _xMoveSpeed);
            transform.position = new Vector3(x, transform.position.y, transform.position.z);
        }

        if (_yMoveSpeed != 0)
        {
            float y = _startPosition.y + _yDelta * Mathf.Sin(Time.time * _yMoveSpeed);
            transform.position = new Vector3(transform.position.x, y, transform.position.z);
        }
    }
}
