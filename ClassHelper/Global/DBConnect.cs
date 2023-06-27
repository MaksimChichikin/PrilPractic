using PrilPractika.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrilPractika.ClassHelper.Global
{
    internal class DBConnect
    {
        public static ChichikinKarsheringContext userDataBase { get; set; } = new ChichikinKarsheringContext();
    }
}
