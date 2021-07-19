using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test_FathinMuhammadFadhlullah.Utils;
using Microsoft.AspNetCore.Mvc;

namespace Test_FathinMuhammadFadhlullah.Controllers
{
    [SessionAuthorize]
    public class BaseController : Controller
    {

    }
}