using ProjectManagement.BL;
using ProjectManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace ProjectManagement.API
{
    public class FundAllocationController : ApiController
    {
        public JsonResult<IEnumerable<FundAllocationInfo>> Get()
        {

            FundAllocationInfo[] Allocated = FundAllocationBl.GetAllocatedFunds();

            var allocation = from c in Allocated
                       select c;
            return Json(allocation);

        }


        public HttpResponseMessage Delete(int id)
        {

            return FundAllocationBl.DeleteAllocatedFund(id);

        }

        public decimal GetBalanceForFund(int id) {
            return FundAllocationBl.GetBalanceForFund(id);
        }
        [HttpGet]
        public JsonResult<IEnumerable<BeneForFAInfo>> FetchBeneficiaryForFA(int id)
        {

            BeneForFAInfo[] Beneficiary = FundAllocationBl.GetBeneficiaryForFA();

            var beneficiaries = from c in Beneficiary
                             select c;
            return Json(beneficiaries);

        }

        public HttpResponseMessage Post(FundAllocationInfo FA)
        {
            try
            {
                FundAllocationBl.AddNewFA(FA);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

    }

}
