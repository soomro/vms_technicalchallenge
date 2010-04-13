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
        Box 
    }
    public enum RequestResponseStatuses
    {
        Waiting ,
        Responded ,
        Timeout ,
        Caceled 
    }
    public enum Severities
    {
        Critical ,
        High ,
        Medium ,
        Low ,
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
}