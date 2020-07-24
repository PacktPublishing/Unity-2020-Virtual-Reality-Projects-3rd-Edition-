using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopulateArtFrames : MonoBehaviour
{
    public Texture[] images;

    void Start()
    {
        int imageIndex = 0;
        foreach (Transform artwork in transform)
        {
            GameObject art = artwork.Find("ArtFrame/Image").gameObject;
            Renderer rend = art.GetComponent<Renderer>();
            Material material = rend.material;
            material.mainTexture = images[imageIndex];
            imageIndex++;
            if (imageIndex == images.Length)
                break;
        }
    }
}
