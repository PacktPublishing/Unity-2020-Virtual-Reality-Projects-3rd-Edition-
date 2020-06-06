using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxExposure : MonoBehaviour
{
    public Material skyboxMaterial;
    public float exp = 1.0f;

    private float previousExp = 0f;

    private void Update()
    {
        if (exp != previousExp)
        {
            skyboxMaterial.SetFloat("_Exposure", exp);
            previousExp = exp;
        }
    }
}
