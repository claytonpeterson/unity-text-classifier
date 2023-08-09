
# Text Classifier
This package provides a C# wrapper for the library: https://github.com/lytics/multibayes - providing multiclass naive Bayesian document classification in Unity

A basic example looks like this
```csharp 
using UnityEngine;
using SkybirdGames.TextClassifier;

public class TextClassiferTest : MonoBehaviour
{
    [SerializeField] private NaiveBayesTextClassifierData trainingData;

    void Start()
    {
        var textClassifier = new NaiveBayesTextClassifier(trainingData.ToJson());

        print(textClassifier.Predict(text: "Hello there my friend", threshold: 0.4));

        // result = "greetings"
    }
}
```

## Installation
To install the package in your Unity project:
1. Open the package manager
2. Press the "+" button
3. Select "add package from git URL"
4. Enter: https://github.com/claytonpeterson/unity-text-classifier.git
5. Press "add"

## Training Data Set
The underlying library requires a json training string in the format

```json
[
    {
        "Text": "Example statement",
        "Classes": [ "class" ]
    },
    {
        "Text": "Example statement",
        "Classes": [ "class" ]
    }...
]
```

### About the format
1. **Text** contains a statement that provides an example of the class   
```"Text": "Hello my friend"```
2. **Classes** contains the collection of classes that the statement belongs to   
``` "Classes": [ "greetings", "friendship" ]```

## NaiveBayesTextClassifierData
You can write your json training data manually, or to make things easier you can 
create a **NaiveBayesTextClassifierData** scriptable object in Unity

### How to Create
1. To create the training object select *"Assets/Create/SkybirdGames/Naive Bayes Text Classifier/New Dataset"*
2. Next, select the object in the inspector, open it's **TrainingData** array and press the **"+"** button to add a new class
4. Finally, open the class's **Texts** array, and press the **"+"** button to add example statements to the class

## NaiveBayesTextClassifier
The **NaiveBayesTextClassifier** class is initialized with a string containing the json training data

```csharp
var textClassifier = new NaiveBayesTextClassifier(jsonTrainingData);
```

The **Predict** method returns the predicted class  
The **Threshold** is used to filter out results that have a lower probability than the threshold
```csharp
var text = "Hide behind that rock!"
var threshold = 0.4;
var result = textClassifier.Predict(text, threshold);

// result = "cover"
```

## Included Samples
The folder **"Text Classifier/Samples/TrainingData"** includes:
1. A raw json data file **("combat_training_data")** that is trained to recognize "combat dialogue"
2. A **NaiveBayesTextClassifierData** object that is trained to recognize greetings and farewells