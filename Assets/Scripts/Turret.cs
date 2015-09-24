using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour {

    public GameObject projectile;

    public float bulletSpeed;

    public float fireRate;
    public float fireOfset;
    private Vector2 bulletVelocity;

    private Transform spawn;
    private Transform target;

	// Use this for initialization
	void Start () {
        spawn = transform.Find("spawn");
        target = transform.Find("target");

        bulletVelocity = (target.position - spawn.position).normalized * bulletSpeed;

        InvokeRepeating("Shoot", fireOfset, fireRate);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void Shoot()
    {
        GameObject proj = (GameObject)Instantiate(projectile, spawn.position, Quaternion.identity);
        proj.GetComponent<Projectile>().speedX = bulletVelocity.x;
        proj.GetComponent<Projectile>().speedY = bulletVelocity.y;
    }

    void OnDrawGizmos()
    {
        if(transform.Find("spawn") && transform.Find("target"))
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawLine(transform.Find("spawn").position, transform.Find("target").position);
        }
    }
}
