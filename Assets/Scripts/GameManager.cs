using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public GameObject[] RoadPieces = new GameObject[2];
    public float RoadLength = 100f; 

    public float RoadSpeed = 5f;
    public int Health=10;
    public int Score=0;
    public static GameManager instance;
    public GameObject HealthText;
    public GameObject ScoreText;
    public GameObject GameoverText;

    void Start()
    {
        instance=this;
        GameoverText.SetActive(false);
    }
    void Update()
    {
        foreach (GameObject road in RoadPieces)
        {
            Vector3 newRoadPos = road.transform.position;
            newRoadPos.z -= RoadSpeed * Time.deltaTime;
            if (newRoadPos.z < -RoadLength / 2)
            {
                newRoadPos.z += RoadLength;
                ObstacleSpawn.instance.SpawnObstacle(road);
            }
            road.transform.position = newRoadPos;
        }
    }
}
