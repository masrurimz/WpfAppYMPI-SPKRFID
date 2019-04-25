using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using Prism.Commands;
using WpfAppYMPI_SPKRFID.Models;

namespace WpfAppYMPI_SPKRFID.ViewModels
{
    class SPKListViewModel : BindableBase
    {
        private SPKModel sPKModel;
        public SPKModel SPKModel
        {
            get { return sPKModel; }
            set { SetProperty(ref sPKModel, value); }
        }

        public SPKListViewModel()
        {
            sPKModel = SPKModel.Instance;
        }

    }
}
