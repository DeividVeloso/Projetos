﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaelumEstoque.Controllers
{
    public class ContadorController : Controller
    {
        // GET: Contador
        public ActionResult Index()
        {
            object valorDaSession = Session["contador"];
            int contador = Convert.ToInt32(valorDaSession);
            contador++;
            Session["contador"] = contador;
            return View(contador);
        }
    }
}