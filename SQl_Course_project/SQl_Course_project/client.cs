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
    
    public partial class client
    {
        public int ID_client { get; set; }
        public string Full_name { get; set; }
        public string passport_ID { get; set; }
        public string issued_by { get; set; }
        public Nullable<int> year_of_birth { get; set; }
        public Nullable<int> date_of_birth { get; set; }
        public Nullable<int> month_of_birth { get; set; }
        public string place_of_residence { get; set; }
    }
}