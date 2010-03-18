using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VMSCORE
{
    public class Incident
    {
        public Crisis Crisis
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public string ShortDescription
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public EnumLocationType LocationType
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public List<Dictionary<string, string>> LocationCoordinates
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public string Explanation
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public DateTime DateCreated
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public DateTime? DateClosed
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public EnumSeverity Severity
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public EnumIncidentType IncidentType
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public IList<NeedItem> NeedList
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public IList<VMSCORE.Request> Requests
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public EnumIncidentStatus IncidentStatus
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public IList<VMSCORE.ProgressReport> ProgressReports
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public IncidentReport IncidentReport
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public string ShortAddress
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }
    }
}
