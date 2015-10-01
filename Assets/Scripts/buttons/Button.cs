using UnityEngine;
using System.Collections;

public abstract class Button : MonoBehaviour {

    private BoxCollider2D m_box;

    // Use this for initialization
    void Start()
    {
        m_box = GetComponent<BoxCollider2D>();

        myStart();
    }

    // Update is called once per frame
    void Update()
    {
        if (didheTouchYou())
        {
            if (m_box.OverlapPoint(whereDidHeTouchYou()))
            {
                onButtonPress();
            }
        }

        fuckdate();
    }

    public abstract void onButtonPress();
    public virtual void myStart()
    {

    }
    public virtual void fuckdate()
    {

    }

    bool didheTouchYou()
    {
        return Input.GetMouseButtonUp(0);
    }

    Vector2 whereDidHeTouchYou()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
