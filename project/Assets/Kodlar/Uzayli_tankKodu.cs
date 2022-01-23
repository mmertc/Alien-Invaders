using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Uzayli_tankKodu : MonoBehaviour
{
    public GameObject PowerUp;
    private Rigidbody rig;
    public ParticleSystem dusmanPatlama;
    public float Hiz, DonusHizi, Can, powerUpHizi;
    private Vector3 hedefKonum, oyuncuKonum;
    public int Puan;

    private bool PowerUpAtildi = false;

    // Use this for initialization
    void Start()
    {
        rig = GetComponent<Rigidbody>();
        oyuncuKonum = GameObject.FindGameObjectWithTag("Player").transform.position;

        if (transform.position.x == oyuncuKonum.x)
            hedefKonum = new Vector3(oyuncuKonum.x, oyuncuKonum.y * 10, oyuncuKonum.z);

        else if (transform.position.x > oyuncuKonum.x)
            hedefKonum = new Vector3(oyuncuKonum.x - (transform.position.x - oyuncuKonum.x) * 10, oyuncuKonum.y - (transform.position.y - oyuncuKonum.y) * 10, oyuncuKonum.z);

        else if (transform.position.x < oyuncuKonum.x)
            hedefKonum = new Vector3(oyuncuKonum.x + (oyuncuKonum.x - transform.position.x) * 10, oyuncuKonum.y - (transform.position.y - oyuncuKonum.y) * 10, oyuncuKonum.z);
    }

    // Update is called once per frame
    void FixedUpdate()
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
                if (!PowerUpAtildi)
                {
                    GameObject powerUp = Instantiate(PowerUp, transform.position, PowerUp.transform.rotation);
                    powerUp.GetComponent<Rigidbody>().velocity = Vector3.down * powerUpHizi;
                    PowerUpAtildi = true;
                }
                Destroy(gameObject);
            }
        }
        else if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<OyuncuKodu>().Can--;
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
    

