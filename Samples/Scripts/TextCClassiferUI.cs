using TMPro;
using UnityEngine;
using SkybirdGames.TextClassifier;

public class TextCClassiferUI : MonoBehaviour
{
    [SerializeField] private TextAsset trainingFile;
    [SerializeField] private TMP_Text inferenceReadout;
    [SerializeField] private TMP_InputField queryInputField;
    [SerializeField] private double tolerance;

    private TextClassifier classifier;

    private void Start()
    {
        if (trainingFile == null)
        {
            Debug.LogError("No training file");
            return;
        }

        classifier = new TextClassifier(trainingFile.text);

        inferenceReadout.text = "";
    }

    public void SumbitQuery()
    {
        inferenceReadout.text =
            classifier.Predict(
                text: queryInputField.text,
                threshold: tolerance);
    }
}
