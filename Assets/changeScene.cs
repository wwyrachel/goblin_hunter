using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScene : MonoBehaviour {
    public GameObject guiObject;
    public string SceneToLoad;
    public HUD hud;

    public GameObject target;

    bool touch = false;
 


    public void start() {

        guiObject.SetActive(false);
        touch = false;
    }

    public void Update()
    {
        //print("up");
        //print("touch" + touch);
        if (touch == true)
        {
            //print("yes");
            //DontDestroyOnLoad(this.target);
            SceneManager.LoadScene(SceneToLoad);
        }


    }

    void OnTriggerEnter(Collider other) {
        print("touch");
        if (other.tag == "Player") {
            print("player");
            hud.OpenMessagePanel("");
            touch = true;
            print("no");
            //SceneManager.LoadScene(SceneToLoad);

            

        }
    }

     void OnTriggerExit(){
        hud.CloseMessagePanel("");
        touch = false;


    }

   


}
