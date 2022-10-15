﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainAlgorithm : MonoBehaviour
{
    private int length = 4;

    private int[] testArray = {0,1,0};
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


        //DisplayPatterns();

        //DisplayPatternsSelective();

        int index = FindNextValue();

        Debug.Log("Next value: " + index);


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


            /*
            if (correctness > 0)
            {
                Debug.Log("Correct Pattern: " + patterns[i].ToString() + " Correctness: " + correctness);
            }
            */



            double rawVal = patterns[i].SortValue();
            double val = correctness * rawVal;

            

            if (val > bestVal)
            {
                bestVal = val;
                valueableIndex = i;
            }

        }
        

        if (valueableIndex != -1)
        {
            return patterns[valueableIndex].LastValue();
        }
        return -1;
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
                val = RemoveInsignificantValues(val, patterns[i].Count());
                patterns[i].AddVal(val);


                arrayIndex++;
            }
        }

    }


    public double RemoveInsignificantValues(double val, int patternLength)
    {
            
        if (patternLength > 8)
        {
            if (val < 0.9)
            {
                return 0;
            }
        }
        else if (patternLength > 5)
        {
            if (val < 0.8)
            {
                return 0;
            }
        }
        else if (patternLength > 3)
        {
            if (val < 0.7)
            {
                return 0;
            }
        }
        else if (patternLength > 1)
        {
            if (val < 0.9)
            {
                return 0;
            }
        }

        return val;

    }





    // Update is called once per frame
    void Update()
    {
        
    }


}
