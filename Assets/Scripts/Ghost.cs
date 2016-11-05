using UnityEngine;
using System.Collections;

public class Ghost : MonoBehaviour {
    public float speed = 1.0f;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && !other.isTrigger)
        {
            transform.LookAt(other.transform.position);
            transform.Translate(Time.deltaTime * speed * (other.transform.position - transform.position).normalized, Space.World);
        }
    }

}
