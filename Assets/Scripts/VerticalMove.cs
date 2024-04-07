using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalMove : MonoBehaviour
{
    public AnimationCurve myCurve;
    public float MovementSlow = 1;
    public float CurveLength = 1;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, myCurve.Evaluate(((Time.time / MovementSlow) % myCurve.length)) * CurveLength, transform.position.z);
    }
}
