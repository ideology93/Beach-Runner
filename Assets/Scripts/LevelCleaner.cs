using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCleaner : MonoBehaviour
{
    public class Objs
    {
        public List<Transform> list;
    }
    public Transform Obstacles;
    public Transform Platforms;
    public Transform Coins;
    public Transform Environment;
    public List<Transform> obstacles = new List<Transform>();
    public List<Transform> platforms = new List<Transform>();
    public List<Transform> coins = new List<Transform>();
    public List<Transform> environment = new List<Transform>();
    public Transform Player;
    private float playerPosition;
    private float plaformOffset;
    int p = 0;
    int e = 0;
    int o = 0;
    void Awake()
    {

        for (int i = 0; i < Obstacles.childCount; i++)
        {
            obstacles.Add(Obstacles.GetChild(i));
        }
        for (int i = 0; i < Platforms.childCount; i++)
        {
            platforms.Add(Platforms.GetChild(i));
        }
        for (int i = 0; i < Environment.childCount; i++)
        {
            environment.Add(Environment.GetChild(i));
        }
        for (int i = 0; i < Coins.childCount; i++)
        {
            coins.Add(Coins.GetChild(i));
        }



    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = Player.position.z;
        plaformOffset = platforms[p].position.z;
        if (platforms[p].position.z + 5 < playerPosition)
        {
            platforms[p].gameObject.SetActive(false);
            if (p < platforms.Count - 1)
                p++;
        }
        if (obstacles[o].position.z + 3 < playerPosition)
        {
            obstacles[o].gameObject.SetActive(false);
            if (o < obstacles.Count - 1)
                o++;
        }
        if (environment[e].position.z + 10 < playerPosition)
        {

            environment[e].gameObject.SetActive(false);
            if (e < environment.Count - 1)
                e++;
        }

    }
}
