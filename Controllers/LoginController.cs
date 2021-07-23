using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POOREC.Models;

namespace POOREC.Controllers
{
   [Route("Login")]
    public class LoginController : Controller
    {
        Musico m1 = new Musico();

        public IActionResult Index()
        {
            return View();
        }

        [Route("Logar")]
        public IActionResult Logar(IFormCollection form)
        {
            // Lemos todos os arquivos do CSV
            List<string> csv = m1.ReadAllLinesCSV("DataBase/Usuario.csv");

            // Verificamos se as informações passadas existe na lista de string
            var logado =
            csv.Find(
                x =>
                x.Split(";")[2] == form["Email"] &&
                x.Split(";")[3] == form["Senha"]
            );


            // Redirecionamos o usuário logado caso encontrado
            if (logado != null)
            {
                // Definimos os valores a serem salvos na sessão
                HttpContext.Session.SetString("_UserName", logado.Split(";")[1]);

                return LocalRedirect("~/");
            }
            return LocalRedirect("~/Home");
        }

        [Route("Logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("_UserName");
            return LocalRedirect("~/");
        }

    }
}