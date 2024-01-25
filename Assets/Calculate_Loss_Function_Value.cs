using System.Globalization;
using TMPro;
using UnityEngine;

/// <summary>
/// Shows the squared error (predicted - actual)^2 between the network output and the target value.
/// </summary>
public class Calculate_Loss_Function_Value : MonoBehaviour
{
    [SerializeField]
    private TMP_Text predictedValueInput;

    // Label in the form "Actual Value: 6"
    [SerializeField]
    private TMP_Text actualValueInput;

    [SerializeField]
    private TMP_Text resultText;

    void Update()
    {
        if (predictedValueInput == null || actualValueInput == null || resultText == null)
        {
            return;
        }

        if (TryParse(predictedValueInput.text, out float predictedValue) &&
            TryGetValueFromLabel(actualValueInput.text, out float actualValue))
        {
            float result = Mathf.Pow(predictedValue - actualValue, 2);
            resultText.text = "Loss function Value: " + result.ToString("0.##", CultureInfo.InvariantCulture);
        }
        else
        {
            // The output is not available yet, e.g. in the first frame
            resultText.text = "Loss function Value: NA";
        }
    }

    static bool TryGetValueFromLabel(string label, out float value)
    {
        // Take the part after the colon
        string[] parts = label.Split(':');
        value = 0f;
        return parts.Length == 2 && TryParse(parts[1], out value);
    }

    static bool TryParse(string text, out float value)
    {
        return float.TryParse(text.Trim(), NumberStyles.Float, CultureInfo.InvariantCulture, out value);
    }
}
