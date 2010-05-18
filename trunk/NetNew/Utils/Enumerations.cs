using System.ComponentModel;
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
        [Description("New")]
        Created =0,
        [Description("Resource Gathering")]
        ResourceGathering =1,
        [Description("Resolving")]
        Working=2 ,
        [Description("Completed")]
        Complete =3,
    }
    public enum IncidentTypes:short
    {
        Fire ,
        [Description("Collapsed Building")]
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
    public enum RequestResponseStatuses:short
    {
        Waiting =0,
        Responded =1,
        Timeout =2,
        Canceled=3 
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
        _Punc,
        _Space,
        _StartsWith_abc,
        _AllowAll
    }

    public enum MessageTypes
    {
        Info,
        Error,
        Warning
    }

    
}