using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class dusmansilah : MonoBehaviour
{
    [Header(" silah ayarlar")]
    float atesetmesikligi;
    public float atesetmesikligi2=0.3f;
    public float menzil;
   
    float darbegucu=20;
  

    [Header("sesler")]
    public AudioSource[] atesetmesesi;
    [Header("efektler")]
    public ParticleSystem[] efektler;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void ateset()
    {
       
        efektler[0].Play();
        atesetmesesi[0].Play();
       /*
        RaycastHit hit;
        if (Physics.Raycast(benimcam.transform.position, benimcam.transform.forward, out hit, menzil))
        {
           
            Instantiate(efektler[1], hit.point, Quaternion.LookRotation(hit.normal));
            
        }
        */
    }
  
    
}
