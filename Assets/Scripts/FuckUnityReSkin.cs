using UnityEngine;
using System;
using System.Linq;

public class FuckUnityReSkin : MonoBehaviour {

    public string staticSprites;
    public string teleportSprites;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void LateUpdate () {
        var subSprites = Resources.LoadAll<Sprite>(staticSprites).Concat(Resources.LoadAll<Sprite>(teleportSprites)).ToArray();

        foreach(var renderer in GetComponentsInChildren<SpriteRenderer>())
        {
            string spriteName = renderer.sprite.name;
            var newSprite = Array.Find(subSprites, item => item.name == spriteName);

            if (newSprite)
                renderer.sprite = newSprite;
        }

	}
}
