using HaliSaha.Entitiy;
using HaliSaha.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaliSaha.DAL
{
    public static class HelperKiralanmisSaha
    {

        public static List<KiralanmisSahaModel> KiralanmisSahaListesi(int kullaniciID)
        {
            using (HalıSahaEntities hs = new HalıSahaEntities())
            {
                var liste = hs.KiralanmışSahaTablo.Where(x => x.KullaniciID == kullaniciID).ToList();
                List<KiralanmisSahaModel> kiralikSahaListesi = new List<KiralanmisSahaModel>();
                foreach (var item in liste)
                {
                    KiralanmisSahaModel ksm = new KiralanmisSahaModel();
                    ksm.KSID = item.KSID;
                    ksm.SahaTablo.SahaAdi = item.SahaTablo.SahaAdi;
                    ksm.SahaTablo.Telefon = item.SahaTablo.Telefon;
                    ksm.SahaTablo.Adres = item.SahaTablo.Adres;
                    ksm.SahaTablo.SahaID = item.SahaTablo.SahaID;
                    ksm.SaatBaslangic = item.SaatBaslangic;
                    kiralikSahaListesi.Add(ksm);

                }
                return kiralikSahaListesi;

            }
        }

        public static bool KiralanmisSahaIslemleri(KiralanmışSahaTablo kiraliksaha, EntityState state)
        {
            using (HalıSahaEntities hs = new HalıSahaEntities())
            {
                hs.Entry(kiraliksaha).State = state;
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

        public static List<KiralanmisSahaModel> KiralanmisSahaListesi(int semtID, int sahaID, int macSaat, int kullaniciID)
        {
            using (HalıSahaEntities hs = new HalıSahaEntities())
            {
                var liste = hs.KiralanmışSahaTablo.Where(x => x.SemtID == semtID && x.SahaID == sahaID && x.SaatBaslangic == macSaat && x.KullaniciID != null && x.KullaniciID == kullaniciID).ToList();
                List<KiralanmisSahaModel> sahaList = new List<KiralanmisSahaModel>();

                foreach (var item in liste)
                {
                    KiralanmisSahaModel ksm = new KiralanmisSahaModel();

                    ksm.KSID = item.KSID;
                    ksm.SahaTablo.SahaAdi = item.SahaTablo.SahaAdi;
                    ksm.SahaTablo.Telefon = item.SahaTablo.Telefon;
                    ksm.SahaTablo.Adres = item.SahaTablo.Adres;
                    ksm.SahaTablo.SahaID = item.SahaTablo.SahaID;
                    ksm.SaatBaslangic = item.SaatBaslangic;
                    ksm.KullaniciID = item.KullaniciID;
                    sahaList.Add(ksm);


                }
                return sahaList;

            }
        }

        public static KiralanmışSahaTablo KiralanmisSaha(int semtID, int sahaID, int macSaat)
        {
            using (HalıSahaEntities hs = new HalıSahaEntities())
            {
                var saha = hs.KiralanmışSahaTablo.Where(x => x.SemtID == semtID && x.SahaID == sahaID && x.SaatBaslangic == macSaat && x.KullaniciID == null).FirstOrDefault();
                return saha;

            }
        }

        public static List<KiralanmışSahaTablo> BütünSahalarinListesi()
        {
            using (HalıSahaEntities hs = new HalıSahaEntities())
            {
                var liste = hs.KiralanmışSahaTablo.ToList();
                return liste;

            }
        }

        public static KiralanmışSahaTablo KiralikSahaIdAl(int id)
        {
            using (HalıSahaEntities hs = new HalıSahaEntities())
            {
                var saha = hs.KiralanmışSahaTablo.Where(x => x.KSID == id).FirstOrDefault();
                return saha;
            }
        }

        public static List<KiralanmışSahaTablo> IdAlListeGetir(int sahaID)
        {
            using (HalıSahaEntities hs=new HalıSahaEntities())
            {
                var liste = hs.KiralanmışSahaTablo.Where(x => x.SahaID == sahaID).ToList();
                return liste;


            }
        }
    }

}

