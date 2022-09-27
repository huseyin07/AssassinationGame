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

        //public void sola_hareket(Animator anim,string anaparametreadý,string kontrolparametre,float yurume,float kosma,float ilerisol,float gerisol) {
        public void sola_hareket(Animator anim, string anaparametreadý, string kontrolparametre,List<float> parametreler ) { 
            if (Input.GetKey(KeyCode.A))
            {
                anim.SetBool(kontrolparametre, true);
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    anim.SetFloat(anaparametreadý, parametreler[1]);
                }
                else if (Input.GetKey(KeyCode.W))
                {
                    anim.SetFloat(anaparametreadý, parametreler[2]);
                }
                else if (Input.GetKey(KeyCode.S))
                {
                    anim.SetFloat(anaparametreadý, parametreler[3]);
                }
                else
                {
                    anim.SetFloat(anaparametreadý, parametreler[0]);

                }
            }
            if (Input.GetKeyUp(KeyCode.A))
            {
                anim.SetBool(kontrolparametre, false);
                anim.SetFloat(anaparametreadý, 0f);
            }

        }
        public void saga_hareket(Animator anim, string anaparametreadý, string kontrolparametre, List<float> parametreler)
        {
            if (Input.GetKey(KeyCode.D))
            {
                anim.SetBool(kontrolparametre, true);
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    anim.SetFloat(anaparametreadý, parametreler[1]);
                }
                else if (Input.GetKey(KeyCode.W))
                {
                    anim.SetFloat(anaparametreadý, parametreler[2]);
                }
                else if (Input.GetKey(KeyCode.S))
                {
                    anim.SetFloat(anaparametreadý, parametreler[3]);
                }
                else
                {
                    anim.SetFloat(anaparametreadý, parametreler[0]);

                }
            }
            if (Input.GetKeyUp(KeyCode.D))
            {
                anim.SetBool(kontrolparametre, false);
                anim.SetFloat(anaparametreadý, 0f);
            }

        }
        public void geri_hareket(Animator anim, string anaparametreadý)
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                anim.SetBool(anaparametreadý, true);
            }
            if (Input.GetKeyUp(KeyCode.S))
            {
                anim.SetBool(anaparametreadý, false);
            }
        }
        public void egilme(Animator anim, string anaparametreadý, string kontrolparametre, List<float> parametreler)
        {
            if (Input.GetKey(KeyCode.C))
            {
                anim.SetBool(kontrolparametre, true);
                if (Input.GetKey(KeyCode.W))
                {
                    anim.SetFloat(anaparametreadý, parametreler[1]);
                }
                else if (Input.GetKey(KeyCode.S))
                {
                    anim.SetFloat(anaparametreadý, parametreler[2]);
                }
                else if (Input.GetKey(KeyCode.A))
                {
                    anim.SetFloat(anaparametreadý, parametreler[3]);
                }
                else if (Input.GetKey(KeyCode.D))
                {
                    anim.SetFloat(anaparametreadý, parametreler[4]);
                }
                else
                {
                    anim.SetFloat(anaparametreadý, parametreler[0]);

                }
            }
            if (Input.GetKeyUp(KeyCode.C))
            {
                anim.SetBool(kontrolparametre, false);
                anim.SetFloat(anaparametreadý, 0);
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
            CamOfSet.y = 0; // y koordinatyla iþimiz yok sýfýrlýyoruz sýkýntý cýkmasýn diye.
            karakter.transform.forward = Vector3.Slerp(karakter.transform.forward, CamOfSet, Time.deltaTime * donushizi); // yumuþak bir geçiþ saðlanýyor.karakterimizi döndürüyoruz mousemizin yönüne göre.
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
