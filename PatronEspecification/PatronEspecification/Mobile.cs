using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronEspecification
{
    public enum BrandName
    {
        Samsung, Apple, Htc
    }

    public enum Type
    {
        Basic, Smart
    }


    public class Mobile
    {
        public BrandName BrandName { get; set; }
        public Type Type { get; set; }
        public int Value { get; set; }


        public Mobile(BrandName brandname, Type type)
        {
            this.BrandName = brandname;
            this.Type = type;
        }
        public Mobile(BrandName brandname, Type type,int value)
        {
            this.BrandName = brandname;
            this.Value = value;
        }
    }
}
