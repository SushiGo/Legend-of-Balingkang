using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionBalloon : MonoBehaviour {

    public GameObject player;
    private Vector3 offsetY;

	// Use this for initialization
	void Start ()
    {
		offsetY = this.transform.position - player.transform.position;
    }
	
	// Update is called once per frame
	void Update ()
    {
        this.transform.position = new Vector3(player.transform.position.x, player.transform.position.y+offsetY.y, this.transform.position.z);
	}
}
