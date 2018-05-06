using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour {

    [SerializeField] private float distance;
    [SerializeField] private float speed;
    private bool forward;
    private bool secondPhase;
    private string direction;

    private void Start()
    {
        forward = true;
        secondPhase = false;
        direction = "forward";
    }
    
    void Update()
    {
        if (!secondPhase)
        {
            if (forward)
                transform.Translate(Vector3.forward * Time.deltaTime * speed);

            else
                transform.Translate(Vector3.back * Time.deltaTime * speed);

            if (transform.position.z > distance)
                forward = false;

            if (transform.position.z < 0)
                forward = true;
        }
        if (secondPhase)
        {
            if(speed < 30)
            {
                setSpeed(Time.deltaTime * 3);
            }
            if (direction.Equals("forward"))
            {
                if (transform.position.z < 120)
                {
                    transform.Translate(Vector3.forward * Time.deltaTime * speed);
                }
                else
                {
                    direction = "right";
                }
            }
            if (direction.Equals("right"))
            {
                if (transform.position.x < 120)
                {
                    transform.Translate(Vector3.right * Time.deltaTime * speed);
                }
                else
                {
                    direction = "backward";
                }
            }
            if (direction.Equals("backward"))
            {
                if (transform.position.z > 0)
                {
                    transform.Translate(Vector3.back * Time.deltaTime * speed);
                }
                else
                {
                    direction = "left";
                }
            }
            if (direction.Equals("left"))
            {
                if (transform.position.x > 0)
                {
                    transform.Translate(Vector3.left * Time.deltaTime * speed);
                }
                else
                {
                    direction = "forward";
                }
            }
        }
    }

    public void setSpeed(float newSpeed)
    {
        speed += newSpeed;
        Debug.Log(speed);
    }

    public void setSecondPhase()
    {
        secondPhase = true;
    }
}
