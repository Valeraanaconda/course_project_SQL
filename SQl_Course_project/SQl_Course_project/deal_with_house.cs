//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SQl_Course_project
{
    using System;
    using System.Collections.Generic;
    
    public partial class deal_with_house
    {
        public int ID_deal { get; set; }
        public Nullable<int> cadastral_number { get; set; }
        public Nullable<int> number_of_rooms { get; set; }
        public Nullable<int> number_of_floor { get; set; }
        public Nullable<double> area_h { get; set; }
        public string customer { get; set; }
        public string saller { get; set; }
        public Nullable<double> price { get; set; }
    }
}