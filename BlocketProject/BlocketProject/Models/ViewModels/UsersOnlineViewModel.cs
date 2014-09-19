using BlocketProject.Models.Blocks;
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

        }
        public int RegistredUsers { get; set; }
        public int MaleUsers { get; set; }
        public int FemaleUsers { get; set; }
    }
}