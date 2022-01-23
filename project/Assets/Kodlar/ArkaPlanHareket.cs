using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArkaPlanHareket : MonoBehaviour {

    GameObject oyuncu;
    MeshRenderer mr;
    public float yavaslik;
    Vector2 arkaPlan;

    // Use this for initialization
    void Start ()
    {
        oyuncu = GameObject.FindGameObjectWithTag("Player").gameObject;
        mr = GetComponent<MeshRenderer>();
        arkaPlan = mr.material.mainTextureOffset;
    }
	
	// Update is called once per frame
	void Update () {

        if (oyuncu)
        {
            arkaPlan.y += Time.deltaTime / 10;

            if (Input.GetKey(KeyCode.D))
            {
                arkaPlan = mr.material.mainTextureOffset;
                arkaPlan.x += Time.deltaTime / yavaslik;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                arkaPlan = mr.material.mainTextureOffset;
                arkaPlan.x -= Time.deltaTime / yavaslik;
            }
            if (Input.GetKey(KeyCode.W))
            {
                arkaPlan = mr.material.mainTextureOffset;
                arkaPlan.y += Time.deltaTime / yavaslik;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                //arkaPlan = mr.material.mainTextureOffset;
                //arkaPlan.y -= Time.deltaTime / yavaslik;
            }

            mr.material.mainTextureOffset = arkaPlan;
        }
    }
}
