using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Reflection;

namespace BLL.BEntities
{
    public class Crisis : DAL.Crisis
    {
        public ObservableCollection<string> LocationCoordinates = new ObservableCollection<string>();

        public Crisis()
        {
           
            
        }
        public Crisis(DAL.Crisis dataObject)
        {
            this.Update(dataObject);

        }
       
        public BLL.BEntities.Crisis Update(DAL.Crisis dataObject)
        {
            
            Type type = dataObject.GetType();
            while (type != null)
            {
                UpdateForType(type, dataObject, this);
                type = type.BaseType;
            }
            return this;
        }


        private static void UpdateForType(Type type, DAL.Crisis source, BLL.BEntities.Crisis destination)
        {
            FieldInfo[] myObjectFields = type.GetFields(
                BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);

            foreach (FieldInfo fi in myObjectFields)
            {
                fi.SetValue(destination, fi.GetValue(source));
            }
        }

        public Utils.Enumerations.CrisisStatuses Status
        {
            get
            {
                return Utils.Reflection.SafeConvertToEnum<Utils.Enumerations.CrisisStatuses>(StatusVal, Utils.Enumerations.CrisisStatuses.Active);
            }
            set
            {
                StatusVal = (Int16)value;
            }
        }
        public Utils.Enumerations.LocationTypes LocationType
        {
            get
            {
                return Utils.Reflection.SafeConvertToEnum<Utils.Enumerations.LocationTypes>(LocationTypeVal, Utils.Enumerations.LocationTypes.Rectangle);
            }
            set
            {
                LocationTypeVal = (Int16)value;
            }
        }
        
    }
}
