//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace COFFE
{
    using System;
    using System.Collections.Generic;
    
    public partial class Warehouse
    {
        public int ID_Item { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public Nullable<int> Supplier_ID { get; set; }
        public Nullable<int> Products_ID { get; set; }
    
        public virtual Products Products { get; set; }
        public virtual Suppliers Suppliers { get; set; }
    }
}
