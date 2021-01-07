using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplicationsFonctions : MonoBehaviour
{
    int result;

    // Start is called before the first frame update
    void Start()
    {
        result = 0;
        result = 5 + 2;
        Debug.Log(result);

        for(int i = 0; i < 20; i++ ){
            result = Increment(result);
        }

        result = Add(result, 5);
    }

    int Increment(int r){
        r++;
        Debug.Log(r);

        return r;
    }

    int Add(int a, int b) {
        int result = a + b;
        Debug.Log(result);
        return result;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
