using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Fungus;

public class HealthPoint : MonoBehaviour {

    public Image ImageHealthBar;

    public Text TxtHealth;

    public static Flowchart FlowChartManager;

    public Flowchart talkFlowchart;

    public string restart;

    public int Min;

    public int Max;

    private int mCurrentValue;

    private float mCurrentPercent;

    public void SetHealth(int health) {
        if (health != mCurrentPercent) {
            if (Max - Min == 0)
            {
                mCurrentValue = 0;
                mCurrentPercent = 0;
            }
            else {
                mCurrentValue = health;

                mCurrentPercent = (float) mCurrentValue / (float) (Max - Min);
            }

            TxtHealth.text = string.Format("{0} %", Mathf.RoundToInt(mCurrentPercent * 100));

            ImageHealthBar.fillAmount = mCurrentPercent;
        }
    }

	public float CurrentPercent {
        get {
            return mCurrentPercent;
        }
    }

    public int CurrentValue {
        get {
            return mCurrentValue;
        }
    }

    void Start() {
        SetHealth(100);
    }

    void PlayBlock(string targetBlockName)
    {
        Block targrtBlock = talkFlowchart.FindBlock(targetBlockName);
        talkFlowchart.ExecuteBlock(targrtBlock);
    }

    void Update() {
        if (mCurrentValue <= 0) {
            print("die");
            //PlayerPrefs.DeleteAll();
            //SceneManager.LoadScene("MainScene");
            Block targrtBlock = talkFlowchart.FindBlock(restart);
            talkFlowchart.ExecuteBlock(targrtBlock);

        }

    }
}
