using MVVMExample.Commands;
using MVVMExample.Models;
using MVVMExample.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMExample.ViewModels
{
    public class EditViewModel:BaseViewModel
    {

        public EditWindow EditWindow { get; set; }

        private Printer editPrinter;

        public Printer EditPrinter
        {
            get { return editPrinter; }
            set { editPrinter = value;OnPropertyChanged(); }
        }


        public RelayCommand SaveCommand { get; set; }


        public EditViewModel()
        {
            SaveCommand = new RelayCommand(o =>
              {
                  EditWindow.Close();
              });
        }

    }
}
