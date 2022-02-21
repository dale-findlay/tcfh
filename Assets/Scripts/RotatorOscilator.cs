using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatorOscilator : MonoBehaviour {

    public Vector3 axis;

    public float min;
    public float max;

    public float speed = 3.0f;

    void Update()
    {

        float t = Mathf.PingPong(Time.time * speed * 2.0f, 1.0f);

        Vector3 rotation = axis * Mathf.Lerp(min, max, t);

        transform.eulerAngles = rotation;

    }
}
