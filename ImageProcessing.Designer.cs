namespace ImageProcessing
{
    partial class ImageProcessing
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.MainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.menuItemFile = new System.Windows.Forms.MenuItem();
            this.menuItemOpen = new System.Windows.Forms.MenuItem();
            this.menuItemSave = new System.Windows.Forms.MenuItem();
            this.menuItemSep1 = new System.Windows.Forms.MenuItem();
            this.menuItemExit = new System.Windows.Forms.MenuItem();
            this.menuItemEdit = new System.Windows.Forms.MenuItem();
            this.menuItemUndo = new System.Windows.Forms.MenuItem();
            this.menuItemClearImage = new System.Windows.Forms.MenuItem();
            this.menuItemColor = new System.Windows.Forms.MenuItem();
            this.menuItemSetColor = new System.Windows.Forms.MenuItem();
            this.menuItemGamma = new System.Windows.Forms.MenuItem();
            this.menuItemBrightness = new System.Windows.Forms.MenuItem();
            this.menuItemContrast = new System.Windows.Forms.MenuItem();
            this.menuItemGrayscale = new System.Windows.Forms.MenuItem();
            this.menuItemInvert = new System.Windows.Forms.MenuItem();
            this.powerConstrast = new System.Windows.Forms.MenuItem();
            this.menuItemImage = new System.Windows.Forms.MenuItem();
            this.menuItemResize = new System.Windows.Forms.MenuItem();
            this.menuItemRotateFlip = new System.Windows.Forms.MenuItem();
            this.menuItemRotate90 = new System.Windows.Forms.MenuItem();
            this.menuItemRotate180 = new System.Windows.Forms.MenuItem();
            this.menuItemRotate270 = new System.Windows.Forms.MenuItem();
            this.menuItemSep3 = new System.Windows.Forms.MenuItem();
            this.menuItemFlipH = new System.Windows.Forms.MenuItem();
            this.menuItemFlipV = new System.Windows.Forms.MenuItem();
            this.menuItemCrop = new System.Windows.Forms.MenuItem();
            this.histMenu = new System.Windows.Forms.MenuItem();
            this.skalowanieHist = new System.Windows.Forms.MenuItem();
            this.obroc = new System.Windows.Forms.MenuItem();
            this.rozmycie = new System.Windows.Forms.MenuItem();
            this.pochylenie = new System.Windows.Forms.MenuItem();
            this.binary = new System.Windows.Forms.MenuItem();
            this.bicubic = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.RobertsPoziom = new System.Windows.Forms.MenuItem();
            this.RobertsPion = new System.Windows.Forms.MenuItem();
            this.PrewittPoziom = new System.Windows.Forms.MenuItem();
            this.PrewittPion = new System.Windows.Forms.MenuItem();
            this.SobelPoziom = new System.Windows.Forms.MenuItem();
            this.SobelPion = new System.Windows.Forms.MenuItem();
            this.Laplace = new System.Windows.Forms.MenuItem();
            this.LaplaceFirst = new System.Windows.Forms.MenuItem();
            this.LaplaceSecond = new System.Windows.Forms.MenuItem();
            this.LaplaceThird = new System.Windows.Forms.MenuItem();
            this.LaplaceSharp = new System.Windows.Forms.MenuItem();
            this.StatMin = new System.Windows.Forms.MenuItem();
            this.StatMax = new System.Windows.Forms.MenuItem();
            this.Median = new System.Windows.Forms.MenuItem();
            this.medianowyN1 = new System.Windows.Forms.MenuItem();
            this.MedianowyN2 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.inicjalyBezier = new System.Windows.Forms.MenuItem();
            this.platyBezier = new System.Windows.Forms.MenuItem();
            this.SuspendLayout();
            // 
            // MainMenu1
            // 
            this.MainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemFile,
            this.menuItemEdit,
            this.menuItemColor,
            this.menuItemImage,
            this.histMenu,
            this.menuItem1});
            // 
            // menuItemFile
            // 
            this.menuItemFile.Index = 0;
            this.menuItemFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemOpen,
            this.menuItemSave,
            this.menuItemSep1,
            this.menuItemExit});
            this.menuItemFile.Text = "&File";
            // 
            // menuItemOpen
            // 
            this.menuItemOpen.Index = 0;
            this.menuItemOpen.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
            this.menuItemOpen.Text = "&Open";
            this.menuItemOpen.Click += new System.EventHandler(this.menuItemOpen_Click);
            // 
            // menuItemSave
            // 
            this.menuItemSave.Index = 1;
            this.menuItemSave.Shortcut = System.Windows.Forms.Shortcut.CtrlS;
            this.menuItemSave.Text = "&Save";
            this.menuItemSave.Click += new System.EventHandler(this.menuItemSave_Click);
            // 
            // menuItemSep1
            // 
            this.menuItemSep1.Index = 2;
            this.menuItemSep1.Text = "-";
            // 
            // menuItemExit
            // 
            this.menuItemExit.Index = 3;
            this.menuItemExit.Text = "E&xit";
            this.menuItemExit.Click += new System.EventHandler(this.menuItemExit_Click);
            // 
            // menuItemEdit
            // 
            this.menuItemEdit.Index = 1;
            this.menuItemEdit.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemUndo,
            this.menuItemClearImage});
            this.menuItemEdit.Text = "&Edit";
            // 
            // menuItemUndo
            // 
            this.menuItemUndo.Index = 0;
            this.menuItemUndo.Shortcut = System.Windows.Forms.Shortcut.CtrlZ;
            this.menuItemUndo.Text = "&Undo";
            this.menuItemUndo.Click += new System.EventHandler(this.menuItemUndo_Click);
            // 
            // menuItemClearImage
            // 
            this.menuItemClearImage.Index = 1;
            this.menuItemClearImage.Text = "C&lear Image";
            this.menuItemClearImage.Click += new System.EventHandler(this.menuItemClearImage_Click);
            // 
            // menuItemColor
            // 
            this.menuItemColor.Index = 2;
            this.menuItemColor.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemSetColor,
            this.menuItemGamma,
            this.menuItemBrightness,
            this.menuItemContrast,
            this.menuItemGrayscale,
            this.menuItemInvert,
            this.powerConstrast});
            this.menuItemColor.Text = "&Color";
            // 
            // menuItemSetColor
            // 
            this.menuItemSetColor.Index = 0;
            this.menuItemSetColor.Text = "&Set Color";
            this.menuItemSetColor.Click += new System.EventHandler(this.menuItemSetColor_Click);
            // 
            // menuItemGamma
            // 
            this.menuItemGamma.Index = 1;
            this.menuItemGamma.Text = "&Gamma";
            this.menuItemGamma.Click += new System.EventHandler(this.menuItemGamma_Click);
            // 
            // menuItemBrightness
            // 
            this.menuItemBrightness.Index = 2;
            this.menuItemBrightness.Text = "&Brightness";
            this.menuItemBrightness.Click += new System.EventHandler(this.menuItemBrightness_Click);
            // 
            // menuItemContrast
            // 
            this.menuItemContrast.Index = 3;
            this.menuItemContrast.Text = "Con&trast";
            this.menuItemContrast.Click += new System.EventHandler(this.menuItemContrast_Click);
            // 
            // menuItemGrayscale
            // 
            this.menuItemGrayscale.Index = 4;
            this.menuItemGrayscale.Text = "&Grayscale";
            this.menuItemGrayscale.Click += new System.EventHandler(this.menuItemGrayscale_Click);
            // 
            // menuItemInvert
            // 
            this.menuItemInvert.Index = 5;
            this.menuItemInvert.Text = "&Invert";
            this.menuItemInvert.Click += new System.EventHandler(this.menuItemInvert_Click);
            // 
            // powerConstrast
            // 
            this.powerConstrast.Index = 6;
            this.powerConstrast.Text = "Power Constrast";
            this.powerConstrast.Click += new System.EventHandler(this.powerConstrast_Click);
            // 
            // menuItemImage
            // 
            this.menuItemImage.Index = 3;
            this.menuItemImage.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemResize,
            this.menuItemRotateFlip,
            this.menuItemCrop});
            this.menuItemImage.Text = "&Image";
            // 
            // menuItemResize
            // 
            this.menuItemResize.Index = 0;
            this.menuItemResize.Text = "&Resize";
            this.menuItemResize.Click += new System.EventHandler(this.menuItemResize_Click);
            // 
            // menuItemRotateFlip
            // 
            this.menuItemRotateFlip.Index = 1;
            this.menuItemRotateFlip.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemRotate90,
            this.menuItemRotate180,
            this.menuItemRotate270,
            this.menuItemSep3,
            this.menuItemFlipH,
            this.menuItemFlipV});
            this.menuItemRotateFlip.Text = "Ro&tate && Flip";
            // 
            // menuItemRotate90
            // 
            this.menuItemRotate90.Index = 0;
            this.menuItemRotate90.Text = "Rotate &90";
            this.menuItemRotate90.Click += new System.EventHandler(this.menuItemRotate90_Click);
            // 
            // menuItemRotate180
            // 
            this.menuItemRotate180.Index = 1;
            this.menuItemRotate180.Text = "Rotate &180";
            this.menuItemRotate180.Click += new System.EventHandler(this.menuItemRotate180_Click);
            // 
            // menuItemRotate270
            // 
            this.menuItemRotate270.Index = 2;
            this.menuItemRotate270.Text = "Rotate &270";
            this.menuItemRotate270.Click += new System.EventHandler(this.menuItemRotate270_Click);
            // 
            // menuItemSep3
            // 
            this.menuItemSep3.Index = 3;
            this.menuItemSep3.Text = "-";
            // 
            // menuItemFlipH
            // 
            this.menuItemFlipH.Index = 4;
            this.menuItemFlipH.Text = "Flip &Horizontal";
            this.menuItemFlipH.Click += new System.EventHandler(this.menuItemFlipH_Click);
            // 
            // menuItemFlipV
            // 
            this.menuItemFlipV.Index = 5;
            this.menuItemFlipV.Text = "Flip &Vertical";
            this.menuItemFlipV.Click += new System.EventHandler(this.menuItemFlipV_Click);
            // 
            // menuItemCrop
            // 
            this.menuItemCrop.Index = 2;
            this.menuItemCrop.Text = "Cro&p";
            this.menuItemCrop.Click += new System.EventHandler(this.menuItemCrop_Click);
            // 
            // histMenu
            // 
            this.histMenu.Index = 4;
            this.histMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.skalowanieHist,
            this.obroc,
            this.rozmycie,
            this.pochylenie,
            this.binary,
            this.bicubic});
            this.histMenu.Text = "Histogram";
            this.histMenu.Click += new System.EventHandler(this.binary_Click);
            // 
            // skalowanieHist
            // 
            this.skalowanieHist.Index = 0;
            this.skalowanieHist.Text = "Skalowanie";
            this.skalowanieHist.Click += new System.EventHandler(this.skalowanieHist_Click);
            // 
            // obroc
            // 
            this.obroc.Index = 1;
            this.obroc.Text = "Obracanie";
            this.obroc.Click += new System.EventHandler(this.obroc_Click);
            // 
            // rozmycie
            // 
            this.rozmycie.Index = 2;
            this.rozmycie.Text = "Filtr rozmywajacy";
            this.rozmycie.Click += new System.EventHandler(this.rozmycie_Click);
            // 
            // pochylenie
            // 
            this.pochylenie.Index = 3;
            this.pochylenie.Text = "Pochylenie";
            this.pochylenie.Click += new System.EventHandler(this.pochylenie_Click);
            // 
            // binary
            // 
            this.binary.Index = 4;
            this.binary.Text = "Binarne";
            this.binary.Click += new System.EventHandler(this.binary_Click);
            // 
            // bicubic
            // 
            this.bicubic.Index = 5;
            this.bicubic.Text = "Bikubiczne";
            this.bicubic.Click += new System.EventHandler(this.bicubic_Click);
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 5;
            this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.RobertsPoziom,
            this.RobertsPion,
            this.PrewittPoziom,
            this.PrewittPion,
            this.SobelPoziom,
            this.SobelPion,
            this.Laplace,
            this.LaplaceSharp,
            this.StatMin,
            this.StatMax,
            this.Median,
            this.menuItem2,
            this.inicjalyBezier,
            this.platyBezier});
            this.menuItem1.Text = "Filtry";
            // 
            // RobertsPoziom
            // 
            this.RobertsPoziom.Index = 0;
            this.RobertsPoziom.Text = "Roberts poziomy";
            this.RobertsPoziom.Click += new System.EventHandler(this.RobertsPoziom_Click);
            // 
            // RobertsPion
            // 
            this.RobertsPion.Index = 1;
            this.RobertsPion.Text = "Roberts pionowy";
            this.RobertsPion.Click += new System.EventHandler(this.RobertsPion_Click);
            // 
            // PrewittPoziom
            // 
            this.PrewittPoziom.Index = 2;
            this.PrewittPoziom.Text = "Prewitt poziomy";
            this.PrewittPoziom.Click += new System.EventHandler(this.PrewittPoziom_Click);
            // 
            // PrewittPion
            // 
            this.PrewittPion.Index = 3;
            this.PrewittPion.Text = "Prewitt pionowy";
            this.PrewittPion.Click += new System.EventHandler(this.PrewittPion_Click);
            // 
            // SobelPoziom
            // 
            this.SobelPoziom.Index = 4;
            this.SobelPoziom.Text = "Sobel poziomy";
            this.SobelPoziom.Click += new System.EventHandler(this.SobelPoziom_Click);
            // 
            // SobelPion
            // 
            this.SobelPion.Index = 5;
            this.SobelPion.Text = "Sobel pionowy";
            this.SobelPion.Click += new System.EventHandler(this.SobelPion_Click);
            // 
            // Laplace
            // 
            this.Laplace.Index = 6;
            this.Laplace.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.LaplaceFirst,
            this.LaplaceSecond,
            this.LaplaceThird});
            this.Laplace.Text = "Laplace";
            // 
            // LaplaceFirst
            // 
            this.LaplaceFirst.Index = 0;
            this.LaplaceFirst.Text = "Pierwszy";
            this.LaplaceFirst.Click += new System.EventHandler(this.LaplaceFirst_Click);
            // 
            // LaplaceSecond
            // 
            this.LaplaceSecond.Index = 1;
            this.LaplaceSecond.Text = "Drugi";
            this.LaplaceSecond.Click += new System.EventHandler(this.LaplaceSecond_Click);
            // 
            // LaplaceThird
            // 
            this.LaplaceThird.Index = 2;
            this.LaplaceThird.Text = "Trzeci";
            this.LaplaceThird.Click += new System.EventHandler(this.LaplaceThird_Click);
            // 
            // LaplaceSharp
            // 
            this.LaplaceSharp.Index = 7;
            this.LaplaceSharp.Text = "Wyostrzanie Laplace";
            this.LaplaceSharp.Click += new System.EventHandler(this.LaplaceSharp_Click);
            // 
            // StatMin
            // 
            this.StatMin.Index = 8;
            this.StatMin.Text = "Statystyczny min";
            this.StatMin.Click += new System.EventHandler(this.StatMin_Click);
            // 
            // StatMax
            // 
            this.StatMax.Index = 9;
            this.StatMax.Text = "Statystyczny max";
            this.StatMax.Click += new System.EventHandler(this.StatMax_Click);
            // 
            // Median
            // 
            this.Median.Index = 10;
            this.Median.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.medianowyN1,
            this.MedianowyN2});
            this.Median.Text = "Medianowy";
            // 
            // medianowyN1
            // 
            this.medianowyN1.Index = 0;
            this.medianowyN1.Text = "n=1";
            this.medianowyN1.Click += new System.EventHandler(this.MedianowyN1_Click);
            // 
            // MedianowyN2
            // 
            this.MedianowyN2.Index = 1;
            this.MedianowyN2.Text = "n=2";
            this.MedianowyN2.Click += new System.EventHandler(this.MedianowyN2_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 11;
            this.menuItem2.Text = "-";
            // 
            // inicjalyBezier
            // 
            this.inicjalyBezier.Index = 12;
            this.inicjalyBezier.Text = "Inicja³y Bezier";
            this.inicjalyBezier.Click += new System.EventHandler(this.InicjalyBezier_Click);
            // 
            // platyBezier
            // 
            this.platyBezier.Index = 13;
            this.platyBezier.Text = "Platy Bezier";
            this.platyBezier.Click += new System.EventHandler(this.platyBezier_Click);
            // 
            // ImageProcessing
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(764, 509);
            this.DoubleBuffered = true;
            this.Menu = this.MainMenu1;
            this.Name = "ImageProcessing";
            this.Text = "Image Processing";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ImageProcessing_Paint);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MainMenu MainMenu1;
        private System.Windows.Forms.MenuItem menuItemFile;
        private System.Windows.Forms.MenuItem menuItemOpen;
        private System.Windows.Forms.MenuItem menuItemSave;
        private System.Windows.Forms.MenuItem menuItemSep1;
        private System.Windows.Forms.MenuItem menuItemExit;
        private System.Windows.Forms.MenuItem menuItemEdit;
        private System.Windows.Forms.MenuItem menuItemUndo;
        private System.Windows.Forms.MenuItem menuItemClearImage;
        private System.Windows.Forms.MenuItem menuItemColor;
        private System.Windows.Forms.MenuItem menuItemSetColor;
        private System.Windows.Forms.MenuItem menuItemGamma;
        private System.Windows.Forms.MenuItem menuItemBrightness;
        private System.Windows.Forms.MenuItem menuItemContrast;
        private System.Windows.Forms.MenuItem menuItemGrayscale;
        private System.Windows.Forms.MenuItem menuItemInvert;
        private System.Windows.Forms.MenuItem menuItemImage;
        private System.Windows.Forms.MenuItem menuItemResize;
        private System.Windows.Forms.MenuItem menuItemRotateFlip;
        private System.Windows.Forms.MenuItem menuItemRotate90;
        private System.Windows.Forms.MenuItem menuItemRotate180;
        private System.Windows.Forms.MenuItem menuItemRotate270;
        private System.Windows.Forms.MenuItem menuItemSep3;
        private System.Windows.Forms.MenuItem menuItemFlipH;
        private System.Windows.Forms.MenuItem menuItemFlipV;
        private System.Windows.Forms.MenuItem menuItemCrop;
        private System.Windows.Forms.MenuItem powerConstrast;
        private System.Windows.Forms.MenuItem histMenu;
        private System.Windows.Forms.MenuItem skalowanieHist;
        private System.Windows.Forms.MenuItem obroc;
        private System.Windows.Forms.MenuItem rozmycie;
        private System.Windows.Forms.MenuItem pochylenie;
        private System.Windows.Forms.MenuItem binary;
        private System.Windows.Forms.MenuItem bicubic;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem RobertsPoziom;
        private System.Windows.Forms.MenuItem RobertsPion;
        private System.Windows.Forms.MenuItem PrewittPoziom;
        private System.Windows.Forms.MenuItem PrewittPion;
        private System.Windows.Forms.MenuItem SobelPoziom;
        private System.Windows.Forms.MenuItem SobelPion;
        private System.Windows.Forms.MenuItem Laplace;
        private System.Windows.Forms.MenuItem LaplaceSharp;
        private System.Windows.Forms.MenuItem StatMin;
        private System.Windows.Forms.MenuItem StatMax;
        private System.Windows.Forms.MenuItem Median;
        private System.Windows.Forms.MenuItem LaplaceFirst;
        private System.Windows.Forms.MenuItem LaplaceSecond;
        private System.Windows.Forms.MenuItem LaplaceThird;
        private System.Windows.Forms.MenuItem medianowyN1;
        private System.Windows.Forms.MenuItem MedianowyN2;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem inicjalyBezier;
        private System.Windows.Forms.MenuItem platyBezier;
    }
}

