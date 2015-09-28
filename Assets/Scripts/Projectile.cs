using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    public float speedX;
    public float speedY;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "Player" && other.tag != "Turret" && other.tag != "Projectile")
        {
            Die();
        }
    }

    void Update()
    {
        transform.position += new Vector3(speedX, speedY, 0f) * Time.deltaTime;
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
