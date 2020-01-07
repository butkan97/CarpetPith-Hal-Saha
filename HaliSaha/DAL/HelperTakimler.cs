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
    public static class HelperTakimler
    {
        public static bool TakimIslemleri(TakımTablo takim, EntityState state)
        {
            using (HalıSahaEntities hs = new HalıSahaEntities())
            {
                hs.Entry(takim).State = state;
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

        public static List<TakimModel> TakimlariListele()
        {
            using (HalıSahaEntities hs = new HalıSahaEntities())
            {
                List<TakimModel> takimListesi = new List<TakimModel>();
                var liste = hs.TakımTablo.Where(x => x.TakımSilmedurum == true).ToList();

                foreach (var item in liste)
                {
                    TakimModel tm = new TakimModel();

                    tm.TakımAdı = item.TakımAdı;
                    tm.Telefon = item.Telefon;
                    tm.SemtTablo.SemtAdi = item.SemtTablo.SemtAdi;
                    tm.TakımID = item.TakımID;
                    tm.SahaTablo.SahaAdi = item.SahaTablo.SahaAdi;


                    takimListesi.Add(tm);

                }
                return takimListesi;


            }
        }

        public static TakımTablo TakimIdAlma(int takimID)
        {
            using (HalıSahaEntities hs = new HalıSahaEntities())
            {
                var takim = hs.TakımTablo.FirstOrDefault(x => x.TakımID == takimID);
                return takim;

            }
        }

        public static List<TakımTablo> TakimlariListele(int sahaID)
        {
            using (HalıSahaEntities hs = new HalıSahaEntities())
            {
                var takımList = hs.TakımTablo.Where(x => x.SahaID == sahaID && x.TakımDurum == true && x.TakımSilmedurum == true).ToList();

                return takımList;

            }
        }

        public static bool TakimDurumDüzenle(int takimID)
        {
            using (HalıSahaEntities hs = new HalıSahaEntities())
            {
                var takim = hs.TakımTablo.Where(x => x.TakımID == takimID).FirstOrDefault();

                takim.TakımDurum = false;
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

        public static bool TakimDurumDüzenle(int takimID, int macSaati, int kullaniciID)
        {
            using (HalıSahaEntities hs = new HalıSahaEntities())
            {
                var takim = hs.TakımTablo.Where(x => x.TakımID == takimID).FirstOrDefault();

                takim.TakımDurum = false;
                takim.MacSaati = macSaati;
                
                takim.KullaniciID = kullaniciID;
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

        public static List<TakimModel> TakimListele(int kullaniciID)
        {
            using (HalıSahaEntities hs = new HalıSahaEntities())
            {
                List<TakimModel> takimList = new List<TakimModel>();
                var liste = hs.TakımTablo.Where(x => x.KullaniciID == kullaniciID).ToList();

                foreach (var item in liste)
                {
                    TakimModel tm = new TakimModel();
                    tm.TakımID = item.TakımID;
                    tm.TakımAdı = item.TakımAdı;
                    tm.KullaniciID = kullaniciID;

                    tm.Telefon = item.Telefon;
                    tm.SemtTablo.SemtAdi = item.SemtTablo.SemtAdi;
                    tm.Tarih = item.Tarih;
                    tm.MacSaati = item.MacSaati;
                    takimList.Add(tm);
                }
                return takimList;


            }
        }

        public static List<TakımTablo> GenelTakımList()
        {
            using (HalıSahaEntities hs = new HalıSahaEntities())
            {
                var genelTakimList = hs.TakımTablo.ToList();
                return genelTakimList;
            }
        }

        public static List<TakımTablo> TakimlariListele( int saat, int sahaID)
        {
            using (HalıSahaEntities hs = new HalıSahaEntities())
            {
                var liste = hs.TakımTablo.Where(x => x.MacSaati == saat && x.SahaID == sahaID).ToList();
                return liste;


            }
        }



    }
}
