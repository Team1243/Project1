using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationChange : MonoBehaviour
{
    float delayTime = 0.5f;

    private void Update()
    {
        transform.Rotate(Vector3.forward * 30f * Time.deltaTime);
    }
}
