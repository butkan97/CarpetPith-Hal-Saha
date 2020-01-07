using HaliSaha.Entitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaliSaha.DAL
{
    public static class HelperSemt
    {

        public static List<string> SemtListele()
        {

            using (HalıSahaEntities hs = new HalıSahaEntities())
            {
                List<string> semtAdlariList = new List<string>();

                var liste = hs.SemtTablo.ToList();

                foreach (var item in liste)
                {
                    semtAdlariList.Add(item.SemtAdi);
                }
                return semtAdlariList;

            }
        }

        public static List<SemtTablo> Listeleee()
        {
            using (HalıSahaEntities hs = new HalıSahaEntities())
            {
                var liste = hs.SemtTablo.ToList();
                return liste;
            }
        }

        
        
    }
}
