//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Datality.Tinker
{
    using System;
    using System.Collections.Generic;
    
    public partial class Toxicity : Bass
    {
        public string Type { get; set; }
        public string Test { get; set; }
        public string Result { get; set; }
        public string Source { get; set; }
    
        public virtual Chemical Chemical { get; set; }
    }
}
