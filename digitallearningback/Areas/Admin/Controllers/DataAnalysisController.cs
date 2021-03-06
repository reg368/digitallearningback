﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using digitallearningback.DAO;
using digitallearningback.Models;

namespace digitallearningback.Areas.Admin.Controllers
{
    public class DataAnalysisController : Controller
    {

        private VW_DataAnalysisIndexInfoService daservice = new VW_DataAnalysisIndexInfoService();
        private VW_DataAnalysisLevelDetailInfoService dadetailservice = new VW_DataAnalysisLevelDetailInfoService();


        // GET: Admin/DataAnalysis
        public ActionResult Index()
        {
            List<vw_DataAnalysisIndexInfo> infolist = daservice.selectAll();
            ViewBag.infolist = infolist;
            return View(infolist.FirstOrDefault<vw_DataAnalysisIndexInfo>());
        }

        public ActionResult Details(int lid , string level) {
            ViewBag.level = level;
            return View(dadetailservice.selectByLevelId(lid));
        }
    }
}