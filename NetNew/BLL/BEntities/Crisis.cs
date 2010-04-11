using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace BLL.BEntities
{
    public class Crisis : DAL.Crisis
    {
        public ObservableCollection<string> LocationCoordinates = new ObservableCollection<string>();
    }
}
