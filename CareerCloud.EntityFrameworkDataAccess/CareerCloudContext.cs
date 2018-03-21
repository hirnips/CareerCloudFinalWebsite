using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using CareerCloud.Pocos;

namespace CareerCloud.EntityFrameworkDataAccess
{
    public class CareerCloudContext : DbContext
    {
        public CareerCloudContext() : base(ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString)
        {
        }

        public DbSet<ApplicantEducationPoco> ApplicantEducations { get; set; }
        public DbSet<ApplicantJobApplicationPoco> ApplicantJobApplications { get; set; }
        public DbSet<ApplicantProfilePoco> ApplicantProfilePocos { get; set; }
        public DbSet<ApplicantResumePoco> ApplicantResumes { get; set; }
        public DbSet<ApplicantSkillPoco> ApplicantSkills { get; set; }
        public DbSet<ApplicantWorkHistoryPoco> ApplicantWorkHistorys { get; set; }
        public DbSet<CompanyDescriptionPoco> CompanyDescriptions { get; set; }
        public DbSet<CompanyJobDescriptionPoco> CompanyJobDescriptions { get; set; }
        public DbSet<CompanyJobEducationPoco> CompanyJobEducations { get; set; }
        public DbSet<CompanyJobPoco> CompanyJobs { get; set; }
        public DbSet<CompanyJobSkillPoco> CompanyJobSkills { get; set; }
        public DbSet<CompanyLocationPoco> CompanyLocations { get; set; }
        public DbSet<CompanyProfilePoco> CompanyProfiles { get; set; }
        public DbSet<SecurityLoginPoco> SecurityLogins { get; set; }
        public DbSet<SecurityLoginsLogPoco> SecurityLoginsLogs { get; set; }
        public DbSet<SecurityLoginsRolePoco> SecurityLoginsRoles { get; set; }
        public DbSet<SecurityRolePoco> SecurityRoles { get; set; }
        public DbSet<SystemCountryCodePoco> SystemCountryCodes { get; set; }
        public DbSet<SystemLanguageCodePoco> SystemLanguageCodes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CompanyJobPoco>()
                .HasMany(e => e.CompanyJobDescriptions)
                .WithRequired(e => e.CompanyJob)
                .HasForeignKey(e => e.Job)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CompanyJobPoco>()
                .HasMany(e => e.CompanyJobEducations)
                .WithRequired(e => e.CompanyJob)
                .HasForeignKey(e => e.Job)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ApplicantProfilePoco>()
                .HasMany(a => a.ApplicantResumes)
                .WithRequired(r => r.ApplicantProfile)
                .HasForeignKey(r => r.Applicant)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SecurityLoginPoco>()
                .HasMany(s => s.ApplicantProfiles)
                .WithRequired(a => a.SecurityLogin)
                .HasForeignKey(a => a.Login)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SecurityLoginPoco>()
                .HasMany(s => s.SecurityLoginsRoles)
                .WithRequired(r => r.SecurityLogin)
                .HasForeignKey(r => r.Login)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CompanyProfilePoco>()
                .HasMany(c => c.CompanyDescriptions)
                .WithRequired(d => d.companyProfile)
                .HasForeignKey(d => d.Company)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CompanyProfilePoco>()
                .HasMany(j => j.CompanyJobs)
                .WithRequired(j => j.CompanyProfile)
                .HasForeignKey(c => c.Company)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CompanyProfilePoco>()
                .HasMany(l => l.CompanyLocations)
                .WithRequired(l => l.CompanyProfile)
                .HasForeignKey(c => c.Company)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CompanyJobPoco>()
                .HasMany(j => j.CompanyJobSkills)
                .WithRequired(j => j.CompanyJob)
                .HasForeignKey(s => s.Job)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SecurityRolePoco>()
                .HasMany(s => s.SecurityLoginsRoles)
                .WithRequired(s => s.SecurityRole)
                .HasForeignKey(sr => sr.Role)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SecurityLoginPoco>()
                .HasMany(s => s.SecurityLoginsLogs)
                .WithRequired(s => s.SecurityLogin)
                .HasForeignKey(l => l.Login)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SystemCountryCodePoco>()
                .HasMany(c => c.ApplicantProfiles)
                .WithRequired(c => c.SystemCountryCode)
                .HasForeignKey(s => s.Country)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ApplicantProfilePoco>()
                .HasMany(a => a.ApplicantEducations)
                .WithRequired(a => a.ApplicantProfile)
                .HasForeignKey(p => p.Applicant)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ApplicantProfilePoco>()
               .HasMany(a => a.ApplicantJobApplications)
               .WithRequired(a => a.ApplicantProfile)
               .HasForeignKey(p => p.Applicant)
               .WillCascadeOnDelete(false);

            modelBuilder.Entity<ApplicantProfilePoco>()
               .HasMany(a => a.ApplicantResumes)
               .WithRequired(a => a.ApplicantProfile)
               .HasForeignKey(p => p.Applicant)
               .WillCascadeOnDelete(false);

            modelBuilder.Entity<ApplicantProfilePoco>()
               .HasMany(a => a.ApplicantSkills)
               .WithRequired(a => a.ApplicantProfile)
               .HasForeignKey(p => p.Applicant)
               .WillCascadeOnDelete(false);

            modelBuilder.Entity<ApplicantProfilePoco>()
               .HasMany(a => a.ApplicantWorkHistories)
               .WithRequired(a => a.ApplicantProfile)
               .HasForeignKey(p => p.Applicant)
               .WillCascadeOnDelete(false);

            modelBuilder.Entity<CompanyJobPoco>()
               .HasMany(a => a.ApplicantJobApplications)
               .WithRequired(a => a.CompanyJob)
               .HasForeignKey(p => p.Job)
               .WillCascadeOnDelete(false);

            modelBuilder.Entity<SystemCountryCodePoco>()
               .HasMany(a => a.ApplicantWorkHistories)
               .WithRequired(a => a.SystemCountryCode)
               .HasForeignKey(p => p.CountryCode)
               .WillCascadeOnDelete(false);

            //modelBuilder.Entity<SystemLanguageCodePoco>()
            //    .HasMany(c => c.CompanyDescriptions)
            //    .WithRequired(s => s.SystemLanguageCode)
            //    .HasForeignKey(s => s.LanguageId)
            //    .WillCascadeOnDelete(false);




            //base.OnModelCreating(modelBuilder);
        }

    }
}
