using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resizer : MonoBehaviour //Ŀ���� �۾����°�, �Դٰ��� �ϴ� �ð� �����ְ� ���� ũ�⿡�� ��� ������ �����ָ� �˴ϴ�.
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
