using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatorXY : MonoBehaviour
{
    public int rotationSlow = 0;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate (new Vector3 (15, 30, 0) * (Time.deltaTime/rotationSlow));
    }
}
