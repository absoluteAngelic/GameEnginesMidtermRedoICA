using System.Collections.Generic;
using UnityEngine;

public class SnakeManager : Singleton<SnakeManager>
{
    public Vector3 currentDirection;

    public GameObject snakeHead;

    public Transform tailTransform;

    public List<GameObject> snakeParts = new List<GameObject>();

    public GameObject snakePartPrefab;

    public int lastIndex;

    public GameObject food;

    public float secondsElapsed;

    public int lastSecondsElapsed;

    void Start()
    {
        snakeHead = GameObject.Find("SnakePiece");
        tailTransform = snakeHead.transform;
    }

    void Update()
    {
        if (food != null)
        {
            if (snakeHead.transform.position == food.transform.position)
            {
                GrowSnake();
            }
        }



        if (Input.GetKeyDown(KeyCode.W))
        {
            currentDirection = new Vector3(0, 1, 0);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            currentDirection = new Vector3(-1, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            currentDirection = new Vector3(1, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            currentDirection = new Vector3(0, -1, 0);
        }

        secondsElapsed += Time.deltaTime * 2.5f;

        if (lastSecondsElapsed + snakeHead.GetComponent<SnakeMovement>().partIndex < (int)secondsElapsed)
        {
            lastSecondsElapsed++;

            snakeHead.transform.position += currentDirection;
            for (int i = 1; i < snakeParts.Count; i++)
            {
                if (lastSecondsElapsed + snakeParts[i].GetComponent<SnakeMovement>().partIndex < (int)secondsElapsed)
                {
                    snakeParts[i].transform.position = snakeParts[i - 1].transform.position;
                }
            }
        }
    }

    public void GrowSnake()
    {
        GameObject instantiatedSnake = Instantiate(snakePartPrefab, tailTransform);
        instantiatedSnake.GetComponent<SnakeMovement>().partIndex = ++lastIndex;
        Destroy(food);
    }
}
