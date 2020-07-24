using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

[System.Serializable]
public struct ImageData
{
    public RawImage buttonImage;
    public string thumbnailURL;
    public string imageURL;
    public string attribution;
}

public class WebImages : MonoBehaviour
{
    public ImageData[] imageData;
    public Renderer imageRenderer;

    private void Start()
    {
        foreach (ImageData data in imageData)
        {
            StartCoroutine(GetWebButton(data.buttonImage, data.thumbnailURL));
        }
    }

    public void LoadImage(int index)
    {
        StartCoroutine(GetWebImage(imageData[index].imageURL));
    }

    IEnumerator GetWebImage(string url)
    {
        using (UnityWebRequest webRequest = UnityWebRequestTexture.GetTexture(url))
        {
            // request and wait for the result
            yield return webRequest.SendWebRequest();

            if (webRequest.isNetworkError || webRequest.isHttpError)
            {
                Debug.Log(webRequest.error);
            }
            else
            {
                Debug.Log("Got data " + webRequest.responseCode);
                var texture = DownloadHandlerTexture.GetContent(webRequest);
                imageRenderer.material.SetTexture("_BaseMap", texture);
                //imageRenderer.material.mainTexture = DownloadHandlerTexture.GetContent(webRequest);
            }
        }
    }

    IEnumerator GetWebButton(RawImage rawImage, string url)
    {
        using (UnityWebRequest webRequest = UnityWebRequestTexture.GetTexture(url))
        {
            // request and wait for the result
            yield return webRequest.SendWebRequest();

            if (webRequest.isNetworkError || webRequest.isHttpError)
            {
                Debug.Log(webRequest.error);
            }
            else
            {
                Debug.Log("Got data " + webRequest.responseCode);
                var texture = DownloadHandlerTexture.GetContent(webRequest);
                rawImage.texture = texture;
            }
        }
    }
}
