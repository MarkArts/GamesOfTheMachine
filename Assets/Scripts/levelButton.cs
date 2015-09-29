using UnityEngine;
using System.Collections;

public class levelButton : MonoBehaviour {


    public string level;

    private BoxCollider2D m_box;

	// Use this for initialization
	void Start () {
        m_box = GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (didheTouchYou())
        {
            if (m_box.OverlapPoint(whereDidHeTouchYou()))
            {
                showMeOnTheDoll();
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            if (m_box.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition)))
            {
                showMeOnTheDoll();
            }
        }

	}

    void showMeOnTheDoll()
    {
        Application.LoadLevel(level);
    }

    bool didheTouchYou()
    {
        return Input.touchCount > 0;
    }

    Vector2 whereDidHeTouchYou()
    {
        Vector2 ret = Vector2.zero;

        foreach(Touch touch in Input.touches)
        {
            if(touch.phase == TouchPhase.Ended) {
                return touch.position;
            }
        }

        return ret;
    }
}
