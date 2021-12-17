using OkulKitapligiADONET_BLL.ViewModels;
using OkulKitapligiADONET_DAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkulKitapligiADONET_BLL
{
    public class KitapOduncIslemManager
    {
        MyPocketDAL myPocketDAL = new MyPocketDAL("DESKTOP-HNE43R2", "OKULKITAPLIGI", "", "");

        public DataTable TumKitaplariGetir()
        {
            try
            {
                DataTable data = new DataTable();
                data = myPocketDAL.GetTheData("Kitaplar", "*", "SilindiMi=0");
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataTable TumOgrencileriGetir()
        {
            try
            {
                DataTable data = new DataTable();
                data = myPocketDAL.GetTheData("Ogrenciler", "OgrId, CONCAT(OgrAd, ' ' , OgrSoyad) as OgrenciAdSoyad, Cinsiyet, Sinif, DogumTarihi, SilindiMi", "SilindiMi=0");
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GrideVerileriGetir()
        {
            try
            {
                DataTable data = new DataTable();
                data = myPocketDAL.GetTheData("select i.IslemId, i.KitapId, CONCAT(o.OgrAd, ' ', o.OgrSoyad) as OgrenciAdSoyad, k.KitapAd,i.OduncAldigiTarihi,i.OduncBitisTarihi from Islem i inner join Kitaplar k on k.KitapId=i.KitapId inner join Ogrenciler o on o.OgrId=i.OgrId");

                return data;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<IslemViewModel> GrideVerileriViewModelleGetir()
        {
            List<IslemViewModel> data = new List<IslemViewModel>();

            try
            {
                DataTable theData = new DataTable();
                theData = myPocketDAL.GetTheData("select i.IslemId, k.KitapId, o.OgrId, CONCAT(o.OgrAd, ' ', o.OgrSoyad) as OgrenciAdSoyad, k.KitapAd, i.OduncAldigiTarihi, i.OduncBitisTarihi, i.TeslimEdildiMi from  Islem i inner join Kitaplar k on k.KitapId = i.KitapId inner join Ogrenciler o on o.OgrId = i.OgrId");

                //veriler dataTable ile geldi. Ama o verileri tek tek döngü ile dönerken içindeki verileri viewmodel'e aktaralım.

                for (int i = 0; i < theData.Rows.Count; i++)
                {
                    DataRow satir = theData.Rows[i];

                    IslemViewModel veri = new IslemViewModel()
                    {
                        IslemId = (int)theData.Rows[i].ItemArray[0],
                        KitapId = (int)theData.Rows[i].ItemArray[1],
                        OgrId = (int)theData.Rows[i].ItemArray[2],
                        OgrenciAdSoyad = theData.Rows[i].ItemArray[3].ToString(),
                        KitapAd = theData.Rows[i].ItemArray[4].ToString(),
                        OduncAldigiTarihi=Convert.ToDateTime(theData.Rows[i].ItemArray[5]),
                        OduncBitisTarihi=Convert.ToDateTime(theData.Rows[i].ItemArray[6]),
                        TeslimEdildiMi=(bool)theData.Rows[i].ItemArray[7]
                    };

                    //IslemViewModels tipindeki veri isimli nesne IslemViewModels tipine sahip listeye eklenecek.
                    data.Add(veri); //ekledik.


                }
            }
            catch (Exception ex)
            {

                throw ex;
            }


            return data;
        }

        public int KitabinStogunuGetir(int kitapId)
        {
            try
            {
                int stokAdeti = 0;

                object data = myPocketDAL.GetTheDataByExecuteScalar($"select Stok from Kitaplar where KitapId = {kitapId}");
                if (data != null)
                {
                    stokAdeti = Convert.ToInt32(data);
                }

                return stokAdeti;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool OduncKitapKaydiniYap(string tableName, Hashtable htVeri)
        {
            bool sonuc = false;
            try
            {
                //Stok Adedi
                object stokAdeti = myPocketDAL.GetTheDataByExecuteScalar("select Stok from Kitaplar where KitapId=" + htVeri["KitapId"].ToString());

                if (stokAdeti != null)
                {
                    //Stok azaltacağız.
                    stokAdeti = (int)stokAdeti - 1;
                    string updateCumlesi = "Update Kitaplar set Stok=" + stokAdeti + " where KitapId=" + htVeri["KitapId"];

                    //Ödünç
                    string insertCumlesi = myPocketDAL.CreateInsertQueryAsString(tableName, htVeri);

                    sonuc = myPocketDAL.ExecuteTheQueriesWithTransaction(insertCumlesi, updateCumlesi);


                }
                else
                {
                    throw new Exception("HATA : Stok adet bilgisi alımadığı için hata oluştu!");
                }



            }
            catch (Exception ex)
            {

                throw ex;
            }



            return sonuc;
        }

        public bool OduncKitapTeslimEt(string tableName, int islemId, int kitapId)
        {
            bool sonuc = false;
            try
            {
                //Stok
                object stokAdet = myPocketDAL.GetTheDataByExecuteScalar("select Stok from Kitaplar where KitapId=" + kitapId);
                if (stokAdet!=null)
                {
                    stokAdet = (int)stokAdet + 1;
                    string[] komutcumleleri = new string[2];
                    komutcumleleri[0] = "update Kitaplar Set Stok=" + stokAdet + " where KitapId=" + kitapId;

                    //CreateUpdateAsString isimli metodunu kullanmak amacıyla hashtable yapacağız.
                    //Kullanmak istemezsek 2.Komut cümlesini yukarıdaki gibi ekleyebiliriz.

                    //komutcumleleri[1] = "update Islem Set TeslimEdildiMi=1,OduncBitisTarihi='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' where IslemId=" + islemId;

                    Hashtable htVeri = new Hashtable();

                    string bitisTarihi = "'"
                        + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                        + "'";

                    htVeri.Add("TeslimEdildiMi", "1");
                    htVeri.Add("OduncBitisTarihi", bitisTarihi);
                    string kosulum = "IslemId=" + islemId;
                    komutcumleleri[1] = myPocketDAL.CreateUpdateQueryAsString("Islem", htVeri, kosulum);

                    sonuc = myPocketDAL.ExecuteTheQueriesWithTransaction(komutcumleleri);
                }

                else
                {
                    throw new Exception("HATA : Stok adeti çekilemediği için hata oluştu!");
                }

                return sonuc;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}