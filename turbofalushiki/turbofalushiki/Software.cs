using System;
using System.Collections.Generic;
using System.Text;

namespace turbofalushiki
{
    internal class Software : IComparable, ICloneable
    {
        public string Title { get; private set; }
        public string Version { get; private set; }
        public decimal Price { get; private set; }
        public License SoftwareLicense { get; private set; }
        public Software(string title, string version, decimal price, License license)
        {
            Title = title;
            Version = version;
            Price = price;
            SoftwareLicense = license;
        }
        public void SetTitle(string newTitle)
        {
            Title = newTitle;
        }
        public int CompareTo(object obj)
        {
            if (obj == null) return -1;
            if (obj is Software otherSoftware)
            {
                return this.Price.CompareTo(otherSoftware.Price);
            }
            else
            {
                throw new ArgumentException("Обьект не является типом Software");
            }
        }
        public object Clone()
        {
            License clonedLicense = (License)this.SoftwareLicense.Clone();
            return new Software(this.Title, this.Version, this.Price, clonedLicense);
        }
        public override string ToString()
        {
            return $"{Title} {Version} | Цена: {Price:C} | Лицензия: {SoftwareLicense}";
        }
    }
}
