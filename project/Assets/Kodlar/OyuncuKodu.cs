using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OyuncuKodu : MonoBehaviour {

    public HaritaSinirlari haritaSinirlari;

    public Transform solNamlu, ortaNamlu, sagNamlu, solOrtaNamlu, sagOrtaNamlu;
    public GameObject mermi, karakterOlmePartikul;
    public AudioSource asAtes, asMainTheme, asPowerUp;
    public AudioClip atesSesi, mainTheme, PowerUpSes;
    public Text puanText, maksPuantext, EnerjiCekirdegiText;
    public int atesGucu, mermiHizi, Can, MevcutPuan;
    public float hareketHizi;
    
    // Use this for initialization
    void Start ()
    {
        asMainTheme.PlayOneShot(mainTheme);
        MevcutPuan = 0;

        if (!PlayerPrefs.HasKey("maksPuan"))
        {
            maksPuantext.text = 0.ToString();
            PlayerPrefs.SetInt("maksPuan", 0);
        }
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (gameObject.GetComponent<OyuncuKodu>().Can <= 0)
        {
            Instantiate(karakterOlmePartikul, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        if (PlayerPrefs.GetInt("maksPuan") < MevcutPuan)
        {
            PlayerPrefs.SetInt("maksPuan", MevcutPuan);
        }
        maksPuantext.text = PlayerPrefs.GetInt("maksPuan").ToString();
        puanText.text = MevcutPuan.ToString();
        EnerjiCekirdegiText.text = atesGucu.ToString();
        Hareket();
	}


    void Hareket()
    {
        if (Input.GetKeyDown(KeyCode.K))
            atesGucu++;


        if (Input.GetKeyDown(KeyCode.Space))
        {
            switch (atesGucu)
            {
                case 0:
                    {
                        GameObject yeniMermi1 = Instantiate(mermi, ortaNamlu.position, transform.rotation);
                        yeniMermi1.GetComponent<Rigidbody>().velocity = Vector3.up * mermiHizi;
                        break;
                    }
                case 1:
                    {
                        GameObject yeniMermi1 = Instantiate(mermi, solNamlu.position, transform.rotation);
                        yeniMermi1.GetComponent<Rigidbody>().velocity = Vector3.up * mermiHizi;

                        GameObject yeniMermi2 = Instantiate(mermi, sagNamlu.position, transform.rotation);
                        yeniMermi2.GetComponent<Rigidbody>().velocity = Vector3.up * mermiHizi;
                        break;
                    }
                case 2:
                    {
                        GameObject yeniMermi1 = Instantiate(mermi, ortaNamlu.position, transform.rotation);
                        yeniMermi1.GetComponent<Rigidbody>().velocity = Vector3.up * mermiHizi;

                        GameObject yeniMermi2 = Instantiate(mermi, sagNamlu.position, transform.rotation);
                        yeniMermi2.GetComponent<Rigidbody>().velocity = Vector3.up * mermiHizi;

                        GameObject yeniMermi3 = Instantiate(mermi, solNamlu.position, transform.rotation);
                        yeniMermi3.GetComponent<Rigidbody>().velocity = Vector3.up * mermiHizi;
                        break;
                    }
                case 3:
                    {
                        GameObject yeniMermi1 = Instantiate(mermi, solNamlu.position, transform.rotation);
                        yeniMermi1.GetComponent<Rigidbody>().velocity = Vector3.up * mermiHizi;

                        GameObject yeniMermi2 = Instantiate(mermi, ortaNamlu.position, transform.rotation);
                        yeniMermi2.GetComponent<Rigidbody>().velocity = Vector3.up * mermiHizi;

                        GameObject yeniMermi3 = Instantiate(mermi, sagNamlu.position, transform.rotation);
                        yeniMermi3.GetComponent<Rigidbody>().velocity = Vector3.up * mermiHizi;

                        GameObject yeniMermi4 = Instantiate(mermi, solOrtaNamlu.position, transform.rotation);
                        yeniMermi4.GetComponent<Rigidbody>().velocity = Vector3.up * mermiHizi;
                        break;
                    }

                case 4:
                    {
                        GameObject yeniMermi1 = Instantiate(mermi, solNamlu.position, transform.rotation);
                        yeniMermi1.GetComponent<Rigidbody>().velocity = Vector3.up * mermiHizi;

                        GameObject yeniMermi2 = Instantiate(mermi, ortaNamlu.position, transform.rotation);
                        yeniMermi2.GetComponent<Rigidbody>().velocity = Vector3.up * mermiHizi;

                        GameObject yeniMermi3 = Instantiate(mermi, sagNamlu.position, transform.rotation);
                        yeniMermi3.GetComponent<Rigidbody>().velocity = Vector3.up * mermiHizi;

                        GameObject yeniMermi4 = Instantiate(mermi, solOrtaNamlu.position, transform.rotation);
                        yeniMermi4.GetComponent<Rigidbody>().velocity = Vector3.up * mermiHizi;

                        GameObject yeniMermi5 = Instantiate(mermi, sagOrtaNamlu.position, transform.rotation);
                        yeniMermi5.GetComponent<Rigidbody>().velocity = Vector3.up * mermiHizi;
                        break;
                    }

                default:
                    {
                        GameObject yeniMermi1 = Instantiate(mermi, solNamlu.position, transform.rotation);
                        yeniMermi1.GetComponent<Rigidbody>().velocity = Vector3.up * mermiHizi;

                        GameObject yeniMermi2 = Instantiate(mermi, ortaNamlu.position, transform.rotation);
                        yeniMermi2.GetComponent<Rigidbody>().velocity = Vector3.up * mermiHizi;

                        GameObject yeniMermi3 = Instantiate(mermi, sagNamlu.position, transform.rotation);
                        yeniMermi3.GetComponent<Rigidbody>().velocity = Vector3.up * mermiHizi;

                        GameObject yeniMermi4 = Instantiate(mermi, solOrtaNamlu.position, transform.rotation);
                        yeniMermi4.GetComponent<Rigidbody>().velocity = Vector3.up * mermiHizi;

                        GameObject yeniMermi5 = Instantiate(mermi, sagOrtaNamlu.position, transform.rotation);
                        yeniMermi5.GetComponent<Rigidbody>().velocity = Vector3.up * mermiHizi;
                        break;
                    }
            }
            asAtes.PlayOneShot(atesSesi);
        }

        if(Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * hareketHizi * Time.deltaTime);
            
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * hareketHizi * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up * hareketHizi * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.down * hareketHizi * Time.deltaTime);
        }

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, haritaSinirlari.SolSinir, haritaSinirlari.SagSinir), Mathf.Clamp(transform.position.y, haritaSinirlari.AltSinir, haritaSinirlari.UstSinir), 0);
    }


    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "PowerUp")
        {
            atesGucu++;
            MevcutPuan += 300;

            asPowerUp.PlayOneShot(PowerUpSes);

            Destroy(GameObject.FindGameObjectWithTag("PowerUp"));
        }
    }
}
