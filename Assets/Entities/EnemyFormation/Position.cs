using UnityEngine;
using System.Collections;

public class Position : MonoBehaviour {

	void OnDrawGizmos(){
		Gizmos.DrawSphere(transform.position,1);
	}
}
