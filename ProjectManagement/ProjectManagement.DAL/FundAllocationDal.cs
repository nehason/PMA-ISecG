using ProjectManagement.Model;
using ProjectManagement.SPHelper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.DAL
{
    public class FundAllocationDal
    {
        public static FundAllocationInfo[] GetAllocatedFunds()
        {
            ArrayList al = new ArrayList();
            int retValue = -1;
            //Generated Code for query : dbo.GetAllVendors
            using (SqlDataReader dr = ProjManagementAdmin.GetAllocatedFunds(out retValue)) //Initialize and retrieve code for Datareader goes here
            {

                while (dr.Read())
                {
                    FundAllocationInfo alloc = new FundAllocationInfo();

                    alloc.AllocationId = Convert.ToInt32(dr["allocation_id"]);
                    alloc.FundId = Convert.ToInt32(dr["fund_id"]);
                    alloc.FundDesc = dr["fund_desc"].ToString();
                    alloc.BeneficiaryId = Convert.ToInt32(dr["beneficiary_id"]);
                    alloc.BeneficiaryName = dr["beneficiary_name"].ToString();
                    alloc.AllocatedBy = dr["allocated_by"].ToString();
                    alloc.ChangedBy = dr["changed_by"].ToString();
                    alloc.AllocatedBy = dr["allocated_by"].ToString();
                    alloc.Amount = Convert.ToDecimal(dr["allocated_amount"]);

                    al.Add(alloc);
                }
                //dr.Close();
            }

            FundAllocationInfo[] allInfo = new FundAllocationInfo[al.Count];
            al.CopyTo(allInfo);
            return allInfo;
        }

        public static BeneForFAInfo[] GetBeneficiaryForFA()
        {
            ArrayList al = new ArrayList();
            int retValue = -1;
            using (SqlDataReader dr = ProjManagementAdmin.GetBeneForFA(out retValue)) //Initialize and retrieve code for Datareader goes here
            {

                while (dr.Read())
                {
                    BeneForFAInfo b = new BeneForFAInfo();

                    b.BeneficiaryId = Convert.ToInt32(dr["beneficiary_id"]);
                    b.BeneficiaryName = dr["beneficiary_name"].ToString();
                    b.ProjectName = dr["project_name"].ToString();
                    b.LocationName = dr["location_name"].ToString();

                    al.Add(b);
                }
                //dr.Close();
            }

            BeneForFAInfo[] allInfo = new BeneForFAInfo[al.Count];
            al.CopyTo(allInfo);
            return allInfo;
        }
        public static int DeleteAllocatedFund(int FAId)
        {
            int retValue = -1;
            return ProjManagementAdmin.DeleteAllocatedFund(FAId,out retValue);
        }

        public static decimal GetBalanceForFund(int FundId)
        {
            int retValue = -1;
            return ProjManagementAdmin.GetBalanceForFund(FundId,out retValue);
        }

        public static int AddNewFA(FundAllocationInfo FA)
        {
            if ( FA == null)
                throw new ArgumentNullException("Fund is missing");


            int retValue = -1;
            return ProjManagementAdmin.AddNewFA(FA, out retValue);
        }
    }
}
