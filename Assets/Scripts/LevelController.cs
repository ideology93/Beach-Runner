using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public LevelPiece[] levelPieces;
    public Transform cam;
    public int drawDistance;
    public float pieceLength;
    public float speed;

    private void Start()
    {
        for (int i = 0; i < drawDistance; i++)
        {
            GameObject newLevelPiece = Instantiate(levelPieces[0].prefab, new Vector3(0f, 0f, pieceLength * i), Quaternion.identity);
        }
    }
    private void FixedUpdate()
    {
        cam.transform.position = Vector3.MoveTowards(cam.transform.position, cam.transform.position + Vector3.forward, Time.deltaTime * speed);
    }
}

[System.Serializable]
public class LevelPiece
{
    public string name;
    public GameObject prefab;
    public int probability = 1;
}

// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class ObjectPooler : MonoBehaviour
// {
//     [System.Serializable]
//     public class Pool
//     {
//         public GameObject prefab;
//         public int size;
//         public string type;
//     }
//     public static ObjectPooler instance;
//     private void Awake()
//     {
//         instance = this;
//     }
//     public List<Pool> pools;
//     public Dictionary<string, Queue<GameObject>> poolDictionary;
//     GameObject objectToSpawn;
//     void Start()
//     {
//         poolDictionary = new Dictionary<string, Queue<GameObject>>();
//         foreach (Pool pool in pools)
//         {
//             Queue<GameObject> objectPool = new Queue<GameObject>();
//             for (int i = 0; i < pool.size; i++)
//             {
//                 GameObject obj = Instantiate(pool.prefab);
//                 obj.SetActive(false);
//                 objectPool.Enqueue(obj);
//             }
//             poolDictionary.Add(pool.type, objectPool);
//         }
//     }
//     public GameObject SpawnFromPool(string type, Vector3 position, Quaternion rotation)
//     {
//         if (!poolDictionary.ContainsKey(type))
//         {
//             Debug.LogWarning("Pool with type:" + type + " doesn't exist.");
//             return null;
//         }
//         objectToSpawn = poolDictionary[type].Dequeue();
//         objectToSpawn.SetActive(true);
//         objectToSpawn.transform.position = position;
//         objectToSpawn.transform.rotation = rotation;
//         poolDictionary[type].Enqueue(objectToSpawn);
//         return objectToSpawn;
//     }

// }

