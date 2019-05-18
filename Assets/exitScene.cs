using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class exitScene : MonoBehaviour {

    public string SceneToLoad;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    
        //print("up");
        //print("touch" + touch);
        if (Input.GetKeyDown(KeyCode.N))
        {
            //print("yes");
            SceneManager.LoadScene(SceneToLoad);
        }


    

     }
}
