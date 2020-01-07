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
    public static class HelperSaha
    {

        public static bool SahaIslemleri(SahaTablo saha, EntityState state)
        {
            using (HalıSahaEntities hs = new HalıSahaEntities())
            {
                hs.Entry(saha).State = state;
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


        public static List<string> SahaListele()
        {
            using (HalıSahaEntities hs = new HalıSahaEntities())
            {
                List<string> sahaList = new List<string>();
                var liste = hs.SahaTablo.ToList();
                foreach (var item in liste)
                {
                    sahaList.Add(item.SahaAdi);
                }
                return sahaList;
            }
        }

        public static List<SahaTablo> SahaListelee(int semtID)
        {
            using (HalıSahaEntities hs = new HalıSahaEntities())
            {
                var liste = hs.SahaTablo.Where(x => x.SahaSilmeDurum == true && x.SemtID == semtID).ToList();

                return liste;

            }
        }
        public static List<SahaTablo> SahaListelee()
        {
            using (HalıSahaEntities hs = new HalıSahaEntities())
            {
                var liste = hs.SahaTablo.Where(x => x.SahaSilmeDurum == true).ToList();
                return liste;

            }
        }

        public static List<SahaModel> SahaModelList()
        {
            using (HalıSahaEntities hs = new HalıSahaEntities())
            {
                List<SahaModel> modelsahalistesi = new List<SahaModel>();
                var liste = hs.SahaTablo.Where(x => x.SahaSilmeDurum == true).ToList();

                foreach (var item in liste)
                {
                    SahaModel sm = new SahaModel();
                    sm.SahaID = item.SahaID;
                    sm.SahaAdi = item.SahaAdi;
                    sm.SemtTablo.SemtAdi = item.SemtTablo.SemtAdi;
                    sm.Telefon = item.Telefon;
                    sm.Adres = item.Adres;
                    modelsahalistesi.Add(sm);

                }
                return modelsahalistesi;
            }

        }

        public static SahaTablo SahaIdAl(int sahaID)
        {
            using (HalıSahaEntities hs = new HalıSahaEntities())
            {
                var saha = hs.SahaTablo.FirstOrDefault(x => x.SahaID == sahaID);
                return saha;
            }
        }

       


    }
}
