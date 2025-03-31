using System;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public List<Tube> tubes = new List<Tube>();
    public Ball balPrefab;

    private List<int> typeList = new List<int>()
    {
        1, 1, 2, 2, 1, 0, 2, 0, 0, 1, 2, 0
    };

    private void Start()
    {
        SpawmBall();
    }

    private void SpawmBall()
    {
        for (int i = 0; i < tubes.Count-2; i++)
        {
            for (int j = 0; j < tubes[0].maxBall; j++)
            {
                int type = typeList[4 * i + j];
                var ball = tubes[i].InstantiateBall(type);
                tubes[i].AddBall(ball);
            }
        }
    }
}
