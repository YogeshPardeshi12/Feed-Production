//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataContext
{
    using System;
    
    public partial class Sp_MMaterial_EntityReport_Result
    {
        public long MaterialId { get; set; }
        public string MaterialCode { get; set; }
        public string MaterialName { get; set; }
        public Nullable<long> MatrialUnit { get; set; }
        public Nullable<long> PackingId { get; set; }
        public string ForCasteFlag { get; set; }
        public string AcFlag { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string Remark { get; set; }
    }
}