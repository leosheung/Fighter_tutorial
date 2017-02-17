using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonControl : MonoBehaviour
{
    Color holly = new Color(1, 1, 1, 1);
    Color old_driver = new Color(1, 1, 0, 1);

    [SerializeField] GameObject guizi;
    public float speed = 1.0f;
	// Use this for initialization
	void Start ()
    {
        // gameObject.transform.localScale = new Vector3(2, 2, 20);
        for (int i = 0; i < 200; i++)
        {
            GameObject.Instantiate(guizi,
                                   new Vector3(Random.Range(0, 500), 20, Random.Range(0, 500)),
                                   Quaternion.identity);
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.position += transform.forward * speed;

        holly = Vector4.Lerp(holly, old_driver, 0.01f);
        gameObject.GetComponent<Renderer>().material.SetColor("_Color", holly);

        if (Input.GetKey(KeyCode.UpArrow))
        {
            gameObject.transform.localEulerAngles += new Vector3(-0.5f, 0, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            gameObject.transform.localEulerAngles += new Vector3(0.5f, 0, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            gameObject.transform.localEulerAngles += new Vector3(0, -0.5f, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            gameObject.transform.localEulerAngles += new Vector3(0, 0.5f, 0);
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            Debug.Log("鬼子进村了！！！");
            GameObject bullet = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            bullet.transform.position = gameObject.transform.position;
            bullet.tag = "baga";

            bullet.AddComponent<Rigidbody>();
            bullet.GetComponent<Rigidbody>().velocity = transform.forward * 300;
            bullet.GetComponent<Rigidbody>().useGravity = false;

            Debug.Log(transform.eulerAngles);

        }
    }
}
