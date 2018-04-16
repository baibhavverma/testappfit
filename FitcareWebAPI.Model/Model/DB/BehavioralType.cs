using System;
using System.Collections.Generic;

namespace FitcareWebAPI.Model.Model.DB
{
    public partial class BehavioralType
    {
        public BehavioralType()
        {
            TblCurrentEatingActivity = new HashSet<CurrentEatingActivity>();
            TblMotivatedEatingActivity = new HashSet<MotivatedEatingActivity>();
        }

        public int TypeId { get; set; }
        public string TypeName { get; set; }

        public ICollection<CurrentEatingActivity> TblCurrentEatingActivity { get; set; }
        public ICollection<MotivatedEatingActivity> TblMotivatedEatingActivity { get; set; }
    }
}
