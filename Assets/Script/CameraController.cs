using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public bool trackPlayer;
    public GameObject player;
    public float minX, maxX;

    private Vector3 offset, offsetVert;

	// Use this for initialization
	void Start ()
    {
        offsetVert = this.transform.position - player.transform.position;
    }
	
	// Update is called once per frame
	void Update ()
    {
		if(trackPlayer)
        {
            this.transform.position = player.transform.position + offset;
            this.transform.position = new Vector3(Mathf.Clamp(this.transform.position.x, minX, maxX),
                this.transform.position.y,
                this.transform.position.z);
        }
        if(Input.GetKeyDown(KeyCode.T)) // tracked ketika player ada di x tertentu
        {
            offset = this.transform.position - player.transform.position;
            trackPlayer = !trackPlayer;
        }

        //OFFSET VERTICAL
        this.transform.position = new Vector3(this.transform.position.x, player.transform.position.y + offsetVert.y, this.transform.position.z);
	}
}
