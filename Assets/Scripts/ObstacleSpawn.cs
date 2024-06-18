using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawn : MonoBehaviour
{
    public static ObstacleSpawn instance;
    public GameObject prevroad;
    public GameObject[] Obstacles;
    public int ObstacleLength=3;
    // Start is called before the first frame update
    void Start()
    {
        instance=this;
        ObstacleLength=Obstacles.Length;
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
                int[] c = Choose(ObstacleLength, 0, ObstacleLength);
                for(int i=0;i<ObstacleLength;i++)
                {
                    GameObject obs= Instantiate(Obstacles[i],temp.transform.GetChild(c[i]).transform);
                    obs.transform.SetParent(road.transform.Find("car parent").transform);
                }
            }
        }
        
    }
    public static int[] Choose(int k, int min, int max)
{
    var items = new List<int>();
    for(var i=min; i<max; i++) items.Add(i);
 
    var choices = new int[k];
    for (var i = 0; i < k; i++)
    {
        var index = UnityEngine.Random.Range(0, items.Count);
        choices[i] = items[index];
        items.RemoveAt(index);
    }
    return choices;
}
    
}
