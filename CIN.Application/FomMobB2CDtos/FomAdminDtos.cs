﻿using AutoMapper;
using CIN.Domain.FomMgt;
using CIN.DB.One.Migrations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using CIN.Domain.OpeartionsMgt;
using CIN.Domain.SalesSetup;
using CIN.Domain.SystemSetup;
using CIN.Domain.InventorySetup;
using Microsoft.AspNetCore.Http;
using CIN.Application.FomMobDtos;

namespace CIN.Application.FomMobB2CDtos
{
    [AutoMap(typeof(TblSndDefCustomerMaster))]
    public class TblProfmClientMasterDto
    {
        public int Id { get; set; }
        public string ClientName { get; set; }
        public string ClientName_Ar { get; set; }
        public string ClientShortName { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Area { get; set; }
        public string PrimaryAddress { get; set; }
        public string SecondaryAddress { get; set; }
        public string RegisteredMobile { get; set; }
        public string RegisteredEmail { get; set; }
        public string AlternameMobile { get; set; }
        public string AlternateEmail { get; set; }
        public string LandLine1 { get; set; }
        public string LandLine2 { get; set; }
        public string ContactPerson1 { get; set; }
        public string Designation1 { get; set; }
        public string ContactPerson2 { get; set; }
        public string Designation2 { get; set; }
        public string VATNum { get; set; }
        public string CRNum { get; set; }
        public string TypeOfBusiness { get; set; }
        public string NumOfEmp { get; set; }
        public string LogoPath { get; set; }
        public float GeoLocLat { get; set; }
        public float GeoLocLan { get; set; }
        public float GeoLocGain { get; set; }
        public DateTime InActiveDate { get; set; }
        public string LoginPassword { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
    }

    //[AutoMap(typeof(TblErpFomSysCompany))]
    //public class TblErpFomSysCompanyDto
    //{
    //    public int Id { get; set; }

    //    [StringLength(100)]
    //    public string CompanyName { get; set; }

    //    [StringLength(100)]
    //    public string CompanyNameAr { get; set; }

    //    [Required]
    //    [StringLength(500)]
    //    public string CompanyAddress { get; set; }

    //    [StringLength(500)]
    //    public string CompanyAddressAr { get; set; }

    //    [StringLength(20)]
    //    public string Phone { get; set; }

    //    [Required]
    //    [StringLength(100)]
    //    public string Email { get; set; }
    //    [StringLength(50)]
    //    public string VATNumber { get; set; }
    //    [StringLength(12)]
    //    public string DateFormat { get; set; }

    //    [StringLength(15)]
    //    public string GeoLocLatitude { get; set; }

    //    [StringLength(15)]
    //    public string GeoLocLongitude { get; set; }

    //    [StringLength(100)]
    //    public string LogoURL { get; set; }

    //    //[StringLength(1)]
    //    //public char PriceDecimal { get; set; }

    //    //[StringLength(1)]
    //    //public char QuantityDecimal { get; set; }

    //    [StringLength(20)]
    //    public string City { get; set; }

    //    [StringLength(20)]
    //    public string State { get; set; }

    //    [StringLength(50)]
    //    public string Country { get; set; }
    //    [StringLength(20)]
    //    public string Mobile { get; set; }
    //    [StringLength(100)]
    //    public string Website { get; set; }
    //    [StringLength(200)]
    //    public string LogoImagePath { get; set; }

    //    [StringLength(50)]
    //    public string CrNumber { get; set; }
    //    [StringLength(80)]
    //    public string CcNumber { get; set; }
    //    public bool IsActive { get; set; }
    //    public DateTime CreatedOn { get; set; }
    //    public string CreatedBy { get; set; }


    //}

    //[AutoMap(typeof(TblErpFomSysCompanyBranch))]
    //public class TblErpFomSysCompanyBranchDto
    //{
    //    public int Id { get; set; }
    //    public int CompanyId { get; set; }
    //    public int? ZoneId { get; set; }
    //    [StringLength(20)]
    //    public string BranchCode { get; set; }
    //    [StringLength(150)]
    //    public string BankName { get; set; }
    //    [StringLength(150)]
    //    public string BankNameAr { get; set; }
    //    [StringLength(100)]
    //    public string BranchName { get; set; }
    //    [StringLength(500)]
    //    public string BranchAddress { get; set; }
    //    [StringLength(500)]
    //    public string BranchAddressAr { get; set; }
    //    [StringLength(80)]
    //    public string AccountNumber { get; set; }
    //    [StringLength(20)]
    //    public string Phone { get; set; }
    //    [StringLength(20)]
    //    public string Mobile { get; set; }
    //    public string City { get; set; }
    //    [StringLength(20)]
    //    public string State { get; set; } // ref state
    //    [StringLength(100)]
    //    public string AuthorityName { get; set; }
    //    [StringLength(15)]
    //    public string GeoLocLatitude { get; set; }
    //    [StringLength(15)]
    //    public string GeoLocLongitude { get; set; }
    //    [StringLength(512)]
    //    public string Remarks { get; set; }
    //    [StringLength(80)]
    //    public string Iban { get; set; }
    //    public bool IsActive { get; set; }
    //    public DateTime CreatedOn { get; set; }
    //    public string CreatedBy { get; set; }
    //}

    //[AutoMap(typeof(TblErpFomSysUser))]
    //public class TblErpFomSysUserDto
    //{
    //    public int Id { get; set; }
    //    [StringLength(20)]
    //    public string UserCode { get; set; }
    //    [StringLength(100)]
    //    public string UserName { get; set; }
    //    [StringLength(128)]
    //    public string Password { get; set; }
    //    [StringLength(15)]
    //    public string UserType { get; set; } //Admin, Manager, etc
    //    [StringLength(256)]
    //    public string UserEmail { get; set; }
    //    [StringLength(256)]
    //    public string SwpireCardId { get; set; }
    //    public string PrimaryBranch { get; set; } // Ref branchCode
    //    [StringLength(128)]
    //    public string ImagePath { get; set; }
    //    public bool IsActive { get; set; }
    //    public DateTime ModifiedOn { get; set; }
    //    public string ModifiedBy { get; set; }
    //    public bool IsLoginAllow { get; set; }
    //    public bool IsSigned { get; set; }
    //    [StringLength(50)]
    //    public string SiteCode { get; set; }
    //    public string LoginType { get; set; } //Employee,Teacher,Driver

    //}


    [AutoMap(typeof(TblSndDefCustomerMaster))]
    public class TblSndDefCustomerMasterDto
    {

        public int Id { get; set; }

        [StringLength(20)]
        public string CustCode { get; set; }
        [StringLength(200)]
        [Required]
        public string CustName { get; set; }
        [StringLength(200)]
        public string CustArbName { get; set; }
        [StringLength(50)]
        public string CustAlias { get; set; }
        public short CustType { get; set; }

        [StringLength(50)]
        public string VATNumber { get; set; }
        public string CustCatCode { get; set; }
        public short CustRating { get; set; }
        public string SalesTermsCode { get; set; }
        [Column(TypeName = "decimal(17,3)")]
        public decimal CustDiscount { get; set; }
        [Column(TypeName = "decimal(17,3)")]
        public decimal CustCrLimit { get; set; }
        [Column(TypeName = "decimal(17,3)")]
        public decimal? CustOutStandBal { get; set; }

        [Column(TypeName = "decimal(17,3)")]
        public decimal? CustAvailCrLimit { get; set; }

        [StringLength(20)]
        public string CustSalesRep { get; set; }
        [StringLength(100)]
        public string CustSalesArea { get; set; }
        public string CustARAc { get; set; }
        [Column(TypeName = "date")]
        public DateTime CustLastPaidDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime CustLastSalesDate { get; set; }
        [Column(TypeName = "decimal(17,3)")]
        public decimal CustLastPayAmt { get; set; }
        [StringLength(500)]
        public string CustAddress1 { get; set; }
        [StringLength(20)]
        public string CustCityCode1 { get; set; }
        [StringLength(50)]
        public string CustMobile1 { get; set; }
        [StringLength(50)]
        public string CustPhone1 { get; set; }
        [StringLength(500)]
        public string CustEmail1 { get; set; }
        [StringLength(200)]
        public string CustContact1 { get; set; }
        [StringLength(500)]
        public string CustAddress2 { get; set; }
        public string CustCityCode2 { get; set; }
        [StringLength(50)]
        public string CustMobile2 { get; set; }
        [StringLength(50)]
        public string CustPhone2 { get; set; }
        [StringLength(500)]
        public string CustEmail2 { get; set; }
        [StringLength(200)]
        public string CustContact2 { get; set; }
        [StringLength(200)]
        public string CustUDF1 { get; set; }
        [StringLength(200)]
        public string CustUDF2 { get; set; }
        [StringLength(200)]
        public string CustUDF3 { get; set; }
        public bool CustAllowCrsale { get; set; }
        public bool CustAlloCrOverride { get; set; }
        public bool CustOnHold { get; set; }
        public bool CustAlloChkPay { get; set; }
        public bool CustSetPriceLevel { get; set; }
        public short CustPriceLevel { get; set; }
        public bool CustIsVendor { get; set; }
        public bool CustArAcBranch { get; set; }
        public string CustArAcCode { get; set; }
        public string CustDefExpAcCode { get; set; }
        public string CustARAdjAcCode { get; set; }
        public string CustARDiscAcCode { get; set; }
        [StringLength(50)]
        public string CrNumber { get; set; }
        [StringLength(200)]
        public string CustNameAliasEn { get; set; }
        [StringLength(200)]
        public string CustNameAliasAr { get; set; }
        public bool IsActive { get; set; }
        [Column(TypeName = "date")]
        public DateTime? CreatedOn { get; set; }
        [Column(TypeName = "date")]
        public DateTime? ModifiedOn { get; set; }

    }



    public class SndDefCustomerMasterDto
    {

        public int Id { get; set; }

        [StringLength(20)]
        public string CustCode { get; set; }
        [StringLength(200)]
        [Required]
        public string CustName { get; set; }
        [StringLength(200)]
        public string CustArbName { get; set; }
        [StringLength(50)]
        public string CustAlias { get; set; }
        public short CustType { get; set; }

        [StringLength(50)]
        public string VATNumber { get; set; }
        public string CustCatCode { get; set; }
        public short CustRating { get; set; }
        public string SalesTermsCode { get; set; }
        [Column(TypeName = "decimal(17,3)")]
        public decimal CustDiscount { get; set; }
        [Column(TypeName = "decimal(17,3)")]
        public decimal CustCrLimit { get; set; }
        [Column(TypeName = "decimal(17,3)")]
        public decimal? CustOutStandBal { get; set; }

        [Column(TypeName = "decimal(17,3)")]
        public decimal? CustAvailCrLimit { get; set; }

        [StringLength(20)]
        public string CustSalesRep { get; set; }
        [StringLength(100)]
        public string CustSalesArea { get; set; }
        public string CustARAc { get; set; }
        [Column(TypeName = "date")]
        public DateTime CustLastPaidDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime CustLastSalesDate { get; set; }
        [Column(TypeName = "decimal(17,3)")]
        public decimal CustLastPayAmt { get; set; }
        [StringLength(500)]
        public string CustAddress1 { get; set; }
        [StringLength(20)]
        public string CustCityCode1 { get; set; }
        [StringLength(50)]
        public string CustMobile1 { get; set; }
        [StringLength(50)]
        public string CustPhone1 { get; set; }
        [StringLength(500)]
        public string CustEmail1 { get; set; }
        [StringLength(200)]
        public string CustContact1 { get; set; }
        [StringLength(500)]
        public string CustAddress2 { get; set; }
        public string CustCityCode2 { get; set; }
        [StringLength(50)]
        public string CustMobile2 { get; set; }
        [StringLength(50)]
        public string CustPhone2 { get; set; }
        [StringLength(500)]
        public string CustEmail2 { get; set; }
        [StringLength(200)]
        public string CustContact2 { get; set; }
        [StringLength(200)]
        public string CustUDF1 { get; set; }
        [StringLength(200)]
        public string CustUDF2 { get; set; }
        [StringLength(200)]
        public string CustUDF3 { get; set; }
        public bool CustAllowCrsale { get; set; }
        public bool CustAlloCrOverride { get; set; }
        public bool CustOnHold { get; set; }
        public bool CustAlloChkPay { get; set; }
        public bool CustSetPriceLevel { get; set; }
        public short CustPriceLevel { get; set; }
        public bool CustIsVendor { get; set; }
        public bool CustArAcBranch { get; set; }
        public string CustArAcCode { get; set; }
        public string CustDefExpAcCode { get; set; }
        public string CustARAdjAcCode { get; set; }
        public string CustARDiscAcCode { get; set; }
        [StringLength(50)]
        public string CrNumber { get; set; }
        [StringLength(200)]
        public string CustNameAliasEn { get; set; }
        [StringLength(200)]
        public string CustNameAliasAr { get; set; }
        public bool IsActive { get; set; }
        [Column(TypeName = "date")]
        public DateTime? CreatedOn { get; set; }
        [Column(TypeName = "date")]
        public DateTime? ModifiedOn { get; set; }

    }


    public class InputImageFromCustomerDto
    {
        public int Id { get; set; }
        public IFormFile Image1IForm { get; set; }
        public IFormFile Image2IForm { get; set; }
        public IFormFile Image3IForm { get; set; }
        public string WebRoot { get; set; }
    }



    public class InputImageThumbnailDto
    {
        public int Id { get; set; }
        public IFormFile Image1IForm { get; set; }
        public string WebRoot { get; set; }
    }
    public class InputCreateUpdateCustomerDto : SndDefCustomerMasterDto
    {
        public bool IsFromMobile { get; set; } = false;
        public bool IsFromWeb { get; set; } = false;
    }


    public class CreateUpdateResultDto
    {
        public bool IsSuccess { get; set; }
        public int ErrorId { get; set; }             //error id
        public string ErrorMsg { get; set; }

    }



    //[AutoMap(typeof(TblSndDefCustomerMaster))]
    //public class TblSndDefCustomerMasterDto : AutoActiveGenerateIdAuditableKeyDto<int>
    //{

    //    [StringLength(20)]
    //    public string CustCode { get; set; }
    //    [StringLength(200)]

    //    public string CustName { get; set; }
    //    [StringLength(200)]
    //    public string CustArbName { get; set; }
    //    [StringLength(50)]
    //    public string CustAlias { get; set; }
    //    public short CustType { get; set; }

    //    [StringLength(20)]
    //    public string CustCatCode { get; set; }

    //    [StringLength(50)]
    //    public string VATNumber { get; set; }
    //    public short CustRating { get; set; }

    //    [StringLength(20)]
    //    public string SalesTermsCode { get; set; }
    //    // [Column(TypeName = "decimal(7,2)")]
    //    public decimal CustDiscount { get; set; }
    //    //  [Column(TypeName = "decimal(12,3)")]
    //    public decimal CustCrLimit { get; set; }
    //    public decimal? CustOutStandBal { get; set; }
    //    public decimal? CustAvailCrLimit { get; set; }


    //    // [StringLength(20)]
    //    public string CustSalesRep { get; set; }
    //    [StringLength(100)]
    //    public string CustSalesArea { get; set; }


    //    [StringLength(50)]
    //    public string CustARAc { get; set; }
    //    //   [Column(TypeName = "date")]
    //    public DateTime CustLastPaidDate { get; set; }
    //    // [Column(TypeName = "date")]
    //    public DateTime CustLastSalesDate { get; set; }
    //    //   [Column(TypeName = "decimal(12,3)")]
    //    public decimal CustLastPayAmt { get; set; }
    //    [StringLength(500)]
    //    public string CustAddress1 { get; set; }

    //    [StringLength(20)]
    //    public string CustCityCode1 { get; set; }
    //    [StringLength(50)]
    //    public string CustMobile1 { get; set; }
    //    [StringLength(50)]
    //    public string CustPhone1 { get; set; }
    //    [StringLength(500)]
    //    public string CustEmail1 { get; set; }
    //    [StringLength(200)]
    //    public string CustContact1 { get; set; }
    //    [StringLength(500)]
    //    public string CustAddress2 { get; set; }
    //    //  [Required]
    //    [StringLength(20)]
    //    public string CustCityCode2 { get; set; }
    //    [StringLength(50)]
    //    public string CustMobile2 { get; set; }
    //    [StringLength(50)]
    //    public string CustPhone2 { get; set; }
    //    [StringLength(500)]
    //    public string CustEmail2 { get; set; }
    //    [StringLength(200)]
    //    public string CustContact2 { get; set; }
    //    [StringLength(200)]
    //    public string CustUDF1 { get; set; }
    //    [StringLength(200)]
    //    public string CustUDF2 { get; set; }
    //    [StringLength(200)]
    //    public string CustUDF3 { get; set; }
    //    public bool CustAllowCrsale { get; set; }
    //    public bool CustAlloCrOverride { get; set; }
    //    public bool CustOnHold { get; set; }
    //    public bool CustAlloChkPay { get; set; }
    //    public bool CustSetPriceLevel { get; set; }
    //    public short CustPriceLevel { get; set; }
    //    public bool CustIsVendor { get; set; }
    //    public bool CustArAcBranch { get; set; }

    //    [StringLength(50)]
    //    public string CustArAcCode { get; set; }

    //    [StringLength(50)]
    //    public string CustDefExpAcCode { get; set; }

    //    [StringLength(50)]
    //    public string CustARAdjAcCode { get; set; }

    //    [StringLength(50)]
    //    public string CustARDiscAcCode { get; set; }

    //    //public string stateone { get; set; }
    //    //public string countryone { get; set; }
    //    //public string statetwo { get; set; }
    //    //public string countrytwo { get; set; }
    //    [StringLength(50)]
    //    public string CrNumber { get; set; }
    //    [StringLength(200)]
    //    public string CustNameAliasEn { get; set; }
    //    [StringLength(200)]
    //    public string CustNameAliasAr { get; set; }

    //   // public int NumberOfSites { get; set; }
    //}



    [AutoMap(typeof(TblErpInvItemMaster))]
    public class TblErpInvItemMasterDto
    {

        public int Id { get; set; }
        [StringLength(20)]
        public string ItemCode { get; set; }

        [StringLength(20)]
        public string HSNCode { get; set; }

        [StringLength(100)]
        public string ItemDescription { get; set; }

        [StringLength(100)]
        public string ItemDescriptionAr { get; set; }

        [StringLength(250)]
        public string ShortName { get; set; }
        [StringLength(250)]
        public string ShortNameAr { get; set; }

      
        [StringLength(20)]
        public string ItemCat { get; set; }

        [StringLength(20)]
        public string ItemSubCat { get; set; }

        [StringLength(20)]
        public string ItemClass { get; set; }

        [StringLength(20)]
        public string ItemSubClass { get; set; }

        [StringLength(10)]
        public string ItemBaseUnit { get; set; }

        [StringLength(10)]
        public string ItemAvgCost { get; set; }

        [StringLength(10)]
        public string ItemStandardCost { get; set; }

        [StringLength(20)]
        public string ItemPrimeVendor { get; set; }

        [Column(TypeName = "decimal(12,5)")]
        public decimal ItemStandardPrice1 { get; set; }

        [Column(TypeName = "decimal(12,5)")]
        public decimal ItemStandardPrice2 { get; set; }

        [Column(TypeName = "decimal(12,5)")]
        public decimal ItemStandardPrice3 { get; set; }

        [StringLength(20)]
        public string ItemType { get; set; }

        [StringLength(20)]
        public decimal ItemQty { get; set; }
        public string DeptCodes { get; set; }

        [StringLength(20)]
        public string ItemTracking { get; set; }
        [StringLength(20)]
        public string ItemWeight { get; set; }

        [StringLength(20)]
        public string ItemTaxCode { get; set; }
        public bool AllowPriceOverride { get; set; }
        public bool AllowDiscounts { get; set; }
        public bool AllowQuantityOverride { get; set; }
        public bool IsActive { get; set; }


    }



    public class ErpInvItemMasterDto
    {

        public int Id { get; set; }
        [StringLength(20)]
        public string ItemCode { get; set; }

        [StringLength(20)]
        public string HSNCode { get; set; }

        [StringLength(100)]
        public string ItemDescription { get; set; }

        [StringLength(100)]
        public string ItemDescriptionAr { get; set; }

        [StringLength(250)]
        public string ShortName { get; set; }
        [StringLength(250)]
        public string ShortNameAr { get; set; }
        [StringLength(20)]
        public string ItemCat { get; set; }

        [StringLength(20)]
        public string ItemSubCat { get; set; }

        [StringLength(20)]
        public string ItemClass { get; set; }

        [StringLength(20)]
        public string ItemSubClass { get; set; }

        [StringLength(10)]
        public string ItemBaseUnit { get; set; }

        [StringLength(10)]
        public string ItemAvgCost { get; set; }

        [StringLength(10)]
        public string ItemStandardCost { get; set; }

        [StringLength(20)]
        public string ItemPrimeVendor { get; set; }
        public decimal ItemStandardPrice1 { get; set; }    
        public decimal ItemStandardPrice2 { get; set; }   
        public decimal ItemStandardPrice3 { get; set; }

        [StringLength(20)]
        public string ItemType { get; set; }

        public string[] DeptCodes { get; set; }

        [StringLength(20)]
        public string ItemTracking { get; set; }
        [StringLength(20)]
        public string ItemWeight { get; set; }

        [StringLength(20)]
        public string ItemTaxCode { get; set; }
        public bool AllowPriceOverride { get; set; }
        public bool AllowDiscounts { get; set; }
        public bool AllowQuantityOverride { get; set; }
        public bool IsActive { get; set; }


    }

    [AutoMap(typeof(TblInvDefSubCategory))]
    public class TblInvDefSubCategoryDto
    {
        public int Id { get; set; }

        [StringLength(20)]
        public string ItemSubCatCode { get; set; }
        [StringLength(41)]
        public string SubCatKey { get; set; }
        [StringLength(20)]
        public string ItemCatCode { get; set; }
        [StringLength(50)]
        public string ItemSubCatName { get; set; }
        [StringLength(50)]
        public string ItemSubCatNameAr { get; set; }
        [StringLength(50)]
        public string ItemSubCatDesc { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }

    }


    public class InvDefSubCategoryDto
    {
        public int Id { get; set; }

        [StringLength(20)]
        public string ItemSubCatCode { get; set; }
        [StringLength(41)]
        public string SubCatKey { get; set; }
        [StringLength(20)]
        public string ItemCatCode { get; set; }
        [StringLength(50)]
        public string ItemSubCatName { get; set; }
        [StringLength(50)]
        public string ItemSubCatNameAr { get; set; }
        [StringLength(50)]
        public string ItemSubCatDesc { get; set; }
        public bool IsActive { get; set; }
       

    }



    [AutoMap(typeof(TblInvDefCategory))]
    public class TblInvDefCategoryDto
    {
        public int Id { get; set; }

        [StringLength(20)]
        public string ItemCatCode { get; set; }
        [StringLength(50)]
        public string ItemCatName { get; set; }
        [StringLength(50)]
        public string ItemCatName_Ar { get; set; }

        [StringLength(50)]
        public string ItemCatDesc { get; set; }
        [StringLength(5)]
        public string ItemCatPrefix { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }


    }

    public class InvDefCategoryDto
    {
        public int Id { get; set; }
        public string ItemCatCode { get; set; }
        public string ItemCatName { get; set; }
        public string ItemCatName_Ar { get; set; }
        public string ItemCatDesc { get; set; }
        public string ItemCatPrefix { get; set; }
        public bool IsActive { get; set; }

    }


    [AutoMap(typeof(TblErpSysMenuOption))]
    public class TblErpSysMenuOptionDto
    {

        public int Id { get; set; }

        [StringLength(10)]
        public string MenuCode { get; set; }
        public sbyte Level1 { get; set; }
        public sbyte Level2 { get; set; }
        public sbyte Level3 { get; set; }
        [StringLength(40)]
        public string MenuNameEng { get; set; }
        [StringLength(40)]
        public string MenuNameArb { get; set; }
        public bool IsForm { get; set; }

        [StringLength(40)]
        public string Path { get; set; }
        [StringLength(10)]
        public string ModuleName { get; set; }

    }

    [AutoMap(typeof(TblErpFomDepartment))]
    public class TblErpFomDepartmentDto
    {

        public int Id { get; set; }
        [StringLength(20)]
        public string DeptCode { get; set; }
        public string NameEng { get; set; }
        public string NameArabic { get; set; }
        public string DeptServType { get; set; }
        public string ServiceTimePeriods { get; set; }
        public string FullImagePath { get; set; }
        public string ThumbNailImage { get; set; }
        public bool IsSheduleRequired1 { get; set; }
        public bool IsSheduleRequired2 { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }


    }


    public class ErpFomDepartmentDto
    {
        public int Id { get; set; }
        [StringLength(20)]
        public string DeptCode { get; set; }
        public string NameEng { get; set; }
        public string NameArabic { get; set; }
        public string DeptServType { get; set; }
        public string[] ServiceTimePeriods { get; set; }
        public string ThumbNailImage { get; set; }
        public IFormFile TImage { get; set; }
        public bool IsSheduleRequired1 { get; set; }
        public bool IsSheduleRequired2 { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

    }



    [AutoMap(typeof(TblErpFomCustomerContract))]
    public class TblErpFomCustomerContractDto
    {
       
        public int Id { get; set; }
       
        [StringLength(20)]
        public string ContractCode { get; set; }
        public string CustCode { get; set; }
        public string CustSiteCode { get; set; }
        public string CustContNumber { get; set; }
        public DateTime ContStartDate { get; set; }
        public DateTime ContEndDate { get; set; }
        public string ContDeptCode { get; set; }
        public string ContProjManager { get; set; }
        public string ContProjSupervisor { get; set; }
        public string ContApprAuthorities { get; set; }
        public string Remarks { get; set; }
        public bool IsAppreoved { get; set; }
        public bool IsSheduleRequired { get; set; }
        public string ApprovedBy { get; set; }
        public DateTime ApprovedDate { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }


    }


    public class ErpFomCustomerContractDto
    {

        public int Id { get; set; }

        [StringLength(20)]
        public string ContractCode { get; set; }
        public string CustCode { get; set; }
        public string CustSiteCode { get; set; }
        public string CustContNumber { get; set; }
        public DateTime ContStartDate { get; set; }
        public DateTime ContEndDate { get; set; }
        public string[] ContDeptCode { get; set; }           //multiple Codes separated by ,(comma)

      //  public string ContDeptCode { get; set; }
        public string ContProjManager { get; set; }
        public string ContProjSupervisor { get; set; }
        public string ContApprAuthorities { get; set; }
        public string Remarks { get; set; }
        public bool IsAppreoved { get; set; }
        public bool IsSheduleRequired { get; set; }
        public string ApprovedBy { get; set; }
        public DateTime ApprovedDate { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }


    }

    public class ErpFomCustContractScheduleSummaryDto
    {
        public ErpFomCustomerContractDto CustomerContractDto { get; set; }
        public ErpFomScheduleSummaryDto ScheduleSummaryDto { get; set; }
        public decimal GeoLatitude { get; set; }
        public decimal GeoLongitude { get; set; }
        public string SchType { get; set; }
        // public GenerateScheduleDto GenerateScheduleDto { get; set; }
    }

    public class RsErpFomScheduleDetailsDto
    {
        public int Id { get; set; }
        public int SchId { get; set; }
        public int ContractId { get; set; }
        public DateTime SchDate { get; set; }
        public string Department { get; set; }
        public string SerType { get; set; }
        public string Frequency { get; set; }
        public string TranNumber { get; set; }
        public string ServiceItem { get; set; }
        public string Remarks { get; set; }
        public TimeSpan Time { get; set; }
        public bool IsReschedule { get; set; }
        public bool IsActive { get; set; }
        public string CustomerName { get; set; }
        public string CustomerNameAr { get; set; }
        public string SiteName { get; set; }
        public string SiteNameAr { get; set; }
        public string ContractCode { get; set; }
    }


    [AutoMap(typeof(TblErpFomResources))]
    public class TblErpFomResourcesDto
    { 
        public int Id { get; set; }

        [StringLength(20)]
        public string ResCode { get; set; }
        public string ResTypeCode { get; set; }
        public string DeptCodes { get; set; }           //multiple Codes separated by ,(comma)
        public string NameEng { get; set; }
        public string NameAr { get; set; }
        public bool ApprovalAuth { get; set; }

        public string LoginUser { get; set; }
        public bool IsActive { get; set; }
        [Column(TypeName = "date")]
        public DateTime? CreatedOn { get; set; }
        [Column(TypeName = "date")]
        public DateTime? ModifiedOn { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }


    }

    public class ErpFomResourcesDto
    {
        public int Id { get; set; }

        [StringLength(20)]
        public string ResCode { get; set; }
        public string ResTypeCode { get; set; }
        public string[] DeptCodes { get; set; }           //multiple Codes separated by ,(comma)
        public string NameEng { get; set; }
        public string NameAr { get; set; }
        public bool ApprovalAuth { get; set; }
        public string LoginUser { get; set; }
        public bool IsActive { get; set; }
        [Column(TypeName = "date")]
        public DateTime? CreatedOn { get; set; }
        [Column(TypeName = "date")]
        public DateTime? ModifiedOn { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }


    }


    [AutoMap(typeof(TblErpFomResourceType))]
    public class TblErpFomResourceTypeDto
    {
       
        public int Id { get; set; }
        public string ResTypeCode { get; set; }
        public string ResTypeName { get; set; }
        public string ResTypeNameAr { get; set; }
        public bool IsActive { get; set; }
        [Column(TypeName = "date")]
        public DateTime? CreatedOn { get; set; }
        [Column(TypeName = "date")]
        public DateTime? ModifiedOn { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }

    }


    //[AutoMap(typeof(TblSndDefCustomerCategory))]
    //public class TblSndDefCustomerCategoryDto
    //{
    //    public int Id { get; set; }
    //    [StringLength(20)]
    //    public string CustCatCode { get; set; }
    //    [StringLength(50)]
    //    public string CustCatName { get; set; }
    //    [StringLength(50)]
    //    public string CustCatDesc { get; set; }
    //    [StringLength(3)]
    //    public string CatPrefix { get; set; }
    //    public int LastSeq { get; set; }

    //}

    [AutoMap(typeof(TblSndDefCustomerCategory))]
    public class TblSndDefCustomerCategoryDto : AutoActiveGenerateIdAuditableKeyDto<int>
    {
        [Required]
        [StringLength(20)]
        public string CustCatCode { get; set; }
        [StringLength(50)]
        [Required]
        public string CustCatName { get; set; }
        [StringLength(50)]
        [Required]
        public string CustCatDesc { get; set; }
        [StringLength(3)]
        public string CatPrefix { get; set; }
        public int LastSeq { get; set; }

    }

    [AutoMap(typeof(TblErpFomActivities))]
    public class TblErpFomActivitiesDto
    {
        
        public int Id { get; set; }
        [StringLength(20)]
        public string ActCode { get; set; }
        public string DeptCode { get; set; }
        public string ActName { get; set; }
        public string ActNameAr { get; set; }
        public string FullImagePath { get; set; }
        public string ThumbNailImage { get; set; }
        public bool IsActive { get; set; }
        public bool IsB2B { get; set; }
        public bool IsB2C { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string CreatedBy { get; set; }


    }

    [AutoMap(typeof(TblErpFomSubContractor))]
    public class TblErpFomSubContractorDto
    {
        public int Id { get; set; }
        [StringLength(20)]
        public string SubContCode { get; set; }
        public string DeptCodes { get; set; }
        public string NameEng { get; set; }
        public string NameArabic { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string ContactPerson1 { get; set; }
        public string DesgContactPerson1 { get; set; }
        public string ContactPerson1Phone { get; set; }
        public string ContactPerson2 { get; set; }
        public string DesgContactPerson2 { get; set; }
        public string ContactPerson2Phone { get; set; }
        public string Website { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

    }

    public class ErpFomSubContractorDto
    {
        public int Id { get; set; }
        [StringLength(20)]
        public string SubContCode { get; set; }
        public string[] DeptCodes { get; set; }           //multiple Codes separated by ,(comma)
        public string NameEng { get; set; }
        public string NameArabic { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string ContactPerson1 { get; set; }
        public string DesgContactPerson1 { get; set; }
        public string ContactPerson1Phone { get; set; }
        public string ContactPerson2 { get; set; }
        public string DesgContactPerson2 { get; set; }
        public string ContactPerson2Phone { get; set; }
        public string Website { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

    }


    public class CityStateCountryMappingDto : AutoActiveGenerateIdKeyDto<int>
    {
        [StringLength(50)]
        public string CityCode { get; set; }
        [StringLength(100)]
        public string CityName { get; set; }
        [StringLength(100)]
        public string CityNameAr { get; set; }
        [StringLength(50)]
        public string StateCode { get; set; }
        [StringLength(100)]
        public string StateName { get; set; }
        [StringLength(50)]
        public string CountryCode { get; set; }
        [StringLength(100)]
        public string CountryName { get; set; }



    }


    [AutoMap(typeof(TblSndDefSiteMaster))]
    public class TblSndDefSiteMasterDto : AutoActiveGenerateIdAuditableKeyDto<int>
    {

        [StringLength(50)]
        public string SiteCode { get; set; }
        [Required]
        [StringLength(200)]
        public string SiteName { get; set; }


        [StringLength(200)]
        public string SiteArbName { get; set; }

        public string CustomerCode { get; set; }


        [StringLength(500)]
        public string SiteAddress { get; set; }
        [StringLength(20)]

        public string SiteCityCode { get; set; }

        [Column(TypeName = "decimal(7,2)")]
        public decimal SiteGeoLatitude { get; set; }

        [Column(TypeName = "decimal(7,2)")]
        public decimal SiteGeoLongitude { get; set; }

        [Column(TypeName = "decimal(7,2)")]
        public decimal SiteGeoGain { get; set; }
        public decimal SiteGeoLatitudeMeter { get; set; }
        public decimal SiteGeoLongitudeMeter { get; set; }
        public bool IsChildCustomer { get; set; }
        [StringLength(50)]
        public string VATNumber { get; set; }
    }


    public class TblFomLoginMasterDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }

    }


    public class LoginSuccessMessageDto
    {
        public string Message { get; set; }
        public bool Status { get; set; }

        public int UserId { get; set; }

    }

    public class ProfmLoginMetaDataDto
    {
        [Required(ErrorMessage = "*")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "*")]
        public string Password { get; set; }


    }

    public class BaseLoginUserDTO
    {
        public int UserId { get; set; }
        public string ApiToken { get; set; }
        public string BranchCode { get; set; }
        public string DBConnectionString { get; set; }


    }

    public class ForgotPasswordDto
    {
        public string Password { get; set; }
        public bool Status { get; set; }

    }


    public class MenuItemFlatNodeListDto
    {
        public int UserId { get; set; }
        public List<string> Nodes { get; set; }
    }


    #region Menu DTOS
    public class GetSideMenuOptionListDto
    {
        public string ModuleEn { get; set; }
        public string ModuleAr { get; set; }
        public string SubModuleEn { get; set; }
        public string SubModuleAr { get; set; }
        public bool HasMultiItems { get; set; }
        public MainModuleMenuOptionDto MainModule { get; set; }
        public List<SubModuleMenuOptionDto> SubModules { get; set; }
        public List<MultiListMenuOptionDto> MItems { get; set; }
        public List<TblErpSysMenuOptionDto> Items { get; set; }
        //public List<TblErpSysMenuOptionDto> ArItems { get; set; }
    }

    public class MultiListMenuOptionDto
    {
        public MainModuleMenuOptionDto SubModule { get; set; }
        public List<SubModuleMenuOptionDto> Links { get; set; }
    }

    public class MainModuleMenuOptionDto
    {
        public string ModuleEn { get; set; }
        public string ModuleAr { get; set; }
        public string Module { get; set; }

    }
    public class SubModuleMenuOptionDto
    {
        [StringLength(10)]
        public string MenuNameEng { get; set; }
        [StringLength(10)]
        public string MenuNameArb { get; set; }
        public bool IsForm { get; set; }
        [StringLength(40)]
        public string Path { get; set; }
    }





    #endregion


    [AutoMap(typeof(TblErpFomScheduleSummary))]
    public class TblErpFomScheduleSummaryDto
    {
        public int Id { get; set; }
        public int ContractId { get; set; }
        public string DeptCode { get; set; }
        public bool IsApproved { get; set; }
        public DateTime ApproveDate { get; set; }
        public string ApprovedBy { get; set; }
        public bool IsSchGenerated { get; set; }

    }

    [AutoMap(typeof(TblErpFomScheduleWeekdays))]
    public class TblErpFomScheduleWeekdaysDto
    {
        public int Id { get; set; }
        public int SchId { get; set; }
        public int ContractId { get; set; }
        public string WeekDay { get; set; }
        public TimeSpan Time { get; set; }
        public bool AllDayLong { get; set; }
        public string Remarks { get; set; }
        public bool IsActive { get; set; }
    }



    public class ErpFomScheduleSummaryDto
    {
        public ErpFomScheduleSummaryDto()
        {
            TableRows = new List<ErpFomScheduleWeekdaysDto>();
        }
        public int Id { get; set; }
        public string ContractCode { get; set; }
        public string CustCode { get; set; }
        public string DeptCode { get; set; }
        public bool? IsApproved { get; set; }
        public DateTime? ApproveDate { get; set; }
        public string ApprovedBy { get; set; }
        public bool? IsSchGenerated { get; set; }
        public List<ErpFomScheduleWeekdaysDto> TableRows { get; set; }
    }


    public class GenerateScheduleDto : ErpFomScheduleSummaryDto
    {
        public int SchId { get; set; }
        public DateTime contStartDate { get; set; }
        public DateTime contEndDate { get; set; }
      

    }

        public class ErpFomScheduleWeekdaysDto
    {
        public string WeekDay { get; set; }
        public string Time { get; set; }
        public string Remarks { get; set; }  
        public bool IsActive { get; set; }
    }



    public class GeneratedScheduleDetailsDto
    {
        public GeneratedScheduleDetailsDto()
        {
            DetailRows = new List<FomScheduleDetailsDto>();
        }
        public int Id { get; set; }
        public string ContractCode { get; set; }
        public string CustCode { get; set; }
        public string DeptCode { get; set; }
        public bool? IsApproved { get; set; }
        public DateTime? ApproveDate { get; set; }
        public string ApprovedBy { get; set; }
        public bool? IsSchGenerated { get; set; }
        public List<FomScheduleDetailsDto> DetailRows { get; set; }
    }



    public class FomScheduleDetailsDto
    {
        public int Id { get; set; }
        public int SchId { get; set; }
        public int ContractId { get; set; }
        public DateTime SchDate { get; set; }
        public string Department { get; set; }
        public string SerType { get; set; }
        public string Frequency { get; set; }
        public string TranNumber { get; set; }
        public string ServiceItem { get; set; }
        public string Remarks { get; set; }
        public string Time { get; set; }
        public bool IsReschedule { get; set; }
        public bool IsActive { get; set; }

        public string CustomerName { get; set; }
        public string CustomerNameAr { get; set; }
        public string SiteName { get; set; }
        public string SiteNameAr { get; set; }
        public string ContractCode { get; set; }
    }




    [AutoMap(typeof(TblErpFomScheduleDetails))]
    public class TblErpFomScheduleDetailsDto
    {
        public int Id { get; set; }
        public int SchId { get; set; }
        public int ContractId { get; set; }
        public DateTime SchDate { get; set; }
        public string Department { get; set; }
        public string SerType { get; set; }
        public string Frequency { get; set; }
        public string TranNumber { get; set; }
        public string ServiceItem { get; set; }
        public string Remarks { get; set; }
        public TimeSpan Time { get; set; }
        public bool IsReschedule { get; set; }
        public bool IsActive { get; set; }
    }
    public class RQDashBoardFiltersDto
    {
        public int? ContractId { get; set; }
        public string CustomerCode { get; set; }
        public DateTime? UserDate { get; set; }


    }
    public class Out_FomWebDashBoardTicketsData
    {
        public int TotalTickets { get; set; } = 0;
        public int ClosedTickets { get; set; } = 0;
        public int PendingTickets { get; set; } = 0;
        public Out_FomWebDashBoardLast30DaysData Last30DaysData { get; set; } = new();
        public List<Out_FomWebDashBoardDepWiseTicketsData> DepWiseData { get; set; } = new();
        public List<Out_FomWebDashBoardMonthWiseTicketsData> MonthWiseData { get; set; } = new();
        public List<Out_FomWebDashBoardDepAndStatusWiseTicketsData> DepAndStatusWiseData { get; set; } = new();

        public List<string> MonthsNames { get; set; } = new();
        public List<int> MonthlyTotalTickets { get; set; } = new();
        public List<Out_FomWebDashBoardRecenetTickets> RecentTickets { get; set; } = new();
    }
    public class WebDashboardMonths
    {
        public int month { get; set; }
        public int year { get; set; }
        public string name { get; set; }
    }
}