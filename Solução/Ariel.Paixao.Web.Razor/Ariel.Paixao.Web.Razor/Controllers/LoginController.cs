using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Ariel.Paixao.Web.Razor.Dominios;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;

namespace Ariel.Paixao.Web.Razor.Controllers
{
    public class LoginController : Controller
    {
        private readonly LanHouseContext _context;

        public LoginController(LanHouseContext context)
        {
            _context = context;
        }

        // GET: Login/Create
        public IActionResult Create()
        {
            HttpContext.Session.Clear();
            return View();
        }

        // POST: Login/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Email,Senha")] Usuarios usuarios)
        {
            if (ModelState.IsValid)
            {
                Usuarios retorno = _context.Usuarios.FirstOrDefault(x => x.Email == usuarios.Email && x.Senha == usuarios.Senha);

                if (retorno == null)
                {
                    ViewBag.Mensagem = "E-mail ou senha inválidos";
                    return View(usuarios);
                }

                HttpContext.Session.SetString("email", usuarios.Email);
                ViewBag.Mensagem = "Usuário válido";
                return RedirectToAction("Create", "RegistroDefeitos");
            }

            return View(usuarios);
        }
    }
}
