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
    public static class HelperOyuncu
    {

        public static bool OyuncuIslemleri(OyuncuTablo oyuncu, EntityState state)
        {
            using (HalıSahaEntities hs = new HalıSahaEntities())
            {
                hs.Entry(oyuncu).State = state;
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

        public static List<OyuncuModel> OyuncuListele()
        {
            using (HalıSahaEntities hs = new HalıSahaEntities())
            {
                List<OyuncuModel> oyuncuListesi = new List<OyuncuModel>();
                var liste = hs.OyuncuTablo.ToList();

                foreach (var item in liste)
                {
                    OyuncuModel om = new OyuncuModel();

                    om.OyuncuAdi = item.OyuncuAdi;
                    om.OyuncuSoyadi = item.OyuncuSoyadi;
                    om.OyuncuTelefon = item.OyuncuTelefon;
                    om.MevkiTablo.Mevki = item.MevkiTablo.Mevki;
                    om.OyuncuID = item.OyuncuID;
                    om.SahaTablo.SahaAdi = item.SahaTablo.SahaAdi;
                    oyuncuListesi.Add(om);
                }
                return oyuncuListesi;
            }
        }

        public static OyuncuTablo OyuncuIdAl(int oyuncuID)
        {
            using (HalıSahaEntities hs = new HalıSahaEntities())
            {
                var oyuncu = hs.OyuncuTablo.FirstOrDefault(x => x.OyuncuID == oyuncuID);
                return oyuncu;
            }
        }

        public static List<OyuncuTablo> OyuncuListele(int sahaID, int mevkiID)
        {
            using (HalıSahaEntities hs = new HalıSahaEntities())
            {
                List<OyuncuTablo> oyuncuList = hs.OyuncuTablo.Where(x => x.SahaID == sahaID && x.MevkiID == mevkiID && x.Durum == true && x.OyuncuSilmedurum == true).ToList();
                return oyuncuList;

            }
        }

        public static bool OyuncuDurumDüzenle(int oyuncuId, int macSaati, int kullaniciID)
        {
            using (HalıSahaEntities hs = new HalıSahaEntities())
            {
                var oyuncu = hs.OyuncuTablo.Where(x => x.OyuncuID == oyuncuId).FirstOrDefault();
                oyuncu.Durum = false;
                oyuncu.MacSaati = macSaati;
                oyuncu.KullaniciID = kullaniciID;
               
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

        public static List<OyuncuModel> OyuncuListele(int kullaniciID)
        {
            using (HalıSahaEntities hs = new HalıSahaEntities())
            {

                List<OyuncuModel> oyuncuList = new List<OyuncuModel>();
                var liste = hs.OyuncuTablo.Where(x => x.KullaniciID == kullaniciID).ToList();

                foreach (var item in liste)
                {
                    OyuncuModel om = new OyuncuModel();
                    om.OyuncuID = item.OyuncuID;
                    om.OyuncuAdi = item.OyuncuAdi;
                    om.OyuncuSoyadi = item.OyuncuSoyadi;
                    om.KullaniciID = kullaniciID;
                    om.MevkiTablo.Mevki = item.MevkiTablo.Mevki;
                    om.OyuncuTelefon = item.OyuncuTelefon;
                    om.SahaTablo.SahaAdi = item.SahaTablo.SahaAdi;
                    om.MacSaati = item.MacSaati;
                    om.Tarih = item.Tarih;
                    om.SahaTablo.SahaAdi = item.SahaTablo.SahaAdi;
                    oyuncuList.Add(om);

                }
                return oyuncuList;

            }

        }

        public static List<OyuncuTablo> GenelOyuncuListele()
        {
            using (HalıSahaEntities hs = new HalıSahaEntities())
            {
                var genelOyuncuList = hs.OyuncuTablo.ToList();
                return genelOyuncuList;

            }
        }

        public static List<OyuncuTablo> OyuncuListeler(int saat, int sahaID)
        {
            using (HalıSahaEntities hs = new HalıSahaEntities())
            {
                var liste = hs.OyuncuTablo.Where(x => x.MacSaati == saat && x.SahaID == sahaID).ToList();
                return liste;
            }
        }






    }
}
