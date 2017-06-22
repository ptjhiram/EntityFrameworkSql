﻿using System;
using System.Collections.Generic;

namespace NuDataDb.EF
{
    public partial class Applications
    {
        public Applications()
        {
            AppLoginHistories = new HashSet<AppLoginHistories>();
            AppSettings = new HashSet<AppSettings>();
            AppUserSettings = new HashSet<AppUserSettings>();
            EndUserLicenseAgreements = new HashSet<EndUserLicenseAgreements>();
            UserAuthentications = new HashSet<UserAuthentications>();
        }

        public string ApplicationName { get; set; }
        public Guid ApplicationId { get; set; }
        public string Description { get; set; }
        public bool BannerEnable { get; set; }
        public string BannerMessage { get; set; }
        public string LicneseAgreement { get; set; }
        public Guid LastUpdatedByUser { get; set; }
        public string SupportNumber { get; set; }
        public string SupportEmail { get; set; }
        public string SupportAvailability { get; set; }

        public virtual ICollection<AppLoginHistories> AppLoginHistories { get; set; }
        public virtual ICollection<AppSettings> AppSettings { get; set; }
        public virtual ICollection<AppUserSettings> AppUserSettings { get; set; }
        public virtual ICollection<EndUserLicenseAgreements> EndUserLicenseAgreements { get; set; }
        public virtual ICollection<UserAuthentications> UserAuthentications { get; set; }
    }
}