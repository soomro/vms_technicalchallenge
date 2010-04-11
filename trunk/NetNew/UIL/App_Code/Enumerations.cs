using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public enum PageActions
{
    Create,
    Edit,
    View,
    None
}

public enum MessageTypes
{
    Info,
    Error,
    Warning
}

public enum MapModes
{
    DefineCrisis=1,
    DefineIncident=2,
    ShowCrisis=3
}