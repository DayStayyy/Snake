using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodGenerator : MonoBehaviour
{
    public GameObject food;

    // Start is called before the first frame update
    void Start()
    {
        GenerateFood();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void GenerateFood()
    {
        GameObject newFood =
            Instantiate(food,
            new Vector3(Mathf.Round(Random.Range(-8.0f, 8.0f)) + 0.5f,
                Random.Range(-4, 4),
                0),
            Quaternion.identity);
    }
}
