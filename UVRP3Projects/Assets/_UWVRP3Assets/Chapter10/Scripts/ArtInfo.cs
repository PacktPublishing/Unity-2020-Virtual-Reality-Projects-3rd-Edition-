using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ArtInfo : MonoBehaviour
{
    public ArtInfoData artInfo;
    public GameObject image;
    public TMP_Text title;
    public TMP_Text artist;
    public TMP_Text description;
    public Transform frame;

    private void Start()
    {
        Renderer rend = image.GetComponent<Renderer>();
        Material material = rend.material;
        material.mainTexture = artInfo.image;

        title.text = artInfo.title;
        artist.text = artInfo.artist;
        description.text = artInfo.description;
        frame.localScale = TextureToScale(artInfo.image, frame.localScale);
    }

    private Vector3 TextureToScale(Texture texture, Vector3 scale)
    {
        if (texture.width > texture.height)
        {
            scale.x = 1f;
            scale.y = (float)texture.height / (float)texture.width;
        }
        else
        {
            scale.x = (float)texture.width / (float)texture.height;
            scale.y = 1f;
        }
        return scale;
    }
}
