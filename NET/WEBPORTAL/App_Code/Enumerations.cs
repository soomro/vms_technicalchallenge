using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public enum EnumPageAction
{
    Create,
    Edit,
    View,
    None
}

public enum EnumMessageType
{
    Info,
    Error,
    Warning
}

public enum EnumMapMode
{
    DefineCrisis=1,
    DefineIncident=2,
    ShowCrisis=3
}