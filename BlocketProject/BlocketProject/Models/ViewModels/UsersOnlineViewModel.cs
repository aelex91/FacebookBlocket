using BlocketProject.Models.Blocks;
using EPiServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlocketProject.Models.ViewModels
{
    public class UsersOnlineViewModel
    {
        public UsersOnlineViewModel(UsersOnlineBlock currentBlock)
        {
            this.Heading = currentBlock.Name;
            this.FemaleLogo = currentBlock.Logofemale;
            this.MaleLogo = currentBlock.Logomale;
        }
        public string Heading { get; set; }
        public int RegistredUsers { get; set; }
        public int MaleUsers { get; set; }
        public int FemaleUsers { get; set; }
        public Url FemaleLogo { get; set; }
        public Url MaleLogo { get; set; }
    }
}