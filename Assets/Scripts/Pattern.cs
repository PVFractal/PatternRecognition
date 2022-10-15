using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern : MonoBehaviour
{
    private List<int> pattern;

    private double value;
    // Start is called before the first frame update
    void Start()
    {
    }

    public Pattern()
    {
        pattern = new List<int>();
    }

    public void addToPattern(int num)
    {
        pattern.Add(num);
    }
    public int Count()
    {
        return pattern.Count;
    }
    public void SetVal(double val)
    {
        value = val;
    }
    public void AddVal(double val)
    {
        value += val;
    }

    public double GetVal()
    {
        return value;
    }
    public override string ToString()
    {
        string s = "[";

        for (int i = 0; i < pattern.Count-1; i++)
        {
            s += pattern[i].ToString() + ",";
        }


        return s + pattern[pattern.Count-1] + "]";
    }
    public int LastValue()
    {
        return pattern[pattern.Count - 1];
    }

    public double Compare(List<int> array, int startIndex)
    {
        int length = pattern.Count;
        int correct = 0;

        for (int i = startIndex; i < startIndex + length; i++)
        {
            if (array[i] == pattern[i - startIndex])
            {
                correct++;
            }
        }
        return (double)correct/(double)length;
    }

    



    public double PredictionCorrectness(List<int> array)
    {
        int length = pattern.Count - 1;
        int arrayLen = array.Count;
        int correct = 0;
        int patternIndex = 0;
        for (int i = arrayLen - length; i < arrayLen; i++)
        {
            if (array[i] == pattern[patternIndex])
            {
                correct++;
            }
            patternIndex++;
        }


        return (double)correct / (double)length;
    }



    public double SortValue()
    {
        double inverseVal = 1.0 - (1.0 / ((double)pattern.Count * 0.75));
        double final = inverseVal * value;
        return final;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
