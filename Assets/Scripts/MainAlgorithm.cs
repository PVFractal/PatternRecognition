using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainAlgorithm : MonoBehaviour
{
    private int length = 4;

    private int[] testArray = {0, 1, 2, 3, 1, 2, 1, 2, 3, 1, 5, 4, 6, 2, 3, 4, 1, 3, 2};
    private List<int> dataArray;

    private List<Pattern> patterns;

    // Start is called before the first frame update
    void Start()
    {
        dataArray = new List<int>(testArray);
        length = dataArray.Count;

        GetPrediction();
    }

    public void GetPrediction()
    {
        patterns = new List<Pattern>();
        
        GetPatternList();

        /*
        Pattern p = new Pattern();
        p.addToPattern(1);
        p.addToPattern(2);
        patterns.Add(p);
        */

        

        CheckPatterns();

        DisplayPatternsSelective();

        int index = GetMostValueablePattern();

        Debug.Log("Most valuable: " + patterns[index].ToString());


    }

    private void GetPatternList()
    {
        

        //Loops through the different sized patterns, from 2 to length -1
        for (int patternSize = 2; patternSize < length; patternSize++)
        {
            int arrayIndex = 0;

            while (arrayIndex + patternSize <= length) 
            {
                Pattern p = new Pattern();
                for (int i = 0; i < patternSize; i++)
                {
                    int positionInArray = i + arrayIndex;
                    p.addToPattern(dataArray[positionInArray]);
                    

                }
                patterns.Add(p);

                arrayIndex++;
            }
            


        }

    }

    private void DisplayPatterns()
    {
        for (int i = 0; i < patterns.Count; i++)
        {
            Debug.Log("Pattern: " + patterns[i].ToString() + " Value: " + patterns[i].GetVal());
        }
    }

    private void DisplayPatternsSelective()
    {
        for (int i = 0; i < patterns.Count; i++)
        {
            if (patterns[i].GetVal() <= 1) { continue; }
            Debug.Log("Pattern: " + patterns[i].ToString() + " Value: " + patterns[i].GetVal());
        }
    }

    private int GetMostValueablePattern()
    {
        int valueableIndex = -1;
        double bestVal = 0;
        for (int i = 0; i < patterns.Count; i++)
        {
            double val = patterns[i].SortValue();
            if (val > bestVal)
            {
                bestVal = val;
                valueableIndex = i;
            }

        }
        return valueableIndex;
    }

    private int FindNextValue()
    {
        int valueableIndex = -1;
        double bestVal = 0;
        for (int i = 0; i < patterns.Count; i++)
        {
            double correctness = patterns[i].PredictionCorrectness(dataArray);

            if (correctness < 0.8)
            {
                correctness = 0;
            }
            double rawVal = patterns[i].GetVal();
            double val = correctness * rawVal;

            if (val > 0)
            {
                Debug.Log("FinalVal: " + val);
            }

            if (val > bestVal)
            {
                bestVal = val;
                valueableIndex = i;
            }

        }
        


        return 0;
    }






    private void CheckPatterns()
    {
        
        //Getting all patterns
        for (int i = 0; i < patterns.Count; i++)
        {

            int arrayIndex = 0;

            while (arrayIndex + patterns[i].Count() < length)
            {
                double val = patterns[i].Compare(dataArray, arrayIndex);
                patterns[i].RemoveInsignificantValues();



                arrayIndex++;
            }
        }

    }



    




    // Update is called once per frame
    void Update()
    {
        
    }


}
