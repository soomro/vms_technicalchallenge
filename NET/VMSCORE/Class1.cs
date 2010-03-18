using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VMSCORE
{
    public class Class1
    { // test
        int a = 0;

        public static void addnew()
        {
            EFContainer1 e = new EFContainer1();
            VolunteerSet v = new VolunteerSet();
            v.Name = "abdullah";
            v.BirthDate = DateTime.Now;
            NeedItemSet n = new NeedItemSet();
            n.NeedName = "car";
            n.Metric = "item";
            n.Amount = 5;
            v.NeedItemSets.Add(n);

            e.VolunteerSets.AddObject(v);
            e.SaveChanges();
          
            
        }
    }
}
