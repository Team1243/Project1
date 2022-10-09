using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RocketPositionScore : MonoBehaviour
{
    private TextMeshProUGUI _text;
    private float _firstPosY;
    private int _thisPosY;

    private void Awake()
    {
        _text = GameObject.Find("ThisPosText").GetComponent<TextMeshProUGUI>();
        _firstPosY = transform.position.y;
    }

    private void Update()
    {
        RocketScoreNow();
        BestScore();
    }

    private void RocketScoreNow()
    {
        _thisPosY = ((int)transform.position.y - (int)_firstPosY) / 10;
        _text.text = _thisPosY.ToString();
    }

    public void BestScore() 
    {
        if (PlayerPrefs.GetInt("BestScore") < _thisPosY)
            PlayerPrefs.SetInt("BestScore", _thisPosY);
    }
}
