using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveSelf : MonoBehaviour
{
    public bool checkOutOfBounds = true;
    public Vector3 minBounds = Vector3.negativeInfinity;
    public Vector3 maxBounds = Vector3.positiveInfinity;

    public bool checkTimeout = true;
    public float timeOut = 15f;

    private float timer;

    private void OnEnable()
    {
        if (checkTimeout)
        {
            timer = Time.time + timeOut;
        }
    }

    private void Update()
    {
        if (checkOutOfBounds)
        {
            Vector3 pos = transform.position;
            if (pos.x < minBounds.x || pos.x > maxBounds.x ||
                pos.y < minBounds.y || pos.y > maxBounds.y ||
                pos.z < minBounds.z || pos.z > maxBounds.z)
            {
                Remove();
            }
        }

        if (checkTimeout && Time.time > timer)
        {
            Remove();
        }
    }

    private void Remove()
    {
        Destroy(gameObject);
    }
}
