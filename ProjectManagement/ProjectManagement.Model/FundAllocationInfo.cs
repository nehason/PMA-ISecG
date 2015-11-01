using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Model
{
    public class FundAllocationInfo
    {
        public int AllocationId { get; set; }

        public int FundId { get; set; }

        public string FundDesc { get; set; }

        public string BeneficiaryName { get; set; }

        public int BeneficiaryId { get; set; }

        public decimal Amount { get; set; }

        public DateTime AllocatedDate { get; set; }

        public DateTime ChangedDate { get; set; }

        public string AllocatedBy { get; set; }

        public string ChangedBy { get; set; }
    }

}

