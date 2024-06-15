using Common.Application;
using Common.Application.FileUtil.Services;
using Common.Application.SecurityUtil;
using Microsoft.AspNetCore.Http;
using Shop.Application._Utilities;
using Shop.Domain.SiteEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.SiteEntities.Sliders.Edit
{
    public class EditSliderCommand:IBaseCommand
    {
        public long SliderId { get;  set; }
        public string Link { get; set; }
        public IFormFile ImageFile { get;  set; }
        public string Title { get;  set; }
    }
   
}

