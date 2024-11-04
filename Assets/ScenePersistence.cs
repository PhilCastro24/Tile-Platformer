using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenePersistence : MonoBehaviour
{
    void Awake()
    {
        int numOfScenePersists = FindObjectsOfType<ScenePersistence>().Length;

        if (numOfScenePersists > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void ResetScenePersist()
    {
        Destroy(gameObject);
    }
}
