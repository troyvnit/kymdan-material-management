﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KMM.Model.Models;

namespace KMM.Models
{
    public class MaterialProposalViewModel : BaseModel
    {
        public string Description { get; set; }
        public string ManagementCode { get; set; }
        public string ProposalCode { get; set; }
        public string ProposerUserName { get; set; }
        public string ImplementerUserName { get; set; }
        public Department Department { get; set; }
        public ProgressStatus ProgressStatus { get; set; }
        public bool Finished { get; set; }
        public bool Approved { get; set; }
        public string Note { get; set; }
    }
}