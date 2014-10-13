using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using BlocketProject.Models.Blocks;
using EPiServer;

namespace BlocketProject.Models.Pages
{
    public class SitePageData : PageData
    {

        public StartPage StartPage
        {
            get
            {
                return DataFactory.Instance.Get<StartPage>(ContentReference.StartPage);
            }
        }


    }
}