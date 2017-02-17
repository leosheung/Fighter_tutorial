using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoDie : MonoBehaviour
{
    float OnHitTime = 0;
    bool dying = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (dying == true)
        {
            if (Time.realtimeSinceStartup - OnHitTime >= 5)
            {
                Destroy(gameObject);
            }
        }
        
	}

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "baga")
        {
            dying = true;
            OnHitTime = Time.realtimeSinceStartup;
            GetComponent<AudioSource>().Play();
            GetComponent<Rigidbody>().velocity = new Vector3(0, 10, 0);
        }
    }
}
