﻿using GestionAgroite_V1_CSI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionAgroite_V1_CSI.Controllers
{
    public class LoginController : Controller
    {
        Usuario objusuario = new Usuario();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Acceder(string usuario, string password)
        {

            var rm = objusuario.Acceder(usuario, password);
            if (rm.response)
            {
                Session["idusuario"] = rm.idusuario;
                return Redirect("~/Admin/Index");
            }
            return Redirect("~/Login/Index");
        }

        public ActionResult LogOut()
        {
            SessionHelper.DestroyUserSession();
            Session.Clear();
            return Redirect("~/Login/Index");
        }
    }
}