using UnityEngine;
using UnityEditor;
using System.Collections;

public class GhostDie : MonoBehaviour {

    public Animator anim;



    void Start()
    {

        
    }

    //we sent message to this from ghost trap trigger
	public IEnumerator ghostDie()
    {
        yield return new WaitForSeconds(1f);
        anim.Play("Ghost Die");


    }


}
