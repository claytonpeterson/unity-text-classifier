using UnityEngine;
using SkybirdGames.TextClassifier;
using UnityEditor;

public class PredictionTester : MonoBehaviour
{
    [SerializeField] private TextAsset trainingFile;
    [SerializeField] private string inputText;
    [SerializeField] private double tolerance;

    private void Start()
    {
        var trainingFilePath = AssetDatabase.GetAssetPath(trainingFile);
        var textClassifier = new TextClassifier(trainingFilePath);

        print(textClassifier.Predict(inputText, tolerance));
    }
}
