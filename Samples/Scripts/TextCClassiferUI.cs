using TMPro;
using UnityEngine;
using SkybirdGames.TextClassifier;
using UnityEditor;

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

        var trainingFilePath = AssetDatabase.GetAssetPath(trainingFile);

        classifier = new TextClassifier(trainingFilePath);

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
