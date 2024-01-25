using System.Globalization;
using TMPro;
using UnityEngine;

/// <summary>
/// Computes the value of one neuron as the weighted sum of two inputs:
/// neuron1 * edge1 + neuron2 * edge2. Inputs and result are read from and written to text labels.
/// </summary>
public class Calculator : MonoBehaviour
{
    [SerializeField]
    private TMP_Text neuron1;

    [SerializeField]
    private TMP_Text neuron2;

    [SerializeField]
    private TMP_Text edge1;

    [SerializeField]
    private TMP_Text edge2;

    [SerializeField]
    private TMP_Text textField;

    void Update()
    {
        if (neuron1 == null || neuron2 == null || edge1 == null || edge2 == null || textField == null)
        {
            return;
        }

        if (TryParse(neuron1.text, out float neuron1Value) &&
            TryParse(neuron2.text, out float neuron2Value) &&
            TryParse(edge1.text, out float edge1Value) &&
            TryParse(edge2.text, out float edge2Value))
        {
            float result = neuron1Value * edge1Value + neuron2Value * edge2Value;
            textField.text = result.ToString("0.##", CultureInfo.InvariantCulture);
        }
        else
        {
            // Same placeholder the neuron prefabs show before they receive a value
            textField.text = "NA";
        }
    }

    static bool TryParse(string text, out float value)
    {
        return float.TryParse(text, NumberStyles.Float, CultureInfo.InvariantCulture, out value);
    }
}
