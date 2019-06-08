using UnityEngine;

public class Interactable : MonoBehaviour {
	//attemt to create a key pickup
	public float radius = 3f;
    //draw gizmos for a position
    void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(transform.position, radius);
	}
}
