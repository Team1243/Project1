using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftAndRight : MonoBehaviour
{
    int a = 1;
    float delayTime = 0.5f;
    float sum;

    private void Update()
    {
        
    }

    private void OnEnable()
    {
        StartCoroutine(LeftToRightMove());
    }

    IEnumerator LeftToRightMove()
    {
        if(Time.deltaTime <= delayTime)
        {
            transform.position = new Vector3(transform.position.x + 0.1f * a, transform.position.y, transform.position.z);
            if(transform.position.x >= 7)
            {
                a = -1;
            }
            else if(transform.position.x <= -11)
            {
                a = 1;
            }
        }

        yield return new WaitForSeconds(0.01f);
        StartCoroutine(LeftToRightMove());
    }
}
