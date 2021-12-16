using OkulKitapligiADONET_BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OkulKitapligiADONET
{
    public partial class FormKitapOduncIslemleri : Form
    {
        public FormKitapOduncIslemleri()
        {
            InitializeComponent();
        }

        //GLOBAL ALAN
        KitapOduncIslemManager kitapOduncIslemManager = new KitapOduncIslemManager();

        private void FormKitapOduncIslemleri_Load(object sender, EventArgs e)
        {
            TumOgrencileriComboyaGetir();
            //
            OgrenciGroupBoxTemizle();
            KitapGroupBoxPasifYap();
            OduncTarihGroupBoxPasifYap();

            //datetimepicker ayarlarını burada yapalım.
            dateTimePickerBaslangic.Format = DateTimePickerFormat.Custom;
            dateTimePickerBaslangic.CustomFormat = "dd.MM.yyyy";
            dateTimePickerBaslangic.MinDate = new DateTime
                (DateTime.Now.Year, DateTime.Now.Month, 1);

            dateTimePickerBitis.Format = DateTimePickerFormat.Custom;
            dateTimePickerBitis.CustomFormat = "dd.MM.yyyy";
            dateTimePickerBitis.MinDate =
                dateTimePickerBaslangic.Value.AddDays(1);
            dateTimePickerBitis.MaxDate =
                dateTimePickerBaslangic.Value.AddMonths(3);

            //data gridi dolduralım.
            GridViewiAyarlaveDoldur();

            //
            UC_MyButtonOduncAl.myButton.Text = "ÖDÜNÇ AL";
            UC_MyButtonOduncAl.myButton.Click += new EventHandler(btn_OduncKitapAl);



        }

        private void btn_OduncKitapAl(object sender, EventArgs e)
        {
            try
            {
                bool kontrol = false;
                //tarihleri kontrol et
                if (dateTimePickerBitis.Value < dateTimePickerBaslangic.Value)
                {
                    MessageBox.Show("HATA: Tarih bilgilerinde yanlış giriş yaptınız!");
                }
                else
                {
                    if (comboBoxOgrenci.SelectedIndex > -1)
                    {
                        if (comboBoxKitap.SelectedIndex > -1)
                        {
                            //Kitap stoğu var mı?
                            kontrol =
                                kitapOduncIslemManager.KitabinStogunuGetir((int)comboBoxKitap.SelectedValue) == 0 ? false : true;
                        }
                        else
                        {
                            MessageBox.Show("HATA: Kitap seçmeden işlem yapılamaz!");
                            //temizlik
                        }
                    }
                    else
                    {
                        MessageBox.Show("HATA: Öğrenci seçmeden işlem yapılamaz!");
                        //temizlik
                    }
                }


                if (kontrol)
                {
                    MessageBox.Show("INSERT İLE EKLEME YAPILACAK.");
                }

                else
                {
                    MessageBox.Show("HATA : Kitap stokta bulunmamaktadır. Ödünç alma geçersiz!");
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Beklenmedik hata oluştu!" + ex.Message);
            }

        }

        private void GridViewiAyarlaveDoldur()
        {
            dataGridViewOduncKitaplar.MultiSelect = false;
            dataGridViewOduncKitaplar.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dataGridViewOduncKitaplar.DataSource =
                kitapOduncIslemManager.GrideVerileriGetir();

            dataGridViewOduncKitaplar.Columns["IslemId"].Visible = false;

            //datagrid view düzenlensin.....

        }

        private void TumKitaplariComboyaGetir()
        {
            comboBoxKitap.DisplayMember = "KitapAd";
            comboBoxKitap.ValueMember = "KitapId";
            comboBoxKitap.DataSource =
            kitapOduncIslemManager.TumKitaplariGetir();
        }

        private void TumOgrencileriComboyaGetir()
        {
            comboBoxOgrenci.DisplayMember = "OgrenciAdSoyad";
            comboBoxOgrenci.ValueMember = "OgrId";
            comboBoxOgrenci.DataSource =
            kitapOduncIslemManager.TumOgrencileriGetir();
        }

        private void OgrenciGroupBoxTemizle()
        {
            comboBoxOgrenci.SelectedIndex = -1;
        }

        private void KitapGroupBoxPasifYap()
        {
            comboBoxKitap.SelectedIndex = -1;
            groupBoxKitap.Enabled = false;
        }
        private void OduncTarihGroupBoxPasifYap()
        {
            dateTimePickerBaslangic.Value = DateTime.Now;
            dateTimePickerBitis.Value = DateTime.Now.AddDays(1);
            groupBoxOduncTarihler.Enabled = false;
        }
        private void OduncTarihGroupBoxAktifYap()
        {
            dateTimePickerBaslangic.Value = DateTime.Now;
            dateTimePickerBitis.Value = DateTime.Now.AddDays(1);
            groupBoxOduncTarihler.Enabled = true;
        }

        private void comboBoxOgrenci_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxOgrenci.SelectedIndex > -1)
            {
                //Aktif??
                KitapGroupBoxAktifYap();
                TumKitaplariComboyaGetir();
                comboBoxKitap.SelectedIndex = -1;

            }
        }
        private void KitapGroupBoxAktifYap()
        {
            groupBoxKitap.Enabled = true;
        }

        private void comboBoxKitap_SelectedIndexChanged(object sender, EventArgs e)
        {
            //groupbox tarih alanı aktifleşecek.
            if (comboBoxKitap.SelectedIndex > -1)
            {
                OduncTarihGroupBoxAktifYap();
            }

            else
            {
                OduncTarihGroupBoxPasifYap();
            }
        }

        private void dateTimePickerBaslangic_ValueChanged(object sender, EventArgs e)
        {
            //Burada seçilecek tarih, dateTimePickerBitis'i etkilesin.
            dateTimePickerBitis.MinDate =
                dateTimePickerBaslangic.Value.AddDays(1);

            dateTimePickerBitis.Value =
                dateTimePickerBaslangic.Value.AddDays(1);

            dateTimePickerBitis.MaxDate =
                dateTimePickerBaslangic.Value.AddMonths(3);


        }
    }
}
