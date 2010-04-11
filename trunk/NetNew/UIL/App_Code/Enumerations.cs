using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public enum PageAction
{
    Create,
    Edit,
    View,
    None
}

public enum MessageType
{
    Info,
    Error,
    Warning
}

public enum MapMode
{
    DefineCrisis=1,
    DefineIncident=2,
    ShowCrisis=3
}