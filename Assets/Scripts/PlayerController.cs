using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	
	float turnSpeed = 120f;
	float moveSpeed = 8;
	float vertSpeed = 10f;
    public Transform treasure;
    Transform myTransform;
    public Image map;
    public Text text;

    void Start()
    {
        map.enabled = false;
        myTransform = gameObject.GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update () 
	{
        /*
		if(Input.GetKey (KeyCode.W))
		{
			transform.Translate ( new Vector3(0f,0f, moveSpeed) * Time.deltaTime);
		}
		
		if (Input.GetKey (KeyCode.S) )
		{
			transform.Translate ( new Vector3(0f, 0f, -moveSpeed) * Time.deltaTime );
		}
		
		if(Input.GetKey (KeyCode.A))
		{
			transform.Rotate (0f, -turnSpeed * Time.deltaTime, 0f);
		}
		if(Input.GetKey (KeyCode.D))
		{
			transform.Rotate (0f, turnSpeed * Time.deltaTime, 0f);
		}
         * */
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0f, 0f, 1f) * Time.deltaTime * moveSpeed;
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-1f, 0f, 0f) * Time.deltaTime * moveSpeed;
            transform.eulerAngles = new Vector3(0f, -90f, 0f);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0f, 0f, -1f) * Time.deltaTime * moveSpeed;
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(1f, 0f, 0f) * Time.deltaTime * moveSpeed;
            transform.eulerAngles = new Vector3(0f, 90f, 0f);
        }
        
        if (Input.GetKey(KeyCode.M))
        {
            map.enabled = !map.enabled;
        }

        float distance = AtoBDistance(myTransform.position, treasure.position);
        if(distance < 4)
        {
            Destroy(treasure);
            text.text = "Hooray";
        }

        Camera.main.transform.position = transform.position + new Vector3(0f, 15f, -10f);
		
	}

    float AtoBDistance(Vector3 A, Vector3 B)
    {
        Vector3 BA = B - A;

        float a2 = BA.x * BA.x;
        float b2 = BA.y * BA.y;
        float distance = Mathf.Sqrt(a2 + b2);
        Debug.Log(distance);
        return distance;
    }
}
