using Leap.Unity.Interaction;
using UnityEngine;

/// <summary>
/// Moves all neuron and weight sliders to random positions when the button is pressed.
/// </summary>
public class RandomizeSliders : MonoBehaviour
{
    [SerializeField]
    private InteractionSlider[] neuronSliders;

    [SerializeField]
    private InteractionSlider[] edgeSliders;

    [SerializeField]
    private InteractionButton button;

    void Update()
    {
        if (button != null && button.pressedThisFrame)
        {
            RandomizeSliderValues(neuronSliders);
            RandomizeSliderValues(edgeSliders);
        }
    }

    static void RandomizeSliderValues(InteractionSlider[] sliders)
    {
        foreach (var slider in sliders)
        {
            if (slider == null)
            {
                continue;
            }

            // One of the 11 positions 0.0, 0.1, ..., 1.0 that SliderValueToText shows as -5..5.
            // The slider clamps its value to 0..1, so integer values would only reach the ends.
            slider.HorizontalSliderValue = Random.Range(0, 11) / 10f;
        }
    }
}
