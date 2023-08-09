using System.Collections.Generic;
using Unity.Plastic.Newtonsoft.Json;
using UnityEngine;

namespace SkybirdGames.TextClassifier
{
    [CreateAssetMenu(menuName = "SkybirdGames/Naive Bayes Text Classifier/New Dataset", fileName = "Naive Bayes Text Classifier Dataset")]
    public class NaiveBayesTextClassifierData : ScriptableObject
    {
        [System.Serializable]
        public struct JsonStatement
        {
            public string Text;
            public string[] Classes;
        }

        [System.Serializable]
        public struct RecognizedClass
        {
            public string Class;
            public string[] Texts;
        }

        [SerializeField] private RecognizedClass[] trainingData;

        public string ToJson()
        {
            var document = new List<JsonStatement>();

            foreach (var entry in trainingData)
            {
                foreach(var text in entry.Texts)
                {
                    document.Add(new JsonStatement
                    {
                        Classes = new string[1] { entry.Class },
                        Text = text
                    });
                }
            }

            return JsonConvert.SerializeObject(document);
        }
    }
}
