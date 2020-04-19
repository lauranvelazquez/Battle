using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowOne : MonoBehaviour
{
    public float speed;
    public float visionRadiosStop;

    private GameObject player;

    private Vector3 initialPosition;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        initialPosition = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        //target mas distancia 
        Vector3 target = initialPosition;
        float distance = Vector3.Distance(player.transform.position, transform.position);
        if (distance >= visionRadiosStop)
        {
            target = player.transform.position;
        }

        float fixedSpeed = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, fixedSpeed);

        Debug.DrawLine(transform.position, target, Color.green);

    }

    private void OnDrawGizmos()
    {

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, visionRadiosStop);
    }
}