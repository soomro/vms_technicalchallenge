//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.Serialization;
using VMSCORE.Util;

namespace VMSCORE.EntityClasses
{
    [DataContract(IsReference = true)]
    [KnownType(typeof(Alert))]
    [KnownType(typeof(Incident))]
    public partial class Crisis: IObjectWithChangeTracker, INotifyPropertyChanged
    {
        #region Primitive Properties
    
        [DataMember]
        public int Id
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    if (ChangeTracker.ChangeTrackingEnabled && ChangeTracker.State != ObjectState.Added)
                    {
                        throw new InvalidOperationException("The property 'Id' is part of the object's key and cannot be changed. Changes to key properties can only be made when the object is not being tracked or is in the Added state.");
                    }
                    _id = value;
                    OnPropertyChanged("Id");
                }
            }
        }
        private int _id;
    
        [DataMember]
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged("Name");
                }
            }
        }
        private string _name;
    
        [DataMember]
        public string Explanation
        {
            get { return _explanation; }
            set
            {
                if (_explanation != value)
                {
                    _explanation = value;
                    OnPropertyChanged("Explanation");
                }
            }
        }
        private string _explanation;
    
        [DataMember]
        private short StatusVal
        {
            get { return _statusVal; }
            set
            {
                if (_statusVal != value)
                {
                    _statusVal = value;
                    OnPropertyChanged("StatusVal");
                }
            }
        }
        private short _statusVal;
        public EnumCrisisStatus Status
        {
            get
            {
                return Util.ReflectionUtil.SafeConvertToEnum<EnumCrisisStatus>(StatusVal, EnumCrisisStatus.Active);
            }
            set
            {
                StatusVal = (Int16)value;
            }
        }

        [DataMember]
        private short CrisisTypeVal
        {
            get { return _crisisTypeVal; }
            set
            {
                if (_crisisTypeVal != value)
                {
                    _crisisTypeVal = value;
                    OnPropertyChanged("CrisisTypeVal");
                }
            }
        }
        private short _crisisTypeVal;
        public EnumCrisisType Statusx
        {
            get
            {
                return Util.ReflectionUtil.SafeConvertToEnum<EnumCrisisType>(CrisisTypeVal, EnumCrisisType.Earthquake);
            }
            set
            {
                CrisisTypeVal = (Int16)value;
            }
        }

        [DataMember]
        private short LocationTypeVal
        {
            get { return _locationTypeVal; }
            set
            {
                if (_locationTypeVal != value)
                {
                    _locationTypeVal = value;
                    OnPropertyChanged("LocationTypeVal");
                }
            }
        }
        private short _locationTypeVal;
        public EnumLocationType CrisisType
        {
            get
            {
                return Util.ReflectionUtil.SafeConvertToEnum<EnumLocationType>(LocationTypeVal, EnumLocationType.Rectangle);
            }
            set
            {
                LocationTypeVal = (Int16)value;
            }
        }

        [DataMember]
        private string LocationCoordinatesStr
        {
            get { return _locationCoordinatesStr; }
            set
            {
                if (_locationCoordinatesStr != value)
                {
                    _locationCoordinatesStr = value;
                    OnPropertyChanged("LocationCoordinatesStr");
                }
            }
        }
        private string _locationCoordinatesStr;
        public IList<string> LocationCoordinates
        {
            get
            {
                return new ObservableStringList(LocationCoordinatesStr, "LocationCoordinatesStr", this);
            }
        }

        [DataMember]
        public System.DateTime DateCreated
        {
            get { return _dateCreated; }
            set
            {
                if (_dateCreated != value)
                {
                    _dateCreated = value;
                    OnPropertyChanged("DateCreated");
                }
            }
        }
        private System.DateTime _dateCreated;
    
        [DataMember]
        public Nullable<System.DateTime> DateClosed
        {
            get { return _dateClosed; }
            set
            {
                if (_dateClosed != value)
                {
                    _dateClosed = value;
                    OnPropertyChanged("DateClosed");
                }
            }
        }
        private Nullable<System.DateTime> _dateClosed;

        #endregion
        #region Navigation Properties
    
        [DataMember]
        public TrackableCollection<Alert> Alerts
        {
            get
            {
                if (_alerts == null)
                {
                    _alerts = new TrackableCollection<Alert>();
                    _alerts.CollectionChanged += FixupAlerts;
                }
                return _alerts;
            }
            set
            {
                if (!ReferenceEquals(_alerts, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
                    if (_alerts != null)
                    {
                        _alerts.CollectionChanged -= FixupAlerts;
                    }
                    _alerts = value;
                    if (_alerts != null)
                    {
                        _alerts.CollectionChanged += FixupAlerts;
                    }
                    OnNavigationPropertyChanged("Alerts");
                }
            }
        }
        private TrackableCollection<Alert> _alerts;
    
        [DataMember]
        public TrackableCollection<Incident> Incidents
        {
            get
            {
                if (_incidents == null)
                {
                    _incidents = new TrackableCollection<Incident>();
                    _incidents.CollectionChanged += FixupIncidents;
                }
                return _incidents;
            }
            set
            {
                if (!ReferenceEquals(_incidents, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
                    if (_incidents != null)
                    {
                        _incidents.CollectionChanged -= FixupIncidents;
                    }
                    _incidents = value;
                    if (_incidents != null)
                    {
                        _incidents.CollectionChanged += FixupIncidents;
                    }
                    OnNavigationPropertyChanged("Incidents");
                }
            }
        }
        private TrackableCollection<Incident> _incidents;

        #endregion
        #region ChangeTracking
    
        protected virtual void OnPropertyChanged(String propertyName)
        {
            if (ChangeTracker.State != ObjectState.Added && ChangeTracker.State != ObjectState.Deleted)
            {
                ChangeTracker.State = ObjectState.Modified;
            }
            if (_propertyChanged != null)
            {
                _propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    
        protected virtual void OnNavigationPropertyChanged(String propertyName)
        {
            if (_propertyChanged != null)
            {
                _propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    
        event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged{ add { _propertyChanged += value; } remove { _propertyChanged -= value; } }
        private event PropertyChangedEventHandler _propertyChanged;
        private ObjectChangeTracker _changeTracker;
    
        [DataMember]
        public ObjectChangeTracker ChangeTracker
        {
            get
            {
                if (_changeTracker == null)
                {
                    _changeTracker = new ObjectChangeTracker();
                    _changeTracker.ObjectStateChanging += HandleObjectStateChanging;
                }
                return _changeTracker;
            }
            set
            {
                if(_changeTracker != null)
                {
                    _changeTracker.ObjectStateChanging -= HandleObjectStateChanging;
                }
                _changeTracker = value;
                if(_changeTracker != null)
                {
                    _changeTracker.ObjectStateChanging += HandleObjectStateChanging;
                }
            }
        }
    
        private void HandleObjectStateChanging(object sender, ObjectStateChangingEventArgs e)
        {
            if (e.NewState == ObjectState.Deleted)
            {
                ClearNavigationProperties();
            }
        }
    
        protected bool IsDeserializing { get; private set; }
    
        [OnDeserializing]
        public void OnDeserializingMethod(StreamingContext context)
        {
            IsDeserializing = true;
        }
    
        [OnDeserialized]
        public void OnDeserializedMethod(StreamingContext context)
        {
            IsDeserializing = false;
            ChangeTracker.ChangeTrackingEnabled = true;
        }
    
        protected virtual void ClearNavigationProperties()
        {
            Alerts.Clear();
            Incidents.Clear();
        }

        #endregion
        #region Association Fixup
    
        private void FixupAlerts(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (Alert item in e.NewItems)
                {
                    item.Crisis = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("Alerts", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Alert item in e.OldItems)
                {
                    if (ReferenceEquals(item.Crisis, this))
                    {
                        item.Crisis = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("Alerts", item);
                    }
                }
            }
        }
    
        private void FixupIncidents(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (Incident item in e.NewItems)
                {
                    item.Crisis = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("Incidents", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Incident item in e.OldItems)
                {
                    if (ReferenceEquals(item.Crisis, this))
                    {
                        item.Crisis = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("Incidents", item);
                    }
                }
            }
        }

        #endregion
    }
}
