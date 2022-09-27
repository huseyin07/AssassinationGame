using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using kutuphanem;
using UnityEngine.UI;

public class karakterkontrol : MonoBehaviour
{
    float inputx;
    public Image healtbar;
    Animator anim;
    Vector3 yonum;
    Camera maincam;
    float maksimumuzunluk=1;
    float donushizi = 10;
    float maxspeed;
    animasyon a = new animasyon();
    public static float saglik;

    float[] sol_yon_parametreleri = { 0.12f, 0.34f, 0.63f, 0.92f };
    float[] sag_yon_parametreleri = { 0.12f, 0.34f, 0.63f, 0.92f };
    float[] egilme_yon_parametreleri = { 0.2f, 0.35f, 0.40f, 0.45f, 1f };
    // Start is called before the first frame update
    void Start()
    {       
        anim = GetComponent<Animator>();
        maincam = Camera.main;
        saglik = 100;
    }


    void LateUpdate()
    {
        a.karakter_hareket(anim, "speed",maksimumuzunluk, 1, 0.2f);
        a.karakter_rotation(maincam, donushizi, gameObject);
        a.sola_hareket(anim, "solharekett", "sol_aktifmi",a.Parametre_olustur(sol_yon_parametreleri));
        a.saga_hareket(anim, "sagharekett", "sag_aktifmi", a.Parametre_olustur(sag_yon_parametreleri));
        a.geri_hareket(anim, "geriyuru");
        a.egilme(anim, "egilme", "egilme_aktifmi", a.Parametre_olustur(egilme_yon_parametreleri));
    }
    public void saglikdurumu(float darbegucu)
    {
        saglik -= darbegucu;
        healtbar.fillAmount = saglik / 100;
        Debug.Log(saglik);
        if (saglik <= 100)
        {
            Debug.Log("oldn");
        }
    }
}
