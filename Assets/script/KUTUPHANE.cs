using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace kutuphanem {
    public class animasyon
    {
        private float maxspeedclass;
        private float inputxclass;
       
       
        public float yonudisaricikar()
        {
            return inputxclass;
        }

        //public void sola_hareket(Animator anim,string anaparametreadı,string kontrolparametre,float yurume,float kosma,float ilerisol,float gerisol) {
        public void sola_hareket(Animator anim, string anaparametreadı, string kontrolparametre,List<float> parametreler ) { 
            if (Input.GetKey(KeyCode.A))
            {
                anim.SetBool(kontrolparametre, true);
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    anim.SetFloat(anaparametreadı, parametreler[1]);
                }
                else if (Input.GetKey(KeyCode.W))
                {
                    anim.SetFloat(anaparametreadı, parametreler[2]);
                }
                else if (Input.GetKey(KeyCode.S))
                {
                    anim.SetFloat(anaparametreadı, parametreler[3]);
                }
                else
                {
                    anim.SetFloat(anaparametreadı, parametreler[0]);

                }
            }
            if (Input.GetKeyUp(KeyCode.A))
            {
                anim.SetBool(kontrolparametre, false);
                anim.SetFloat(anaparametreadı, 0f);
            }

        }
        public void saga_hareket(Animator anim, string anaparametreadı, string kontrolparametre, List<float> parametreler)
        {
            if (Input.GetKey(KeyCode.D))
            {
                anim.SetBool(kontrolparametre, true);
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    anim.SetFloat(anaparametreadı, parametreler[1]);
                }
                else if (Input.GetKey(KeyCode.W))
                {
                    anim.SetFloat(anaparametreadı, parametreler[2]);
                }
                else if (Input.GetKey(KeyCode.S))
                {
                    anim.SetFloat(anaparametreadı, parametreler[3]);
                }
                else
                {
                    anim.SetFloat(anaparametreadı, parametreler[0]);

                }
            }
            if (Input.GetKeyUp(KeyCode.D))
            {
                anim.SetBool(kontrolparametre, false);
                anim.SetFloat(anaparametreadı, 0f);
            }

        }
        public void geri_hareket(Animator anim, string anaparametreadı)
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                anim.SetBool(anaparametreadı, true);
            }
            if (Input.GetKeyUp(KeyCode.S))
            {
                anim.SetBool(anaparametreadı, false);
            }
        }
        public void egilme(Animator anim, string anaparametreadı, string kontrolparametre, List<float> parametreler)
        {
            if (Input.GetKey(KeyCode.C))
            {
                anim.SetBool(kontrolparametre, true);
                if (Input.GetKey(KeyCode.W))
                {
                    anim.SetFloat(anaparametreadı, parametreler[1]);
                }
                else if (Input.GetKey(KeyCode.S))
                {
                    anim.SetFloat(anaparametreadı, parametreler[2]);
                }
                else if (Input.GetKey(KeyCode.A))
                {
                    anim.SetFloat(anaparametreadı, parametreler[3]);
                }
                else if (Input.GetKey(KeyCode.D))
                {
                    anim.SetFloat(anaparametreadı, parametreler[4]);
                }
                else
                {
                    anim.SetFloat(anaparametreadı, parametreler[0]);

                }
            }
            if (Input.GetKeyUp(KeyCode.C))
            {
                anim.SetBool(kontrolparametre, false);
                anim.SetFloat(anaparametreadı, 0);
            }

        }
        /*public void karakter_hareket(Animator anim,string hiz,Vector3 yonum,float maxspeed,float maksimumuzunluk)
        {
            anim.SetFloat(hiz, Vector3.ClampMagnitude(yonum, maxspeed).magnitude, maksimumuzunluk, Time.deltaTime * 10);
        }*/
    
        public void karakter_hareket(Animator anim, string hiz, float maksimumuzunluk, float tamhiz, float yurumehizi)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                maxspeedclass = tamhiz;

            }
            else if (Input.GetKey(KeyCode.W))
            {
                maxspeedclass = yurumehizi;
                inputxclass = 1;

            }
            else
            {
                maxspeedclass = 0;
                inputxclass = 0;

            }
            anim.SetFloat(hiz, Vector3.ClampMagnitude(new Vector3(inputxclass, 0, 0), maxspeedclass).magnitude, maksimumuzunluk, Time.deltaTime * 10);
        }
        public void karakter_rotation(Camera maincam,float donushizi,GameObject karakter)
        {
            Vector3 CamOfSet = maincam.transform.forward;
            CamOfSet.y = 0; // y koordinatyla işimiz yok sıfırlıyoruz sıkıntı cıkmasın diye.
            karakter.transform.forward = Vector3.Slerp(karakter.transform.forward, CamOfSet, Time.deltaTime * donushizi); // yumuşak bir geçiş sağlanıyor.karakterimizi döndürüyoruz mousemizin yönüne göre.
        }
        public List <float> Parametre_olustur(float[] deger)
        {
            List<float> parametreler = new List<float>();
            foreach (float item in deger)
            {
                parametreler.Add(item);

            }
            return parametreler;
        }
    }

}
