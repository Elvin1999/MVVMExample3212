using MVVMExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMExample.Repositories
{
    public class FakeRepo
    {

        public List<Printer> GetAll()
        {
            return new List<Printer>
            {
                new Printer{Color="Red",Model="R100",Vendor="Canon"},
                new Printer{Color="Blue",Model="L200",Vendor="HP"},
                new Printer{Color="SkyBlue",Model="M100",Vendor="Epson"},
                new Printer{Color="Indigo",Model="C202",Vendor="Varta"},
            };
        }


    }
}
