using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseBooster : MonoBehaviour
{
    [SerializeField] private float _maxBooster = 100; // 사용할 수 있는 최대의 부스터량

    private Movement _movement;

    [SerializeField] private float _nowBooster; // 현제의 부스터 상황
    private float _booster = 5; // 초마다 사용하는 부스터의량

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
