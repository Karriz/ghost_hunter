using UnityEngine;
using System.Collections;

public class Cross : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "Ghost")
        {
            Debug.Log("Ghost destroyed!");
            //Remove candle
            Destroy(coll.gameObject);
            GameObject.FindWithTag("Player").GetComponent<LanternColor>().removeGhost();
        }

    }
}
