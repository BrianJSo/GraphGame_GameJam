using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowmanController : MonoBehaviour
{

    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float maxRotate = 45.0f;
    [SerializeField] private float minRotate = -45.0f;

    private enum Direction
    {
        FORWARD, BACKWARD, LEFT, RIGHT, NONE
    }

    private Direction currentDir = Direction.NONE;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Snowman started");
    }

    private void Update()
    {
        this.InputListen();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.Move();
    }

    private void InputListen()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            this.currentDir = Direction.FORWARD;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            this.currentDir = Direction.BACKWARD;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            this.currentDir = Direction.LEFT;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            this.currentDir = Direction.RIGHT;
        }
//        else if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
//        {
//            this.currentDir = Direction.NONE;
//        } 
        else if (!(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
        {
            this.currentDir = Direction.NONE;
        }
    }

    private void Move()
    {
        if (this.currentDir == Direction.FORWARD)
        {
            this.gameObject.transform.Rotate(Vector3.forward * Time.deltaTime * this.speed);
        }
        else if (this.currentDir == Direction.BACKWARD)
        {
            this.gameObject.transform.Rotate(Vector3.back * Time.deltaTime * this.speed);
        }
        else if (this.currentDir == Direction.LEFT)
        {
            this.gameObject.transform.Rotate(Vector3.left * Time.deltaTime * this.speed);
        }
        else if (this.currentDir == Direction.RIGHT)
        {
            this.gameObject.transform.Rotate(Vector3.right * Time.deltaTime * this.speed);
        } else
        {
            this.gameObject.transform.Rotate(Vector3.zero);
        }

        Vector3 curRotate = this.gameObject.transform.localRotation.eulerAngles;

        curRotate.x = (curRotate.x < 180) ? Mathf.Clamp(curRotate.x, 0, maxRotate) : Mathf.Clamp(curRotate.x, 360 - maxRotate, 360);
        curRotate.y = 0f;
        curRotate.z = (curRotate.z < 180) ? Mathf.Clamp(curRotate.z, 0, maxRotate) : Mathf.Clamp(curRotate.z, 360 - maxRotate, 360);

        this.gameObject.transform.localRotation = Quaternion.Euler(curRotate);
    }

}
