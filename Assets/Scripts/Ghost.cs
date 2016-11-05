using UnityEngine;
using System.Collections;

public class Ghost : MonoBehaviour {
    public float speed = 1.0f;
    private string playingAnim = "idle";
    private GameObject attackAnim;
    private GameObject idleAnim;
    private AudioSource audio;

	// Use this for initialization
	void Start () {
        audio = gameObject.GetComponent<AudioSource>();
        attackAnim = transform.Find("attack_anim").gameObject;
        idleAnim = transform.Find("ghost_Anim").gameObject;

        attackAnim.SetActive(false);
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

            if (playingAnim == "idle")
            {
                audio.Play();
                attackAnim.SetActive(true);
                idleAnim.SetActive(false);
                playingAnim = "attack";
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" && !other.isTrigger)
        {

            if (playingAnim == "attack")
            {
                attackAnim.SetActive(false);
                idleAnim.SetActive(true);
                playingAnim = "idle";
            }
        }
    }

}
