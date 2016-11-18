using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

   public GameObject enemyPrefab;
   public float width = 15.0f;
   public float height = 10.0f;	
   public float xxxMax = 5.0f;
   public float xxxMin = -9.0f;
   public float padding = 5.0f;
   public float speed = 2.0f;
   public bool touched = false;
	void Start () {

	   float value = Camera.main.transform.position.z - transform.position.z;
	   Vector3 leftBoundary = Camera.main.ViewportToWorldPoint(new Vector3(0 ,0 ,value));
	   Vector3 rightBoundary = Camera.main.ViewportToWorldPoint(new Vector3(1 ,0 ,value));

	   xxxMax = rightBoundary.x - padding;
	   xxxMin = leftBoundary.x + padding;

	   foreach(Transform child in transform)
	   {
	      GameObject enemy = Instantiate(enemyPrefab,child.position,Quaternion.identity) as GameObject;
	      enemy.transform.parent = child;
       }

	}
	void OnDrawGizmos(){
	
	   Gizmos.DrawWireCube(new Vector3(0,0,0),new Vector3(width,height));
	}


	void Update(){
	
	     if(touched){
		 
		    transform.position +=  new Vector3(speed * Time.deltaTime,0,0);
			touched = true;
		 
		 }else if(transform.position.x > xxxMin){
		 
		   transform.position +=  new Vector3(speed * Time.deltaTime,0,0);
		   touched = false;
		 }

	 }	
}
