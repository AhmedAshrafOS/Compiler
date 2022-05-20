using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Services;
using WebApplication3.ViewModels;
using Newtonsoft.Json;
namespace WebApplication3.Controllers
{
    public class TokenController : Controller
    {
        Compiler Compiler = new Compiler() ;

        // GET: Token
        //public ActionResult listof(string brands)
        //{
        //    var toklist = JsonConvert.DeserializeObject<List<string>>(brands);
        //    TokenViews TokenViews = new TokenViews()
        //    {
        //        tok = toklist,
        //    };
        //    return View(TokenViews);
        //}


       [HttpGet]
        public ActionResult SaveRecord()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SaveRecord(string file)
        {
            string s = Compiler.getCodeFromFile("C:\\Users\\Ahmed\\Desktop\\WebApplication3\\WebApplication3\\WebApplication3\\Scanner.txt");
            //Compiler.DisplayTokens(s);
            var list = Compiler.DisplayTokens(s);
            ViewBag.Emp_data = list;
            return View();
        }

    }
}