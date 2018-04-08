using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGameObjects : MonoBehaviour {

    public string[] gameObjectNamesToDestroy;

    // Use this for initialization
    void Start()
    {
        foreach (string name in gameObjectNamesToDestroy)
        {
            var go = GameObject.Find(name);
            if (go != null) { Destroy(go); }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

}
