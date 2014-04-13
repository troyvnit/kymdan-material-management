using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using KMM.Data.Service;
using KMM.Model.Models;
using KMM.Models;

namespace KMM.Controllers
{
    public class HomeController : Controller
    {
        private IMaterialProposalService _materialProposalService { get; set; }

        public HomeController(IMaterialProposalService _materialProposalService)
        {
            this._materialProposalService = _materialProposalService;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetMaterialProposal()
        {
            var materialProposals = _materialProposalService.GetMaterialProposals().Select(Mapper.Map<MaterialProposal, MaterialProposalViewModel>);
            return Json(materialProposals, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddOrUpdateMaterialProposal()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}