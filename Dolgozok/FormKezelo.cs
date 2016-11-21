using System;

public class Class1
{
	public Class1()
	{

        public FormKezelo(Form peldanyF) {
            this.peldanyF = peldanyF;
        }

        Form peldanyF;

        public void AblakMegnyitasa() {
            peldanyF.Show();
        }
        public void AblakRejtese() {
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
