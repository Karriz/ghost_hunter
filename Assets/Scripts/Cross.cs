﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Cross : MonoBehaviour {
    public GameObject candle;
    private int ghostCount;

    private float baseHeight;

    private List<GameObject> candles = new List<GameObject>();

	// Use this for initialization
	void Start () {
        Debug.Log(candle);
        ghostCount = CountGhosts();
        baseHeight = transform.position.y - GetComponent<MeshRenderer>().bounds.extents.y;
        SpawnCandles(ghostCount);

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
            

            candles[ghostCount - 1].transform.Find("Point light").GetComponent<Light>().enabled = false;
            candles[ghostCount - 1].transform.Find("CandleParticles").GetComponent<ParticleSystem>().Stop();

            ghostCount--;

            if (ghostCount <= 0)
            {
                //Win game
            }
        }

    }

    public int CountGhosts()
    {
        GameObject[] ghosts = GameObject.FindGameObjectsWithTag("Ghost");
        return ghosts.Length;
    }

    public void SpawnCandles(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject newcandle = Instantiate(candle);
            newcandle.transform.parent = transform;
            
            Vector3 rotationVector = Quaternion.AngleAxis(i*360f/amount, Vector3.up) * transform.right * 5f;

            newcandle.transform.localPosition = rotationVector;

            newcandle.transform.position = new Vector3(newcandle.transform.position.x,baseHeight,newcandle.transform.position.z);

            candles.Add(newcandle);
        }
    }
}
