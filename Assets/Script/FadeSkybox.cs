using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeSkybox : MonoBehaviour {

    public Material skybox;
    private bool blending = false;
    private float blendTime = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.F))
        {
            blending = true;
        }

        if(blending)
        {
            print("blending");
            blendTime += Time.deltaTime;
            skybox.SetFloat("_Blend", blendTime);
            if(blendTime >= 1)
            {
                blending = false;
            }
        }
	}
}
