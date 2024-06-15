using Common.Application;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Products.RemoveImage
{
    public class RemoveImageProductCommand:IBaseCommand
    {
        public long ProductId { get; set; }
        public long ImageId { get; set; }
    }
    

}
