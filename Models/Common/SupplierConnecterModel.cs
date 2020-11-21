using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flight_Project.Models.Common
{
    public class SupplierConnecterModel
    {
        public string BaseAddress { get; set; }
        public List<Headears> Headears { get; set; }
    }
    public class Headears
    {
        public Hashtable DefaultHeaders { get; set; }
    }
}
