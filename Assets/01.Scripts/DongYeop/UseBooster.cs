using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseBooster : MonoBehaviour
{
    [SerializeField] private float _maxBooster = 100; // ����� �� �ִ� �ִ��� �ν��ͷ�

    private Movement _movement;

    [SerializeField] private float _nowBooster; // ������ �ν��� ��Ȳ
    private float _booster = 5; // �ʸ��� ����ϴ� �ν����Ƿ�

    private void Awake()
    {
        _movement = GetComponent<Movement>();
    }

    private void Start()
    {
        _nowBooster = _maxBooster;
    }

    private void Update()
    {
        OnBooster();
    }

    private void OnBooster()
    {
        if (_movement.isBooster)
            _nowBooster -= _booster * Time.deltaTime;
    }
}
