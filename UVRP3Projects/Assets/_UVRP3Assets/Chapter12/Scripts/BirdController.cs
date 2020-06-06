using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    public Transform bird;
    public float flightTime = 5f;
    public float turningTime = 2.5f;
    public float flyAwayTime = 20f;
    public List<Transform> targets = new List<Transform>();

    private Animator birdAnim;
    private int index;

    void Start()
    {
        // initialize references
        birdAnim = bird.GetComponent<Animator>();

        // start at first target marker
        bird.transform.position = targets[0].position;
        bird.transform.rotation = targets[0].rotation;
        index = 0;
    }

    public void FlyToNextLocation()
    {
        index++;

        if (index == targets.Count - 1)
        {
            FlyAway(targets[index].transform);
        }
        else
        {
            FlyToTarget(targets[index].transform);
        }
    }

    private void FlyToTarget(Transform target)
    {
        birdAnim.SetBool("flying", true);
        birdAnim.SetBool("landing", false);

        bird.transform
            .DORotate(target.eulerAngles, turningTime)
            .OnComplete(() =>
            {
                birdAnim.SetBool("flying", false);
                birdAnim.SetBool("landing", true);

            });

        bird.transform
            .DOJump(target.position, 1f, 1, flightTime)
            .OnComplete(() =>
            {
                birdAnim.SetBool("landing", false);

            });
    }



    private void FlyAway(Transform target)
    {
        birdAnim.SetBool("flying", true);
        birdAnim.SetBool("landing", false);
        bird.transform.DORotate(target.eulerAngles, 2.5f);
        bird.transform.DOMove(target.position, flyAwayTime);
    }
}
