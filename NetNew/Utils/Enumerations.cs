namespace Utils.Enumerations
{
    public enum CrisisStatuses:short
    {
        Active ,
        Closed ,
    }
    public enum CrisisTypes:short
    {
        Fire ,
        Earthquake ,
        Avalanche ,
    }
    public enum IncidentStatuses:short
    {
        Created ,
        ResourceGathering ,
        Working ,
        Complete ,
    }
    public enum IncidentTypes:short
    {
        Fire ,
        CollapsedBuilding ,
        Bomb ,
        Accident ,
    }
    public enum LocationTypes:short
    {
        Rectangle ,
        Circle ,
        Freeform 
    }
    public enum MapTypes:short
    {
        Satelite ,
        Map,
        Terrain ,
    }
    public enum MetricTypes:short
    { 
        Item=1,
        Liter=2,
        Kg=3,
        Box=4 
    }
    public enum RequestResponseStatuses
    {
        Waiting ,
        Responded ,
        Timeout ,
        Caceled 
    }
    public enum Severities:short
    {
        Critical =1,
        High =2,
        Medium =3,
        Low =4,
    }
   
    public enum UserTypes:short
    {
        Volunteer,
        Manager
    }
    public enum Gender:short
    {
        Man,
        Woman
    }

    /// <summary>
    /// Used to indicate which rules will be applied for validation
    /// </summary>
    public enum ValRules
    {
        //Mohsen: Not agree with underscore in the begining. to be discussed
        _abc,
        _123,
        _SpeChars, // special characters ( symbols and punctiations )
        _Space,
        _StartsWith_abc
    }

    public enum MessageTypes
    {
        Info,
        Error,
        Warning
    }

    
}