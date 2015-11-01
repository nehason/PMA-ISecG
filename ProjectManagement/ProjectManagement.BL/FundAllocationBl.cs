using ProjectManagement.DAL;
using ProjectManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.BL
{
    public class FundAllocationBl
    {
        public static FundAllocationInfo[] GetAllocatedFunds()
        {
            FundAllocationInfo[] FAInfo = FundAllocationDal.GetAllocatedFunds();
            return FAInfo;

        }

        public static BeneForFAInfo[] GetBeneficiaryForFA()
        {
            BeneForFAInfo[] BInfo = FundAllocationDal.GetBeneficiaryForFA();
            return BInfo;

        }

        public static int AddNewFA(FundAllocationInfo FA)
        {
            return FundAllocationDal.AddNewFA(FA);
        }

        public static HttpResponseMessage DeleteAllocatedFund(int FAId)
        {
            try
            {
                int val = FundAllocationDal.DeleteAllocatedFund(FAId);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                Console.WriteLine("EXCEPTION: " + ex);
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }

        }
        public static decimal GetBalanceForFund(int FundId)
        {
            decimal balance = FundAllocationDal.GetBalanceForFund(FundId);
            return balance;
        }
    }
}
