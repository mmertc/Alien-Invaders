using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectSilmeSayaci : MonoBehaviour {


    public float sayacSuresi;
    public ParticleSystem partikul;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        sayacSuresi -= Time.deltaTime;
        if (sayacSuresi <= 0)
        {
            if (partikul)
                Instantiate(partikul, transform.position, transform.rotation);
            Destroy(gameObject);
        }
	}
}
