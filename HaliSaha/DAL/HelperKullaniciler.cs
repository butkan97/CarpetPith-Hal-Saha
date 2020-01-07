using HaliSaha.Entitiy;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaliSaha.DAL
{
    public static class HelperKullaniciler
    {
        public static bool KullaniciIslemleri(KullaniciGirisTablo kullanici, EntityState state)
        {
            using (HalıSahaEntities hs = new HalıSahaEntities())
            {
                hs.Entry(kullanici).State = state;
                if (hs.SaveChanges() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }

        public static KullaniciGirisTablo GirisKontrol(string kullaniciAdi, string sifre, bool a)
        {
            using (HalıSahaEntities hs = new HalıSahaEntities())
            {
                var kullanici = hs.KullaniciGirisTablo.Where(x => x.KullaniciAdi == kullaniciAdi && x.KullaniciSifre == sifre && x.KullaniciTipi == a).FirstOrDefault();

                return kullanici;



            }
        }

        public static bool KullaniciKontrol(string kullaniciAdi)
        {
            using (HalıSahaEntities hs = new HalıSahaEntities())
            {
                return hs.KullaniciGirisTablo.Where(x => x.KullaniciAdi == kullaniciAdi).FirstOrDefault() == null;


            }
        }



    }

}
