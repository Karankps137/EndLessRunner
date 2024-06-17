using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollision : MonoBehaviour
{
    public object GameoverText { get; private set; }

    // Start is called before the first frame update
    void Start() => GameManager.instance.GameoverText.SetActive(false);

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Obstacle")
        {
            //add health condition above 1
            GameManager.instance.Health--;
            GameManager.instance.HealthText.GetComponent<Text>().text=GameManager.instance.Health.ToString();

            //check health 0, set text to gameover
        }
        if(other.gameObject.tag=="Coin")
        {
            GameManager.instance.Score++;
            GameManager.instance.ScoreText.GetComponent<Text>().text=GameManager.instance.Score.ToString();
            if(GameManager.instance.Score%10==0)
            GameManager.instance.HealthText.GetComponent<Text>().text=(++GameManager.instance.Health).ToString();
            Destroy(other.gameObject);
        }
        if (GameManager.instance.Health == 0)
        {
            GameManager.instance.GameoverText.SetActive(true);
            Debug.Log("Gameover");
            GameManager.instance.RoadSpeed = 0;

        }


    }
}
