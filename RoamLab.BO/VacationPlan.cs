    using System;
    using System.Collections.Generic;
    using System.Text;

    namespace RoamLab.BO
    {
        public class VacationPlan
        {
            public int PlanID { get; set; }
            public int UserID { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public int DestinationLocationID { get; set; }
            public DateTime CreatedDate { get; set; }
            public IEnumerable<PlanItem> PlanItems { get; set; }
            public int IsPublic { get; set; }
        }

    }
