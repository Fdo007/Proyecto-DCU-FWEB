using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Proyecto_DCU_FWEB.Areas.Identity.Data;

// Add profile data for application users by adding properties to the AplicacionUsuario class
public class AplicacionUsuario : IdentityUser
{
    public string Nombre { get; set; }

    public string SegundoNombre { get; set; }

    public string Apellido { get; set; }




}

