using Microsoft.Win32;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Windows;
using System.Xml;
using System.Xml.Schema;

namespace testovoe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string filenameXML = "";
        string schemaPath = Directory.GetCurrentDirectory() + "\\XSD.xsd";
        List<string> errors = new List<string>();

        int ips = 0;


        public MainWindow()
        {
            InitializeComponent();
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            btn_down.IsEnabled = false;
        }

        private void btn_xsd_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                filenameXML = openFileDialog.FileName;

                labelXcd.Text = "";
                ips = 0;
                btn_down.IsEnabled = false;
            }

            FileInfo f = new FileInfo(filenameXML);
            FileStream fs = f.OpenRead();

            // Закрыть файловый поток
            fs.Close();

           XmlSchemaSet sc = new XmlSchemaSet();

            sc.Add(null, schemaPath);

            XmlReaderSettings settings = new XmlReaderSettings();
            settings.ValidationType = ValidationType.Schema;
            settings.Schemas = sc;
            settings.ValidationEventHandler += new ValidationEventHandler(ValidationCallBack);

            XmlReader reader = XmlReader.Create(filenameXML, settings);

            while (reader.Read()) ;
            Simple();
        }


        private  void ValidationCallBack(object sender, ValidationEventArgs e)
        {
            ips = 1; 
        }


        private void Simple()
        {
            if (ips == 0)
            {
                labelXcd.Text = "Проверка достоверности документа завершена успешно.";
                btn_down.IsEnabled = true;
            }
            else
            {
                labelXcd.Text = "Документ не прошел проверку достоверности.";
                btn_down.IsEnabled = false;
            }
        }



        private ZL__LIST ZL__;
    
        private void btn_down_Click(object sender, RoutedEventArgs e)
        {
            ///  сериализируем данные
            ZL__LIST XMLSerializer = Serializer.ReadFromFile(filenameXML);

            PatientsManager manager = new PatientsManager();
            ZL__LIST newDate = new ZL__LIST();

            List<ZL__LIST> zL__s = new List<ZL__LIST>();
            zL__s.Add(XMLSerializer);

            foreach (var pat in zL__s)
            {
                ZL__ = new ZL__LIST();

                manager.InsertZGLV(pat.Num_zglv.Numversion, pat.Num_zglv.Data_Zglv, pat.Num_zglv.Filename, pat.Num_zglv.Year, pat.Num_zglv.Code_mo);
                ZL__.Num_event = pat.Num_event;
                manager.InsertPERS1(ZL__);
            }
        }

        private void btn_dow_Click(object sender, RoutedEventArgs e)
        {
            List<ZL__LIST> child;
            PatientsManager manager = new PatientsManager();

            child = manager.GetAll();
            processingGrid.ItemsSource = child;
        }

    }
}
