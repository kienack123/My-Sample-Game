using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyBezierCurves;
using UnityEngine;
using UnityEngine.Serialization;

public class BezierCurveMove : MonoBehaviour
{
    public BezierCurve3D Curve;
    public float speed = 2;
    private float time;
    private float t = 0;
    private void Update()
    {
        t += speed * Time.deltaTime;
        time = Mathf.Clamp01(t);
        transform.position =  Curve.GetPoint(time);
        transform.rotation = Curve.GetRotation(time,Vector3.up);
        Debug.Log(transform.position);
        Debug.Log(transform.rotation);
        
        if (t >= 1f)
        {
            t = 0f;
        }
    }
}
