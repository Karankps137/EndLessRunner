using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 0.01f;
    public GameObject PlayerChildAnimation;
    public Transform PlayerLeft;
    public Transform PlayerRight;
    public Transform PlayerCenter;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public enum Position
        {
        Center,
        Right,
        Left
    }

    // Update is called once per frame
    void Update()
    {
        //Move player
        //this.gameObject.transform.Translate(new Vector3(0, 0, speed));
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Play Jump Animation
            PlayerChildAnimation.GetComponent<Animator>().SetTrigger("Jump");
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            //Play Crouch Animation
            PlayerChildAnimation.GetComponent<Animator>().SetTrigger("Crouch");
        }
        if (Input.GetKey(KeyCode.A))
        {
            //Move player to left
            if (Position.Left != CheckPlayerPosition(this.transform))
            //if(this.transform.position.x!=-2.5f)
            {
                this.transform.position= Vector3.Lerp(this.transform.position, new Vector3(this.transform.position.x - 0.5f, this.transform.position.y, this.transform.position.z), 0.05f);
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            //Move player to right
            if (Position.Right != CheckPlayerPosition(this.transform))
                //if (this.transform.position.x!=2.5f)
            {
                this.transform.position= Vector3.Lerp(this.transform.position, new Vector3(this.transform.position.x + 0.5f, this.transform.position.y, this.transform.position.z), 0.05f);
            }
        }

    }

    Position CheckPlayerPosition(Transform pos)
    {
        if (pos.position == PlayerCenter.transform.position)
            return Position.Center;
        else if (pos.position == PlayerLeft.transform.position)
            return Position.Left;
        else if (pos.position == PlayerRight.transform.position)
            return Position.Right;

        return 0;
    }
}
