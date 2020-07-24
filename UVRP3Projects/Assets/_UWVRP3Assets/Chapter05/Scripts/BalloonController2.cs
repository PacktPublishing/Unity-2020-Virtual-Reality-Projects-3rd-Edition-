using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonController2 : MonoBehaviour
{
    public GameObject balloonPrefab;
    public float floatStrength = 20f;
    public float growRate = 1.5f;

    private GameObject balloon;

    void Update()
    {
        if (balloon != null)
        {
            GrowBalloon();
        }
    }

    public void CreateBalloon()
    {
        balloon = Instantiate(balloonPrefab);
        balloon.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
    }

    public void ReleaseBalloon()
    {
        Rigidbody rb = balloon.GetComponent<Rigidbody>();
        Vector3 force = Vector3.up * floatStrength;
        rb.AddForce(force);

        GameObject.Destroy(balloon, 10f);
        balloon = null;
    }

    public void GrowBalloon()
    {
        balloon.transform.localScale += balloon.transform.localScale * growRate * Time.deltaTime;
    }
}
