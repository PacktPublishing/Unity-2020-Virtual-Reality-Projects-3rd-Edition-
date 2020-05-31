using UnityEngine;
using UnityEngine.UI;

public class LightsControls : MonoBehaviour
{
    public Slider directionalAngleSlider;
    public Slider directionalIntensitySlider;
    public Slider spotIntensitySlider;
    public Toggle bulbEmissionToggle;

    public Light directionalLight;
    public Light spotLight;
    public Renderer spotBulb;

    private Text directionalAngleText;
    private Text directionalIntensityText;
    private Text spotIntensityText;

    private bool _bulbEmission;
    private Color _emissionColor;

    private void Start()
    {
        directionalAngleText = directionalAngleSlider.GetComponentInChildren<Text>();
        directionalIntensityText = directionalIntensitySlider.GetComponentInChildren<Text>();
        spotIntensityText = spotIntensitySlider.GetComponentInChildren<Text>();

        directionalAngleSlider.value = DirectionalAngle;
        directionalIntensitySlider.value = DirectionalIntensity;
        spotIntensitySlider.value = SpotIntensity;

        _emissionColor = spotBulb.material.GetColor("_EmissionColor");
        _bulbEmission = (_emissionColor != Color.black);
        bulbEmissionToggle.isOn = BulbEmission;
    }

    public float DirectionalAngle {
        get => directionalLight.transform.localEulerAngles.x;
        set {
            Vector3 angles = directionalLight.transform.localEulerAngles;
            angles.x = value;
            directionalLight.transform.localEulerAngles = angles;
            directionalAngleText.text = value.ToString("F0");
        }
    }

    public float DirectionalIntensity {
        get => directionalLight.intensity;
        set {
            directionalLight.intensity = value;
            directionalIntensityText.text = value.ToString("F1");
        }
    }

    public float SpotIntensity {
        get => spotLight.intensity;
        set {
            spotLight.intensity = value;
            spotIntensityText.text = value.ToString("F1");
        }
    }

    public bool BulbEmission {
        get => _bulbEmission;
        set {
            spotBulb.material.SetColor("_EmissionColor", value ? _emissionColor : Color.black);
            _bulbEmission = value;
        }
    }
}
