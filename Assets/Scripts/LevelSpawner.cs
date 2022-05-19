using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawner : MonoBehaviour
{
    public GameObject prefabGrass;
    public List<GameObject> prefabList;

    private void Awake()
    {
        prefabList = new List<GameObject>();
        for (int i = 0; i < 35; i++)
        {
            prefabList.Add(prefabGrass);
        }
    }

}
