using System;
using System.IO;
using OfficeOpenXml;
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

namespace Save_And_Load_Program
{
    public partial class MainWindow : Window
    {
        //Namnet till CSV-filen där datan kommer att sparas
        private const string FileName = "G:/Min enhet/saveload/Data.csv";
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            //När "S" tryckes körs "SaveDataToCsv"
            if(e.Key == Key.S)
            {
                SaveDataToCsv();
            }
            //När "L" tryckes ner kommer istället "LoadDataFromCsv" att köras
            else if (e.Key == Key.L)
            {
                LoadDataFromCsv();
            }
        }

        private void SaveDataToCsv()
        {
            try
            {
                //Sparar datan till csv filen 
                using(StreamWriter writer = new StreamWriter(FileName))
                {
                    //i första cellen kommer name och age skrivas in
                    writer.WriteLine("Name, Age");
                    //i cellen under kommer den mer personliga datan att skrivas in, i detta fall Björne och 78
                    writer.WriteLine("Björne, 78");
                }
                //när datan är sparad poppar en ruta upp där det står data saved
                MessageBox.Show("Data Saved");
            }
            catch(Exception ex)
            {
                //ifall något fel händer kommer det komma upp en ruta där det står att något gått fel
                MessageBox.Show($"Error with saving data: {ex.Message}");
            }
        }

        private void LoadDataFromCsv()
        {
            try
            {
                //kollar om datafilen existerar
                if (!File.Exists(FileName))
                {
                    //om det inte finns en fil kommer felmeddelande komma upp
                    MessageBox.Show("No data file found");
                    return;
                }
                //läser datan från filen och separerar datan amed ett kommatecken
                using (StreamReader reader = new StreamReader(FileName))
                {
                    string headerLine = reader.ReadLine();
                    string dataLine = reader.ReadLine();
                    string[] dataValues = dataLine.Split(',');

                    string name = dataValues[0];
                    int age = int.Parse(dataValues[1]);

                    MessageBox.Show($"Name: {name}\nAge: {age}");
                }
            }

            catch (Exception ex)
            {
                //ifall något fel händer kommer det komma upp en ruta där det står att något gått fel
                MessageBox.Show($"Error loading the data: {ex.Message}");
            }    
        }
    }
}
