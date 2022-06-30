using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPush : MonoBehaviour {

    public Transform Player;
    Transform touched;
    Rigidbody objectRB;
    [Range(0f, 2000f)]
    public float force;

	// Use this for initialization
	void Start ()
    {
        objectRB = GetComponent<Rigidbody>();
		
	}

    private void Update()
    {
        Player.position = Player.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Push")
        {
            touched = transform.parent;
            int count = touched.childCount;

            for (int i = 0; i < count; i++)
            {
                Transform child = touched.GetChild(i);
                Rigidbody part = child.GetComponent<Rigidbody>();
                part.isKinematic = false;
            }

            objectRB.AddForce((transform.position - Player.position) * force);
        }

        if(other.gameObject.tag == "Explosion")
        {
            Timer.currentScore = Timer.currentScore + 1;
            Destroy(this.gameObject);            
        }
    }
}
