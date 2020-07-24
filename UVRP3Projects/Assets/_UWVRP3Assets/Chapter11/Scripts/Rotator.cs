using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [Tooltip("Rotation rate in degrees per second")]
    public Vector3 rate;

    void Update()
    {
        transform.Rotate(rate * Time.deltaTime);
    }
}
