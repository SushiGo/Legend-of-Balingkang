using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    public GameObject player;
    public float speed;
    public float radius;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        float step = speed * Time.deltaTime;
        Vector3 targetPos = player.transform.position;
        if(player.GetComponent<Player>().facing == "right")
        {
            targetPos.x -= radius;
        }
        else
        {
            targetPos.x += radius;
        }
        targetPos.y = this.transform.position.y;
        targetPos.z = this.transform.position.z;
        transform.position = Vector3.MoveTowards(transform.position, targetPos, step);
    }
}
