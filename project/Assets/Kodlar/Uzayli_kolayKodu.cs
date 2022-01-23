using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Uzayli_kolayKodu : MonoBehaviour {

    public GameObject patlama, oyuncuHasarPatlamasi;
    public int Can, Puan;
    

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "DostMermi")
        {
            Destroy(col.gameObject);
            Instantiate(patlama, transform.position, transform.rotation);
            Can--;

            if (Can <= 0)
            {
                GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<OyuncuKodu>().MevcutPuan += Puan;
                Instantiate(patlama, transform.position, transform.rotation);
                Destroy(gameObject);           
            }
        }
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<OyuncuKodu>().Can--;
            //Instantiate(oyuncuHasarPatlamasi, transform.position, transform.rotation);
            Can--;
            if (Can <= 0)
            {
                col.gameObject.GetComponent<OyuncuKodu>().MevcutPuan += Puan;
                Instantiate(patlama, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }
    }
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<OyuncuKodu>().Can--;
            Can--;
            if (Can <= 0)
            {
                Instantiate(patlama, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }
    }
}
