using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace SystemOverview
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private string sitecorePath { get; set; }

        private string umbracoPath { get; set; }

        private string sitecoreTooltips { get; set; }

        private string umbracoTooltips { get; set; }

        private string cmsPath { get; set; }

        private string cmsTooltips { get; set; }

        private string DBFrontPath { get; set; }

        private string DBFrontTootips { get; set; }

        private string ECommercePath { get; set; }

        private string ECommerceTooltips { get; set; }

        private string ERPPath { get; set; }

        private string ERPTooltips { get; set; }

        private string PIMPath { get; set; }
        private string PIMTooltips { get; set; }

        public string mlPath { get; set; }

        public string mlTooltips { get; set; }


        public string sitecore1Path { get; set; }

        public string sitecore1Tooltips { get; set; }

        private void lbCMS_MouseUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Process.Start(cmsPath);
            }
            catch
            {
                MessageBox.Show("The system can not find the IIS on the system. Pls chek that the system have an IIS !", "We do not find any IIS on the system.", MessageBoxButton.OK, MessageBoxImage.Question);
            }
        }

        private void lbERP_MouseUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Process.Start(ERPPath);
            }
            catch
            {
                MessageBox.Show("The system can not find the ERP on the system. Pls chek that the system have an ERP !", "We do not find any ERP on the system.", MessageBoxButton.OK, MessageBoxImage.Question);
            }
        }


        private void imDBFront_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Process.Start(DBFrontPath);
            }
            catch
            {
                MessageBox.Show("The system can not find ssms on the system. Pls chek that the system have an ssms !", "We do not find any ssms on the system.", MessageBoxButton.OK, MessageBoxImage.Question);
            }
        }

        private void imERPDB_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Process.Start(DBFrontPath);
            }
            catch
            {
                MessageBox.Show("The system can not find ssms on the system. Pls chek that the system have an ssms !", "We do not find any ssms on the system.", MessageBoxButton.OK, MessageBoxImage.Question);
            }
        }

        private void imConnector_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Process.Start(ECommercePath);
            }
            catch
            {
                MessageBox.Show("The system can not find the connector on the system. Pls chek that the system have a connector !", "We do not find any connector on the system.", MessageBoxButton.OK, MessageBoxImage.Question);
            }
        }

        private void imPIM_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Process.Start(PIMPath);
            }
            catch
            {
                MessageBox.Show("The system can not find the PIM on the system. Pls chek that the system have a PIM installed !", "We do not find any PIM on the system.", MessageBoxButton.OK, MessageBoxImage.Question);
            }
        }

        private void imPIMERP_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                //string cmd = @"C:\Program Files (x86)\Microsoft Dynamics NAV\80\RoleTailored Client\finsql.exe";
                Process.Start(ERPPath);
            }
            catch
            {
                MessageBox.Show("The system can not find the PIM on the system. Pls chek that the system have a PIM installed !", "We do not find any PIM on the system.", MessageBoxButton.OK, MessageBoxImage.Question);
            }
        }

        private void image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                string cmd = @"http://evision.webtests.dk/";
                Process.Start(cmd);
            }
            catch
            {
                MessageBox.Show("The system can not find the Evision webtest on the system. Pls chek that the system have a Evision webtest installed !", "We do not find any Evision webtest on the system.", MessageBoxButton.OK, MessageBoxImage.Question);
            }
        }

        private void imML_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Process.Start(mlPath);
            }
            catch
            {
                MessageBox.Show("We can not find the folder in the system. Pls chek that the system have this Evision folder installed !", "We do not find this folder on the system.", MessageBoxButton.OK, MessageBoxImage.Question);
            }
        }

        private void imgUmbraco1_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Process.Start(umbracoPath);
            }
            catch
            {
                MessageBox.Show("The system can not find the homepage on the system. Pls chek that the system have a homepage installed !", "We do not find any homepage on the system.", MessageBoxButton.OK, MessageBoxImage.Question);
            }
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            // Hide the main window
            mainWindow.Hide();
            // Start the text dialog window to show some help for this program
            new StartUpWindow().ShowDialog();
            mainWindow.Show();

            sitecore1Path = ConfigurationManager.AppSettings["sitecore1Path"];
            sitecore1Tooltips = ConfigurationManager.AppSettings["sitecore1Tooltips"];

            if (sitecore1Path.Length > 2)
            {
                imSitecore1.Cursor = Cursors.Hand;
                imSitecore1.ToolTip = sitecore1Tooltips;
            }
            else
            {
                imSitecore1.ToolTip = null;
                imSitecore1.Cursor = null;
            }
            image.Cursor = imSitecore1.Cursor;
            image.ToolTip = imSitecore1.ToolTip;

            mlPath = ConfigurationManager.AppSettings["mlPath"];
            mlTooltips = ConfigurationManager.AppSettings["mlTooltips"];
            if (mlTooltips.Length > 2)
            {
                imML.ToolTip = mlTooltips;
            }
            else
            {
                imML.ToolTip = null;
            }
            image_Copy6.Cursor = imML.Cursor;
            image_Copy6.ToolTip = imML.ToolTip;

            cmsPath = ConfigurationManager.AppSettings["cmsPath"];
            cmsTooltips = ConfigurationManager.AppSettings["cmsTooltips"];
            if (cmsTooltips.Length > 2)
            {
                lbCMS.ToolTip = cmsTooltips;
            }
            else
            {
                lbCMS.ToolTip = null;
            }

            DBFrontPath = ConfigurationManager.AppSettings["DBFrontPath"];
            DBFrontTootips = ConfigurationManager.AppSettings["DBFrontTootips"];

            ECommercePath = ConfigurationManager.AppSettings["ECommercePath"];
            ECommerceTooltips = ConfigurationManager.AppSettings["ECommerceTooltips"];
            if (ECommerceTooltips.Length > 3)
            {
                imEcommerce.ToolTip = ECommerceTooltips;
                imEcommerce.Cursor = Cursors.Hand;
            }
            else
            {
                imEcommerce.ToolTip = null;
                imEcommerce.Cursor = Cursors.Arrow;
            }
            image_Copy1.Cursor = imEcommerce.Cursor;
            image_Copy1.ToolTip = imEcommerce.ToolTip;

            umbracoPath = ConfigurationManager.AppSettings["umbracoPath"];
            if (umbracoPath.Length > 2)
            {
                imgUmbraco1.Cursor = Cursors.Hand;
            }
            else
            {
                imgUmbraco1.Cursor = null;
            }

            umbracoTooltips = ConfigurationManager.AppSettings["umbracoTooltips"];
            if (umbracoTooltips.Length > 2)
            {
                imgUmbraco1.ToolTip = umbracoTooltips;
            }

            image_Copy.Cursor = imgUmbraco1.Cursor;
            image_Copy.ToolTip = imgUmbraco1.ToolTip;

            DBFrontPath = ConfigurationManager.AppSettings["DBFrontPath"];
            if (DBFrontPath.Length > 2)
            {
                imFrontDB.Cursor = Cursors.Hand;
            }
            else
            {
                imFrontDB.Cursor = null;
            }

            DBFrontTootips = ConfigurationManager.AppSettings["DBFrontTootips"];
            if (DBFrontTootips.Length > 2)
            {
                imFrontDB.ToolTip = DBFrontTootips;
            }
            else
            {
                imFrontDB.ToolTip = null;
            }
            image_Copy2.Cursor = imFrontDB.Cursor;
            image_Copy2.ToolTip = imFrontDB.ToolTip;

            ERPPath = ConfigurationManager.AppSettings["ERPPath"];

            ERPTooltips = ConfigurationManager.AppSettings["ERPTooltips"];
            if (ERPTooltips.Length > 2)
            {
                imERP.ToolTip = ERPTooltips;
                imERP.Cursor = Cursors.Hand;
            }
            else
            {
                imERP.ToolTip = null;
                imERP.Cursor = null;
            }
            image_Copy7.Cursor = imERP.Cursor;
            image_Copy7.ToolTip = imERP.ToolTip;

            PIMPath = ConfigurationManager.AppSettings["pimPath"];
            PIMTooltips = ConfigurationManager.AppSettings["pimTooltips"];

            if (PIMTooltips.Length > 2)
            {
                imPIM.ToolTip = PIMTooltips;
                imPIM.Cursor = Cursors.Hand;
            }
            else
            {
                imPIM.Cursor = null;
            }
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);

            Title = "System Overview version " + fvi.FileVersion + " : " + System.IO.File.GetLastWriteTime(Assembly.GetExecutingAssembly().Location);
        }

        private void imSitecore1_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Process.Start(sitecore1Path);
            }
            catch
            {
                MessageBox.Show("The demo website for Sitecore is not fund. Pls chek that the system have a demo Sitecore homepage installed !", "We do not find the Sitecore web demo on the system.", MessageBoxButton.OK, MessageBoxImage.Question);
            }
        }

        private void image_Copy4_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            // C:\Program Files (x86)\Evision\Evision.Econnector
            try
            {
                Process.Start(@"C:\Program Files (x86)\Evision\Evision.Econnector\");
            }
            catch
            {
                MessageBox.Show("This folder is not fund. Pls chek that the system have this the connector installed !", "We do not find the connector and there by this folder on the system.", MessageBoxButton.OK, MessageBoxImage.Question);
            }

        }
    }
}
