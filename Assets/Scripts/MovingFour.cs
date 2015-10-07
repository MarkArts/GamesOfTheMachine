using UnityEngine;
using System.Collections;

public class MovingFour : MonoBehaviour {

    public float speed;
    public bool backtrack;
    private bool backtracking;

    private Vector2 posOne;
    private Vector2 posTwo;
    private Vector2 posThree;
    private Vector2 posFour;


    // the position the object is currently moving towards
    private Vector2 targetPos;

    // Use this for initialization
    void Start()
    {
        backtracking = false;

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
            if (backtrack)
            {
                backtracking = false;
            }

            targetPos = posTwo;
        }
        else if (targetPos == posTwo)
        {
            if (backtrack && backtracking)
                targetPos = posOne;
            else
                targetPos = posThree;
        }
        else if (targetPos == posThree)
        {
            if (backtrack && backtracking)
                targetPos = posTwo;
            else
                targetPos = posFour;
        }
        else if (targetPos == posFour)
        {
            if (backtrack)
            {
                targetPos = posThree;
                backtracking = true;
            }
            else
                targetPos = posOne;
        }
    }
}
