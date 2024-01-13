using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SalesNet.Model;

namespace SalesNet.DataEntities;

public partial class AdventureContext : DbContext
{
    public AdventureContext()
    {
    }

    public AdventureContext(DbContextOptions<AdventureContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ArrivalDepartureMaster> ArrivalDepartureMasters { get; set; }

    public virtual DbSet<BillTransaction> BillTransactions { get; set; }

    public virtual DbSet<Bkup02jue2017SnApprasialFormEmployeeRelationship> Bkup02jue2017SnApprasialFormEmployeeRelationships { get; set; }

    public virtual DbSet<Bkup2jan2015Sheet2> Bkup2jan2015Sheet2s { get; set; }

    public virtual DbSet<Bkup2jan2015SnDarMovement> Bkup2jan2015SnDarMovements { get; set; }

    public virtual DbSet<BkupRecipientUsersList> BkupRecipientUsersLists { get; set; }

    public virtual DbSet<BkupRecipientUsersList16april2015> BkupRecipientUsersList16april2015s { get; set; }

    public virtual DbSet<BkupSnEmployeeIncentive13aug2014> BkupSnEmployeeIncentive13aug2014s { get; set; }

    public virtual DbSet<BkupSnEmployeeTargetDetails20may2014> BkupSnEmployeeTargetDetails20may2014s { get; set; }

    public virtual DbSet<Blog> Blogs { get; set; }

    public virtual DbSet<Ceomessage> Ceomessages { get; set; }

    public virtual DbSet<EmployeeStatusMaster> EmployeeStatusMasters { get; set; }

    public virtual DbSet<ErrorLog> ErrorLogs { get; set; }

    public virtual DbSet<FileName1234> FileName1234s { get; set; }

    public virtual DbSet<GetOrderListAgainstEcitpc> GetOrderListAgainstEcitpcs { get; set; }

    public virtual DbSet<Hrmanual> Hrmanuals { get; set; }

    public virtual DbSet<InActiveEmployeesDarnotShiftedList> InActiveEmployeesDarnotShiftedLists { get; set; }

    public virtual DbSet<JobPromotion> JobPromotions { get; set; }

    public virtual DbSet<KnowledgeSharing> KnowledgeSharings { get; set; }

    public virtual DbSet<LocalConveyanceMaster> LocalConveyanceMasters { get; set; }

    public virtual DbSet<Master> Masters { get; set; }

    public virtual DbSet<OnlineTest> OnlineTests { get; set; }

    public virtual DbSet<OracleUser> OracleUsers { get; set; }

    public virtual DbSet<OracleUsersBkp281111> OracleUsersBkp281111s { get; set; }

    public virtual DbSet<OrderVertical> OrderVerticals { get; set; }

    public virtual DbSet<Query> Queries { get; set; }

    public virtual DbSet<Quote> Quotes { get; set; }

    public virtual DbSet<RecipientUsersList> RecipientUsersLists { get; set; }

    public virtual DbSet<RecipientUsersListBkup05april2017> RecipientUsersListBkup05april2017s { get; set; }

    public virtual DbSet<RecipientUsersListBkup20april2016> RecipientUsersListBkup20april2016s { get; set; }

    public virtual DbSet<RecipientUsersListForTest> RecipientUsersListForTests { get; set; }

    public virtual DbSet<Script> Scripts { get; set; }

    public virtual DbSet<Sheet1> Sheet1s { get; set; }

    public virtual DbSet<Sheet2> Sheet2s { get; set; }

    public virtual DbSet<SnActivityArea> SnActivityAreas { get; set; }

    public virtual DbSet<SnAppActivity> SnAppActivities { get; set; }

    public virtual DbSet<SnApplicationHead> SnApplicationHeads { get; set; }

    public virtual DbSet<SnAppraisalFourthReportingHead> SnAppraisalFourthReportingHeads { get; set; }

    public virtual DbSet<SnAppraisalGroup> SnAppraisalGroups { get; set; }

    public virtual DbSet<SnAppraisalGroupForEmployee> SnAppraisalGroupForEmployees { get; set; }

    public virtual DbSet<SnAppraisalGroupFourthReportingHeadMapping> SnAppraisalGroupFourthReportingHeadMappings { get; set; }

    public virtual DbSet<SnAppraisalQuestionSetMaster> SnAppraisalQuestionSetMasters { get; set; }

    public virtual DbSet<SnAppraisalStaticQuestion> SnAppraisalStaticQuestions { get; set; }

    public virtual DbSet<SnAppraisalStaticQuestionFormRelationship> SnAppraisalStaticQuestionFormRelationships { get; set; }

    public virtual DbSet<SnAppraisalfourthreportingheadBack07March2019> SnAppraisalfourthreportingheadBack07March2019s { get; set; }

    public virtual DbSet<SnApprasialAudit> SnApprasialAudits { get; set; }

    public virtual DbSet<SnApprasialFormEmployeeRelationship> SnApprasialFormEmployeeRelationships { get; set; }

    public virtual DbSet<SnApprasialFormEmployeeRelationship08april2019> SnApprasialFormEmployeeRelationship08april2019s { get; set; }

    public virtual DbSet<SnApprasialFormEmployeeRelationship1> SnApprasialFormEmployeeRelationship1s { get; set; }

    public virtual DbSet<SnApprasialFormEmployeeRelationship2> SnApprasialFormEmployeeRelationship2s { get; set; }

    public virtual DbSet<SnApprasialFormEmployeeRelationshipBkupon16July2015> SnApprasialFormEmployeeRelationshipBkupon16July2015s { get; set; }

    public virtual DbSet<SnApprasialFormEmployeeSectionRelationsship> SnApprasialFormEmployeeSectionRelationsships { get; set; }

    public virtual DbSet<SnApprasialFormQuestionRelationship> SnApprasialFormQuestionRelationships { get; set; }

    public virtual DbSet<SnApprasialFormSectionRelationship> SnApprasialFormSectionRelationships { get; set; }

    public virtual DbSet<SnApprasialFormStaticQuestionRelationship> SnApprasialFormStaticQuestionRelationships { get; set; }

    public virtual DbSet<SnApprraisalMasterSalaryBreakup> SnApprraisalMasterSalaryBreakups { get; set; }

    public virtual DbSet<SnApprraisalMasterSalaryBreakup18apr2019> SnApprraisalMasterSalaryBreakup18apr2019s { get; set; }

    public virtual DbSet<SnApprraisalSalaryBreakupValue> SnApprraisalSalaryBreakupValues { get; set; }

    public virtual DbSet<SnApprraisalText> SnApprraisalTexts { get; set; }

    public virtual DbSet<SnBranchMaster> SnBranchMasters { get; set; }

    public virtual DbSet<SnBranchPrincipalTarget> SnBranchPrincipalTargets { get; set; }

    public virtual DbSet<SnCallStatusMaster> SnCallStatusMasters { get; set; }

    public virtual DbSet<SnCallTypeMaster> SnCallTypeMasters { get; set; }

    public virtual DbSet<SnCategorisedOther> SnCategorisedOthers { get; set; }

    public virtual DbSet<SnClaimMasterDetail> SnClaimMasterDetails { get; set; }

    public virtual DbSet<SnClaimSettlementDetail> SnClaimSettlementDetails { get; set; }

    public virtual DbSet<SnClaimSettlementFor> SnClaimSettlementFors { get; set; }

    public virtual DbSet<SnClaimTravelDetail> SnClaimTravelDetails { get; set; }

    public virtual DbSet<SnClaimTravelExpensesDetail> SnClaimTravelExpensesDetails { get; set; }

    public virtual DbSet<SnClaimsConveyanceDetail> SnClaimsConveyanceDetails { get; set; }

    public virtual DbSet<SnClaimsTravelExpense> SnClaimsTravelExpenses { get; set; }

    public virtual DbSet<SnCompetitor> SnCompetitors { get; set; }

    public virtual DbSet<SnCurrencyMaster> SnCurrencyMasters { get; set; }

    public virtual DbSet<SnCustDepartmentMaster> SnCustDepartmentMasters { get; set; }

    public virtual DbSet<SnCustDesignationMaster> SnCustDesignationMasters { get; set; }

    public virtual DbSet<SnCustomer> SnCustomers { get; set; }

    public virtual DbSet<SnCustomerContact> SnCustomerContacts { get; set; }

    public virtual DbSet<SnCustomerContactsBkup> SnCustomerContactsBkups { get; set; }

    public virtual DbSet<SnCustomerProduct> SnCustomerProducts { get; set; }

    public virtual DbSet<SnCustomersBckup10may2023> SnCustomersBckup10may2023s { get; set; }

    public virtual DbSet<SnCustomersBkup> SnCustomersBkups { get; set; }

    public virtual DbSet<SnCustomertemp> SnCustomertemps { get; set; }

    public virtual DbSet<SnDar> SnDars { get; set; }

    public virtual DbSet<SnDarComment> SnDarComments { get; set; }

    public virtual DbSet<SnDarCommentsRead> SnDarCommentsReads { get; set; }

    public virtual DbSet<SnDarCompetitor> SnDarCompetitors { get; set; }

    public virtual DbSet<SnDarMovement> SnDarMovements { get; set; }

    public virtual DbSet<SnDarOther> SnDarOthers { get; set; }

    public virtual DbSet<SnDarProduct> SnDarProducts { get; set; }

    public virtual DbSet<SnDarothersMapping> SnDarothersMappings { get; set; }

    public virtual DbSet<SnDarproductsOld> SnDarproductsOlds { get; set; }

    public virtual DbSet<SnDarstatus> SnDarstatuses { get; set; }

    public virtual DbSet<SnDepartmentMaster> SnDepartmentMasters { get; set; }

    public virtual DbSet<SnDesignationMaster> SnDesignationMasters { get; set; }

    public virtual DbSet<SnEmployee> SnEmployees { get; set; }

    public virtual DbSet<SnEmployeeAddress> SnEmployeeAddresses { get; set; }

    public virtual DbSet<SnEmployeeAttachment> SnEmployeeAttachments { get; set; }

    public virtual DbSet<SnEmployeeError> SnEmployeeErrors { get; set; }

    public virtual DbSet<SnEmployeeIncentive> SnEmployeeIncentives { get; set; }

    public virtual DbSet<SnEmployeeIncentiveBkup04may2016> SnEmployeeIncentiveBkup04may2016s { get; set; }

    public virtual DbSet<SnEmployeeIncentiveBkup05nov2014> SnEmployeeIncentiveBkup05nov2014s { get; set; }

    public virtual DbSet<SnEmployeeIncentiverenamed> SnEmployeeIncentiverenameds { get; set; }

    public virtual DbSet<SnEmployeePolicy> SnEmployeePolicies { get; set; }

    public virtual DbSet<SnEmployeeProductVertical> SnEmployeeProductVerticals { get; set; }

    public virtual DbSet<SnEmployeeResignation> SnEmployeeResignations { get; set; }

    public virtual DbSet<SnEmployeeTarget> SnEmployeeTargets { get; set; }

    public virtual DbSet<SnEmployeeTargetDetail> SnEmployeeTargetDetails { get; set; }

    public virtual DbSet<SnEmployeeTargetDetailsBackUp18092013> SnEmployeeTargetDetailsBackUp18092013s { get; set; }

    public virtual DbSet<SnEmployeeTargetMaster> SnEmployeeTargetMasters { get; set; }

    public virtual DbSet<SnEmployeeTargetMasterBackUp18092013> SnEmployeeTargetMasterBackUp18092013s { get; set; }

    public virtual DbSet<SnEmployees25july2018> SnEmployees25july2018s { get; set; }

    public virtual DbSet<SnEmployees25nov2019> SnEmployees25nov2019s { get; set; }

    public virtual DbSet<SnEmployeesOld> SnEmployeesOlds { get; set; }

    public virtual DbSet<SnFundType> SnFundTypes { get; set; }

    public virtual DbSet<SnGradeMaster> SnGradeMasters { get; set; }

    public virtual DbSet<SnGroupEmployeeRelationship> SnGroupEmployeeRelationships { get; set; }

    public virtual DbSet<SnHeadOffice> SnHeadOffices { get; set; }

    public virtual DbSet<SnHierarchy> SnHierarchies { get; set; }

    public virtual DbSet<SnHoliday> SnHolidays { get; set; }

    public virtual DbSet<SnHolidayBak> SnHolidayBaks { get; set; }

    public virtual DbSet<SnHrloginCredential> SnHrloginCredentials { get; set; }

    public virtual DbSet<SnIncentiveType> SnIncentiveTypes { get; set; }

    public virtual DbSet<SnIncentiveUser> SnIncentiveUsers { get; set; }

    public virtual DbSet<SnInstallationStatusMaster> SnInstallationStatusMasters { get; set; }

    public virtual DbSet<SnInvoiceApprovalMaster> SnInvoiceApprovalMasters { get; set; }

    public virtual DbSet<SnKnowYourColleague> SnKnowYourColleagues { get; set; }

    public virtual DbSet<SnLeadForward> SnLeadForwards { get; set; }

    public virtual DbSet<SnLeadGeneration> SnLeadGenerations { get; set; }

    public virtual DbSet<SnLeadProduct> SnLeadProducts { get; set; }

    public virtual DbSet<SnLeadStatus> SnLeadStatuses { get; set; }

    public virtual DbSet<SnLeadTypeMaster> SnLeadTypeMasters { get; set; }

    public virtual DbSet<SnLicenseTypeMaster> SnLicenseTypeMasters { get; set; }

    public virtual DbSet<SnLockDay> SnLockDays { get; set; }

    public virtual DbSet<SnLogError> SnLogErrors { get; set; }

    public virtual DbSet<SnLostReason> SnLostReasons { get; set; }

    public virtual DbSet<SnManageEmployeeApprHistory> SnManageEmployeeApprHistories { get; set; }

    public virtual DbSet<SnMasterAppraisalCategory> SnMasterAppraisalCategories { get; set; }

    public virtual DbSet<SnMasterApprasialForm> SnMasterApprasialForms { get; set; }

    public virtual DbSet<SnMasterGroup> SnMasterGroups { get; set; }

    public virtual DbSet<SnMasterQuestion> SnMasterQuestions { get; set; }

    public virtual DbSet<SnMasterSection> SnMasterSections { get; set; }

    public virtual DbSet<SnMasterSla> SnMasterSlas { get; set; }

    public virtual DbSet<SnMasterStatus> SnMasterStatuses { get; set; }

    public virtual DbSet<SnMasterUserType> SnMasterUserTypes { get; set; }

    public virtual DbSet<SnMonthMaster> SnMonthMasters { get; set; }

    public virtual DbSet<SnOfficeActivity> SnOfficeActivities { get; set; }

    public virtual DbSet<SnOfficeDar> SnOfficeDars { get; set; }

    public virtual DbSet<SnOrderApprovalMaster> SnOrderApprovalMasters { get; set; }

    public virtual DbSet<SnOrderClosedStatusMaster> SnOrderClosedStatusMasters { get; set; }

    public virtual DbSet<SnOrderDispatchedDetail> SnOrderDispatchedDetails { get; set; }

    public virtual DbSet<SnOrderPrincipal> SnOrderPrincipals { get; set; }

    public virtual DbSet<SnOrderProcessing> SnOrderProcessings { get; set; }

    public virtual DbSet<SnOrderProduct> SnOrderProducts { get; set; }

    public virtual DbSet<SnPaymentDetail> SnPaymentDetails { get; set; }

    public virtual DbSet<SnPaymentForMaster> SnPaymentForMasters { get; set; }

    public virtual DbSet<SnPaymentModeMaster> SnPaymentModeMasters { get; set; }

    public virtual DbSet<SnPriceList> SnPriceLists { get; set; }

    public virtual DbSet<SnPrincipalMaster> SnPrincipalMasters { get; set; }

    public virtual DbSet<SnPrincipalQuarterName> SnPrincipalQuarterNames { get; set; }

    public virtual DbSet<SnProduct> SnProducts { get; set; }

    public virtual DbSet<SnProductPrincipalMapping> SnProductPrincipalMappings { get; set; }

    public virtual DbSet<SnQuarterMaster> SnQuarterMasters { get; set; }

    public virtual DbSet<SnQuotationDetail> SnQuotationDetails { get; set; }

    public virtual DbSet<SnQuotationNote> SnQuotationNotes { get; set; }

    public virtual DbSet<SnQuotationProductInfo> SnQuotationProductInfos { get; set; }

    public virtual DbSet<SnQuotationSentTo> SnQuotationSentTos { get; set; }

    public virtual DbSet<SnReceivedInConditionMaster> SnReceivedInConditionMasters { get; set; }

    public virtual DbSet<SnReceivedMaster> SnReceivedMasters { get; set; }

    public virtual DbSet<SnRecipientListForSalesNetMail> SnRecipientListForSalesNetMails { get; set; }

    public virtual DbSet<SnRecipientListForVisitDateMail> SnRecipientListForVisitDateMails { get; set; }

    public virtual DbSet<SnRecipientOrderList> SnRecipientOrderLists { get; set; }

    public virtual DbSet<SnRegionMaster> SnRegionMasters { get; set; }

    public virtual DbSet<SnRevenuePercentage> SnRevenuePercentages { get; set; }

    public virtual DbSet<SnSavedSearch> SnSavedSearches { get; set; }

    public virtual DbSet<SnSemesterMaster> SnSemesterMasters { get; set; }

    public virtual DbSet<SnStaticTextMaster> SnStaticTextMasters { get; set; }

    public virtual DbSet<SnSubVerticalMaster> SnSubVerticalMasters { get; set; }

    public virtual DbSet<SnTechlabsPrincipalTarget> SnTechlabsPrincipalTargets { get; set; }

    public virtual DbSet<SnTermsConditionsMaster> SnTermsConditionsMasters { get; set; }

    public virtual DbSet<SnTermsConditionsMasterBk26Nov2015> SnTermsConditionsMasterBk26Nov2015s { get; set; }

    public virtual DbSet<SnTrainingStatusMaster> SnTrainingStatusMasters { get; set; }

    public virtual DbSet<SnUserIncentiveMapped> SnUserIncentiveMappeds { get; set; }

    public virtual DbSet<SnVerticalMaster> SnVerticalMasters { get; set; }

    public virtual DbSet<SnWeeklyActivity> SnWeeklyActivities { get; set; }

    public virtual DbSet<SnWeeklyActivityBkup02feb2016> SnWeeklyActivityBkup02feb2016s { get; set; }

    public virtual DbSet<SnWishesTemplate> SnWishesTemplates { get; set; }

    public virtual DbSet<SnvwAppmi> SnvwAppmis { get; set; }

    public virtual DbSet<SnvwDarcompetitor> SnvwDarcompetitors { get; set; }

    public virtual DbSet<SnvwLatestDar> SnvwLatestDars { get; set; }

    public virtual DbSet<SnvwLatestDarForAppEngg> SnvwLatestDarForAppEnggs { get; set; }

    public virtual DbSet<SnvwMisdar> SnvwMisdars { get; set; }

    public virtual DbSet<SnvwMisproduct> SnvwMisproducts { get; set; }

    public virtual DbSet<SnvwOrderProcessingProduct> SnvwOrderProcessingProducts { get; set; }

    public virtual DbSet<SpecialUser> SpecialUsers { get; set; }

    public virtual DbSet<SubVerticalPrincipalMapping> SubVerticalPrincipalMappings { get; set; }

    public virtual DbSet<TblError> TblErrors { get; set; }

    public virtual DbSet<TempActivityarea> TempActivityareas { get; set; }

    public virtual DbSet<TempOracleUser> TempOracleUsers { get; set; }

    public virtual DbSet<Temptable> Temptables { get; set; }

    public virtual DbSet<TestAssignment> TestAssignments { get; set; }

    public virtual DbSet<TestMapping> TestMappings { get; set; }

    public virtual DbSet<TmpSnCustomerContact> TmpSnCustomerContacts { get; set; }

    public virtual DbSet<TourMaster> TourMasters { get; set; }

    public virtual DbSet<Upcomingevent> Upcomingevents { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Users1> Users1s { get; set; }

    public virtual DbSet<Users2> Users2s { get; set; }

    public virtual DbSet<UsersTemp> UsersTemps { get; set; }

    public virtual DbSet<VwGetleadEmployee> VwGetleadEmployees { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=192.168.1.84;Database=TechlabSalesNetProd;uid=sa;pwd=ttpl@987;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BillTransaction>(entity =>
        {
            entity.Property(e => e.Type)
                .IsFixedLength()
                .HasComment("L-Local\r\nT-Tour");
        });

        modelBuilder.Entity<Bkup02jue2017SnApprasialFormEmployeeRelationship>(entity =>
        {
            entity.Property(e => e.FormEmployeeId).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<Bkup2jan2015SnDarMovement>(entity =>
        {
            entity.Property(e => e.DarMovementId).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<BkupRecipientUsersList>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<BkupRecipientUsersList16april2015>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<BkupSnEmployeeIncentive13aug2014>(entity =>
        {
            entity.Property(e => e.IncentiveId).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<BkupSnEmployeeTargetDetails20may2014>(entity =>
        {
            entity.Property(e => e.EmployeeTargetDetailId).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<Blog>(entity =>
        {
            entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            entity.Property(e => e.ModifiedOn).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.ParentId).HasDefaultValueSql("((0))");
        });

        modelBuilder.Entity<Ceomessage>(entity =>
        {
            entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            entity.Property(e => e.ModificationDate).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<EmployeeStatusMaster>(entity =>
        {
            entity.Property(e => e.EmployeeStatusId).ValueGeneratedNever();
            entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
        });

        modelBuilder.Entity<ErrorLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_log");
        });

        modelBuilder.Entity<GetOrderListAgainstEcitpc>(entity =>
        {
            entity.ToView("GetOrderListAgainstECITPC");
        });

        modelBuilder.Entity<Hrmanual>(entity =>
        {
            entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            entity.Property(e => e.ModifiedOn).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<InActiveEmployeesDarnotShiftedList>(entity =>
        {
            entity.ToView("InActiveEmployeesDARNotShiftedList");
        });

        modelBuilder.Entity<JobPromotion>(entity =>
        {
            entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            entity.Property(e => e.ModifiedOn).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<KnowledgeSharing>(entity =>
        {
            entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            entity.Property(e => e.ModifiedOn).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<OnlineTest>(entity =>
        {
            entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            entity.Property(e => e.ModifiedOn).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<OracleUser>(entity =>
        {
            entity.Property(e => e.Userid).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<OracleUsersBkp281111>(entity =>
        {
            entity.Property(e => e.Userid).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<Quote>(entity =>
        {
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IsDefault).HasDefaultValueSql("((0))");
        });

        modelBuilder.Entity<RecipientUsersList>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_RecipientUser");
        });

        modelBuilder.Entity<RecipientUsersListBkup05april2017>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<RecipientUsersListBkup20april2016>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<RecipientUsersListForTest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_RecipientUserTest");
        });

        modelBuilder.Entity<SnActivityArea>(entity =>
        {
            entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
        });

        modelBuilder.Entity<SnAppActivity>(entity =>
        {
            entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
        });

        modelBuilder.Entity<SnAppraisalGroup>(entity =>
        {
            entity.Property(e => e.IsActive).HasDefaultValueSql("((0))");
        });

        modelBuilder.Entity<SnAppraisalGroupForEmployee>(entity =>
        {
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.ModifiedDate).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<SnAppraisalGroupFourthReportingHeadMapping>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<SnAppraisalStaticQuestion>(entity =>
        {
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            entity.Property(e => e.ModifiedDate).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<SnApprasialAudit>(entity =>
        {
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<SnApprasialFormEmployeeRelationship>(entity =>
        {
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.UpdatedDate).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<SnApprasialFormEmployeeRelationship08april2019>(entity =>
        {
            entity.Property(e => e.FormEmployeeId).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<SnApprasialFormEmployeeRelationship1>(entity =>
        {
            entity.Property(e => e.FormEmployeeId).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<SnApprasialFormEmployeeRelationship2>(entity =>
        {
            entity.Property(e => e.FormEmployeeId).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<SnApprasialFormEmployeeRelationshipBkupon16July2015>(entity =>
        {
            entity.Property(e => e.FormEmployeeId).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<SnApprasialFormEmployeeSectionRelationsship>(entity =>
        {
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.UpdatedDate).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<SnApprasialFormQuestionRelationship>(entity =>
        {
            entity.HasKey(e => e.TransId).HasName("PK__SN_Appra__9E5DDB3C297980B3");
        });

        modelBuilder.Entity<SnApprasialFormSectionRelationship>(entity =>
        {
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.UpdatedDate).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<SnApprasialFormStaticQuestionRelationship>(entity =>
        {
            entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
        });

        modelBuilder.Entity<SnApprraisalMasterSalaryBreakup>(entity =>
        {
            entity.HasKey(e => e.BreakUpId).HasName("PK_Sn_AprraisalMasterSalaryBreakup");

            entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
            entity.Property(e => e.IsYearly).HasComment("Y-Yearly\r\nM-Monthly");
            entity.Property(e => e.ModifiedOn).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<SnApprraisalMasterSalaryBreakup18apr2019>(entity =>
        {
            entity.Property(e => e.BreakUpId).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<SnApprraisalSalaryBreakupValue>(entity =>
        {
            entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
            entity.Property(e => e.ModifiedOn).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.PercentOrAmount)
                .IsFixedLength()
                .HasComment("P-Percentage\r\nA-Amount");
        });

        modelBuilder.Entity<SnApprraisalText>(entity =>
        {
            entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
            entity.Property(e => e.ModifiedOn).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<SnBranchMaster>(entity =>
        {
            entity.Property(e => e.BranchStatus).HasDefaultValueSql("((1))");
            entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
        });

        modelBuilder.Entity<SnCallStatusMaster>(entity =>
        {
            entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
        });

        modelBuilder.Entity<SnCallTypeMaster>(entity =>
        {
            entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
        });

        modelBuilder.Entity<SnClaimMasterDetail>(entity =>
        {
            entity.Property(e => e.ApproveRejectedBy).HasDefaultValueSql("('0')");
            entity.Property(e => e.ApproveRejectionDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.ClaimSettledBy).HasDefaultValueSql("('0')");
            entity.Property(e => e.ClaimSettlementDate).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<SnClaimTravelExpensesDetail>(entity =>
        {
            entity.Property(e => e.TravelExpensesDetailsId).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<SnCompetitor>(entity =>
        {
            entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
        });

        modelBuilder.Entity<SnCustDepartmentMaster>(entity =>
        {
            entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
        });

        modelBuilder.Entity<SnCustDesignationMaster>(entity =>
        {
            entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
        });

        modelBuilder.Entity<SnCustomer>(entity =>
        {
            entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.CustomerStatus).HasDefaultValueSql("((1))");
            entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
        });

        modelBuilder.Entity<SnCustomerContact>(entity =>
        {
            entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
        });

        modelBuilder.Entity<SnCustomerContactsBkup>(entity =>
        {
            entity.Property(e => e.CustContactId).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<SnCustomerProduct>(entity =>
        {
            entity.Property(e => e.CustProductStatus).HasDefaultValueSql("((1))");
            entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
        });

        modelBuilder.Entity<SnCustomersBckup10may2023>(entity =>
        {
            entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
        });

        modelBuilder.Entity<SnCustomersBkup>(entity =>
        {
            entity.Property(e => e.CustomerId).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<SnCustomertemp>(entity =>
        {
            entity.Property(e => e.CustomerId).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<SnDar>(entity =>
        {
            entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IsAppDar).HasDefaultValueSql("((0))");
            entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
        });

        modelBuilder.Entity<SnDarComment>(entity =>
        {
            entity.Property(e => e.DarCommentOn).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
        });

        modelBuilder.Entity<SnDarCompetitor>(entity =>
        {
            entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
        });

        modelBuilder.Entity<SnDarMovement>(entity =>
        {
            entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
        });

        modelBuilder.Entity<SnDarProduct>(entity =>
        {
            entity.Property(e => e.DarProductId).ValueGeneratedOnAdd();
            entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
        });

        modelBuilder.Entity<SnDarproductsOld>(entity =>
        {
            entity.Property(e => e.DarProductId).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<SnDarstatus>(entity =>
        {
            entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
        });

        modelBuilder.Entity<SnDepartmentMaster>(entity =>
        {
            entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
        });

        modelBuilder.Entity<SnDesignationMaster>(entity =>
        {
            entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
        });

        modelBuilder.Entity<SnEmployee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK_SN_EmployeesModified");

            entity.Property(e => e.EmployeeId).ValueGeneratedNever();
            entity.Property(e => e.AadharNumber).IsFixedLength();
            entity.Property(e => e.BloodGroup).IsFixedLength();
            entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Emergencycontactnumber).IsFixedLength();
            entity.Property(e => e.EmpStatus).HasDefaultValueSql("((1))");
            entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
            entity.Property(e => e.IsSalesNetUser).HasDefaultValueSql("((0))");
            entity.Property(e => e.StdNumber).IsFixedLength();
        });

        modelBuilder.Entity<SnEmployeeAddress>(entity =>
        {
            entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
            entity.Property(e => e.IsPermanentAddress).HasDefaultValueSql("((1))");
        });

        modelBuilder.Entity<SnEmployeeAttachment>(entity =>
        {
            entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
        });

        modelBuilder.Entity<SnEmployeeError>(entity =>
        {
            entity.Property(e => e.ErrorDate).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<SnEmployeeIncentive>(entity =>
        {
            entity.Property(e => e.IncentiveId).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<SnEmployeeIncentiveBkup04may2016>(entity =>
        {
            entity.Property(e => e.IncentiveId).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<SnEmployeeIncentiveBkup05nov2014>(entity =>
        {
            entity.Property(e => e.IncentiveId).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<SnEmployeeIncentiverenamed>(entity =>
        {
            entity.HasKey(e => e.IncentiveId).HasName("PK_SN_EmployeeIncentive");

            entity.Property(e => e.AppIncentiveType).HasDefaultValueSql("((0))");
        });

        modelBuilder.Entity<SnEmployeePolicy>(entity =>
        {
            entity.Property(e => e.IsMediclaimPolicy).HasDefaultValueSql("((1))");
        });

        modelBuilder.Entity<SnEmployeeProductVertical>(entity =>
        {
            entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
            entity.Property(e => e.VerticalStatus).HasDefaultValueSql("((1))");
        });

        modelBuilder.Entity<SnEmployeeTarget>(entity =>
        {
            entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<SnEmployeeTargetDetail>(entity =>
        {
            entity.Property(e => e.GroupTarget).HasDefaultValueSql("((0))");
        });

        modelBuilder.Entity<SnEmployeeTargetDetailsBackUp18092013>(entity =>
        {
            entity.Property(e => e.EmployeeTargetDetailId).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<SnEmployeeTargetMasterBackUp18092013>(entity =>
        {
            entity.Property(e => e.EmployeeTargetId).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<SnEmployees25july2018>(entity =>
        {
            entity.Property(e => e.BloodGroup).IsFixedLength();
            entity.Property(e => e.Emergencycontactnumber).IsFixedLength();
        });

        modelBuilder.Entity<SnEmployees25nov2019>(entity =>
        {
            entity.Property(e => e.AadharNumber).IsFixedLength();
            entity.Property(e => e.BloodGroup).IsFixedLength();
            entity.Property(e => e.Emergencycontactnumber).IsFixedLength();
            entity.Property(e => e.StdNumber).IsFixedLength();
        });

        modelBuilder.Entity<SnEmployeesOld>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK_SN_Employees");

            entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.EmpStatus).HasDefaultValueSql("((1))");
            entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
            entity.Property(e => e.IsSalesNetUser).HasDefaultValueSql("((1))");
        });

        modelBuilder.Entity<SnFundType>(entity =>
        {
            entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
        });

        modelBuilder.Entity<SnGradeMaster>(entity =>
        {
            entity.Property(e => e.Grade).IsFixedLength();
        });

        modelBuilder.Entity<SnGroupEmployeeRelationship>(entity =>
        {
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.UpdatedDate).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<SnHierarchy>(entity =>
        {
            entity.Property(e => e.SnhierarchyId).ValueGeneratedNever();
            entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            entity.Property(e => e.IsApplicationTeam).HasDefaultValueSql("((1))");
            entity.Property(e => e.IsHorizontalAccess).HasDefaultValueSql("((1))");
            entity.Property(e => e.IsMarketingTeam).HasDefaultValueSql("((1))");
        });

        modelBuilder.Entity<SnHoliday>(entity =>
        {
            entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
            entity.Property(e => e.ModifiedOn).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<SnHolidayBak>(entity =>
        {
            entity.Property(e => e.HolidayId).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<SnHrloginCredential>(entity =>
        {
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.UpdatedDate).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<SnLeadGeneration>(entity =>
        {
            entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
        });

        modelBuilder.Entity<SnLeadProduct>(entity =>
        {
            entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
        });

        modelBuilder.Entity<SnLeadStatus>(entity =>
        {
            entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
        });

        modelBuilder.Entity<SnLeadTypeMaster>(entity =>
        {
            entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
        });

        modelBuilder.Entity<SnLockDay>(entity =>
        {
            entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            entity.Property(e => e.LockId).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<SnLogError>(entity =>
        {
            entity.Property(e => e.ErrorDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.LogId).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<SnLostReason>(entity =>
        {
            entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
        });

        modelBuilder.Entity<SnManageEmployeeApprHistory>(entity =>
        {
            entity.HasKey(e => e.TransId).HasName("PK__SN_Manag__9E5DDB3CFB186EE4");
        });

        modelBuilder.Entity<SnMasterAppraisalCategory>(entity =>
        {
            entity.Property(e => e.AppraisalCategoryId).ValueGeneratedOnAdd();
            entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
        });

        modelBuilder.Entity<SnMasterQuestion>(entity =>
        {
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<SnMasterSla>(entity =>
        {
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<SnMasterStatus>(entity =>
        {
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.UpdatedDate).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<SnMasterUserType>(entity =>
        {
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<SnOfficeActivity>(entity =>
        {
            entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
        });

        modelBuilder.Entity<SnOfficeDar>(entity =>
        {
            entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
        });

        modelBuilder.Entity<SnOrderPrincipal>(entity =>
        {
            entity.Property(e => e.ReceivedStatus).HasDefaultValueSql("((0))");
        });

        modelBuilder.Entity<SnOrderProcessing>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK_SN_Processing");
        });

        modelBuilder.Entity<SnPaymentDetail>(entity =>
        {
            entity.HasKey(e => e.PaymentCollectionId).HasName("PK_SN_PaymentCollection");
        });

        modelBuilder.Entity<SnPrincipalMaster>(entity =>
        {
            entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
            entity.Property(e => e.PrincipalStatus).HasDefaultValueSql("((1))");
        });

        modelBuilder.Entity<SnProduct>(entity =>
        {
            entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
            entity.Property(e => e.ProductStatus).HasDefaultValueSql("((1))");
        });

        modelBuilder.Entity<SnProductPrincipalMapping>(entity =>
        {
            entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
        });

        modelBuilder.Entity<SnQuotationDetail>(entity =>
        {
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IsLatest).HasDefaultValueSql("((1))");
            entity.Property(e => e.ModifiedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.QuotationStatus).HasDefaultValueSql("((0))");
        });

        modelBuilder.Entity<SnQuotationNote>(entity =>
        {
            entity.Property(e => e.Active).HasDefaultValueSql("((1))");
        });

        modelBuilder.Entity<SnQuotationProductInfo>(entity =>
        {
            entity.Property(e => e.OptionChoosen).HasDefaultValueSql("((0))");
        });

        modelBuilder.Entity<SnQuotationSentTo>(entity =>
        {
            entity.Property(e => e.Sno).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<SnReceivedMaster>(entity =>
        {
            entity.HasKey(e => e.ReceivedId).HasName("PK_SN_OrderReceivedMaster");
        });

        modelBuilder.Entity<SnRecipientListForVisitDateMail>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<SnRecipientOrderList>(entity =>
        {
            entity.Property(e => e.DeliveryStatus).HasDefaultValueSql("((0))");
        });

        modelBuilder.Entity<SnRegionMaster>(entity =>
        {
            entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
            entity.Property(e => e.RegionStatus).HasDefaultValueSql("((1))");
        });

        modelBuilder.Entity<SnRevenuePercentage>(entity =>
        {
            entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IsActive)
                .HasDefaultValueSql("((1))")
                .HasComment("1- Active\r\n0 - De-Active");
            entity.Property(e => e.ModifiedOn).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<SnSavedSearch>(entity =>
        {
            entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<SnSemesterMaster>(entity =>
        {
            entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
        });

        modelBuilder.Entity<SnStaticTextMaster>(entity =>
        {
            entity.Property(e => e.StaticTextId).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<SnSubVerticalMaster>(entity =>
        {
            entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
        });

        modelBuilder.Entity<SnVerticalMaster>(entity =>
        {
            entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
        });

        modelBuilder.Entity<SnWeeklyActivity>(entity =>
        {
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<SnWeeklyActivityBkup02feb2016>(entity =>
        {
            entity.Property(e => e.WeeklyActivityId).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<SnWishesTemplate>(entity =>
        {
            entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
        });

        modelBuilder.Entity<SnvwAppmi>(entity =>
        {
            entity.ToView("SNVW_APPMIS");
        });

        modelBuilder.Entity<SnvwDarcompetitor>(entity =>
        {
            entity.ToView("SNVW_DARCompetitors");
        });

        modelBuilder.Entity<SnvwLatestDar>(entity =>
        {
            entity.ToView("SNVW_LatestDAR");
        });

        modelBuilder.Entity<SnvwLatestDarForAppEngg>(entity =>
        {
            entity.ToView("SNVW_LatestDarForAppEngg");
        });

        modelBuilder.Entity<SnvwMisdar>(entity =>
        {
            entity.ToView("SNVW_MISDAR");
        });

        modelBuilder.Entity<SnvwMisproduct>(entity =>
        {
            entity.ToView("SNVW_MISProducts");
        });

        modelBuilder.Entity<SnvwOrderProcessingProduct>(entity =>
        {
            entity.ToView("SNVW_OrderProcessingProducts");
        });

        modelBuilder.Entity<SpecialUser>(entity =>
        {
            entity.ToView("SpecialUsers");
        });

        modelBuilder.Entity<SubVerticalPrincipalMapping>(entity =>
        {
            entity.HasKey(e => e.Mappingid).HasName("PK__subVerti__8B5885B5571AB1B5");
        });

        modelBuilder.Entity<TempActivityarea>(entity =>
        {
            entity.Property(e => e.ActivityAreaId).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<TestAssignment>(entity =>
        {
            entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
        });

        modelBuilder.Entity<TestMapping>(entity =>
        {
            entity.HasKey(e => e.TestMappingId).HasName("PK_TestMapping_1");

            entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
        });

        modelBuilder.Entity<TmpSnCustomerContact>(entity =>
        {
            entity.Property(e => e.CustContactId).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<Upcomingevent>(entity =>
        {
            entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToView("Users");
        });

        modelBuilder.Entity<Users1>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK_Users");
        });

        modelBuilder.Entity<Users2>(entity =>
        {
            entity.Property(e => e.Userid).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<UsersTemp>(entity =>
        {
            entity.ToView("UsersTemp");
        });

        modelBuilder.Entity<VwGetleadEmployee>(entity =>
        {
            entity.ToView("VW_GETLeadEmployees");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
