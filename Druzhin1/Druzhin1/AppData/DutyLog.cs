//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Druzhin1.AppData
{
    using System;
    using System.Collections.Generic;
    
    public partial class DutyLog
    {
        public Nullable<int> LogID { get; set; }
        public Nullable<System.DateTime> DateTimeStart { get; set; }
        public Nullable<System.DateTime> DateTimeEnd { get; set; }
        public int GuardID { get; set; }
    
        public virtual Guard Guard { get; set; }
    }
}
