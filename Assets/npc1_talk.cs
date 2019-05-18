using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class npc1_talk : MonoBehaviour {
    public static Flowchart FlowChartManager;

    public Flowchart talkFlowchart;
    public string onMouseDown1 = "talkStart";

    public string onCollisionEnter;

    public Key key;

    

    // Use this for initialization
    void Awake()
    {
        //FlowChartManager = GameObject.Find("Dialogue_Flowchart");
    }

    // Update is called once per frame
    void Update()
    {

    }

    void PlayBlock(string targetBlockName) {
        Block targrtBlock = talkFlowchart.FindBlock(targetBlockName);
        talkFlowchart.ExecuteBlock(targrtBlock);
    }

    private void OnTriggerEnter(Collider other)
    {
        print("ysa" + other.gameObject.name);

        if (other.gameObject.tag == "Player") {
            Block targrtBlock = talkFlowchart.FindBlock(onCollisionEnter);
            talkFlowchart.ExecuteBlock(targrtBlock);


        }

        
       
           
        
        
    }

    private void OnMouseDown()
    {
        PlayBlock(onMouseDown1);
    }

}
