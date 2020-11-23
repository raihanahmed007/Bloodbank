using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;

namespace BloodBank_Management_System.Models
{
    public class DbBloodbank : DbContext
    {
        public DbSet<District> Districts { get; set; }
        public DbSet<Donor> Donors { get; set; }
        public DbSet<BloodRecipient> BloodRecipients { get; set; }
        public DbSet<BloodSample> BloodSamples { get; set; }
        public DbSet<BloodInventoryManager> BloodInventoryManagers { get; set; }
        public DbSet<BBMSystem> BBMSystems { get; set; }
    }
    public enum gender { Male, Female, Others }
    public enum group
    {
        [Display(Name = "O+")]
        OPositive,
        [Display(Name = "A+")]
        APositive,
        [Display(Name = "B+")]
        BPositive,
        [Display(Name = "AB+")]
        ABPositive,
        [Display(Name = "AB-")]
        ABNegative,
        [Display(Name = "A-")]
        ANegative,
        [Display(Name = "B-")]
        BNegative,
        [Display(Name = "O-")]
        ONegative
    }
    public class District
    {
        public int DistrictId { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
    }
    public class Donor
    {
        public int DonorId { get; set; }
        [Required]
        [StringLength(20)]
        [Display(Name = "Blood Donor Name")]
        public string DonorName { get; set; }
        [Required]
        public gender Gender { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        [StringLength(100)]
        public string Address { get; set; }
        [Required]
        [Display(Name = "Mobile Number")]
        public string ContactNo { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Blood Donation Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime? DonateDate { get; set; }
        [Required]
        [Display(Name = "Blood Quentity")]
        public int QuentityOfBlood { get; set; }     
 
        [ForeignKey("District")]
        [Display(Name = "District")]
        public int DistrictId { get; set; }
        public virtual District District { get; set; }
    }
    public class BloodRecipient
    {
        [Key]
        public int RecipientId { get; set; }
        [Required]
        [Display(Name = "Blood Recipient Name")]
        public string RecipientName { get; set; }
        [Required]
        public gender Gender { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        [Display(Name = "Mobile Number")]
        public string ContactNo { get; set; }
        [Required]
        [ForeignKey("Donor")]
        [Display(Name = "Blood Donor Name")]
        public int DonorId { get; set; }
        public virtual Donor Donor { get; set; }
    }
    public class BloodSample
    {
        public int BloodSampleId { get; set; }
        [Required]
        [Display(Name = "Blood Group")]
        public group BloodGroups { get; set; }
        [Required]
        [Display(Name = "Blood Quetity")]
        public int BloodQuentity { get; set; }
        [Display(Name = "Blood Donor Name")]

        [ForeignKey("Donor")]
        public int DonorId { get; set; }
        public virtual Donor Donor { get; set; }
    }
    
    public class BloodInventoryManager
    {
        [Key]
        public int ManagerId { get; set; }
        [Required]
        [DisplayName("Inventory Manager Name")]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [DisplayName("Phone Number")]
        public string ContactNo { get; set; }
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }
        [ForeignKey("BloodSample")]
        [Display(Name = "Blood Group")]
        public int BloodSampleId { get; set; }
        public virtual BloodSample BloodSample { get; set; }
    }
    public class BBMSystem
    {
        public int BBMSystemId { get; set; }
        [DisplayName("Blood Bank Management System")]
        public string BBMSName { get; set; }
        [Required]
        [Display(Name = "Blood Group")]
        [ForeignKey("BloodSample")]
        public int BloodSampleId { get; set; }
        [Display(Name = "Blood Inventory Manager Name")]
        [ForeignKey("BloodInventoryManager")]
        public int ManagerId { get; set; }
        [Display(Name = "Blood Recipient Name")]
        [ForeignKey("BloodRecipient")]
        public int RecipientId { get; set; }
        [ForeignKey("Donor")]
        [Display(Name = "Blood Donor Name")]
        public int DonorId { get; set; }
        [ForeignKey("District")]
        public int DistrictId { get; set; }
        public virtual BloodSample BloodSample { get; set; }
        public virtual BloodInventoryManager BloodInventoryManager { get; set; }       
        public virtual BloodRecipient BloodRecipient { get; set; }       
        public virtual Donor Donor { get; set; }       
        public virtual District District { get; set; }

    }
}