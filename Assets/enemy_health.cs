using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_health : MonoBehaviour {
    public float cubeSize = 0.2f;
    public int CubesInRow = 5;

    public float explosionRadius;
    public float explosionForce;
    public float explosionUpward;

    float cubePivotDistance;
    Vector3 cubesPivot;

    [SerializeField]
    private int maxHealth = 100;

    private int currentHealth;

    public event Action<float> OnHealthPctChanged = delegate {  };

    void Start() {
        cubePivotDistance = cubeSize * CubesInRow / 2;
        cubesPivot = new Vector3(cubePivotDistance, cubePivotDistance, cubePivotDistance);
    }

    private void OnEnable() {
        currentHealth = maxHealth;
    }

    public void ModifyHealth(int amount) {
        currentHealth += amount;

        float currentHeathPct = (float)currentHealth / (float)maxHealth;
        OnHealthPctChanged(currentHeathPct);
    }

    void OnCollisionEnter(Collision other) {
        print("yessss" + other.gameObject.tag);
        if (other.gameObject.tag == "Player")
        {
            ModifyHealth(-10);
        }

    }

    void Update() {
        if (currentHealth <= 0) {
            Destroy(gameObject);
            for (int x = 0; x < CubesInRow; x++) {
                for (int y = 0; y < CubesInRow; y++) {
                    for (int z = 0; z < CubesInRow; z++) {
                        createpiece(x, y, z);
                    }
                }

            }
            Vector3 explosionPos = transform.position;
            Collider[] colliders = Physics.OverlapSphere(explosionPos, explosionRadius);
            foreach (Collider hit in colliders) {
                Rigidbody rb = hit.GetComponent<Rigidbody>();
                if (rb != null) {

                    rb.AddExplosionForce(explosionForce, transform.position, explosionRadius, explosionUpward);

                }

            }

        }
        if (Input.GetKeyDown(KeyCode.B)) {
            print("bbb");
            ModifyHealth(-10);

        }
    }

    

    void createpiece(int x, int y, int z) {
        GameObject piece;

        piece = GameObject.CreatePrimitive(PrimitiveType.Cube);
        piece.GetComponent<Renderer>().material.color = new Color(255 , 0, 0);

        piece.transform.position = transform.position + new Vector3(cubeSize*x, cubeSize*y, cubeSize* z)- cubesPivot;
        piece.transform.localScale = new Vector3(cubeSize, cubeSize, cubeSize);

        piece.AddComponent<Rigidbody>();
        piece.GetComponent<Rigidbody>().mass = cubeSize;




    }
	
}
