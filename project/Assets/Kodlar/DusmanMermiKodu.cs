using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DusmanMermiKodu : MonoBehaviour {


    private GameObject Oyuncu, Boss;
    private Vector3 OyuncuKonum;
    public ParticleSystem patlama;
    public float Hiz, hedefYenilemeSuresi, yokOlmayaKalanSure;

    private float hedefYenilemeSuresiMax;
    private Rigidbody rig;

	// Use this for initialization
	void Start ()
    {
        rig = GetComponent<Rigidbody>();

        hedefYenilemeSuresiMax = hedefYenilemeSuresi;
        Boss = GameObject.FindGameObjectWithTag("Boss");
        Oyuncu = GameObject.FindGameObjectWithTag("Player");
	}

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (!Oyuncu)
        {
            Instantiate(patlama, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        if (!Boss)
        {
            yokOlmayaKalanSure -= Time.deltaTime;
            if (yokOlmayaKalanSure <= 0)
            {
                Instantiate(patlama, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }

        if (hedefYenilemeSuresi <= 0)
        {
            if (Oyuncu)
                OyuncuKonum = Oyuncu.transform.position;
            hedefYenilemeSuresi = hedefYenilemeSuresiMax;
        }
        
        hedefYenilemeSuresi -= Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, OyuncuKonum, Hiz);
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<OyuncuKodu>().Can--;
            Destroy(gameObject);
        }
    }
}
