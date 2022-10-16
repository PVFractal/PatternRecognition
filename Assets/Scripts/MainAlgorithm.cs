/*
 * Name: Peter Vahlberg
 * Date created: 10/15/22
 * Purpose: to compute the next number given an array of numbers
 */



using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MainAlgorithm : MonoBehaviour
{
    private int length = 4;

    private int[] testArray = {2,4,6,8,6,4};
    private List<int> dataArray;

    private List<Pattern> patterns;

    public void addToArray(int num)
    {
        dataArray.Add(num);

        if (dataArray.Count > 20)
        {
            dataArray.RemoveAt(0);
        }
    }


    public MainAlgorithm ()
    {
        dataArray = new List<int>();
    }
    public int GetPrediction()
    {


        
        //dataArray = new List<int>(testArray);
        length = dataArray.Count;

        if (length < 3) { return -1; }

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

        return index;
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


}
