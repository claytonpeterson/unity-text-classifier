
# Text Classifier
This package provides a C# wrapper for the library: https://github.com/lytics/multibayes - providing multiclass naive Bayesian document classification in Unity

## Installation
To install the package in your Unity project:
1. Open the package manager
2. Press the "+" button
3. Select "add package from git URL"
4. Enter: https://github.com/claytonpeterson/unity-text-classifier.git
5. Press "add"

## Creating a Training Data Set
In order to create a **classifier** you must first create a **json training data set** in the format
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

## TextClassifer
The **TextClassifier** class is initialized with a string containing the json training data

```csharp
var textClassifier = new TextClassifier(jsonTrainingData);
```

The **Predict** method returns the predicted class  
The **Threshold** is used to filter out results that have a lower probability than the threshold
```csharp
var text = "Hide behind that rock!"
var threshold = 0.4;
var result = textClassifier.Predict(text, threshold);

// result = "cover"
```

## Unity Example
Here is a basic example of how to use the text classifier in Unity  
```csharp
using UnityEngine;
using SkybirdGames.TextClassifier;

public class TextClassiferTest : MonoBehaviour
{
    [SerializeField] 
    private TextAsset jsonTrainingData;

    void Start()
    {
        var textClassifier = new TextClassifier(jsonTrainingData.text);

        print(textClassifier.Predict("Get to cover", 0.4));
    }
}
```
Sample data sets can be found in **"TextSamples/TrainingData"**

