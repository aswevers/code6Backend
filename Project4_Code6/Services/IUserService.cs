using Project4_Code6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project4_Code6.Services
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
    }
}
