using MVVMExample.Commands;
using MVVMExample.Models;
using MVVMExample.Repositories;
using MVVMExample.Views;
using MVVMExample.Views.UC;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MVVMExample.ViewModels
{
    public class AppViewModel:BaseViewModel
    {
        public WrapPanel MyGrid { get; set; }

        public FakeRepo PrinterRepository { get; set; }
        public ObservableCollection<Printer> Printers { get; set; }

        private Printer printer;

        public Printer Printer
        {
            get { return printer; }
            set { printer = value;OnPropertyChanged(); }
        }


        public RelayCommand AddCommand { get; set; }
        public RelayCommand SelectedCommand { get; set; }
        public RelayCommand EditCommand { get; set; }
        public RelayCommand AddUCCommand { get; set; }

        public AppViewModel()
        {

            AddUCCommand = new RelayCommand(o =>
              {
                  var uc = new SpecialUC();
                  uc.Margin=new Thickness(10,10,10,10);
                  MyGrid.Children.Add(uc);
              });



            PrinterRepository = new FakeRepo();
            Printers = new ObservableCollection<Printer>(PrinterRepository.GetAll());

            EditCommand = new RelayCommand(o =>
              {
                  EditViewModel editViewModel = new EditViewModel();
                  editViewModel.EditPrinter = Printer;

                  EditWindow editWindow = new EditWindow();

                  editViewModel.EditWindow = editWindow;

                  editWindow.DataContext = editViewModel;

                  editWindow.ShowDialog();


              }, (c) =>
              {
                  if (Printer == null) return false;
                  return true;
              });

            AddCommand = new RelayCommand(o =>
            {
                Printers.Add(new Printer { Color = "Black", Model = "SomeModel", Vendor = "SomeOne" });
                MessageBox.Show("Printer added successfully");
            });
            

            SelectedCommand = new RelayCommand(o =>
            {
                var printer=o as Printer;
                Printer=printer;
                //MessageBox.Show($"{printer.Model}  {printer.Vendor}");
            });

        }
    }
}
