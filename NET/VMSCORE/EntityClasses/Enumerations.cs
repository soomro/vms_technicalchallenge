
public enum EnumCrisisStatus
{
    Active=1,
    Closed=2,
}
public enum EnumCrisisType
{
    Fire=1,
    Earthquake=2,
}
public enum EnumIncidentStatus
{
    Created=1,
    ResourceGathering=2,
    Working=3,
    Complete=4,
}
public enum EnumIncidentType
{
    Fire=1,
    CollapsedBuilding=2,
    Bomb=3,
    Accident=4,
}
public enum EnumLocationType
{
    Rectangle=1,
    Circle=2,
    Freeform=3
}
public enum EnumMapType
{
    Satelite=1,
    Map=2,
    Terrain=3,
}
public enum EnumMetricType
{
    Box=1
}
public enum EnumRequestResponseStatus
{
    Waiting=1,
    Responded=2,
    Timeout=3,
    Caceled=4
}
public enum EnumSeverity
{
    Critical = 1,
    High = 2,
    /// <summary>
    /// Less severe
    /// </summary>
    Medium = 3,
    Low=4,
}