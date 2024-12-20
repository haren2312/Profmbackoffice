﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIN.Domain.FomMgt.AssetMaintenanceMgt
{

    [Table("tblErpFomSection")]
    public class TblErpFomSection : AutoGeneratedIdKeyAuditableCreatedEntity<int>
    {
        [StringLength(20)]
        [Key]
        public string SectionCode { get; set; }
        [StringLength(200)]
        public string Name { get; set; }
        [StringLength(200)]
        public string NameAr { get; set; }
        [StringLength(250)]
        public string Description { get; set; }
        public bool ForAssetMgt { get; set; }
    }

    [Table("tblErpFomAssetMaster")]
    public class TblErpFomAssetMaster : AutoGeneratedIdKeyAuditableCreatedEntity<int>
    {
        [StringLength(20)]
        [Key]
        public string AssetCode { get; set; }
        [StringLength(200)]
        public string Name { get; set; }
        [StringLength(200)]
        public string NameAr { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
        [StringLength(150)]
        public string Location { get; set; }
        [StringLength(100)]
        public string Classification { get; set; }
        [StringLength(100)]
        public string RouteGroup { get; set; }
        [StringLength(100)]
        public string JobPlan { get; set; }
        public bool HasChild { get; set; } = false;

        [ForeignKey(nameof(SectionCode))]
        public TblErpFomSection Section { get; set; }
        [StringLength(20)]
        public string SectionCode { get; set; }


        [ForeignKey(nameof(DeptCode))]
        public TblErpFomDepartment Department { get; set; }
        [StringLength(20)]
        public string DeptCode { get; set; }


        [ForeignKey(nameof(ContractCode))]
        public TblErpFomCustomerContract CustomerContract { get; set; }
        [StringLength(20)]
        public string ContractCode { get; set; }
        public DateTime? InstallDate { get; set; }
        public DateTime? ReplacementDate { get; set; }
        public bool? IsWrittenOff { get; set; }
        public int? AssetScale { get; set; }
    }

    [Table("tblErpFomAssetMasterChild")]
    public class TblErpFomAssetMasterChild : AutoGenerateIdKey<int>
    {
        [StringLength(20)]
        [Key]
        public string ChildCode { get; set; }
        [StringLength(200)]
        public string Name { get; set; }

        [ForeignKey(nameof(AssetCode))]
        public TblErpFomAssetMaster AssetMaster { get; set; }
        [StringLength(20)]
        public string AssetCode { get; set; }
    }

    [Table("tblErpFomAssetMasterTask")]
    public class TblErpFomAssetMasterTask : PrimaryKey<int>
    {
        [ForeignKey(nameof(AssetCode))]
        public TblErpFomAssetMaster AssetMaster { get; set; }
        [StringLength(20)]
        public string AssetCode { get; set; }


        [ForeignKey(nameof(ActCode))]
        public TblErpFomActivities Activity { get; set; }
        [StringLength(20)]
        public string ActCode { get; set; }


        [ForeignKey(nameof(ResTypeCode))]
        public TblErpFomResourceType ResourceType { get; set; }
        //[StringLength(50)]
        public string ResTypeCode { get; set; }
    }


    [Table("tblErpFomJobPlanMaster")]
    public class TblErpFomJobPlanMaster : AutoGeneratedIdKeyAuditableCreatedEntity<int>
    {
        [StringLength(20)]
        [Key]
        public string JobPlanCode { get; set; }

        public DateTime JobPlanDate { get; set; }

        [ForeignKey(nameof(ContractCode))]
        public TblErpFomCustomerContract CustomerContract { get; set; }
        [StringLength(20)]
        public string ContractCode { get; set; }

        [ForeignKey(nameof(AssetCode))]
        public TblErpFomAssetMaster AssetMaster { get; set; }
        [StringLength(20)]
        public string AssetCode { get; set; }

        public DateTime ContStartDate { get; set; }
        public DateTime ContEndDate { get; set; }
        [StringLength(20)]
        public string Frequency { get; set; }

        [StringLength(200)]
        public string PreFixCode { get; set; }

        [ForeignKey(nameof(DeptCode))]
        public TblErpFomDepartment Department { get; set; }
        [StringLength(20)]
        public string DeptCode { get; set; }

        [ForeignKey(nameof(SectionCode))]
        public TblErpFomSection Section { get; set; }
        [StringLength(20)]
        public string SectionCode { get; set; }


        [StringLength(200)]
        public string PreparedBy { get; set; }
        [StringLength(200)]
        public string ApprovedBy { get; set; }
        public DateTime PlanStartDate { get; set; }

        [StringLength(500)]
        public string Remarks { get; set; }

        public bool NoJobPlanKpi { get; set; } = false; //Job Plan for Asset is not included KPI
        public bool CanGenChildSch { get; set; } = false; //Generate Schedule for Child Items as well, for true Child Schedules are available
        public bool ChildHasDiffFreq { get; set; } = false; //Child Item have Different Frequency for PPM
        public bool Approve { get; set; } = false;
        public bool IsClosed { get; set; } = false;
        public bool IsVoid { get; set; } = false;

    }


    [Table("tblErpFomJobPlanChildSchedule")]
    public class TblErpFomJobPlanChildSchedule : PrimaryKey<long>
    {

        [ForeignKey(nameof(JobPlanCode))]
        public TblErpFomJobPlanMaster JobPlanMaster { get; set; }
        [StringLength(20)]
        public string JobPlanCode { get; set; }

        [StringLength(20)]
        public string AssetCode { get; set; }
        [StringLength(20)]
        public string ChildCode { get; set; }
        [StringLength(20)]
        public string Frequency { get; set; }
        public DateTime PlanStartDate { get; set; }

        [StringLength(250)]
        public string Remarks { get; set; }

        public bool IsClosed { get; set; } = false;
        public DateTime ClosedDate { get; set; }
        [StringLength(250)]
        public string ClosedBy { get; set; }
    }


    [Table("tblErpFomJobPlanMessageLog")]
    public class TblErpFomJobPlanMessageLog : PrimaryKey<int>
    {
        [ForeignKey(nameof(JobPlanCode))]
        public TblErpFomJobPlanMaster JobPlanMaster { get; set; }
        [StringLength(20)]
        public string JobPlanCode { get; set; }

        [StringLength(500)]
        public string Message { get; set; }

        public DateTime MessageDate { get; set; }       
    }


    [Table("tblErpFomJobPlanScheduleClosure")]
    public class TblErpFomJobPlanScheduleClosure : PrimaryKey<long>
    {
        [ForeignKey(nameof(ChildScheduleId))]
        public TblErpFomJobPlanChildSchedule JobPlanChildSchedule { get; set; }
        public long ChildScheduleId { get; set; }

        [StringLength(20)]
        public string JobPlanCode { get; set; }

        [StringLength(20)]
        public string AssetCode { get; set; }
        [StringLength(20)]
        public string ChildCode { get; set; }
        [StringLength(20)]
        public string Frequency { get; set; }
        public DateTime PlanStartDate { get; set; }

        [StringLength(500)]
        public string Remarks { get; set; }
        public DateTime ClosingDate { get; set; }

        [StringLength(250)]
        public string ClosedBy { get; set; }
    }

    [Table("tblErpFomJobPlanScheduleClosureItem")]
    public class TblErpFomJobPlanScheduleClosureItem : PrimaryKey<long>
    {
        [ForeignKey(nameof(ScheduleClosureId))]
        public TblErpFomJobPlanScheduleClosure JobPlanScheduleClosure { get; set; }
        public long ScheduleClosureId { get; set; }

        [StringLength(500)]
        public string Description { get; set; }
        [StringLength(100)]
        public string Quantity { get; set; }
        public int? Hours { get; set; }
        [StringLength(20)]
        public string Source { get; set; }
        public DateTime CreatedDate { get; set; }
    }

}
