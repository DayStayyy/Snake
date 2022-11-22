using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailScript : MonoBehaviour
{
    public GameObject tail;

    public List<GameObject> tailObjects = new List<GameObject>();

    Head headScript;

    // Start is called before the first frame update
    void Start()
    {
        GameObject head = GameObject.Find("Head");
        headScript = head.GetComponent<Head>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void MoveTail()
    {
        for (int i = 0; i < tailObjects.Count; i++)
        {
            tailObjects[i].GetComponent<Tail>().lastPosition =
                tailObjects[i].transform.position;
            if (i == 0)
            {
                tailObjects[i].transform.position = headScript.lastPosition;
            }
            else
            {
                tailObjects[i].transform.position =
                    tailObjects[i - 1].GetComponent<Tail>().lastPosition;
            }
        }
    }

    public void GrowingTail()
    {
        GameObject newTail =
            Instantiate(tail,
            tailObjects[tailObjects.Count - 1]
                .GetComponent<Tail>()
                .lastPosition,
            Quaternion.identity);
        tailObjects.Add (newTail);
    }
}
