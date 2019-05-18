using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class npc_final_talk : MonoBehaviour {

    public static Flowchart FlowChartManager;

    public Flowchart talkFlowchart;
    public string onMouseDown1 = "talkStart";

    public string onCollisionEnter;

    public string onCollisionEnter1;

    public IKeyItem key;



    // Use this for initialization
    void Awake()
    {
        //FlowChartManager = GameObject.Find("Dialogue_Flowchart");
    }

    // Update is called once per frame
    void Update()
    {

    }

    void PlayBlock(string targetBlockName)
    {
        Block targrtBlock = talkFlowchart.FindBlock(targetBlockName);
        talkFlowchart.ExecuteBlock(targrtBlock);
    }

    private void OnTriggerEnter(Collider other)
    {
        print("ys" + other.gameObject.name);

        if (other.gameObject.tag == "Player")
        {

            
            Block targrtBlock1 = talkFlowchart.FindBlock(onCollisionEnter);
            talkFlowchart.ExecuteBlock(targrtBlock1);


        }






    }

    private void OnMouseDown()
    {
        PlayBlock(onMouseDown1);
    }
}
