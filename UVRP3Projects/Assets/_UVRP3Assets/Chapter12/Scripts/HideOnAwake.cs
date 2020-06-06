using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideOnAwake : MonoBehaviour
{
    private void Awake()
    {
        gameObject.SetActive(false);
    }

}
