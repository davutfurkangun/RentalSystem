using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalSystem.entity
{
    internal class BaseLongEntity
    {
        public long Id { get; set; }
        public override string ToString()
        {
            return $"ID: {Id}";
        }


    }
}
