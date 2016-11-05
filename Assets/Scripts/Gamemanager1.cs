using UnityEngine;
using System.Collections;

public class Gamemanager1 : MonoBehaviour {

    public GameObject Player;
    public GameObject[] Ghosts;
    public Transform PlayerStartPosition;
    public Transform[] GhostPositions;
    public Transform TrapPosition;
    private Transform RndPosition;
    int i;
    public float limitRange;
    public AudioClip myClip;
    public AudioClip Die;
    public AudioClip Win;
    public AudioClip HitTheWall;
    public AudioClip GhostNear;
    public GameObject[] Objs;
    public Collider GhostCollider;
    public int loader;

   

    // Use this for initialization
    void Start () {


        can.enabled = false;
        //getComponent ui
        //getcomponent canvas
        //getcomponent inputmanager
        //getcomponent levelcreation
       

	}

    public void LevelCreationInfo()
    {


    }

    public void LevelCreation()
    {

        //canvas sends message to this when level is started
        //and random placer function as it was named as instantiate


    }

    //Needed static assets
    //as public

    //Random placed assets
    //Random placer script was used earlier but now can use
    //it here

    //Ui connection
    //Ui buttons or actually connection to ui scripts

    //game events
    //continuing

    //level creation connection

    //Instantion of ghosts
    void Instantiate()
    {

        RndPosition.position = new Vector3 (Random.Range(0, limitRange), Random.Range(0,0),  Random.Range(0, limitRange));
        GhostPositions[i] = RndPosition;


    }

    //instantion cycle connects to the game loop

  
    public Canvas can;

  

    void OnCollisionEnter(Collision col)
    {

        if (col.collider.tag == "Ghost")
        {
            Debug.Log(can.ToString() + "colliosion");
            can.enabled = true;
        }  
        

    }


    void gameLoop()
    { 
        //player starts game in starting room
        Player.GetComponent<Transform>();
        GhostPositions = FindObjectsOfType(typeof(Transform)) as Transform[];
        Objs = FindObjectsOfType(typeof(GameObject)) as GameObject[];
        i = Objs.Length;

        //if(GhostPositions[i-1].transform == TrapPosition.transform)
        {
            //Ui Show canvas game win


        }
    }
/*
    void musicAndSound()
    {
        switch (loader)
        {
            case 5:

                AudioSource.PlayClipAtPoint(myClip, Player.transform.position);


                break;
            case 4:                                 //other position than player
                AudioSource.PlayClipAtPoint(myClip, Player.transform.position);


                break;
            case 3:
                AudioSource.PlayClipAtPoint(myClip, Player.transform.position);


                break;
            case 2:
                AudioSource.PlayClipAtPoint(myClip, Player.transform.position);


                break;
            case 1:
                AudioSource.PlayClipAtPoint(myClip, Player.transform.position);




                break;
            default:

                AudioSource.PlayClipAtPoint(myClip, Player.transform.position);


                break;
        }
    }

    */

    // Update is called once per frame
    void Update () {
        gameLoop();
        //musicAndSound();
       
    }
}
