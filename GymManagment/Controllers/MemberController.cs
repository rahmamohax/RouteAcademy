using GymMangBLL.Services.Interfaces;
using GymMangBLL.ViewModels.MemberViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mono.TextTemplating;

namespace GymManagment.Controllers
{
    [Authorize(Roles = "SuperAdmin")]
    public class MemberController : Controller
    {
        private readonly IMemberService _memberService;

        public MemberController(IMemberService memberService)
        {
            this._memberService = memberService;
        }

        public ActionResult Index(int id)
        {
            var members= _memberService.GetAllMembers();
            return View(members);

        }

        public ActionResult MemberDetails(int id)
        {
            if (id <= 0)
            {
                TempData["ErrorMessage"] = "Id can't be 0 or negative";
                return RedirectToAction(nameof(Index));
            }
            var member = _memberService.GetMemberDetails(id);
            if (member is null)
            {
                TempData["ErrorMessage"] = "Member Not Found";
                return RedirectToAction(nameof(Index));
            }

            return View(member);
        }

        public ActionResult HealthRecordDetails(int id)
        {
            if (id <= 0)
            {
                TempData["ErrorMessage"] = "Id can't be 0 or negative";
                return RedirectToAction(nameof(Index));
            }
            var healthDetails = _memberService.GetHealthRecordDetails(id);
            if (healthDetails is null)
            {
                TempData["ErrorMessage"] = "Member Not Found";
                return RedirectToAction(nameof(Index));
            }
            return View(healthDetails);
        }

        #region Create Member
        //get
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateMember(CreateMemberViewModel createMember)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("InvalidData", "Check Validation and Missing Fields");
                return View(nameof(Create), createMember);
            }
            var result = _memberService.CreateMember(createMember);
            if (result)
                TempData["SuccessMessage"] = "Member Created Successfully";

            else
                TempData["ErrorMessage"] = "Creation Has Failed, Check Phone and Email";
            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Edit Member
        public ActionResult MemberEdit(int id)
        {
            if (id <= 0)
            {
                TempData["ErrorMessage"] = "Id can't be 0 or negative";
                return RedirectToAction(nameof(Index));
            }
            var member = _memberService.GetMemberToUpdate(id);
            if (member is null)
            {
                TempData["ErrorMessage"] = "Member Not Found";
                return RedirectToAction(nameof(Index));                
            }
            return View(member);
        }

        [HttpPost]
        public ActionResult MemberEdit([FromRoute] int id, UpdateMemberViewModel updateMember)
        {
            if (!ModelState.IsValid)
            {
                return View(updateMember);
            }
            var result = _memberService.UpdateMemberDetails(id, updateMember);
            if (result)
            {
                TempData["SuccessMessage"] = "Member Updated Successfully";
            }
            else
            {
                TempData["ErrorMessage"] = "Update Has Failed, Check Phone and Email";
            }
            return RedirectToAction(nameof(Index));
         }
        #endregion

        #region Delete Member
        public ActionResult Delete(int id)
        {
            if (id <= 0)
            {
                TempData["ErrorMessage"] = "Id can't be 0 or negative";
                return RedirectToAction(nameof(Index));
            }
            var member = _memberService.GetMemberDetails(id);
            if(member is null)
            {
                TempData["ErrorMessage"] = "Member Not Found";
                return RedirectToAction(nameof(Index));
            }
            ViewBag.MemberId = id;
            return View();
        }

        [HttpPost]
        public ActionResult DeleteConfirmed([FromForm] int id)
        {
            var delete = _memberService.RemoveMember(id);
            if (delete) 
                TempData["SuccessMessage"] = "Member is Deleted Successfully";
            else
                TempData["ErrorMessage"] = "Failed to Delete Member";
            return RedirectToAction(nameof(Index));
        }
        #endregion
    }
}
