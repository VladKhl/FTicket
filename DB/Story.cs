//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FTicket.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Story
    {
        public int id { get; set; }
        public int idMatch { get; set; }
        public Nullable<int> Sector { get; set; }
        public Nullable<int> Row { get; set; }
        public Nullable<int> Place { get; set; }
        public int idClient { get; set; }
        public Nullable<int> Price { get; set; }
    
        public virtual Match Match { get; set; }
        public virtual Client Client { get; set; }
    }
}
