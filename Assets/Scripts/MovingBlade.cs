using UnityEngine;
using System.Collections;

public class MovingBlade : MonoBehaviour {

    public float speed;

    private Vector2 beginPos;
    private Vector2 endPos;

    // the position the object is currently moving towards
    private Vector2 targetPos;

    private float progress;
    private float distance;


    // Use this for initialization
    void Start () {
        beginPos = transform.position;
        endPos = transform.FindChild("end").transform.position;

        transform.FindChild("end").GetComponent<SpriteRenderer>().enabled = false;

        targetPos = endPos;
        distance = Vector2.Distance(beginPos, endPos);
    }
	
	// Update is called once per frame
	void Update () {

        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        if(new Vector2(transform.position.x, transform.position.y) == beginPos || new Vector2(transform.position.x, transform.position.y) == endPos)
        {
            flip();
        }

        progress = (Vector2.Distance(transform.position, targetPos) / distance) * 100;
	}

    void flip()
    {
        if(targetPos == beginPos) {
            targetPos = endPos;
        }
        else
        {
            targetPos = beginPos;
        }
    }

}
