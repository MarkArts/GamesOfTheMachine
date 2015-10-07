using UnityEngine;
using System.Collections;

public class MovingFour : MonoBehaviour {


    public float speed;

    private Vector2 posOne;
    private Vector2 posTwo;
    private Vector2 posThree;
    private Vector2 posFour;

    // the position the object is currently moving towards
    private Vector2 targetPos;

    // Use this for initialization
    void Start()
    {
        posOne = transform.position;
        posTwo = transform.FindChild("two").transform.position;
        posThree = transform.FindChild("three").transform.position;
        posFour = transform.FindChild("four").transform.position;

        transform.FindChild("two").GetComponent<SpriteRenderer>().enabled = false;
        transform.FindChild("three").GetComponent<SpriteRenderer>().enabled = false;
        transform.FindChild("four").GetComponent<SpriteRenderer>().enabled = false;

        targetPos = posTwo;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        if (new Vector2(transform.position.x, transform.position.y) == targetPos )
        {
            next();
        }
    }

    void next()
    {
        if (targetPos == posOne)
        {
            Debug.Log("postwo");
            targetPos = posTwo;
        }
        else if (targetPos == posTwo)
        {
            Debug.Log("posThree");
            targetPos = posThree;
        }
        else if (targetPos == posThree)
        {
            Debug.Log("posFour");
            targetPos = posFour;
        }
        else if (targetPos == posFour)
        {
            Debug.Log("posOne");
            targetPos = posOne;
        }
    }
}
