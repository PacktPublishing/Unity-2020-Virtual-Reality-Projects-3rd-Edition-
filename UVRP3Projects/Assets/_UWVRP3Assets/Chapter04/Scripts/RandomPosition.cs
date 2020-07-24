using System.Collections;
using UnityEngine;

public class RandomPosition : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(RePositionWithDelay());
    }

    IEnumerator RePositionWithDelay()
    {
        while (true)
        {
            SetRandomPosition();
            yield return new WaitForSeconds(5f);
        }
    }

    void SetRandomPosition()
    {
        float x = Random.Range(-5.0f, 5.0f);
        float z = Random.Range(-5.0f, 5.0f);
        Debug.Log("X,Z: " + x.ToString("F2") + ", " + z.ToString("F2"));
        transform.position = new Vector3(x, 0.0f, z);
    }
}