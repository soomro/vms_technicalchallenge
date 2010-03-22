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
    [KnownType(typeof(Volunteer))]
    public partial class IncidentReport: IObjectWithChangeTracker, INotifyPropertyChanged
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
        private short IncidentTypeVal
        {
            get { return _incidentTypeVal; }
            set
            {
                if (_incidentTypeVal != value)
                {
                    _incidentTypeVal = value;
                    OnPropertyChanged("IncidentTypeVal");
                }
            }
        }
        private short _incidentTypeVal;
        public EnumIncidentType IncidentType
        {
            get
            {
                return Util.ReflectionUtil.SafeConvertToEnum<EnumIncidentType>(IncidentTypeVal, EnumIncidentType.Accident);
            }
            set
            {
                IncidentTypeVal = (Int16)value;
            }
        }


        [DataMember]
        public string Description
        {
            get { return _description; }
            set
            {
                if (_description != value)
                {
                    _description = value;
                    OnPropertyChanged("Description");
                }
            }
        }
        private string _description;
    
        [DataMember]
        public string ImageFile
        {
            get { return _imageFile; }
            set
            {
                if (_imageFile != value)
                {
                    _imageFile = value;
                    OnPropertyChanged("ImageFile");
                }
            }
        }
        private string _imageFile;
    
        [DataMember]
        public string VideoFile
        {
            get { return _videoFile; }
            set
            {
                if (_videoFile != value)
                {
                    _videoFile = value;
                    OnPropertyChanged("VideoFile");
                }
            }
        }
        private string _videoFile;
    
        [DataMember]
        public string Location
        {
            get { return _location; }
            set
            {
                if (_location != value)
                {
                    _location = value;
                    OnPropertyChanged("Location");
                }
            }
        }
        private string _location;
    
        [DataMember]
        public string LocationCoordinatesStr
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
    
        [DataMember]
        public int IncidentId
        {
            get { return _incidentId; }
            set
            {
                if (_incidentId != value)
                {
                    _incidentId = value;
                    OnPropertyChanged("IncidentId");
                }
            }
        }
        private int _incidentId;

        #endregion
        #region Navigation Properties
    
        [DataMember]
        public Volunteer Volunteer
        {
            get { return _volunteer; }
            set
            {
                if (!ReferenceEquals(_volunteer, value))
                {
                    var previousValue = _volunteer;
                    _volunteer = value;
                    FixupVolunteer(previousValue);
                    OnNavigationPropertyChanged("Volunteer");
                }
            }
        }
        private Volunteer _volunteer;

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
            Volunteer = null;
            FixupVolunteerKeys();
        }

        #endregion
        #region Association Fixup
    
        private void FixupVolunteer(Volunteer previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.IncidentReports.Contains(this))
            {
                previousValue.IncidentReports.Remove(this);
            }
    
            if (Volunteer != null)
            {
                if (!Volunteer.IncidentReports.Contains(this))
                {
                    Volunteer.IncidentReports.Add(this);
                }
    
            }
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("Volunteer")
                    && (ChangeTracker.OriginalValues["Volunteer"] == Volunteer))
                {
                    ChangeTracker.OriginalValues.Remove("Volunteer");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("Volunteer", previousValue);
                }
                if (Volunteer != null && !Volunteer.ChangeTracker.ChangeTrackingEnabled)
                {
                    Volunteer.StartTracking();
                }
                FixupVolunteerKeys();
            }
        }
    
        private void FixupVolunteerKeys()
        {
            const string IdKeyName = "Volunteer.Id";
    
            if(ChangeTracker.ExtendedProperties.ContainsKey(IdKeyName))
            {
                if(Volunteer == null ||
                   !Equals(ChangeTracker.ExtendedProperties[IdKeyName], Volunteer.Id))
                {
                    ChangeTracker.RecordOriginalValue(IdKeyName, ChangeTracker.ExtendedProperties[IdKeyName]);
                }
                ChangeTracker.ExtendedProperties.Remove(IdKeyName);
            }
        }

        #endregion
    }
}
