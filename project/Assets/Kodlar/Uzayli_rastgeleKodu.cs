using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Uzayli_rastgeleKodu : MonoBehaviour {

    Rigidbody rig;
    public ParticleSystem dusmanPatlama, oyuncuHasarPatlamasi;
    public  HaritaSinirlari haritaSinirlari;

    private float HareketHizi, donusSuresi;
    private float donusSuresiMax;
    private bool sagaDogru;
    public int Can, Puan;

	// Use this for initialization
	void Start ()
    {
        HareketHizi = Random.Range(5f, 30f);

        donusSuresi = Random.Range(0.3f, 3f);
        rig = GetComponent<Rigidbody>();
        donusSuresiMax = donusSuresi;

        if (Random.Range(0, 2) == 1)
            sagaDogru = true;
        else sagaDogru = false;

        Hareket();
	}

    // Update is called once per frame
    void Update()
    {
        donusSuresi -= Time.deltaTime;

        if(donusSuresi <= 0)
        {
            boolDegistir(ref sagaDogru);
            donusSuresi = donusSuresiMax;
        }
        Hareket();
    }
		
	private void Hareket()
    {       
        if (sagaDogru)
        {
            rig.velocity = new Vector3(1 * HareketHizi, -1 * HareketHizi, 0);
        }
        else
            rig.velocity = new Vector3(-1 * HareketHizi, -1 * HareketHizi, 0);
        if (transform.position.x > haritaSinirlari.SagSinir)
        {
            sagaDogru = false;
            donusSuresi = donusSuresiMax;
        }
        else if (transform.position.x <  haritaSinirlari.SolSinir)
        {
            sagaDogru = true;
            donusSuresi = donusSuresiMax;
        }     
    }

    private bool boolDegistir(ref bool Bool)
    {
        if(Bool)       
            Bool = false;      
        else        
            Bool = true;
        return Bool;
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "DostMermi")
        {
            Can--;
            Instantiate(dusmanPatlama, transform.position, transform.rotation);
            Instantiate(dusmanPatlama, transform.position, transform.rotation);
            Destroy(col.gameObject);
            if (Can <= 0)
            {
                GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<OyuncuKodu>().MevcutPuan += Puan;
                Instantiate(dusmanPatlama, transform.position, transform.rotation);
                Instantiate(dusmanPatlama, transform.position, transform.rotation);
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
                Instantiate(dusmanPatlama, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }
    }

   




}
