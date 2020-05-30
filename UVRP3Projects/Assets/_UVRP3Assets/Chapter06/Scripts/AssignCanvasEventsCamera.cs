using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignCanvasEventsCamera : MonoBehaviour
{
    void Start()
    {
        Canvas canvas = GetComponent<Canvas>();
        if (canvas && canvas.worldCamera == null)
        {
            canvas.worldCamera = Camera.main;
        }
    }
}
