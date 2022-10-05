using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransform : MonoBehaviour
{
    private Transform _cameraColliderTrm;
    private float _rocketFirstTrm;

    private void Awake()
    {
        _cameraColliderTrm = GameObject.Find("CameraCollider Transform").GetComponent<Transform>();

        _rocketFirstTrm = transform.position.y;
    }

    private void Update()
    {
        CameraColliderTrm();
    }

    private void CameraColliderTrm()
    {
        if (_cameraColliderTrm == null)
            return;

        float pos = transform.position.y - _rocketFirstTrm;
        _cameraColliderTrm.position = new Vector3(_cameraColliderTrm.position.x, pos, _cameraColliderTrm.position.z);
    }
}
