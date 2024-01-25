using System.Globalization;
using Leap.Unity.Interaction;
using TMPro;
using UnityEngine;

/// <summary>
/// Shows the position of an Ultraleap slider as an integer from -5 to 5 in a text label.
/// </summary>
public class SliderValueToText : MonoBehaviour
{
    [SerializeField]
    private InteractionSlider slider;

    [SerializeField]
    private TMP_Text textField;

    void Update()
    {
        // Computed neurons reuse this prefab setup without a slider; their label is written by Calculator.
        if (slider == null || textField == null)
        {
            return;
        }

        // wasSlid is also raised when the value is set from code (initial value, RandomizeSliders).
        if (slider.wasSlid)
        {
            // Map the slider range 0..1 to the integers -5..5
            int value = Mathf.RoundToInt(slider.HorizontalSliderValue * 10) - 5;
            textField.text = value.ToString(CultureInfo.InvariantCulture);
        }
    }
}
