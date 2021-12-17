using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkulKitapligiADONET_BLL.ViewModels
{
    public class IslemViewModel
    {
        public string OgrenciAdSoyad { get; set; }
        public string KitapAd { get; set; }

        public int IslemId { get; set; }
        public int KitapId { get; set; }
        public int OgrId { get; set; }
        public DateTime OduncAldigiTarihi { get; set; }
        public DateTime OduncBitisTarihi { get; set; }

        public bool TeslimEdildiMi { get; set; }

        private string _teslimEdildiMiString = "";


        public string TeslimEdildiMiString
        {
            get
            {
                if (this.TeslimEdildiMi)
                {
                    _teslimEdildiMiString = "EVET";
                }
                
                else
                {
                    _teslimEdildiMiString = "HAYIR";
                }

                return _teslimEdildiMiString;
            }
        }

    }
}
