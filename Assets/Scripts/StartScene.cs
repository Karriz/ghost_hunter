using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using System.Collections;

public class StartScene : MonoBehaviour
{
   

   

    public void startScene()
    {
        Debug.Log("Scene tried to load");
        Application.LoadLevel("Test");
    }

    

}