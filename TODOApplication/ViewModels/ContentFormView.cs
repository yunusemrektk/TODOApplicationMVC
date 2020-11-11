using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TODOApplication.Models.EntityFramework;

namespace TODOApplication.ViewModels
{
    public class ContentFormView
    {
        public List<Kullanici> Kullanicilar { get; set; }
        public Content Content { get; set; }
    }
}