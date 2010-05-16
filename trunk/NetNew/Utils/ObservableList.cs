using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Utils
{

    public class ObservableStringList:ObservableCollection<string>
    {
        PropertySetter setterMethod = null;

        public ObservableStringList(string arrayContent, string strPropertyName, object propertyOwner)
        {
            foreach (var item in Collection.ToStrArray(arrayContent))
            {
                this.Add(item);
            }
           this.setterMethod = (PropertySetter)Delegate.CreateDelegate(typeof(PropertySetter),
           propertyOwner, "set_"+strPropertyName);
            
            this.CollectionChanged +=new System.Collections.Specialized.NotifyCollectionChangedEventHandler(ObservableList_CollectionChanged);
        }

        void ObservableList_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {           
           setterMethod.Invoke(Collection.ToString<string>(this));
        }
        

    }

    public class ObservableIntList : ObservableCollection<int>
    {
        PropertySetter setterMethod = null;

        public ObservableIntList(string arrayContent, string strPropertyName, object propertyOwner)
        {
            foreach (var item in Collection.ToIntArray(arrayContent))
            {
                this.Add(item);
            }
            this.setterMethod = (PropertySetter)Delegate.CreateDelegate(typeof(PropertySetter),
            propertyOwner, "set_"+strPropertyName);

            this.CollectionChanged +=new System.Collections.Specialized.NotifyCollectionChangedEventHandler(ObservableList_CollectionChanged);
        }

        void ObservableList_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            setterMethod.Invoke(Collection.ToString<int>(this));
        }


    }

    public class ObservableShortList : ObservableCollection<short>
    {
        PropertySetter setterMethod = null;

        public ObservableShortList(string arrayContent, string strPropertyName, object propertyOwner)
        {
            foreach (var item in Collection.ToShortArray(arrayContent))
            {
                this.Add(item);
            }
            this.setterMethod = (PropertySetter)Delegate.CreateDelegate(typeof(PropertySetter),
            propertyOwner, "set_"+strPropertyName);

            this.CollectionChanged +=new System.Collections.Specialized.NotifyCollectionChangedEventHandler(ObservableList_CollectionChanged);
        }

        void ObservableList_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            setterMethod.Invoke(Collection.ToString<short>(this));
        }


    }

    public delegate void PropertySetter(string val);
}
