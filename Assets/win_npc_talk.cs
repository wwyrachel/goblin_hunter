using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class win_npc_talk : MonoBehaviour {

    public Flowchart talkFlowchart;
    public string onCollisionEnter;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(UnityEngine.Collision other) {
        Block targetBlock = talkFlowchart.FindBlock(onCollisionEnter);
        talkFlowchart.ExecuteBlock(targetBlock);
    }
}
