using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace turbofalushiki
{
    internal class License : ICloneable
    {
        public string Key { get; private set; }
        public int DurationDays { get; private set; }
        public License(string key, int durationDays)
        {
            Key = key;
            DurationDays = durationDays;
        }
        public void UpdateLicense(string newKey, int newDurationDays)
        {
            Key = newKey;
            DurationDays = newDurationDays;
        }
        public object Clone()
        {
            return new License(this.Key, this.DurationDays);
        }
        public override string ToString()
        {
            return $"{Key} ({DurationDays} дн.)";
        }
    }
}
