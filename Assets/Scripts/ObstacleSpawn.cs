using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawn : MonoBehaviour
{
    public static ObstacleSpawn instance;
    public GameObject prevroad;
    public GameObject[] Obstacles;
    // Start is called before the first frame update
    void Start()
    {
        instance=this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnObstacle(GameObject road)
    {
        if(prevroad!=null)
        {
            foreach(Transform temp in road.transform.Find("car parent"))
            {
                Destroy(temp.gameObject);
            }
        }
        prevroad=road;
        Debug.Log("Spawn");
        foreach(Transform temp in road.transform)
        {
            if(temp.name=="Obstacle")
            {
                for(int i=0;i<3;i++)
                {
                    GameObject obs= Instantiate(Obstacles[i],temp.transform.GetChild(Random.Range(0,3)).transform);
                    obs.transform.SetParent(road.transform.Find("car parent").transform);
                }
            }
        }
        
    }
}
