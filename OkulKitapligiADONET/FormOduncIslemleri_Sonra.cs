﻿using OkulKitapligiADONET_BLL;
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
    public partial class FormOduncIslemleri_Sonra : Form
    {
        public FormOduncIslemleri_Sonra()
        {
            InitializeComponent();
        }

        //GLOBAL ALAN
        KitapOduncIslemManager kitapOduncIslemManager = new KitapOduncIslemManager();

        private void FormOduncIslemleri_Load(object sender, EventArgs e)
        {
            //sayfa load olduğunda kitaplar yüklenecek,
            TumKitaplariUC_MyListBoxKitaplaraGetir();


            //sayfa load olduğunda listbox'a gelecek.

        }

        private void TumKitaplariUC_MyListBoxKitaplaraGetir()
        {

            

        }
    }
}
