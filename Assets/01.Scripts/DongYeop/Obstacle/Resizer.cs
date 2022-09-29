using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resizer : MonoBehaviour //커졌다 작아지는거, 왔다갔다 하는 시간 정해주고 지금 크기에서 어떻게 변할지 정해주면 됩니다.
{
    private Vector3 _startSIze;
    [SerializeField] private Vector3 _endSIze;
    [SerializeField] private float _resizeTime;

    private IEnumerator Start()
    {
        _startSIze = transform.localScale;

        while (true)
        {
            yield return StartCoroutine(Resize(_startSIze, _endSIze, _resizeTime));
            yield return StartCoroutine(Resize(_endSIze, _startSIze, _resizeTime));
        }
    }

    private IEnumerator Resize(Vector3 start, Vector3 end, float time)
    {
        float current = 0;
        float percent = 0;

        while (percent < 1)
        {
            current += Time.deltaTime;
            percent = current / time;

            transform.localScale = Vector3.Lerp(start, end, percent);

            yield return null;
        }
    }
}
