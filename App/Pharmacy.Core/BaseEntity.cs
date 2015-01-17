using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pharmacy.Contracts.Entities;

namespace Pharmacy.Core
{
    public class BaseEntity:IDbEntity
    {
        public int Id { get; private set; }
    }
}
