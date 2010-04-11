namespace Utils.Enumerations
{
    public enum CrisisStatuses
    {
        Active = 1,
        Closed = 2,
    }
    public enum CrisisTypes
    {
        Fire = 1,
        Earthquake = 2,
        Avalanche = 3,
    }
    public enum IncidentStatuses
    {
        Created = 1,
        ResourceGathering = 2,
        Working = 3,
        Complete = 4,
    }
    public enum IncidentTypes
    {
        Fire = 1,
        CollapsedBuilding = 2,
        Bomb = 3,
        Accident = 4,
    }
    public enum LocationTypes
    {
        Rectangle = 1,
        Circle = 2,
        Freeform = 3
    }
    public enum MapTypes
    {
        Satelite = 1,
        Map = 2,
        Terrain = 3,
    }
    public enum MetricTypes
    {
        Box = 1
    }
    public enum RequestResponseStatuses
    {
        Waiting = 1,
        Responded = 2,
        Timeout = 3,
        Caceled = 4
    }
    public enum Severities
    {
        Critical = 1,
        High = 2,
        /// <summary>
        /// Less severe
        /// </summary>
        Medium = 3,
        Low = 4,
    }
}