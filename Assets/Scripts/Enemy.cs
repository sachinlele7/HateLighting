using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;

    public float stoppingDistance;

    public float retreatDistance;
    public Transform player;
    private float timebtwshots;
    public float starttimebtwShots;
    public GameObject projectile;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timebtwshots = starttimebtwShots;
    }

    private void Update()
    {
        if(Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
        {
            transform.position = this.transform.position;
        }
        else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }

        if (timebtwshots <= 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            timebtwshots = starttimebtwShots;
        }
        else
        {
            timebtwshots -= Time.deltaTime;
        }
    }


}
