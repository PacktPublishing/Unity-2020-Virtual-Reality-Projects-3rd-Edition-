using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonController3 : MonoBehaviour
{
    public GameObject balloonPrefab;
    public float floatStrength = 20f;
    public float growRate = 1.5f;

    private GameObject balloon;
    private Rigidbody rb;

    void Update()
    {
        if (balloon != null)
        {
            GrowBalloon();
        }
    }

    public void CreateBalloon(GameObject parentHand)
    {
        balloon = Instantiate(balloonPrefab, parentHand.transform);
        balloon.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        rb = balloon.GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }

    public void ReleaseBalloon()
    {
        rb.isKinematic = false;
        balloon.transform.parent = null;
        balloon.GetComponent<Rigidbody>().AddForce(Vector3.up * floatStrength);
        GameObject.Destroy(balloon, 10f);
        balloon = null;
    }

    public void GrowBalloon()
    {
        balloon.transform.localScale += balloon.transform.localScale * growRate * Time.deltaTime;
    }
}
