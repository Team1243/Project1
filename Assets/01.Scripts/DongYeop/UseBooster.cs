using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UseBooster : MonoBehaviour
{
    [SerializeField] private float _maxBooster = 100; // ����� �� �ִ� �ִ��� �ν��ͷ�

    private Movement _movement;
    private Slider _slider;

    private float _booster = 5; // �ʸ��� ����ϴ� �ν����Ƿ�
    
    public float nowBooster; // ������ �ν��� ��Ȳ

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

    public void AddBooster(int addBooster) // �� Ŭ��� ���� ��������� ���� �ν��ͷ� �ø��� ��ũ��Ʈ
    {
        nowBooster += addBooster;
    }
}
