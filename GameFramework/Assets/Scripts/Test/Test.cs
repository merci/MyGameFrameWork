using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {
    string test;
    // Use this for initialization
    void Start () {
       
    }
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < 20; i++)
        {
            using (ZString.Block())
            {
                test = ZString.Concat("12", "222", "33");
            }
            //test = string.Concat("12", "222", "33");
            //Debug.Log(test);
        }
    }
}
