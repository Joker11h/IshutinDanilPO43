using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleFleetApp
{
    internal interface IStorable
    {
        string FilePath { get; }
        void Save(string path);
    }
}
