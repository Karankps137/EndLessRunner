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
                    int c=Random.Range(0,3);
                    GameObject obs= Instantiate(Obstacles[i],temp.transform.GetChild(c).transform);
                    foreach(Transform check in road.transform.Find("car parent").transform)
                    {
                        if(check.transform.position==obs.transform.position)
                        {
                            check.transform.position = temp.transform.GetChild(2-c).transform.position;
                        }
                    }
                    obs.transform.SetParent(road.transform.Find("car parent").transform);
                }
            }
        }
        
    }
}
