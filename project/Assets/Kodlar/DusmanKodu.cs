using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DusmanKodu : MonoBehaviour {
    public GameObject Boss;
    public Text text;
    public GameObject Uzayli_kolay, Uzayli_rush, Uzayli_hizliAtes, Uzayli_rastgele, Uzayli_tank, oyuncu;
    public AudioClip kaybetmeSes;
    public AudioSource askaybetmeSes;
    public HaritaSinirlari haritaSinirlari;

    public float spawnSayaci, HizUzayli_kolay, HizUzayli_rush, HizUzayli_hizliAtes, HizUzayli_rastgele, HizUzayli_tank;
    private float spawnSayaciMax, zamanlaZorlasmaFloat = 2f, zamanlaZorlasmaFloatMax;
    int dusmanSecimi, zamanlaZorlasmaInt;
    bool kaybedildi;

    // Use this for initialization
    void Start ()
    {
        zamanlaZorlasmaFloatMax = zamanlaZorlasmaFloat;
        kaybedildi = false;
        spawnSayaciMax = spawnSayaci;
    }
	
	// Update is called once per frame
	void Update ()
    {
        Boss = GameObject.FindGameObjectWithTag("Boss");
        zamanlaZorlasmaFloat -= Time.deltaTime;

        if (zamanlaZorlasmaFloat < 0)
        {
            zamanlaZorlasmaFloat = zamanlaZorlasmaFloatMax;
            if (zamanlaZorlasmaInt < 51)
                zamanlaZorlasmaInt++;
        }      
        Spawn();

        if (!oyuncu && !kaybedildi)
        {
            askaybetmeSes.PlayOneShot(kaybetmeSes);
            kaybedildi = true;
        }
     
	}

    private void Spawn()
    {
        if (!kaybedildi)
        {
            if (Uzayli_hizliAtes)
            {
                spawnSayaci -= Time.deltaTime;

                if (spawnSayaci <= 0 && !Boss)
                {
                    dusmanSecimi = Random.Range(zamanlaZorlasmaInt, 100);
                   // dusmanSecimi = Random.Range(0, 0);
                    if (dusmanSecimi > 95 && oyuncu.GetComponent<OyuncuKodu>().MevcutPuan > 500)
                    {
                        Instantiate(Uzayli_hizliAtes, new Vector3(Random.Range(haritaSinirlari.SolSinir, haritaSinirlari.SagSinir), 25, 0), Uzayli_hizliAtes.transform.rotation);
                    }
                    else if (dusmanSecimi <= 95 && dusmanSecimi > 85)
                    {
                        Instantiate(Uzayli_tank, new Vector3(Random.Range(haritaSinirlari.SolSinir, haritaSinirlari.SagSinir), 25, 0), Uzayli_tank.transform.rotation);
                    }
                    else if (dusmanSecimi <= 85 && dusmanSecimi > 70)
                    {
                        Instantiate(Uzayli_rush, new Vector3(Random.Range(haritaSinirlari.SolSinir, haritaSinirlari.SagSinir), 25, 0), Uzayli_rush.transform.rotation);
                    }
                    else if (dusmanSecimi <= 70 && dusmanSecimi > 50)
                    {
                        SpawnUzayli_rastgele();
                    }
                    else if (dusmanSecimi >= 0 && dusmanSecimi < 50)
                    {
                        SpawnUzayli_kolay();
                    }
                    if (spawnSayaciMax > 0.2)
                        spawnSayaciMax -= Time.deltaTime * 2;
                    spawnSayaci = spawnSayaciMax;
                }
            }
        }
    }

    private void SpawnUzayli_kolay()
    {
        GameObject uzayli = Instantiate(Uzayli_kolay, new Vector3(Random.Range(haritaSinirlari.SolSinir, haritaSinirlari.SagSinir), 25, 0), Uzayli_kolay.transform.rotation);
        uzayli.GetComponent<Rigidbody>().velocity = Vector3.down * HizUzayli_kolay;
    }

    private void SpawnUzayli_rastgele()
    {             
        GameObject uzayli = Instantiate(Uzayli_rastgele, new Vector3(Random.Range(haritaSinirlari.SolSinir, haritaSinirlari.SagSinir), 25, 0), Uzayli_rastgele.transform.rotation);        
    }
}
