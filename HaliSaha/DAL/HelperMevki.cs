using HaliSaha.Entitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaliSaha.DAL
{
    public static class HelperMevki
    {
        public static List<string> MevkiListele()
        {
            using (HalıSahaEntities hs = new HalıSahaEntities())
            {
                List<string> mevkiAdlari = new List<string>();
                var mevkiList = hs.MevkiTablo.ToList();
                foreach (var item in mevkiList)
                {
                    mevkiAdlari.Add(item.Mevki);
                }

                return mevkiAdlari;

            }
        }

        public static List<MevkiTablo> MevkiListelee()
        {
            using (HalıSahaEntities hs = new HalıSahaEntities())
            {
                var liste = hs.MevkiTablo.ToList();
                return liste;
            }
        }
    }
}
