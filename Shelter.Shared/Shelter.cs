using System;
using System.Collections.Generic;

namespace Shelter.Shared
{
    public class Shelter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Animal> Animals { get; set; }
    }
}