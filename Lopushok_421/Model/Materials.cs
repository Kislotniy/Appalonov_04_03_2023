//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Lopushok_421.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Materials
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Materials()
        {
            this.Products_Material = new HashSet<Products_Material>();
        }
    
        public int id_material { get; set; }
        public string Name_Material { get; set; }
        public int id_Type_Material { get; set; }
        public Nullable<int> QuantityInPackage { get; set; }
        public int id_Unit { get; set; }
        public Nullable<int> QuantityInStorage { get; set; }
        public Nullable<int> MinRemains { get; set; }
        public Nullable<decimal> CostMaterial { get; set; }
    
        public virtual Type_Materials Type_Materials { get; set; }
        public virtual Units Units { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Products_Material> Products_Material { get; set; }
    }
}
