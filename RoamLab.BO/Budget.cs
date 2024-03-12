using System;
using System.Collections.Generic;
using System.Text;

namespace RoamLab.BO
{
    public class Budget
    {
        public int BudgetID { get; set; }
        public int PlanID { get; set; }
        public string Category { get; set; }
        public int Amount { get; set; }
        public decimal Currency { get; set; }
    }

}
