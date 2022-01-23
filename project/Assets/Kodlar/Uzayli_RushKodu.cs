using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Uzayli_RushKodu : MonoBehaviour
{


    public ParticleSystem dusmanPatlama;
    private Vector3 oyuncuKonum, hedefKonum;
    public float Hiz, Can;
    public int Puan;

    // Use this for initialization
    void Start()
    {
        oyuncuKonum = GameObject.FindGameObjectWithTag("Player").transform.position;

        if (transform.position.x == oyuncuKonum.x)
            hedefKonum = new Vector3(oyuncuKonum.x, oyuncuKonum.y * 10, oyuncuKonum.z);

        else if (transform.position.x > oyuncuKonum.x)
            hedefKonum = new Vector3(oyuncuKonum.x - (transform.position.x - oyuncuKonum.x) * 10, oyuncuKonum.y - (transform.position.y - oyuncuKonum.y) * 10, oyuncuKonum.z);

        else if (transform.position.x < oyuncuKonum.x)
            hedefKonum = new Vector3(oyuncuKonum.x + (oyuncuKonum.x - transform.position.x) * 10, oyuncuKonum.y - (transform.position.y - oyuncuKonum.y) * 10, oyuncuKonum.z);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, hedefKonum, Hiz * Time.deltaTime);
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
