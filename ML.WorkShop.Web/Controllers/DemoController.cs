using AutoMapper;
using ML.WorkShop.BLL;
using ML.WorkShop.Infrastructure;
using ML.WorkShop.Infrastructure.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ML.WorkShop.Web.Controllers
{
    public class DemoController : Controller
    {
        private IMemberWorkflow _memberWorkflow;

        public IMemberWorkflow MemberWorkflow
        {
            get
            {
                if (this._memberWorkflow == null)
                {
                    this._memberWorkflow = new MemberWorkflow();
                }
                return this._memberWorkflow;
            }

            set { this._memberWorkflow = value; }
        }

        // GET: Demo
        public ActionResult Index(MemberFilterModel filter, GridState gridstate)
        {
            gridstate.PageSize = 10;
            var querable = MemberWorkflow.GetMembers(filter, gridstate);
            ViewData.Model = querable;
            return View();
        }

        public ActionResult Insert(MemberViewModel data)
        {
            return View();
        }

        [HttpPost]
        [ActionName("Insert")]
        public ActionResult InsertAction(MemberViewModel data)
        {
            data.Id = Guid.NewGuid();
            var result = MemberWorkflow.Insert(data, "Admin");

            return RedirectToAction("Index");

        }

        public ActionResult Edit(MemberFilterModel filter)
        {
            var result = MemberWorkflow.GetMemberDetail(filter.Id);
            ViewData.Model = result;
            return View();
        }


        [HttpPost]
        [ActionName("Edit")]
        public ActionResult UpdataAction(MemberDetailViewModel instance)
        {
            var Detail = MemberWorkflow.GetMemberDetail(instance.Id);

            MemberViewModel data = new MemberViewModel();

            data.Id = Detail.Id;
            data.CompanyId = instance.CompanyId;
            data.WorkId = Detail.WorkId;
            data.Password = (instance.Password != null && instance.Password != Detail.Password) ? instance.Password : Detail.Password;
            if ((bool)instance.Member)
            {
                data.RoleName = "Member";
            }
            else if ((bool)instance.Admin)
            {
                data.RoleName = "Administrator";
            }
            else if ((bool)instance.Lock)
            {
                data.RoleName = "Lock";
            }
            data.Email = instance.Email;
            data.Age = instance.Age;
            data.Name = instance.Name;
            data.CreateDateTime = (DateTime)Detail.CreateDateTime;
            data.CreateUserId = Detail.CreateUserId;

            data.Remark = Detail.Remark;

                var result = MemberWorkflow.Update(data, "Clarke");

            return RedirectToAction("Index");

        }

        
        public ActionResult Delete(MemberViewModel data, string UserId)
        {
            var DDMC = "2AC2BDF1-4F8E-E811-825E-54E1AD1FCD96";
            var FENC = "77A6A81A-508E-E811-825E-54E1AD1FCD96";

            var Detail = MemberWorkflow.GetMemberDetail(data.Id);
            data.CompanyId = (Detail.CompanyId == "DDMC") ? DDMC : FENC;
            data.WorkId = Detail.WorkId;
            if ((bool)Detail.Member)
            {
                data.RoleName = "Member";
            }
            else if ((bool)Detail.Admin)
            {
                data.RoleName = "Administrator";
            }
            else if ((bool)Detail.Lock)
            {
                data.RoleName = "Lock";
            }

            data.Email = Detail.Email;
            data.Name = Detail.Name;
            data.Age = Detail.Age;
            data.Password = Detail.Password;
          
                MemberWorkflow.Delete(data, "Clarke");
                return RedirectToAction("Index");
          

        }
    }
}