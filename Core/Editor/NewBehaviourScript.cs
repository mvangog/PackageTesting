using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.PackageManager.Requests;
using UnityEditor.PackageManager;

public class NewBehaviourScript : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        Client.Add("com.unity.textmeshpro");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
