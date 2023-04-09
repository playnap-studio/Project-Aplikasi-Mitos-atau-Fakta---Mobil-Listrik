using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testo : MonoBehaviour
{

    int a = 7;
    int b = 2;
    int mod;
    // Start is called before the first frame update
    void Start()
    {
        mod = a%b;
        Debug.Log(mod);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
