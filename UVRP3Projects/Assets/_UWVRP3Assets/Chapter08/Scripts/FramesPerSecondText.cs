using UnityEngine;
using UnityEngine.UI;

public class FramesPerSecondText : MonoBehaviour
{
    private float updateInterval = 0.5f;
    private int framesCount;
    private float framesTime;
    private Text text;

    void Start()
    {
        text = GetComponent<Text>();
    }
    
    void Update()
    {
        framesCount++;
        framesTime += Time.unscaledDeltaTime;
        if (framesTime > updateInterval)
        {
            float fps = framesCount / framesTime;
            text.text = string.Format("{0:F2} FPS", fps);
            framesCount = 0;
            framesTime = 0;
        }
    }
}