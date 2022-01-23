using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Uzayli_hizliAtesKodu : MonoBehaviour {

    public ParticleSystem dusmanPatlama;
    public AudioSource asAtes;
    public AudioClip atesSes;
    public HaritaSinirlari haritaSinirlari;
    private Rigidbody rig;
    public GameObject Oyuncu, Mermi, Namlu;

    public int Can, Puan;
    private int toplamCan;
    private bool AtesLimiti60, AtesLimiti30, AtesLimiti20, AtesLimiti10, AtesLimiti90;
    public float HareketHizi, donusSuresi, atesSayaci;
    private float donusSuresiMax, atesSayaciMax;
    private bool sagaDogru;

    // Use this for initialization
    void Start () {
        rig = GetComponent<Rigidbody>();
        rig.velocity = Vector3.down * HareketHizi;
        
        if (Random.Range(0, 2) == 1)
            sagaDogru = true;
        else sagaDogru = false;

        donusSuresi = Random.Range(3f, 6f);
        donusSuresiMax = donusSuresi;
        atesSayaciMax = atesSayaci;
        if (Oyuncu.GetComponent<OyuncuKodu>().atesGucu != 0)
            Can *= Oyuncu.GetComponent<OyuncuKodu>().atesGucu;
        toplamCan = Can;
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (transform.position.y < 17)
        {
            rig.velocity = Vector3.zero;
            transform.position = new Vector3(transform.position.x, 17.1f, transform.position.z);
        }

        if (donusSuresi <= 0)
        {
            boolDegistir(ref sagaDogru);
            donusSuresi = donusSuresiMax;
        }

        Hareket();
        Ates();
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
        else if (transform.position.x < haritaSinirlari.SolSinir)
        {
            sagaDogru = true;
            donusSuresi = donusSuresiMax;
        }
    }

    private bool boolDegistir(ref bool Bool)
    {
        if (Bool)
            Bool = false;
        else
            Bool = true;
        return Bool;
    }

    private void Ates()
    {
        if (Oyuncu)
        {
            if (atesSayaci <= 1 && AtesLimiti10 && Can < (toplamCan * 10) / 100)
            {
                asAtes.PlayOneShot(atesSes);
                Instantiate(Mermi, Namlu.transform.position, transform.rotation);
                AtesLimiti10 = false;
            }
            if (atesSayaci <= 0.7 && AtesLimiti20 && Can < (toplamCan * 20) / 100)
            {
                asAtes.PlayOneShot(atesSes);
                Instantiate(Mermi, Namlu.transform.position, transform.rotation);
                AtesLimiti20 = false;
            }
            if (atesSayaci <= 0.5 && AtesLimiti30 && Can < (toplamCan * 30) / 100)
            {
                asAtes.PlayOneShot(atesSes);
                Instantiate(Mermi, Namlu.transform.position, transform.rotation);
                AtesLimiti30 = false;
            }
            if (atesSayaci <= 0.35 && AtesLimiti60 && Can < (toplamCan * 60) / 100)
            {
                asAtes.PlayOneShot(atesSes);
                Instantiate(Mermi, Namlu.transform.position, transform.rotation);
                AtesLimiti60 = false;
            }
            if (atesSayaci <= 0.2 && AtesLimiti90 && Can < (toplamCan * 90) / 100)
            {
                asAtes.PlayOneShot(atesSes);
                Instantiate(Mermi, Namlu.transform.position, transform.rotation);
                AtesLimiti90 = false;
            }
            if (atesSayaci <= 0)
            {
                asAtes.PlayOneShot(atesSes);
                Instantiate(Mermi, Namlu.transform.position, transform.rotation);

                AtesLimiti10 = true;
                AtesLimiti20 = true;
                AtesLimiti30 = true;
                AtesLimiti60 = true;
                AtesLimiti90 = true;

                atesSayaci = atesSayaciMax;
            }
            atesSayaci -= Time.deltaTime;
        }

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
                Instantiate(dusmanPatlama, transform.position, transform.rotation);
                Instantiate(dusmanPatlama, transform.position, transform.rotation);
                Instantiate(dusmanPatlama, transform.position, transform.rotation);
                Instantiate(dusmanPatlama, transform.position, transform.rotation);
                Instantiate(dusmanPatlama, transform.position, transform.rotation);
                Instantiate(dusmanPatlama, transform.position, transform.rotation);
                Instantiate(dusmanPatlama, transform.position, transform.rotation);
                Instantiate(dusmanPatlama, transform.position, transform.rotation);
                Instantiate(dusmanPatlama, transform.position, transform.rotation);
                Instantiate(dusmanPatlama, transform.position, transform.rotation);
                Instantiate(dusmanPatlama, transform.position, transform.rotation);
                Instantiate(dusmanPatlama, transform.position, transform.rotation);
                Instantiate(dusmanPatlama, transform.position, transform.rotation);
                Instantiate(dusmanPatlama, transform.position, transform.rotation);
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
