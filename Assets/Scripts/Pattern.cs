using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern : MonoBehaviour
{
    private List<int> pattern;
    
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

    public override string ToString()
    {
        string s = "[";

        for (int i = 0; i < pattern.Count-1; i++)
        {
            s += pattern[i].ToString() + ",";
        }


        return s + pattern[pattern.Count-1] + "]";
    }

    public double Compare(List<int> array, int startIndex)
    {

        return 1.0;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
