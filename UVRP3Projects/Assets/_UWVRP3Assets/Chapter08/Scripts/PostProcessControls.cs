using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class PostProcessControls : MonoBehaviour
{
    public Transform uiPanel;
    public GameObject togglePrefab;
    public Volume postProcessVolume;

    private VolumeProfile profile;
    private List<VolumeComponent> components;
    private List<Toggle> toggles = new List<Toggle>();

    private void Start()
    {
        profile = postProcessVolume.profile;
        components = profile.components;

        for (int i = 0; i < components.Count; i++)
        {
            GameObject go = Instantiate(togglePrefab, uiPanel);
            Toggle toggle = go.GetComponent<Toggle>();
            int index = i;
            toggle.onValueChanged.AddListener((value) =>
                { components.ElementAt(index).active = value; });
            Text text = go.GetComponentInChildren<Text>();
            text.text = components.ElementAt(i).name;
            toggles.Add(toggle);
        }
    }
}
