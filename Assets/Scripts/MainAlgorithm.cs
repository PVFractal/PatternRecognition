using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainAlgorithm : MonoBehaviour
{
    private int length = 4;
    private int[] pattern = {0, 1, 2, 3, 1, 2, 1, 2, 3, 1, 5, 4, 6, 2, 3, 4, 1, 3, 2};
    private List<Pattern> patterns;

    // Start is called before the first frame update
    void Start()
    {
        GetPrediction();
    }

    public void GetPrediction()
    {
        patterns = new List<Pattern>();
        //GetPatternList();

        Pattern p = new Pattern();
        p.addToPattern(1);
        p.addToPattern(2);
        patterns.Add(p);


        DisplayPatterns();

        CheckPatterns();


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
                    p.addToPattern(pattern[positionInArray]);
                    

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
            Debug.Log("Pattern: " + patterns[i].ToString());
        }
    }

    private void CheckPatterns()
    {
        //Getting all patterns
        for (int i = 0; i < patterns.Count; i++)
        {

            int arrayIndex = 0;

            while (arrayIndex + patterns[i].Count() <= length)
            {
                
                

                arrayIndex++;
            }



        }

    }







    // Update is called once per frame
    void Update()
    {
        
    }


}
