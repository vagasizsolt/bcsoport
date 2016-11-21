using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dolgozok
{
    class FormKezelo
    {
        public FormKezelo(Form peldanyF)
        {
            this.peldanyF = peldanyF;
        }

        Form peldanyF;

        public void AblakMegnyitasa()
        {
            peldanyF.Show();
        }
        public void AblakRejtese()
        {
            peldanyF.Hide();
        }
        public void AblakBezarasa()
        {
            peldanyF.Close();
        }

        //public void OsszesBezarasa() {

        ///*
        // konstansok.form1kezelo.close
        // * konst-.....
        // */
        //}
    }
}
