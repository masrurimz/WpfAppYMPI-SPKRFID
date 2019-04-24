using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using WpfAppYMPI_SPKRFID.Models;

namespace WpfAppYMPI_SPKRFID.ViewModels
{
    class PMViewModel : BindableBase
    {
        private PMModel pMModel;

        public PMViewModel()
        {
            pMModel = new PMModel();
            pMModel.Message = "This is Test";
        }

        public PMModel PMModel
        {
            get
            {
                return pMModel;
            }
            set
            {
                SetProperty(ref pMModel, value);
            }
        }
    }
}
