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

namespace VMSCORE.EntityClasses
{
    [DataContract(IsReference = true)]
    [KnownType(typeof(RequestResponse))]
    [KnownType(typeof(Address))]
    [KnownType(typeof(StuffItem))]
    [KnownType(typeof(ProgressReport))]
    [KnownType(typeof(IncidentReport))]
    public partial class Volunteer: IObjectWithChangeTracker, INotifyPropertyChanged
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
        public string NameLastName
        {
            get { return _nameLastName; }
            set
            {
                if (_nameLastName != value)
                {
                    _nameLastName = value;
                    OnPropertyChanged("NameLastName");
                }
            }
        }
        private string _nameLastName;
    
        [DataMember]
        public Nullable<System.DateTime> DateBirth
        {
            get { return _dateBirth; }
            set
            {
                if (_dateBirth != value)
                {
                    _dateBirth = value;
                    OnPropertyChanged("DateBirth");
                }
            }
        }
        private Nullable<System.DateTime> _dateBirth;
    
        [DataMember]
        public short GenderVal
        {
            get { return _genderVal; }
            set
            {
                if (_genderVal != value)
                {
                    _genderVal = value;
                    OnPropertyChanged("GenderVal");
                }
            }
        }
        private short _genderVal;
    
        [DataMember]
        public string Occupation
        {
            get { return _occupation; }
            set
            {
                if (_occupation != value)
                {
                    _occupation = value;
                    OnPropertyChanged("Occupation");
                }
            }
        }
        private string _occupation;
    
        [DataMember]
        public string SpecificationsStr
        {
            get { return _specificationsStr; }
            set
            {
                if (_specificationsStr != value)
                {
                    _specificationsStr = value;
                    OnPropertyChanged("SpecificationsStr");
                }
            }
        }
        private string _specificationsStr;
    
        [DataMember]
        public string CoordinatesStr
        {
            get { return _coordinatesStr; }
            set
            {
                if (_coordinatesStr != value)
                {
                    _coordinatesStr = value;
                    OnPropertyChanged("CoordinatesStr");
                }
            }
        }
        private string _coordinatesStr;
    
        [DataMember]
        public System.DateTime CoordinateLastUpdateTime
        {
            get { return _coordinateLastUpdateTime; }
            set
            {
                if (_coordinateLastUpdateTime != value)
                {
                    _coordinateLastUpdateTime = value;
                    OnPropertyChanged("CoordinateLastUpdateTime");
                }
            }
        }
        private System.DateTime _coordinateLastUpdateTime;
    
        [DataMember]
        public System.DateTime LastAccessTime
        {
            get { return _lastAccessTime; }
            set
            {
                if (_lastAccessTime != value)
                {
                    _lastAccessTime = value;
                    OnPropertyChanged("LastAccessTime");
                }
            }
        }
        private System.DateTime _lastAccessTime;

        #endregion
        #region Navigation Properties
    
