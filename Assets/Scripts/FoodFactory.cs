using UnityEngine;

public class FoodFactory : MonoBehaviour
{
    public FoodPiece foodToSpawn;
    GameObject headPiece;
    GameObject currentFood;

    void Start()
    {
        headPiece = GameObject.Find("SnakePiece");
        currentFood = GameObject.Find("Food");
    }

    void Update()
    {
        if (currentFood.transform.position == headPiece.transform.position)
        {
            SnakeManager.Instance.GrowSnake();
            currentFood = SpawnFood();
        }
    }

    GameObject SpawnFood()
    {
        FoodPiece spawnedFood = Instantiate(foodToSpawn, this.gameObject.transform);

        spawnedFood.gameObject.transform.position += new Vector3(Random.RandomRange(-3, 3), Random.RandomRange(-3, 3), 0);

        return spawnedFood.gameObject;
    }
}
