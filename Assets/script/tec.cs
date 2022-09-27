using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tec9 : MonoBehaviour
{
    [Header("ayarlar")]
    float atesetmesikligi;
    float atesetmesikligi2;
    public float menzil;
    [Header("sesler")]
    public AudioSource[] atesetmesesi;
    [Header("efektler")]
    public ParticleSystem[] efektler;
    [Header("genel_islemler")]
    public Camera benimcam;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            ateset();
        }
    }
    void ateset()
    {
        RaycastHit hit;
        if (Physics.Raycast(benimcam.transform.position, benimcam.transform.forward, out hit, menzil))
        {
            efektler[0].Play();
            Debug.Log("sa");
        }
    }
}
