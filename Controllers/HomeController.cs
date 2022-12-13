using Microsoft.AspNetCore.Mvc;
using Proyecto_DCU_FWEB.Models;
using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Proyecto_DCU_FWEB.Helpers;
using Proyecto_DCU_FWEB.Providers;

namespace Proyecto_DCU_FWEB.Controllers
{
    public class HomeController : Controller
    {
        private HelperUploadFiles helperUpload;

        public HomeController(HelperUploadFiles helperUpload)
        {
            this.helperUpload = helperUpload;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Index(IFormFile imagen, int ubicacion)
        {
            string nombreImagen = imagen.FileName;

            string path = "";

            switch (ubicacion)
            {
                case 0:
                    path = await this.helperUpload.UploadFilesAsync(imagen, nombreImagen, Folders.Uploads);
                    break;
                case 1:
                    path = await this.helperUpload.UploadFilesAsync(imagen, nombreImagen, Folders.Images);
                    break;
                case 2:
                    path = await this.helperUpload.UploadFilesAsync(imagen, nombreImagen, Folders.Documents);
                    break;
                case 3:
                    path = await this.helperUpload.UploadFilesAsync(imagen, nombreImagen, Folders.Temp);
                    break;
            }

            ViewBag.Mensaje = "Fichero " + nombreImagen + " subido a " + path;
            return View();

        }
    }
}