using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelObject : MonoBehaviour
{
    [System.Serializable]
    private class RotateObject
    {
        public float speed;
        public float duration;
    }

    [SerializeField]
    private RotateObject[] _rotate;

    private WheelJoint2D _wheelJoint2D;
    private JointMotor2D _jointMotor2D;


    private void Awake()
    {
        _wheelJoint2D = GetComponent<WheelJoint2D>();
        _jointMotor2D = new JointMotor2D();
        StartCoroutine(StartWheelRotation());
    }

    private IEnumerator StartWheelRotation()
    {
        //int _countRotation = 0;
        while (true)
        {
            int _countRotation = Random.Range(0, _rotate.Length);
            yield return new WaitForFixedUpdate();
            _jointMotor2D.motorSpeed = _rotate[_countRotation].speed;
            _jointMotor2D.maxMotorTorque = 10000;
            _wheelJoint2D.motor = _jointMotor2D;

            yield return new WaitForSecondsRealtime(_rotate[_countRotation].duration);
            _countRotation++;
            _countRotation = _countRotation < _rotate.Length ? _countRotation : 0;
        }
    }

/*
    public void StopRotation()
    {
        _jointMotor2D.motorSpeed = _rotate[0].speed;
        _jointMotor2D.maxMotorTorque = 0;
        _wheelJoint2D.motor = _jointMotor2D;
    }*/
}
