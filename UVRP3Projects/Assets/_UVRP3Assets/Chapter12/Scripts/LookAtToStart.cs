using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using TMPro;

public class LookAtToStart : MonoBehaviour
{
    public PlayableDirector timeline;
    public float timeToSelect = 4f;

    private Transform camera;
    private TMP_Text countdownText;
    private float timer;
    private bool resetSetup;

    void Start()
    {
        camera = Camera.main.transform;
        countdownText = GetComponentInChildren<TMP_Text>();
        timer = timeToSelect;
        resetSetup = true;
    }

    void Update()
    {
        // Do nothing if already playing
        if (timeline.state == PlayState.Playing)
            return;

        if (resetSetup)
        {
            StartCoroutine(PlayToSetup());
            resetSetup = false;
        }

        // Is user looking here?
        Ray ray = new Ray(camera.position, camera.rotation * Vector3.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit) && (hit.collider.gameObject == gameObject))
        {
            if (timer > 0f)
            {
                timer -= Time.deltaTime;
                countdownText.text = timer.ToString("F0");
                countdownText.gameObject.SetActive(true);
            }
            else
            {
                // go!
                timeline.Play();
                resetSetup = true;
                countdownText.gameObject.SetActive(false);
            }
        }
        else
        {
            // reset timer
            timer = timeToSelect;
            countdownText.gameObject.SetActive(false);
        }
    }

    IEnumerator PlayToSetup()
    {
        timeline.Play();
        yield return new WaitForSeconds(0.1f);
        timeline.Stop();
    }
}
