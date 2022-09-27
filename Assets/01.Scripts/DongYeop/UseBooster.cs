using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UseBooster : MonoBehaviour
{
    [SerializeField] private float _maxBooster = 100; // 사용할 수 있는 최대의 부스터량

    private Movement _movement;
    private Slider _slider;

    private float _booster = 5; // 초마다 사용하는 부스터의량
    
    public float nowBooster; // 현제의 부스터 상황

    private void Awake()
    {
        _movement = GetComponent<Movement>();
        _slider = GameObject.Find("BoosterSlider").GetComponent<Slider>();
    }

    private void Start()
    {
        nowBooster = _maxBooster;
    }

    private void Update()
    {
        OnBooster();
        SlideUpdate();
    }

    private void OnBooster()
    {
        if (_movement.isBooster)
            nowBooster -= _booster * Time.deltaTime;
    }

    private void SlideUpdate()
    {
        _slider.value = nowBooster/_maxBooster;
    }

    public void AddBooster(int addBooster) // 블럭 클리어떄 같이 실행시켜줄 현제 부스터량 늘리는 스크립트
    {
        nowBooster += addBooster;
    }
}
