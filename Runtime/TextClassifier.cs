using System;
using System.Runtime.InteropServices;
using System.Text;

namespace SkybirdGames.TextClassifier
{ 
    public class TextClassifier
    {
        [DllImport("TextClassifier.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        private static extern IntPtr PredictClass(byte[] input, double threshold, byte[] trainingFilePath);

        private readonly string trainingDataJsonFilepath;

        public TextClassifier(string trainingDataJsonFilepath)
        {
            this.trainingDataJsonFilepath = trainingDataJsonFilepath;
        }

        public string Predict(string text, double threshold)
        {
            IntPtr resultbytes = PredictClass(
                input: Encoding.UTF8.GetBytes(text),
                threshold: threshold,
                trainingFilePath: Encoding.UTF8.GetBytes(trainingDataJsonFilepath));

            return Marshal.PtrToStringAnsi(resultbytes);
        }
    }
}
