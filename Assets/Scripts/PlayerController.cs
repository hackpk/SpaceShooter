using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float distance = 2.0f;
    float newPos;
    float min;
    float max;
	float padding = 0.5f;


	void Start(){
	    Debug.Log("yeah");
	    float value = Camera.main.transform.position.z - transform.position.z;
		Vector3 leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0 ,0 ,value));
	    Vector3 rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1 ,0 ,value));

		min = leftMost.x + padding;
		max = rightMost.x - padding;
	}
	
	void Update () 
	{
	    if(Input.GetKey(KeyCode.LeftArrow))
		{
		  this.transform.position += new Vector3(-distance*Time.deltaTime,0,0);
		
		}else if(Input.GetKey(KeyCode.RightArrow))
		{
		  this.transform.position += new Vector3(distance*Time.deltaTime,0,0);
		
		}
		newPos = Mathf.Clamp(transform.position.x,min,max);
		transform.position = new Vector3(newPos,transform.position.y,0);
	}
}
