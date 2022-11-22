using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : MonoBehaviour
{
    public Vector3 lastPosition;

    enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }

    Direction direction = Direction.Right;

    public TailScript tailScript;

    public FoodGenerator foodGenerator;

    // Start is called before the first frame update
    void Start()
    {
        GameObject tailsScript = GameObject.Find("TailsScript");
        tailScript = tailsScript.GetComponent<TailScript>();
        GameObject foodGeneratorObject = GameObject.Find("FoodScript");
        foodGenerator = foodGeneratorObject.GetComponent<FoodGenerator>();
        InvokeRepeating("Move", 0.3f, 0.7f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && direction != Direction.Down)
        {
            direction = Direction.Up;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && direction != Direction.Up)
        {
            direction = Direction.Down;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && direction != Direction.Right)
        {
            direction = Direction.Left;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && direction != Direction.Left)
        {
            direction = Direction.Right;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            tailScript.GrowingTail();
        }
    }

    void Move()
    {
        lastPosition = transform.position;
        switch (direction)
        {
            case Direction.Up:
                if (transform.position.y < 5)
                {
                    transform.Translate(0, 1, 0);
                }
                else
                {
                    transform.position =
                        new Vector3(transform.position.x,
                            -5,
                            transform.position.z);
                }
                break;
            case Direction.Down:
                if (transform.position.y > -5)
                {
                    transform.Translate(0, -1, 0);
                }
                else
                {
                    transform.position =
                        new Vector3(transform.position.x,
                            5,
                            transform.position.z);
                }
                break;
            case Direction.Left:
                if (transform.position.x > -10)
                {
                    transform.Translate(-1, 0, 0);
                }
                else
                {
                    transform.position =
                        new Vector3(10,
                            transform.position.y,
                            transform.position.z);
                }
                break;
            case Direction.Right:
                if (transform.position.x < 10)
                {
                    transform.Translate(1, 0, 0);
                }
                else
                {
                    transform.position =
                        new Vector3(-10,
                            transform.position.y,
                            transform.position.z);
                }
                break;
        }
        tailScript.MoveTail();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (
            col.gameObject != tailScript.tailObjects[0] &&
            col.gameObject != GameObject.Find("Food(Clone)")
        )
        {
            Debug.Log("Game Over");
            Debug.Log(col.gameObject);
            CancelInvoke("Move");
        }
        if (col.gameObject == GameObject.Find("Food(Clone)"))
        {
            tailScript.GrowingTail();
            Destroy(col.gameObject);
            foodGenerator.GenerateFood();
        }
    }
}
