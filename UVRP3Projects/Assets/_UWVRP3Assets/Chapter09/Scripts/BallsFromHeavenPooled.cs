using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallsFromHeavenPooled : MonoBehaviour
{
    public float startHeight = 10f;
    public float interval = 0.5f;

    private float nextBallTime = 0f;
    private ObjectPooler objectPooler;

    private void Start()
    {
        nextBallTime = Time.time + interval;
        objectPooler = GetComponent<ObjectPooler>();
    }

    void Update()
    {
        if (Time.time > nextBallTime)
        {
            Vector3 position = new Vector3(
                Random.Range(-4f, 4f),
                startHeight,
                Random.Range(-4f, 4f));
            NewBall(position);

            nextBallTime = Time.time + interval;
        }
    }

    private void NewBall(Vector3 position)
    {
        GameObject ball = objectPooler.GetPooledObject();

        if (ball != null)
        {
            ball.transform.position = position;
            ball.transform.rotation = Quaternion.identity;
            ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
}
