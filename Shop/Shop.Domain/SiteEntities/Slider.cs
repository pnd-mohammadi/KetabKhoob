using Common.Domain;
using Common.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.SiteEntities
{
    public class Slider : BaseEntity
    {
        public Slider(string link, string imageName, string title)
        {
            Guard(link, imageName, title);
            Link = link;
            ImageName = imageName;
            Title = title;
        }
        public string Link { get; private set; }
        public string ImageName { get; private set; }
        public string Title { get; private set; }
        public void Edit(string link, string imageName, string title)
        {
            Guard(link, imageName, title);
            Link = link;
            ImageName = imageName;
            Title = title;
        }
        public static void Guard(string link, string imageName, string title)
        {
            NullOrEmptyDomainDataException.CheckString(link, nameof(link));
            NullOrEmptyDomainDataException.CheckString(imageName, nameof(imageName));
            NullOrEmptyDomainDataException.CheckString(title, nameof(title));
        }
    }
}
