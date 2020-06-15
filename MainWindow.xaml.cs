using AutomatasFinitos.Procesos;
using System;
using System.Collections.Generic;
using System.Linq;
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
using Microsoft.Win32;
using System.ComponentModel;
using System.IO;

namespace AutomataWebEbay
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _ruta;
        public string Ruta
        { 
            get { return _ruta; }
             set
             {
                _ruta = value;
                OnPropertyChanged("Ruta");
             }
        }

        private string _texto;
        public string Texto
        {
            get { return _texto; }
            set
            {
                _texto = value;
                OnPropertyChanged("Texto");
            }
        }

        private uint _numWeb;
        public uint NumWeb
        {
            get { return _numWeb; }
            set
            {
                _numWeb = value;
                OnPropertyChanged("NumWeb");
            }
        }

        private uint _numEbay;
        public uint NumEbay
        {
            get { return _numEbay; }
            set
            {
                _numEbay = value;
                OnPropertyChanged("NumEbay");
            }
        }

        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        public MainWindow()
        {
            InitializeComponent();
            Ruta = "";
            Texto = "";
            NumWeb = 0;
            NumEbay = 0;
            DataContext = this;
        }

        private void Event_SelectFile(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.DefaultExt = ".txt";
            dlg.Filter = "Archivos de texto (*.txt)|*.txt";

            bool? result = dlg.ShowDialog();

            if(result == true)
            {
                Ruta = dlg.FileName;
                try
                {
                    var sr = new StreamReader(Ruta);
                    Texto = sr.ReadToEnd();
                }
                catch (IOException ex)
                {
                    MessageBox.Show($"Ha ocurrido un error leyendo el archivo\n{ex.Message}");
                    Texto = "";
                }

                var dict = EvaluarAutomata.Evaluar(Texto);

                if (dict.TryGetValue("web", out uint nweb))
                {
                    NumWeb = nweb;
                }
                else
                {
                    NumWeb = 0;
                }

                if (dict.TryGetValue("ebay", out uint nebay))
                {
                    NumEbay = nebay;
                }
                else
                {
                    NumEbay = 0;
                }
            }
        }
    }
}
