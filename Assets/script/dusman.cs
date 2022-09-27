using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class dusman : MonoBehaviour
{
    [Header(" diðer  ayarlar")]
    NavMeshAgent nevmesh;
    Animator animatorum;
    GameObject hedef;

    [Header(" ayarlar")]
    float atesetmemenzil = 7;
    float saglik;
    float suphelenmemenzil = 10;
    Vector3 baslangicnoktasi;
    bool suphevarmi = false;
    bool ates_Ediliyormu = false;
    public GameObject anahedef;
    [Header(" devriye  ayarlar")]
    public GameObject[] Devriye_noktalari1;
    public GameObject[] Devriye_noktalari2;
    public GameObject[] Devriye_noktalari3;
     bool devriye_varmi;
    Coroutine devriye_At;
    Coroutine devriye_zaman;
     bool devriyekilit;
    public bool devriye_atabilirmi;
    GameObject[] aktifnoktaliste;

    [Header(" silah ayarlar")]
    float atesetmesikligi;
    public float atesetmesikligi2 = 0.3f;
    public float menzil;
    [Header("sesler")]
    public AudioSource[] atesetmesesi;
    [Header("efektler")]
    public ParticleSystem[] efektler;

    public float darbegucu = 2;
    public GameObject atesetmenoktasi;
  
    //public GameObject kafa;
    // Start is called before the first frame update
    void Start()
    {
        nevmesh = GetComponent<NavMeshAgent>();
        animatorum = GetComponent<Animator>();
        baslangicnoktasi = transform.position;
        StartCoroutine(devriyezamankontrol());
        saglik = 100;
        // animatorum.SetBool("yuru", true);
    }
    private void LateUpdate()
    {
        if (nevmesh.remainingDistance <= 1 && nevmesh.stoppingDistance==1)
        {
            animatorum.SetBool("yuru", false);
            transform.rotation = Quaternion.Euler(0, 180, 0);
            devriye_varmi = false;
            if (devriye_atabilirmi)
            {
                devriye_zaman = StartCoroutine(devriyezamankontrol());
                StopCoroutine(devriye_At);
            }
            
            nevmesh.stoppingDistance = 0;
            nevmesh.isStopped = true;
        }
        if (devriyekilit && devriye_atabilirmi)
        {
            devriyekontrol();
        }
       suphelenme();
        atesetme();
        
    }
    IEnumerator devriyeteknikislem()
    {
        nevmesh.isStopped = false;
        devriyekilit = false;
        devriye_varmi = true;
        animatorum.SetBool("yuru", true);
        int toplamnokta = aktifnoktaliste.Length-1;
        int baslangicnokta = 0;
        while (true && devriye_atabilirmi)
        {
            if(Vector3.Distance(transform.position , aktifnoktaliste[baslangicnokta].transform.position) <=1f)
            {
                if (toplamnokta > baslangicnokta)
                {
                    ++baslangicnokta;
                    
                    nevmesh.SetDestination(aktifnoktaliste[baslangicnokta].transform.position);

                }
                else
                {
                    nevmesh.stoppingDistance = 1;
                    nevmesh.SetDestination(baslangicnoktasi);
                    
                }
             
            }
            else
            {
                if (toplamnokta > baslangicnokta)
                {
                    
                    nevmesh.SetDestination(aktifnoktaliste[baslangicnokta].transform.position);

                }
                
            }
           
            yield return null;
        }
    }
    void devriyekontrol()
    {
        int deger = Random.Range(1, 3);
        switch (deger)
        {
            case 1:
                aktifnoktaliste = Devriye_noktalari1;
                break;
            case 2:
                aktifnoktaliste = Devriye_noktalari2;
                break;
            case 3:
                aktifnoktaliste = Devriye_noktalari3;
                break;
            
        }
        devriye_At = StartCoroutine(devriyeteknikislem());
    }
    IEnumerator devriyezamankontrol()
    {
        while (true && !devriye_varmi  && devriye_atabilirmi)
        {
            
            
                yield return new WaitForSeconds(5f);
                devriyekilit = true;
                StopCoroutine(devriye_zaman);
            

        }
    }

    void atesetme()
    {
        Collider[] hitcolliders = Physics.OverlapSphere(transform.position, atesetmemenzil);

        
        foreach (var objeler in hitcolliders)
        {
            if (objeler.gameObject.CompareTag("Player"))
            {
                ates_et(objeler.gameObject);
                

               
            }
            else
            {
                if (ates_Ediliyormu)
                {
                    animatorum.SetBool("yuru", true);
                    nevmesh.isStopped = false;
                    animatorum.SetBool("ateset", false);
                    ates_Ediliyormu = false;
                }
                
            }

        }
    }
    void ates_et(GameObject hedef)
    {
        ates_Ediliyormu = true;
        Vector3 aradakifark = hedef.gameObject.transform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(aradakifark, Vector3.up);
        transform.rotation = rotation;
        animatorum.SetBool("yuru", false);
        nevmesh.isStopped = true;
        animatorum.SetBool("ateset", true);
        RaycastHit hit;
        
        if (Physics.Raycast(atesetmenoktasi.transform.position,atesetmenoktasi.transform.forward, out hit, menzil))
        {
            Color color = Color.red;
            Debug.Log("goruldu");
            Vector3 degisenpoz = new Vector3(atesetmenoktasi.transform.position.x, atesetmenoktasi.transform.position.y + 1.5f, atesetmenoktasi.transform.position.z);
            Debug.DrawLine(atesetmenoktasi.transform.position, degisenpoz, color);
            if (Time.time > atesetmesikligi )
            {
                
                hit.transform.gameObject.GetComponent<karakterkontrol>().saglikdurumu(darbegucu);
                Instantiate(efektler[1], hit.point, Quaternion.LookRotation(hit.normal));
                if (!atesetmesesi[0].isPlaying)
                {
                    efektler[0].Play();
                    atesetmesesi[0].Play();
                }
                atesetmesikligi = Time.time + atesetmesikligi2;
            }
            

        }
    }
    void suphelenme()
    {
        Collider[] hitcolliders = Physics.OverlapSphere(transform.position, suphelenmemenzil);

     
        foreach (var objeler in hitcolliders)
        {
            if (objeler.gameObject.CompareTag("Player"))
            {
                if (animatorum.GetBool("kosma"))
                {
                    animatorum.SetBool("kosma",false);
                    animatorum.SetBool("yuru", true);
                }
                else
                {
                    animatorum.SetBool("yuru", true);
                }
                
                hedef = objeler.gameObject;
                nevmesh.SetDestination(hedef.transform.position);
                if(devriye_atabilirmi)
                StopCoroutine(devriye_At);
                suphevarmi = true;
            }
            else
            {
                if (suphevarmi)
                {
                    hedef = null;
                    
                    if (transform.position != baslangicnoktasi)
                    {
                        nevmesh.stoppingDistance = 1;// geri baslangýca dönerken robot gibi ayný yere donmesin diye 1 metre yakýnýna dönsn istedim.
                        nevmesh.SetDestination(baslangicnoktasi);
                        if (nevmesh.remainingDistance <= 1)//geriye kalan mesafe 1den azaldýysa 
                        {
                            animatorum.SetBool("yuru", false);// dusmaný durdur .
                            transform.rotation = Quaternion.Euler(0, 180, 0);// dusman geri döndüðünde arkasý dönük kalýyor ondan rotasyonunu deðiþtirdik.
                        }
                    }
                    suphevarmi = false;
                    if(devriye_atabilirmi)
                    devriye_At = StartCoroutine(devriyeteknikislem());
                }


            }

        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 7);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, 10);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void saglikdurumu(float darbegucu)
    {
        saglik -= darbegucu;
        if (!suphevarmi)
        {
            animatorum.SetBool("kosma", true);
            nevmesh.SetDestination(anahedef.transform.position);
        }
        
        if (saglik <= 100)
        {
            animatorum.Play("olme");
            Destroy(gameObject,3f);
        }
    }
}
/*RaycastHit hit;
if (Physics.Raycast(kafa.transform.position, kafa.transform.forward, out hit, 10f))
{
    if (hit.transform.gameObject.CompareTag("Player"))
    {
        Debug.Log("carptý");
    }
}
Debug.DrawRay(kafa.transform.position, kafa.transform.forward * 10f, Color.yellow);*/
