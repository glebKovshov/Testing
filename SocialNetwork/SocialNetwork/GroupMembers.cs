//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SocialNetwork
{
    using System;
    using System.Collections.Generic;
    
    public partial class GroupMembers
    {
        public int membership_id { get; set; }
        public int group_id { get; set; }
        public int user_id { get; set; }
        public Nullable<System.DateTime> joined_at { get; set; }
    
        public virtual Groups Groups { get; set; }
        public virtual Users Users { get; set; }
    }
}
