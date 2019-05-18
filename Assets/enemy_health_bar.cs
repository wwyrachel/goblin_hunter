using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemy_health_bar : MonoBehaviour {
    [SerializeField]

    private Image foregroundImage;

    [SerializeField]

    private float updateSpeedSeconds = 0.5f;

    private void Awake() {
        GetComponentInParent<enemy_health>().OnHealthPctChanged += HandleHealthChanged;
    }

    private void HandleHealthChanged(float pct) {

        StartCoroutine(ChangeToPct(pct));
    }

    private IEnumerator ChangeToPct(float pct) {

        float preChangePct = foregroundImage.fillAmount;

        float elasped = 0f;

        while (elasped < updateSpeedSeconds) {
            elasped += Time.deltaTime;
            foregroundImage.fillAmount = Mathf.Lerp(preChangePct, pct, elasped / updateSpeedSeconds);
            yield return null;
        }

        foregroundImage.fillAmount = pct;


    }

    private void LateUpdate() {

        transform.LookAt(Camera.main.transform);
        transform.Rotate(0, 180, 0);
    }

}
