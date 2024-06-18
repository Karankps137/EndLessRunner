using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 0.05f;
    public GameObject PlayerChildAnimation;
    public Transform PlayerLeft;
    public Transform PlayerRight;
    public Transform PlayerCenter;

    public static PlayerMovement instance;
    public bool IsGameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
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
        if (Input.GetKeyDown(KeyCode.Space) && !IsGameOver)
        {
            //Play Jump Animation
            PlayerChildAnimation.GetComponent<Animator>().SetTrigger("Jump");
        }
        if (Input.GetKeyDown(KeyCode.C) && !IsGameOver)
        {
            //Play Crouch Animation
            PlayerChildAnimation.GetComponent<Animator>().SetTrigger("Crouch");
        }
        if (Input.GetKey(KeyCode.A) && !IsGameOver)
        {
            //Move player to left
            if (Position.Left != CheckPlayerPosition(this.transform))
            //if(this.transform.position.x!=-2.5f)
            {
                this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(this.transform.position.x - 2.5f, this.transform.position.y, this.transform.position.z), speed);
            }
        }
        if (Input.GetKey(KeyCode.D) && !IsGameOver)
        {
            //Move player to right
            if (Position.Right != CheckPlayerPosition(this.transform))
            //if (this.transform.position.x!=2.5f)
            {
                this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(this.transform.position.x + 2.5f, this.transform.position.y, this.transform.position.z), speed);
            }
        }

        /*foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                fingerUpPos = touch.position;
                fingerDownPos = touch.position;
            }

            //Detects Swipe while finger is still moving on screen
            if (touch.phase == TouchPhase.Moved)
            {
                if (!detectSwipeAfterRelease)
                {
                    fingerDownPos = touch.position;
                    DetectSwipe();
                }
            }

            //Detects swipe after finger is released from screen
            if (touch.phase == TouchPhase.Ended)
            {
                fingerDownPos = touch.position;
                DetectSwipe();
            }
        }*/
        /*void OnSwipeUp()
        {
            //Do something when swiped up
            //Play Jump Animation
            PlayerChildAnimation.GetComponent<Animator>().SetTrigger("Jump");
        }
    }

        void OnSwipeDown()
        {
        //Do something when swiped down
        //Play Crouch Animation
        PlayerChildAnimation.GetComponent<Animator>().SetTrigger("Crouch");
    }

        void OnSwipeLeft()
        {
        //Do something when swiped left
        //Move player to left
            if (Position.Left != CheckPlayerPosition(this.transform))
            //if(this.transform.position.x!=-2.5f)
            {
                this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(this.transform.position.x - 2.5f, this.transform.position.y, this.transform.position.z), speed);
            }
        }

        void OnSwipeRight()
        {
        //Do something when swiped right
        //Move player to right
            if (Position.Right != CheckPlayerPosition(this.transform))
            //if (this.transform.position.x!=2.5f)
            {
                this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(this.transform.position.x + 2.5f, this.transform.position.y, this.transform.position.z), speed);
            }
        }*/

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
    /*void DetectSwipe()
    {

        if (VerticalMoveValue() > SWIPE_THRESHOLD && VerticalMoveValue() > HorizontalMoveValue())
        {
            Debug.Log("Vertical Swipe Detected!");
            if (fingerDownPos.y - fingerUpPos.y > 0)
            {
                OnSwipeUp();
            }
            else if (fingerDownPos.y - fingerUpPos.y < 0)
            {
                OnSwipeDown();
            }
            fingerUpPos = fingerDownPos;

        }
        else if (HorizontalMoveValue() > SWIPE_THRESHOLD && HorizontalMoveValue() > VerticalMoveValue())
        {
            Debug.Log("Horizontal Swipe Detected!");
            if (fingerDownPos.x - fingerUpPos.x > 0)
            {
                OnSwipeRight();
            }
            else if (fingerDownPos.x - fingerUpPos.x < 0)
            {
                OnSwipeLeft();
            }
            fingerUpPos = fingerDownPos;

        }
        else
        {
            Debug.Log("No Swipe Detected!");
        }*/
}
