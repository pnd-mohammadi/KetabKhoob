using Common.Application;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.SiteEntities.Sliders.Delete
{
    public class DeleteSliderCommand:IBaseCommand
    {
        public DeleteSliderCommand(long sliderId)
        {
            SliderId = sliderId;
        }

        public long SliderId { get; private set; }
    }
  
}
