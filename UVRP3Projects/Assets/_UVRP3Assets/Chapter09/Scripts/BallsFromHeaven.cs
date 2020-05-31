using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallsFromHeaven : MonoBehaviour
{
    public GameObject ballPrefab;
    public float startHeight = 10f;
    public float interval = 0.5f;

    private float nextBallTime = 0f;

    private void Start()
    {
        nextBallTime = Time.time + interval;
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
        Instantiate(ballPrefab, position, Quaternion.identity);
    }
}
