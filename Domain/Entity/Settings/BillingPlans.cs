﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entity.Settings
{
    public class BillingPlans
    {
        public long BillingPlanId { get; set; }
        public Guid BillingPlanKey { get; set; }
        public int LanguageId { get; set; }
        [Required(ErrorMessage = "Billing Plan Name is required")]
        [DisplayName("Billing Plan Name")]
        public string BillingPlanName { get; set; }
        public DateTime? EntryDateTime { get; set; }
        public long? EntryBy { get; set; }
        public DateTime? LastModifyDate { get; set; }
        public long? LastModifyBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        public long? DeletedBy { get; set; }
        public string? Status { get; set; }
        public int total_row { get; set; }
    }
}
