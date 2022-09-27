using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class technine : MonoBehaviour
{
    [Header("ayarlar")]
    float atesetmesikligi;
    public float atesetmesikligi2=0.3f;
    public float menzil;
    int toplammermisayisi=200;
    int sarjorkapasite=30;
    int kalanmermi;
    float darbegucu=25;
    public TextMeshProUGUI toplammermi_text;
    public TextMeshProUGUI kalanmermi_text;

    [Header("sesler")]
    public AudioSource[] atesetmesesi;
    [Header("efektler")]
    public ParticleSystem[] efektler;
    [Header("genel_islemler")]
    public Camera benimcam;
    public Animator karakterAnim;
    // Start is called before the first frame update
    void Start()
    {
        kalanmermi = sarjorkapasite;
        toplammermi_text.text = toplammermisayisi.ToString();
        kalanmermi_text.text = sarjorkapasite.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            reloadkontrol();

        }
        if (karakterAnim.GetBool("reload"))
        {
            reloadteknikislem();
        }
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if(Time.time > atesetmesikligi && kalanmermi!=0)
            {
                ateset();
                atesetmesikligi = Time.time + atesetmesikligi2;
            }
            if (kalanmermi == 0)
            {
                atesetmesesi[1].Play();
            }
            
        }
    }
    void ateset()
    {
        kalanmermi--;
        kalanmermi_text.text = kalanmermi.ToString();
        efektler[0].Play();
        atesetmesesi[0].Play();
        karakterAnim.Play("egilerek_Ates");
        RaycastHit hit;
        if (Physics.Raycast(benimcam.transform.position, benimcam.transform.forward, out hit, menzil))
        {
            if (hit.transform.gameObject.CompareTag("dusman")) {
                hit.transform.gameObject.GetComponent<dusman>().saglikdurumu(darbegucu);
                Instantiate(efektler[2], hit.point, Quaternion.LookRotation(hit.normal));
            }
            else
            {
                Instantiate(efektler[1], hit.point, Quaternion.LookRotation(hit.normal));
            }
           
            
        }
    }
    void reloadkontrol()
    {
        if (kalanmermi < sarjorkapasite && toplammermisayisi != 0)
        {
            karakterAnim.Play("sarjordegisim");
            if (!atesetmesesi[2].isPlaying)
            {
                atesetmesesi[2].Play();
            }
            
        }
    }
    void reloadteknikislem()
    {
        if (kalanmermi == 0)
        {
            if (toplammermisayisi <= sarjorkapasite)
            {
                kalanmermi = toplammermisayisi;
                toplammermisayisi = 0;
            }
            else
            {
                toplammermisayisi -= sarjorkapasite;
                kalanmermi = sarjorkapasite;
            }


        }
        else
        {
            if (toplammermisayisi <= sarjorkapasite)
            {
                int deger = toplammermisayisi + kalanmermi;
                if (deger > sarjorkapasite)
                {
                    kalanmermi = sarjorkapasite;
                    toplammermisayisi = deger - sarjorkapasite;
                }
                else
                {
                    kalanmermi += toplammermisayisi;
                    toplammermisayisi = 0;
                }

            }
            else
            {
                int mevcutmermi = sarjorkapasite - kalanmermi;
                toplammermisayisi -= mevcutmermi;
                kalanmermi = sarjorkapasite;

            }

        }
        toplammermi_text.text = toplammermisayisi.ToString();
        kalanmermi_text.text = sarjorkapasite.ToString();
        karakterAnim.SetBool("reload", false);
    }
}