        [DataMember]
        public TrackableCollection<RequestResponse> RequestResponses
        {
            get
            {
                if (_requestResponses == null)
                {
                    _requestResponses = new TrackableCollection<RequestResponse>();
                    _requestResponses.CollectionChanged += FixupRequestResponses;
                }
                return _requestResponses;
            }
            set
            {
                if (!ReferenceEquals(_requestResponses, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
                    if (_requestResponses != null)
                    {
                        _requestResponses.CollectionChanged -= FixupRequestResponses;
                    }
                    _requestResponses = value;
                    if (_requestResponses != null)
                    {
                        _requestResponses.CollectionChanged += FixupRequestResponses;
                    }
                    OnNavigationPropertyChanged("RequestResponses");
                }
            }
        }
        private TrackableCollection<RequestResponse> _requestResponses;
    
        [DataMember]
        public Address Address
        {
            get { return _address; }
            set
            {
                if (!ReferenceEquals(_address, value))
                {
                    var previousValue = _address;
                    _address = value;
                    FixupAddress(previousValue);
                    OnNavigationPropertyChanged("Address");
                }
            }
        }
        private Address _address;
    
        [DataMember]
        public TrackableCollection<StuffItem> StuffItems
        {
            get
            {
                if (_stuffItems == null)
                {
                    _stuffItems = new TrackableCollection<StuffItem>();
                    _stuffItems.CollectionChanged += FixupStuffItems;
                }
                return _stuffItems;
            }
            set
            {
                if (!ReferenceEquals(_stuffItems, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
                    if (_stuffItems != null)
                    {
                        _stuffItems.CollectionChanged -= FixupStuffItems;
                    }
                    _stuffItems = value;
                    if (_stuffItems != null)
                    {
                        _stuffItems.CollectionChanged += FixupStuffItems;
                    }
                    OnNavigationPropertyChanged("StuffItems");
                }
            }
        }
        private TrackableCollection<StuffItem> _stuffItems;
    
        [DataMember]
        public TrackableCollection<ProgressReport> ProgressReports
        {
            get
            {
                if (_progressReports == null)
                {
                    _progressReports = new TrackableCollection<ProgressReport>();
                    _progressReports.CollectionChanged += FixupProgressReports;
                }
                return _progressReports;
            }
            set
            {
                if (!ReferenceEquals(_progressReports, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
                    if (_progressReports != null)
                    {
                        _progressReports.CollectionChanged -= FixupProgressReports;
                    }
                    _progressReports = value;
                    if (_progressReports != null)
                    {
                        _progressReports.CollectionChanged += FixupProgressReports;
                    }
                    OnNavigationPropertyChanged("ProgressReports");
                }
            }
        }
        private TrackableCollection<ProgressReport> _progressReports;
    
        [DataMember]
        public TrackableCollection<IncidentReport> IncidentReports
        {
            get
            {
                if (_incidentReports == null)
                {
                    _incidentReports = new TrackableCollection<IncidentReport>();
                    _incidentReports.CollectionChanged += FixupIncidentReports;
                }
                return _incidentReports;
            }
            set
            {
                if (!ReferenceEquals(_incidentReports, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
                    if (_incidentReports != null)
                    {
                        _incidentReports.CollectionChanged -= FixupIncidentReports;
                    }
                    _incidentReports = value;
                    if (_incidentReports != null)
                    {
                        _incidentReports.CollectionChanged += FixupIncidentReports;
                    }
                    OnNavigationPropertyChanged("IncidentReports");
                }
            }
        }
        private TrackableCollection<IncidentReport> _incidentReports;

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
            RequestResponses.Clear();
            Address = null;
            FixupAddressKeys();
            StuffItems.Clear();
            ProgressReports.Clear();
            IncidentReports.Clear();
        }

        #endregion
        #region Association Fixup
    
        private void FixupAddress(Address previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && ReferenceEquals(previousValue.Volunteer, this))
            {
                previousValue.Volunteer = null;
            }
    
            if (Address != null)
            {
                Address.Volunteer = this;
            }
    
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("Address")
                    && (ChangeTracker.OriginalValues["Address"] == Address))
                {
                    ChangeTracker.OriginalValues.Remove("Address");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("Address", previousValue);
                }
                if (Address != null && !Address.ChangeTracker.ChangeTrackingEnabled)
                {
                    Address.StartTracking();
                }
                FixupAddressKeys();
            }
        }
    
        private void FixupAddressKeys()
        {
            const string IdKeyName = "Address.Id";
    
            if(ChangeTracker.ExtendedProperties.ContainsKey(IdKeyName))
            {
                if(Address == null ||
                   !Equals(ChangeTracker.ExtendedProperties[IdKeyName], Address.Id))
                {
                    ChangeTracker.RecordOriginalValue(IdKeyName, ChangeTracker.ExtendedProperties[IdKeyName]);
                }
                ChangeTracker.ExtendedProperties.Remove(IdKeyName);
            }
        }
    
        private void FixupRequestResponses(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (RequestResponse item in e.NewItems)
                {
                    item.Volunteer = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("RequestResponses", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (RequestResponse item in e.OldItems)
                {
                    if (ReferenceEquals(item.Volunteer, this))
                    {
                        item.Volunteer = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("RequestResponses", item);
                    }
                }
            }
        }
    
        private void FixupStuffItems(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (StuffItem item in e.NewItems)
                {
                    item.Volunteer = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("StuffItems", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (StuffItem item in e.OldItems)
                {
                    if (ReferenceEquals(item.Volunteer, this))
                    {
                        item.Volunteer = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("StuffItems", item);
                    }
                }
            }
        }
    
        private void FixupProgressReports(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (ProgressReport item in e.NewItems)
                {
                    item.Volunteer = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("ProgressReports", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (ProgressReport item in e.OldItems)
                {
                    if (ReferenceEquals(item.Volunteer, this))
                    {
                        item.Volunteer = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("ProgressReports", item);
                    }
                }
            }
        }
    
        private void FixupIncidentReports(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (IncidentReport item in e.NewItems)
                {
                    item.Volunteer = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("IncidentReports", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (IncidentReport item in e.OldItems)
                {
                    if (ReferenceEquals(item.Volunteer, this))
                    {
                        item.Volunteer = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("IncidentReports", item);
                    }
                }
            }
        }

        #endregion
    }
}
