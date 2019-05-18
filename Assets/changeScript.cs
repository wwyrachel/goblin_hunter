using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScript : MonoBehaviour {

    public string SceneToLoad;
    bool touch1;

    // Use this for initialization
    void Start () {
        touch1 = false;
    }

    void change() {
        print("touch11" + touch1);
        touch1 = true;
        print("touch"+touch1);
    }
	
	// Update is called once per frame
	void Update () {

        if (touch1 == true)
        {
            //print("yes");
            //DontDestroyOnLoad(this.target);
            SceneManager.LoadScene(SceneToLoad);
        }

    }
}
