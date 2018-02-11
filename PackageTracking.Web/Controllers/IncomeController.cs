using Newtonsoft.Json;
using PackageTracking.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PackageTracking.Web.Controllers
{
    public class IncomeController : WebController
    {
        public IncomeController(PackageTrackingContext packageTrackingContext) : base(packageTrackingContext)
        {
        }

        // GET: Income
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase upload)
        {
            if (upload != null)
            {
                var ships = _packageTrackingContext.Ship.ToList();
                // получаем имя файла
                string fileName = System.IO.Path.GetFileName(upload.FileName);
                // сохраняем файл в папку Files в проекте
                upload.SaveAs(Server.MapPath("~/Files/" + fileName));
                
                if(Path.GetExtension(Server.MapPath("~/Files/" + fileName))==".txt")
                {
                    try
                    {
                        string y;
                        using (StreamReader inp = new StreamReader(Server.MapPath("~/Files/" + fileName)))
                        {
                            y = inp.ReadToEnd();
                            inp.Close();
                        }
                        Rootobject a = JsonConvert.DeserializeObject<Rootobject>(y);
                        foreach (Ship s in a.Ships)
                        {
                            _packageTrackingContext.Ship.Attach(s);
                            _packageTrackingContext.Entry(s).State = EntityState.Added;
                            //_packageTrackingContext.Ship.Find(s.ShipID).ShipID = s.ShipID;
                            //_packageTrackingContext.Ship.Add(s);
                            _packageTrackingContext.SaveChanges();
                        }
                    }
                    catch (Exception e)
                    {
                        var message = e.Message;
                    }
                }
            }
            return RedirectToAction("Index");
        }
    }
}