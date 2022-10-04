using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RocketPositionScore : MonoBehaviour
{
    private TextMeshProUGUI _text;
    private int _thisPosY;

    private void Awake()
    {
        _text = GameObject.Find("ThisPosText").GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        RocketScoreNow();
        BestScore();
    }

    private void RocketScoreNow()
    {
        _thisPosY = (int)transform.position.y / 10;
        _text.text = _thisPosY.ToString();
    }

    public void BestScore() 
    {
        if (PlayerPrefs.GetInt("BestScore") < _thisPosY)
            PlayerPrefs.SetInt("BestScore", _thisPosY);
    }
}
