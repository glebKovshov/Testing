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
    
    public partial class Advertisements
    {
        public int ad_id { get; set; }
        public int advertiser_id { get; set; }
        public string content { get; set; }
        public System.DateTime start_date { get; set; }
        public System.DateTime end_date { get; set; }
        public string target_audience { get; set; }
    
        public virtual Users Users { get; set; }
    }
}
