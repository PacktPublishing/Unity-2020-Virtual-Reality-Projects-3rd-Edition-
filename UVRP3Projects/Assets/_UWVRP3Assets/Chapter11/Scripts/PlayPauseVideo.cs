using UnityEngine;
using UnityEngine.Video;

public class PlayPauseVideo : MonoBehaviour
{
    private VideoPlayer video;

    private void Start()
    {
        video = GetComponent<VideoPlayer>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("XRI_Right_TriggerButton"))
        {
            if (video.isPlaying)
            {
                video.Pause();
            }
            else
            {
                video.Play();
            }
        }
    }
}