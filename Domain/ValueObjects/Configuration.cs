using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObjects
{
    public class Configuration
    {
        public string? Id { get; set; } = string.Empty;
        public string? Value { get; set; } = string.Empty;


        public Configuration() { }
    }
}
