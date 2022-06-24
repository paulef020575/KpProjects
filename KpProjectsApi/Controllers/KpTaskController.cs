using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KpProjects.Api.Controllers.Base;
using KpProjects.Classes;
using KpProjects.Data;

namespace KpProjects.Api.Controllers
{
    public class KpTaskController : BaseController<KpTask>
    {
        public KpTaskController(KpProjectsContext context) : base(context)
        {
        }
    }
}
