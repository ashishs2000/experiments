

// This file was automatically generated.
// Do not make changes directly to this file - edit the template instead.
// 
// The following connection settings were used to generate this file
// 
//     Configuration file:     "CypherConverter\App.config"
//     Connection String Name: "Coredata"
//     Connection String:      "Data Source=.;Initial Catalog=coredata;Trusted_Connection=True"

// ReSharper disable InconsistentNaming
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable PartialMethodWithSinglePart

using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration.Configuration;

namespace CypherConverter.Generated
{
	public static class CoredataDb
	{
		public class Application
		{
	 		public static string SchemaName
			{
				get { return "dbo"; }
			}
	 		

			public static string TableName
			{
				get { return "Applications"; }
			}

			public static string Id()
			{
				return "Id";
			}

			public static PrimitivePropertyConfiguration Id(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("Id").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			}

			public static PropertyMappingConfiguration Id(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("Id");
			}

			public static string Code()
			{
				return "Code";
			}

			public static StringPropertyConfiguration Code(StringPropertyConfiguration config)
			{
				return config.HasColumnName("Code").IsRequired().HasMaxLength(20);
			}

			public static PropertyMappingConfiguration Code(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("Code");
			}

			public static string Database()
			{
				return "Database";
			}

			public static StringPropertyConfiguration Database(StringPropertyConfiguration config)
			{
				return config.HasColumnName("Database").IsOptional().HasMaxLength(50);
			}

			public static PropertyMappingConfiguration Database(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("Database");
			}

			public static string Schema()
			{
				return "Schema";
			}

			public static StringPropertyConfiguration Schema(StringPropertyConfiguration config)
			{
				return config.HasColumnName("Schema").IsOptional().HasMaxLength(50);
			}

			public static PropertyMappingConfiguration Schema(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("Schema");
			}

		}

		public class ApplicationSetting
		{
	 		public static string SchemaName
			{
				get { return "dbo"; }
			}
	 		

			public static string TableName
			{
				get { return "ApplicationSettings"; }
			}

			public static string ApplicationSettingId()
			{
				return "ApplicationSettingID";
			}

			public static PrimitivePropertyConfiguration ApplicationSettingId(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("ApplicationSettingID").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			}

			public static PropertyMappingConfiguration ApplicationSettingId(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("ApplicationSettingID");
			}

			public static string EmployerId()
			{
				return "EmployerID";
			}

			public static PrimitivePropertyConfiguration EmployerId(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("EmployerID").IsOptional();
			}

			public static PropertyMappingConfiguration EmployerId(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("EmployerID");
			}

			public static string Code()
			{
				return "Code";
			}

			public static StringPropertyConfiguration Code(StringPropertyConfiguration config)
			{
				return config.HasColumnName("Code").IsRequired().IsUnicode(false).HasMaxLength(50);
			}

			public static PropertyMappingConfiguration Code(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("Code");
			}

			public static string Setting()
			{
				return "Setting";
			}

			public static StringPropertyConfiguration Setting(StringPropertyConfiguration config)
			{
				return config.HasColumnName("Setting").IsOptional().IsUnicode(false).HasMaxLength(5000);
			}

			public static PropertyMappingConfiguration Setting(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("Setting");
			}

			public static string Description()
			{
				return "Description";
			}

			public static StringPropertyConfiguration Description(StringPropertyConfiguration config)
			{
				return config.HasColumnName("Description").IsRequired().IsUnicode(false).HasMaxLength(100);
			}

			public static PropertyMappingConfiguration Description(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("Description");
			}

			public static string UpdateDateTime()
			{
				return "UpdateDateTime";
			}

			public static DateTimePropertyConfiguration UpdateDateTime(DateTimePropertyConfiguration config)
			{
				return config.HasColumnName("UpdateDateTime").IsRequired();
			}

			public static PropertyMappingConfiguration UpdateDateTime(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("UpdateDateTime");
			}

			public static string AllowUserModification()
			{
				return "AllowUserModification";
			}

			public static PrimitivePropertyConfiguration AllowUserModification(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("AllowUserModification").IsRequired();
			}

			public static PropertyMappingConfiguration AllowUserModification(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("AllowUserModification");
			}

			public static string ExpectedValue()
			{
				return "ExpectedValue";
			}

			public static StringPropertyConfiguration ExpectedValue(StringPropertyConfiguration config)
			{
				return config.HasColumnName("ExpectedValue").IsOptional().IsUnicode(false).HasMaxLength(50);
			}

			public static PropertyMappingConfiguration ExpectedValue(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("ExpectedValue");
			}

			public static string UpdatedByUserId()
			{
				return "UpdatedByUserID";
			}

			public static PrimitivePropertyConfiguration UpdatedByUserId(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("UpdatedByUserID").IsRequired();
			}

			public static PropertyMappingConfiguration UpdatedByUserId(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("UpdatedByUserID");
			}

			public static string CreatedByUserId()
			{
				return "CreatedByUserID";
			}

			public static PrimitivePropertyConfiguration CreatedByUserId(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("CreatedByUserID").IsRequired();
			}

			public static PropertyMappingConfiguration CreatedByUserId(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("CreatedByUserID");
			}

			public static string CreationDateTime()
			{
				return "CreationDateTime";
			}

			public static DateTimePropertyConfiguration CreationDateTime(DateTimePropertyConfiguration config)
			{
				return config.HasColumnName("CreationDateTime").IsRequired();
			}

			public static PropertyMappingConfiguration CreationDateTime(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("CreationDateTime");
			}

			public static string ValidationType()
			{
				return "ValidationType";
			}

			public static PrimitivePropertyConfiguration ValidationType(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("ValidationType").IsRequired();
			}

			public static PropertyMappingConfiguration ValidationType(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("ValidationType");
			}

			public static string ValidationData()
			{
				return "ValidationData";
			}

			public static StringPropertyConfiguration ValidationData(StringPropertyConfiguration config)
			{
				return config.HasColumnName("ValidationData").IsOptional().IsUnicode(false).HasMaxLength(200);
			}

			public static PropertyMappingConfiguration ValidationData(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("ValidationData");
			}

			public static string ValidationMin()
			{
				return "ValidationMin";
			}

			public static StringPropertyConfiguration ValidationMin(StringPropertyConfiguration config)
			{
				return config.HasColumnName("ValidationMin").IsOptional().IsUnicode(false).HasMaxLength(200);
			}

			public static PropertyMappingConfiguration ValidationMin(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("ValidationMin");
			}

			public static string ValidationMax()
			{
				return "ValidationMax";
			}

			public static StringPropertyConfiguration ValidationMax(StringPropertyConfiguration config)
			{
				return config.HasColumnName("ValidationMax").IsOptional().IsUnicode(false).HasMaxLength(200);
			}

			public static PropertyMappingConfiguration ValidationMax(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("ValidationMax");
			}

			public static string ValidationMaxMinValueType()
			{
				return "ValidationMaxMinValueType";
			}

			public static PrimitivePropertyConfiguration ValidationMaxMinValueType(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("ValidationMaxMinValueType").IsOptional();
			}

			public static PropertyMappingConfiguration ValidationMaxMinValueType(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("ValidationMaxMinValueType");
			}

			public static string ExtendedHelp()
			{
				return "ExtendedHelp";
			}

			public static StringPropertyConfiguration ExtendedHelp(StringPropertyConfiguration config)
			{
				return config.HasColumnName("ExtendedHelp").IsOptional().IsUnicode(false);
			}

			public static PropertyMappingConfiguration ExtendedHelp(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("ExtendedHelp");
			}

			public static string Unit()
			{
				return "Unit";
			}

			public static StringPropertyConfiguration Unit(StringPropertyConfiguration config)
			{
				return config.HasColumnName("Unit").IsOptional().IsUnicode(false).HasMaxLength(200);
			}

			public static PropertyMappingConfiguration Unit(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("Unit");
			}

			public static string ControlType()
			{
				return "ControlType";
			}

			public static PrimitivePropertyConfiguration ControlType(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("ControlType").IsRequired();
			}

			public static PropertyMappingConfiguration ControlType(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("ControlType");
			}

			public static string ControlSupportData()
			{
				return "ControlSupportData";
			}

			public static StringPropertyConfiguration ControlSupportData(StringPropertyConfiguration config)
			{
				return config.HasColumnName("ControlSupportData").IsOptional();
			}

			public static PropertyMappingConfiguration ControlSupportData(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("ControlSupportData");
			}

			public static string SaveDataTreatment()
			{
				return "SaveDataTreatment";
			}

			public static PrimitivePropertyConfiguration SaveDataTreatment(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("SaveDataTreatment").IsRequired();
			}

			public static PropertyMappingConfiguration SaveDataTreatment(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("SaveDataTreatment");
			}

			public static string DisplayOrder()
			{
				return "DisplayOrder";
			}

			public static PrimitivePropertyConfiguration DisplayOrder(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("DisplayOrder").IsOptional();
			}

			public static PropertyMappingConfiguration DisplayOrder(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("DisplayOrder");
			}

			public static string AllowUserView()
			{
				return "AllowUserView";
			}

			public static PrimitivePropertyConfiguration AllowUserView(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("AllowUserView").IsRequired();
			}

			public static PropertyMappingConfiguration AllowUserView(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("AllowUserView");
			}

			public static string Value()
			{
				return "Value";
			}

			public static StringPropertyConfiguration Value(StringPropertyConfiguration config)
			{
				return config.HasColumnName("Value").IsOptional().IsUnicode(false);
			}

			public static PropertyMappingConfiguration Value(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("Value");
			}

		}

		public class Brand
		{
	 		public static string SchemaName
			{
				get { return "dbo"; }
			}
	 		

			public static string TableName
			{
				get { return "Brands"; }
			}

			public static string BrandId()
			{
				return "BrandID";
			}

			public static PrimitivePropertyConfiguration BrandId(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("BrandID").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			}

			public static PropertyMappingConfiguration BrandId(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("BrandID");
			}

			public static string Url()
			{
				return "url";
			}

			public static StringPropertyConfiguration Url(StringPropertyConfiguration config)
			{
				return config.HasColumnName("url").IsRequired().IsUnicode(false).HasMaxLength(150);
			}

			public static PropertyMappingConfiguration Url(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("url");
			}

			public static string Name()
			{
				return "name";
			}

			public static StringPropertyConfiguration Name(StringPropertyConfiguration config)
			{
				return config.HasColumnName("name").IsRequired().IsUnicode(false).HasMaxLength(150);
			}

			public static PropertyMappingConfiguration Name(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("name");
			}

			public static string CompanyName()
			{
				return "companyName";
			}

			public static StringPropertyConfiguration CompanyName(StringPropertyConfiguration config)
			{
				return config.HasColumnName("companyName").IsRequired().IsUnicode(false).HasMaxLength(150);
			}

			public static PropertyMappingConfiguration CompanyName(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("companyName");
			}

			public static string AllowSso()
			{
				return "allowSSO";
			}

			public static PrimitivePropertyConfiguration AllowSso(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("allowSSO").IsRequired();
			}

			public static PropertyMappingConfiguration AllowSso(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("allowSSO");
			}

			public static string LogoUrl()
			{
				return "logoUrl";
			}

			public static StringPropertyConfiguration LogoUrl(StringPropertyConfiguration config)
			{
				return config.HasColumnName("logoUrl").IsRequired().IsUnicode(false).HasMaxLength(150);
			}

			public static PropertyMappingConfiguration LogoUrl(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("logoUrl");
			}

			public static string Helpurl()
			{
				return "helpurl";
			}

			public static StringPropertyConfiguration Helpurl(StringPropertyConfiguration config)
			{
				return config.HasColumnName("helpurl").IsRequired().IsUnicode(false).HasMaxLength(150);
			}

			public static PropertyMappingConfiguration Helpurl(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("helpurl");
			}

			public static string CompanyUrl()
			{
				return "companyUrl";
			}

			public static StringPropertyConfiguration CompanyUrl(StringPropertyConfiguration config)
			{
				return config.HasColumnName("companyUrl").IsOptional().IsUnicode(false).HasMaxLength(255);
			}

			public static PropertyMappingConfiguration CompanyUrl(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("companyUrl");
			}

			public static string Email()
			{
				return "email";
			}

			public static StringPropertyConfiguration Email(StringPropertyConfiguration config)
			{
				return config.HasColumnName("email").IsRequired().IsUnicode(false).HasMaxLength(255);
			}

			public static PropertyMappingConfiguration Email(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("email");
			}

		}

		public class ClassSpecDepartmentMat
		{
	 		public static string SchemaName
			{
				get { return "dbo"; }
			}
	 		

			public static string TableName
			{
				get { return "ClassSpecDepartmentMat"; }
			}

			public static string ClassSpecDepartmentId()
			{
				return "ClassSpecDepartmentId";
			}

			public static PrimitivePropertyConfiguration ClassSpecDepartmentId(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("ClassSpecDepartmentId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			}

			public static PropertyMappingConfiguration ClassSpecDepartmentId(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("ClassSpecDepartmentId");
			}

			public static string ClassSpecId()
			{
				return "ClassSpecId";
			}

			public static PrimitivePropertyConfiguration ClassSpecId(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("ClassSpecId").IsRequired();
			}

			public static PropertyMappingConfiguration ClassSpecId(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("ClassSpecId");
			}

			public static string DepartmentId()
			{
				return "DepartmentId";
			}

			public static PrimitivePropertyConfiguration DepartmentId(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("DepartmentId").IsRequired();
			}

			public static PropertyMappingConfiguration DepartmentId(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("DepartmentId");
			}

		}

		public class ClassSpecMaster
		{
	 		public static string SchemaName
			{
				get { return "dbo"; }
			}
	 		

			public static string TableName
			{
				get { return "Class_Spec_Master"; }
			}

			public static string ClassSpecId()
			{
				return "ClassSpecID";
			}

			public static PrimitivePropertyConfiguration ClassSpecId(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("ClassSpecID").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			}

			public static PropertyMappingConfiguration ClassSpecId(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("ClassSpecID");
			}

			public static string ClassCode()
			{
				return "Class_Code";
			}

			public static StringPropertyConfiguration ClassCode(StringPropertyConfiguration config)
			{
				return config.HasColumnName("Class_Code").IsOptional().IsUnicode(false).HasMaxLength(50);
			}

			public static PropertyMappingConfiguration ClassCode(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("Class_Code");
			}

			public static string ClassTitle()
			{
				return "Class_Title";
			}

			public static StringPropertyConfiguration ClassTitle(StringPropertyConfiguration config)
			{
				return config.HasColumnName("Class_Title").IsOptional().IsUnicode(false).HasMaxLength(300);
			}

			public static PropertyMappingConfiguration ClassTitle(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("Class_Title");
			}

			public static string ClassConcept()
			{
				return "Class_Concept";
			}

			public static StringPropertyConfiguration ClassConcept(StringPropertyConfiguration config)
			{
				return config.HasColumnName("Class_Concept").IsOptional().IsUnicode(false);
			}

			public static PropertyMappingConfiguration ClassConcept(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("Class_Concept");
			}

			public static string RevisionDate()
			{
				return "RevisionDate";
			}

			public static DateTimePropertyConfiguration RevisionDate(DateTimePropertyConfiguration config)
			{
				return config.HasColumnName("RevisionDate").IsOptional();
			}

			public static PropertyMappingConfiguration RevisionDate(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("RevisionDate");
			}

			public static string ExamplesOfDuties()
			{
				return "ExamplesOfDuties";
			}

			public static StringPropertyConfiguration ExamplesOfDuties(StringPropertyConfiguration config)
			{
				return config.HasColumnName("ExamplesOfDuties").IsOptional().IsUnicode(false);
			}

			public static PropertyMappingConfiguration ExamplesOfDuties(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("ExamplesOfDuties");
			}

			public static string MinimumQualifications()
			{
				return "MinimumQualifications";
			}

			public static StringPropertyConfiguration MinimumQualifications(StringPropertyConfiguration config)
			{
				return config.HasColumnName("MinimumQualifications").IsOptional().IsUnicode(false);
			}

			public static PropertyMappingConfiguration MinimumQualifications(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("MinimumQualifications");
			}

			public static string SupplementalInfo()
			{
				return "SupplementalInfo";
			}

			public static StringPropertyConfiguration SupplementalInfo(StringPropertyConfiguration config)
			{
				return config.HasColumnName("SupplementalInfo").IsOptional().IsUnicode(false);
			}

			public static PropertyMappingConfiguration SupplementalInfo(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("SupplementalInfo");
			}

			public static string EmployerId()
			{
				return "EmployerID";
			}

			public static PrimitivePropertyConfiguration EmployerId(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("EmployerID").IsOptional();
			}

			public static PropertyMappingConfiguration EmployerId(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("EmployerID");
			}

			public static string BargainingUnitId()
			{
				return "BargainingUnitID";
			}

			public static PrimitivePropertyConfiguration BargainingUnitId(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("BargainingUnitID").IsOptional();
			}

			public static PropertyMappingConfiguration BargainingUnitId(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("BargainingUnitID");
			}

			public static string OcGroupId()
			{
				return "OCGroupID";
			}

			public static PrimitivePropertyConfiguration OcGroupId(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("OCGroupID").IsOptional();
			}

			public static PropertyMappingConfiguration OcGroupId(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("OCGroupID");
			}

			public static string BenefitCodeId()
			{
				return "BenefitCodeID";
			}

			public static PrimitivePropertyConfiguration BenefitCodeId(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("BenefitCodeID").IsOptional();
			}

			public static PropertyMappingConfiguration BenefitCodeId(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("BenefitCodeID");
			}

			public static string Flsa()
			{
				return "FLSA";
			}

			public static PrimitivePropertyConfiguration Flsa(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("FLSA").IsOptional();
			}

			public static PropertyMappingConfiguration Flsa(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("FLSA");
			}

			public static string PhysicalClassId()
			{
				return "PhysicalClassID";
			}

			public static PrimitivePropertyConfiguration PhysicalClassId(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("PhysicalClassID").IsOptional();
			}

			public static PropertyMappingConfiguration PhysicalClassId(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("PhysicalClassID");
			}

			public static string AppI()
			{
				return "APP_I";
			}

			public static StringPropertyConfiguration AppI(StringPropertyConfiguration config)
			{
				return config.HasColumnName("APP_I").IsOptional().IsUnicode(false).HasMaxLength(50);
			}

			public static PropertyMappingConfiguration AppI(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("APP_I");
			}

			public static string AppIi()
			{
				return "APP_II";
			}

			public static StringPropertyConfiguration AppIi(StringPropertyConfiguration config)
			{
				return config.HasColumnName("APP_II").IsOptional().IsUnicode(false).HasMaxLength(50);
			}

			public static PropertyMappingConfiguration AppIi(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("APP_II");
			}

			public static string Eeoid()
			{
				return "EEOID";
			}

			public static PrimitivePropertyConfiguration Eeoid(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("EEOID").IsOptional();
			}

			public static PropertyMappingConfiguration Eeoid(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("EEOID");
			}

			public static string Notes()
			{
				return "Notes";
			}

			public static StringPropertyConfiguration Notes(StringPropertyConfiguration config)
			{
				return config.HasColumnName("Notes").IsOptional().IsUnicode(false);
			}

			public static PropertyMappingConfiguration Notes(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("Notes");
			}

			public static string OtherRequirements()
			{
				return "OtherRequirements";
			}

			public static StringPropertyConfiguration OtherRequirements(StringPropertyConfiguration config)
			{
				return config.HasColumnName("OtherRequirements").IsOptional().IsUnicode(false);
			}

			public static PropertyMappingConfiguration OtherRequirements(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("OtherRequirements");
			}

			public static string CreatedById()
			{
				return "CreatedByID";
			}

			public static PrimitivePropertyConfiguration CreatedById(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("CreatedByID").IsOptional();
			}

			public static PropertyMappingConfiguration CreatedById(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("CreatedByID");
			}

			public static string CreatedDate()
			{
				return "CreatedDate";
			}

			public static DateTimePropertyConfiguration CreatedDate(DateTimePropertyConfiguration config)
			{
				return config.HasColumnName("CreatedDate").IsOptional();
			}

			public static PropertyMappingConfiguration CreatedDate(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("CreatedDate");
			}

			public static string LastUpdatedId()
			{
				return "LastUpdatedID";
			}

			public static PrimitivePropertyConfiguration LastUpdatedId(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("LastUpdatedID").IsOptional();
			}

			public static PropertyMappingConfiguration LastUpdatedId(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("LastUpdatedID");
			}

			public static string LastUpdatedDate()
			{
				return "LastUpdatedDate";
			}

			public static DateTimePropertyConfiguration LastUpdatedDate(DateTimePropertyConfiguration config)
			{
				return config.HasColumnName("LastUpdatedDate").IsOptional();
			}

			public static PropertyMappingConfiguration LastUpdatedDate(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("LastUpdatedDate");
			}

			public static string TopStep()
			{
				return "Top_Step";
			}

			public static StringPropertyConfiguration TopStep(StringPropertyConfiguration config)
			{
				return config.HasColumnName("Top_Step").IsOptional().IsUnicode(false).HasMaxLength(50);
			}

			public static PropertyMappingConfiguration TopStep(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("Top_Step");
			}

			public static string StepAtEntry()
			{
				return "StepAtEntry";
			}

			public static StringPropertyConfiguration StepAtEntry(StringPropertyConfiguration config)
			{
				return config.HasColumnName("StepAtEntry").IsOptional().IsUnicode(false).HasMaxLength(50);
			}

			public static PropertyMappingConfiguration StepAtEntry(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("StepAtEntry");
			}

			public static string SalaryMin()
			{
				return "SalaryMIN";
			}

			public static PrimitivePropertyConfiguration SalaryMin(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("SalaryMIN").IsOptional();
			}

			public static PropertyMappingConfiguration SalaryMin(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("SalaryMIN");
			}

			public static string SalaryMax()
			{
				return "SalaryMAX";
			}

			public static PrimitivePropertyConfiguration SalaryMax(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("SalaryMAX").IsOptional();
			}

			public static PropertyMappingConfiguration SalaryMax(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("SalaryMAX");
			}

			public static string NonStdRate()
			{
				return "Non_STD_Rate";
			}

			public static PrimitivePropertyConfiguration NonStdRate(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("Non_STD_Rate").IsOptional();
			}

			public static PropertyMappingConfiguration NonStdRate(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("Non_STD_Rate");
			}

			public static string SalaryPaidId()
			{
				return "SalaryPaidID";
			}

			public static PrimitivePropertyConfiguration SalaryPaidId(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("SalaryPaidID").IsOptional();
			}

			public static PropertyMappingConfiguration SalaryPaidId(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("SalaryPaidID");
			}

			public static string NonStandardPaidId()
			{
				return "NonStandardPaidID";
			}

			public static PrimitivePropertyConfiguration NonStandardPaidId(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("NonStandardPaidID").IsOptional();
			}

			public static PropertyMappingConfiguration NonStandardPaidId(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("NonStandardPaidID");
			}

			public static string RangeOfSalary()
			{
				return "Range_of_Salary";
			}

			public static StringPropertyConfiguration RangeOfSalary(StringPropertyConfiguration config)
			{
				return config.HasColumnName("Range_of_Salary").IsOptional().IsUnicode(false).HasMaxLength(50);
			}

			public static PropertyMappingConfiguration RangeOfSalary(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("Range_of_Salary");
			}

			public static string IsNonStandard()
			{
				return "ISNonStandard";
			}

			public static PrimitivePropertyConfiguration IsNonStandard(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("ISNonStandard").IsRequired();
			}

			public static PropertyMappingConfiguration IsNonStandard(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("ISNonStandard");
			}

			public static string LastRevisedDate()
			{
				return "LastRevisedDate";
			}

			public static DateTimePropertyConfiguration LastRevisedDate(DateTimePropertyConfiguration config)
			{
				return config.HasColumnName("LastRevisedDate").IsOptional();
			}

			public static PropertyMappingConfiguration LastRevisedDate(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("LastRevisedDate");
			}

			public static string Active()
			{
				return "Active";
			}

			public static PrimitivePropertyConfiguration Active(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("Active").IsRequired();
			}

			public static PropertyMappingConfiguration Active(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("Active");
			}

			public static string OtherTitle1()
			{
				return "OtherTitle1";
			}

			public static StringPropertyConfiguration OtherTitle1(StringPropertyConfiguration config)
			{
				return config.HasColumnName("OtherTitle1").IsOptional().IsUnicode(false);
			}

			public static PropertyMappingConfiguration OtherTitle1(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("OtherTitle1");
			}

			public static string OtherTitle2()
			{
				return "OtherTitle2";
			}

			public static StringPropertyConfiguration OtherTitle2(StringPropertyConfiguration config)
			{
				return config.HasColumnName("OtherTitle2").IsOptional().IsUnicode(false);
			}

			public static PropertyMappingConfiguration OtherTitle2(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("OtherTitle2");
			}

			public static string JobInterestCards()
			{
				return "JobInterestCards";
			}

			public static PrimitivePropertyConfiguration JobInterestCards(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("JobInterestCards").IsRequired();
			}

			public static PropertyMappingConfiguration JobInterestCards(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("JobInterestCards");
			}

			public static string BillableHoursId()
			{
				return "BillableHoursID";
			}

			public static PrimitivePropertyConfiguration BillableHoursId(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("BillableHoursID").IsRequired();
			}

			public static PropertyMappingConfiguration BillableHoursId(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("BillableHoursID");
			}

			public static string ClassFormula()
			{
				return "ClassFormula";
			}

			public static StringPropertyConfiguration ClassFormula(StringPropertyConfiguration config)
			{
				return config.HasColumnName("ClassFormula").IsOptional().IsUnicode(false).HasMaxLength(500);
			}

			public static PropertyMappingConfiguration ClassFormula(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("ClassFormula");
			}

			public static string ShowSalaryHourly()
			{
				return "showSalaryHourly";
			}

			public static PrimitivePropertyConfiguration ShowSalaryHourly(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("showSalaryHourly").IsRequired();
			}

			public static PropertyMappingConfiguration ShowSalaryHourly(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("showSalaryHourly");
			}

			public static string ShowSalaryDaily()
			{
				return "showSalaryDaily";
			}

			public static PrimitivePropertyConfiguration ShowSalaryDaily(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("showSalaryDaily").IsRequired();
			}

			public static PropertyMappingConfiguration ShowSalaryDaily(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("showSalaryDaily");
			}

			public static string ShowSalaryBiweekly()
			{
				return "showSalaryBiweekly";
			}

			public static PrimitivePropertyConfiguration ShowSalaryBiweekly(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("showSalaryBiweekly").IsRequired();
			}

			public static PropertyMappingConfiguration ShowSalaryBiweekly(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("showSalaryBiweekly");
			}

			public static string ShowSalaryWeekly()
			{
				return "showSalaryWeekly";
			}

			public static PrimitivePropertyConfiguration ShowSalaryWeekly(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("showSalaryWeekly").IsRequired();
			}

			public static PropertyMappingConfiguration ShowSalaryWeekly(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("showSalaryWeekly");
			}

			public static string ShowSalarySemiMonthly()
			{
				return "showSalarySemiMonthly";
			}

			public static PrimitivePropertyConfiguration ShowSalarySemiMonthly(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("showSalarySemiMonthly").IsRequired();
			}

			public static PropertyMappingConfiguration ShowSalarySemiMonthly(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("showSalarySemiMonthly");
			}

			public static string ShowSalaryMonthly()
			{
				return "showSalaryMonthly";
			}

			public static PrimitivePropertyConfiguration ShowSalaryMonthly(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("showSalaryMonthly").IsRequired();
			}

			public static PropertyMappingConfiguration ShowSalaryMonthly(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("showSalaryMonthly");
			}

			public static string ShowSalaryAnnually()
			{
				return "showSalaryAnnually";
			}

			public static PrimitivePropertyConfiguration ShowSalaryAnnually(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("showSalaryAnnually").IsRequired();
			}

			public static PropertyMappingConfiguration ShowSalaryAnnually(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("showSalaryAnnually");
			}

			public static string PlatformActive()
			{
				return "PlatformActive";
			}

			public static PrimitivePropertyConfiguration PlatformActive(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("PlatformActive").IsOptional();
			}

			public static PropertyMappingConfiguration PlatformActive(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("PlatformActive");
			}

		}

		public class CoreEventsProgress
		{
	 		public static string SchemaName
			{
				get { return "dbo"; }
			}
	 		

			public static string TableName
			{
				get { return "CoreEventsProgress"; }
			}

			public static string EventId()
			{
				return "EventId";
			}

			public static PrimitivePropertyConfiguration EventId(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("EventId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
			}

			public static PropertyMappingConfiguration EventId(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("EventId");
			}

			public static string ApplicationId()
			{
				return "ApplicationId";
			}

			public static PrimitivePropertyConfiguration ApplicationId(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("ApplicationId").IsRequired();
			}

			public static PropertyMappingConfiguration ApplicationId(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("ApplicationId");
			}

			public static string EmployerId()
			{
				return "EmployerId";
			}

			public static PrimitivePropertyConfiguration EmployerId(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("EmployerId").IsRequired();
			}

			public static PropertyMappingConfiguration EmployerId(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("EmployerId");
			}

			public static string Attempts()
			{
				return "Attempts";
			}

			public static PrimitivePropertyConfiguration Attempts(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("Attempts").IsRequired();
			}

			public static PropertyMappingConfiguration Attempts(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("Attempts");
			}

			public static string IsSynced()
			{
				return "IsSynced";
			}

			public static PrimitivePropertyConfiguration IsSynced(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("IsSynced").IsRequired();
			}

			public static PropertyMappingConfiguration IsSynced(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("IsSynced");
			}

			public static string Error()
			{
				return "Error";
			}

			public static StringPropertyConfiguration Error(StringPropertyConfiguration config)
			{
				return config.HasColumnName("Error").IsOptional().IsUnicode(false);
			}

			public static PropertyMappingConfiguration Error(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("Error");
			}

			public static string CreatedDate()
			{
				return "CreatedDate";
			}

			public static DateTimePropertyConfiguration CreatedDate(DateTimePropertyConfiguration config)
			{
				return config.HasColumnName("CreatedDate").IsRequired();
			}

			public static PropertyMappingConfiguration CreatedDate(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("CreatedDate");
			}

			public static string UpdatedDate()
			{
				return "UpdatedDate";
			}

			public static DateTimePropertyConfiguration UpdatedDate(DateTimePropertyConfiguration config)
			{
				return config.HasColumnName("UpdatedDate").IsRequired();
			}

			public static PropertyMappingConfiguration UpdatedDate(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("UpdatedDate");
			}

		}

		public class CustomLabel
		{
	 		public static string SchemaName
			{
				get { return "dbo"; }
			}
	 		

			public static string TableName
			{
				get { return "CustomLabels"; }
			}

			public static string CustomLabelId()
			{
				return "CustomLabelID";
			}

			public static PrimitivePropertyConfiguration CustomLabelId(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("CustomLabelID").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			}

			public static PropertyMappingConfiguration CustomLabelId(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("CustomLabelID");
			}

			public static string EmployerId()
			{
				return "EmployerID";
			}

			public static PrimitivePropertyConfiguration EmployerId(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("EmployerID").IsOptional();
			}

			public static PropertyMappingConfiguration EmployerId(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("EmployerID");
			}

			public static string LabelKey()
			{
				return "LabelKey";
			}

			public static StringPropertyConfiguration LabelKey(StringPropertyConfiguration config)
			{
				return config.HasColumnName("LabelKey").IsRequired().HasMaxLength(1000);
			}

			public static PropertyMappingConfiguration LabelKey(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("LabelKey");
			}

			public static string Singular()
			{
				return "Singular";
			}

			public static StringPropertyConfiguration Singular(StringPropertyConfiguration config)
			{
				return config.HasColumnName("Singular").IsRequired().HasMaxLength(1000);
			}

			public static PropertyMappingConfiguration Singular(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("Singular");
			}

			public static string Plural()
			{
				return "Plural";
			}

			public static StringPropertyConfiguration Plural(StringPropertyConfiguration config)
			{
				return config.HasColumnName("Plural").IsRequired().HasMaxLength(1000);
			}

			public static PropertyMappingConfiguration Plural(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("Plural");
			}

			public static string LabelLevel()
			{
				return "LabelLevel";
			}

			public static PrimitivePropertyConfiguration LabelLevel(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("LabelLevel").IsRequired();
			}

			public static PropertyMappingConfiguration LabelLevel(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("LabelLevel");
			}

			public static string IsSingularOnly()
			{
				return "IsSingularOnly";
			}

			public static PrimitivePropertyConfiguration IsSingularOnly(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("IsSingularOnly").IsRequired();
			}

			public static PropertyMappingConfiguration IsSingularOnly(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("IsSingularOnly");
			}

		}

		public class Department
		{
	 		public static string SchemaName
			{
				get { return "dbo"; }
			}
	 		

			public static string TableName
			{
				get { return "Departments"; }
			}

			public static string DepartmentId()
			{
				return "DepartmentID";
			}

			public static PrimitivePropertyConfiguration DepartmentId(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("DepartmentID").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			}

			public static PropertyMappingConfiguration DepartmentId(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("DepartmentID");
			}

			public static string DepartmentCode()
			{
				return "DepartmentCode";
			}

			public static StringPropertyConfiguration DepartmentCode(StringPropertyConfiguration config)
			{
				return config.HasColumnName("DepartmentCode").IsOptional().IsUnicode(false).HasMaxLength(50);
			}

			public static PropertyMappingConfiguration DepartmentCode(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("DepartmentCode");
			}

			public static string DepartmentName()
			{
				return "DepartmentName";
			}

			public static StringPropertyConfiguration DepartmentName(StringPropertyConfiguration config)
			{
				return config.HasColumnName("DepartmentName").IsOptional().IsUnicode(false).HasMaxLength(100);
			}

			public static PropertyMappingConfiguration DepartmentName(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("DepartmentName");
			}

			public static string EmployerId()
			{
				return "EmployerID";
			}

			public static PrimitivePropertyConfiguration EmployerId(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("EmployerID").IsRequired();
			}

			public static PropertyMappingConfiguration EmployerId(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("EmployerID");
			}

			public static string IsActive()
			{
				return "IsActive";
			}

			public static PrimitivePropertyConfiguration IsActive(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("IsActive").IsRequired();
			}

			public static PropertyMappingConfiguration IsActive(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("IsActive");
			}

			public static string Address1()
			{
				return "Address1";
			}

			public static StringPropertyConfiguration Address1(StringPropertyConfiguration config)
			{
				return config.HasColumnName("Address1").IsRequired().IsUnicode(false).HasMaxLength(80);
			}

			public static PropertyMappingConfiguration Address1(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("Address1");
			}

			public static string Address2()
			{
				return "Address2";
			}

			public static StringPropertyConfiguration Address2(StringPropertyConfiguration config)
			{
				return config.HasColumnName("Address2").IsRequired().IsUnicode(false).HasMaxLength(80);
			}

			public static PropertyMappingConfiguration Address2(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("Address2");
			}

			public static string City()
			{
				return "City";
			}

			public static StringPropertyConfiguration City(StringPropertyConfiguration config)
			{
				return config.HasColumnName("City").IsRequired().IsUnicode(false).HasMaxLength(50);
			}

			public static PropertyMappingConfiguration City(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("City");
			}

			public static string StateId()
			{
				return "StateID";
			}

			public static PrimitivePropertyConfiguration StateId(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("StateID").IsOptional();
			}

			public static PropertyMappingConfiguration StateId(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("StateID");
			}

			public static string ZipCode()
			{
				return "ZipCode";
			}

			public static StringPropertyConfiguration ZipCode(StringPropertyConfiguration config)
			{
				return config.HasColumnName("ZipCode").IsRequired().IsUnicode(false).HasMaxLength(50);
			}

			public static PropertyMappingConfiguration ZipCode(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("ZipCode");
			}

			public static string Phone1()
			{
				return "Phone1";
			}

			public static StringPropertyConfiguration Phone1(StringPropertyConfiguration config)
			{
				return config.HasColumnName("Phone1").IsRequired().IsUnicode(false).HasMaxLength(20);
			}

			public static PropertyMappingConfiguration Phone1(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("Phone1");
			}

			public static string Phone2()
			{
				return "Phone2";
			}

			public static StringPropertyConfiguration Phone2(StringPropertyConfiguration config)
			{
				return config.HasColumnName("Phone2").IsRequired().IsUnicode(false).HasMaxLength(20);
			}

			public static PropertyMappingConfiguration Phone2(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("Phone2");
			}

			public static string WebSiteUrl()
			{
				return "WebSiteURL";
			}

			public static StringPropertyConfiguration WebSiteUrl(StringPropertyConfiguration config)
			{
				return config.HasColumnName("WebSiteURL").IsOptional().IsUnicode(false).HasMaxLength(255);
			}

			public static PropertyMappingConfiguration WebSiteUrl(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("WebSiteURL");
			}

			public static string CreateDate()
			{
				return "createDate";
			}

			public static DateTimePropertyConfiguration CreateDate(DateTimePropertyConfiguration config)
			{
				return config.HasColumnName("createDate").IsOptional();
			}

			public static PropertyMappingConfiguration CreateDate(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("createDate");
			}

			public static string CreatedById()
			{
				return "createdByID";
			}

			public static PrimitivePropertyConfiguration CreatedById(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("createdByID").IsOptional();
			}

			public static PropertyMappingConfiguration CreatedById(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("createdByID");
			}

			public static string UpdateDate()
			{
				return "updateDate";
			}

			public static DateTimePropertyConfiguration UpdateDate(DateTimePropertyConfiguration config)
			{
				return config.HasColumnName("updateDate").IsOptional();
			}

			public static PropertyMappingConfiguration UpdateDate(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("updateDate");
			}

			public static string UpdatedById()
			{
				return "updatedByID";
			}

			public static PrimitivePropertyConfiguration UpdatedById(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("updatedByID").IsOptional();
			}

			public static PropertyMappingConfiguration UpdatedById(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("updatedByID");
			}

			public static string DeptLogo()
			{
				return "deptLogo";
			}

			public static StringPropertyConfiguration DeptLogo(StringPropertyConfiguration config)
			{
				return config.HasColumnName("deptLogo").IsOptional().IsUnicode(false).HasMaxLength(100);
			}

			public static PropertyMappingConfiguration DeptLogo(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("deptLogo");
			}

			public static string PlatformActive()
			{
				return "PlatformActive";
			}

			public static PrimitivePropertyConfiguration PlatformActive(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("PlatformActive").IsRequired();
			}

			public static PropertyMappingConfiguration PlatformActive(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("PlatformActive");
			}

		}

		public class Division
		{
	 		public static string SchemaName
			{
				get { return "dbo"; }
			}
	 		

			public static string TableName
			{
				get { return "Divisions"; }
			}

			public static string DivisionId()
			{
				return "DivisionID";
			}

			public static PrimitivePropertyConfiguration DivisionId(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("DivisionID").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			}

			public static PropertyMappingConfiguration DivisionId(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("DivisionID");
			}

			public static string Division_()
			{
				return "Division";
			}

			public static StringPropertyConfiguration Division_(StringPropertyConfiguration config)
			{
				return config.HasColumnName("Division").IsOptional().IsUnicode(false).HasMaxLength(200);
			}

			public static PropertyMappingConfiguration Division_(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("Division");
			}

			public static string DepartmentId()
			{
				return "DepartmentID";
			}

			public static PrimitivePropertyConfiguration DepartmentId(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("DepartmentID").IsRequired();
			}

			public static PropertyMappingConfiguration DepartmentId(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("DepartmentID");
			}

			public static string EmployerId()
			{
				return "EmployerID";
			}

			public static PrimitivePropertyConfiguration EmployerId(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("EmployerID").IsRequired();
			}

			public static PropertyMappingConfiguration EmployerId(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("EmployerID");
			}

			public static string DivisionCode()
			{
				return "DivisionCode";
			}

			public static StringPropertyConfiguration DivisionCode(StringPropertyConfiguration config)
			{
				return config.HasColumnName("DivisionCode").IsOptional().IsUnicode(false).HasMaxLength(50);
			}

			public static PropertyMappingConfiguration DivisionCode(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("DivisionCode");
			}

			public static string IsActive()
			{
				return "IsActive";
			}

			public static PrimitivePropertyConfiguration IsActive(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("IsActive").IsRequired();
			}

			public static PropertyMappingConfiguration IsActive(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("IsActive");
			}

			public static string CreateDate()
			{
				return "createDate";
			}

			public static DateTimePropertyConfiguration CreateDate(DateTimePropertyConfiguration config)
			{
				return config.HasColumnName("createDate").IsOptional();
			}

			public static PropertyMappingConfiguration CreateDate(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("createDate");
			}

			public static string CreatedById()
			{
				return "createdByID";
			}

			public static PrimitivePropertyConfiguration CreatedById(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("createdByID").IsOptional();
			}

			public static PropertyMappingConfiguration CreatedById(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("createdByID");
			}

			public static string UpdateDate()
			{
				return "updateDate";
			}

			public static DateTimePropertyConfiguration UpdateDate(DateTimePropertyConfiguration config)
			{
				return config.HasColumnName("updateDate").IsOptional();
			}

			public static PropertyMappingConfiguration UpdateDate(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("updateDate");
			}

			public static string UpdatedById()
			{
				return "updatedByID";
			}

			public static PrimitivePropertyConfiguration UpdatedById(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("updatedByID").IsOptional();
			}

			public static PropertyMappingConfiguration UpdatedById(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("updatedByID");
			}

			public static string PlatformActive()
			{
				return "PlatformActive";
			}

			public static PrimitivePropertyConfiguration PlatformActive(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("PlatformActive").IsRequired();
			}

			public static PropertyMappingConfiguration PlatformActive(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("PlatformActive");
			}

		}

		public class Employer
		{
	 		public static string SchemaName
			{
				get { return "dbo"; }
			}
	 		

			public static string TableName
			{
				get { return "Employers"; }
			}

			public static string EmployerId()
			{
				return "EmployerID";
			}

			public static PrimitivePropertyConfiguration EmployerId(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("EmployerID").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			}

			public static PropertyMappingConfiguration EmployerId(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("EmployerID");
			}

			public static string BrandId()
			{
				return "BrandID";
			}

			public static PrimitivePropertyConfiguration BrandId(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("BrandID").IsOptional();
			}

			public static PropertyMappingConfiguration BrandId(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("BrandID");
			}

			public static string IsActive()
			{
				return "isActive";
			}

			public static PrimitivePropertyConfiguration IsActive(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("isActive").IsRequired();
			}

			public static PropertyMappingConfiguration IsActive(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("isActive");
			}

			public static string Name()
			{
				return "name";
			}

			public static StringPropertyConfiguration Name(StringPropertyConfiguration config)
			{
				return config.HasColumnName("name").IsRequired().IsUnicode(false).HasMaxLength(100);
			}

			public static PropertyMappingConfiguration Name(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("name");
			}

			public static string Code()
			{
				return "code";
			}

			public static StringPropertyConfiguration Code(StringPropertyConfiguration config)
			{
				return config.HasColumnName("code").IsOptional().IsUnicode(false).HasMaxLength(25);
			}

			public static PropertyMappingConfiguration Code(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("code");
			}

			public static string Guid()
			{
				return "guid";
			}

			public static PrimitivePropertyConfiguration Guid(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("guid").IsRequired();
			}

			public static PropertyMappingConfiguration Guid(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("guid");
			}

			public static string ContactFirstName()
			{
				return "contactFirstName";
			}

			public static StringPropertyConfiguration ContactFirstName(StringPropertyConfiguration config)
			{
				return config.HasColumnName("contactFirstName").IsOptional().IsUnicode(false).HasMaxLength(20);
			}

			public static PropertyMappingConfiguration ContactFirstName(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("contactFirstName");
			}

			public static string ContactLastName()
			{
				return "contactLastName";
			}

			public static StringPropertyConfiguration ContactLastName(StringPropertyConfiguration config)
			{
				return config.HasColumnName("contactLastName").IsOptional().IsUnicode(false).HasMaxLength(50);
			}

			public static PropertyMappingConfiguration ContactLastName(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("contactLastName");
			}

			public static string Address1()
			{
				return "address1";
			}

			public static StringPropertyConfiguration Address1(StringPropertyConfiguration config)
			{
				return config.HasColumnName("address1").IsOptional().IsUnicode(false).HasMaxLength(50);
			}

			public static PropertyMappingConfiguration Address1(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("address1");
			}

			public static string Address2()
			{
				return "address2";
			}

			public static StringPropertyConfiguration Address2(StringPropertyConfiguration config)
			{
				return config.HasColumnName("address2").IsOptional().IsUnicode(false).HasMaxLength(100);
			}

			public static PropertyMappingConfiguration Address2(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("address2");
			}

			public static string City()
			{
				return "city";
			}

			public static StringPropertyConfiguration City(StringPropertyConfiguration config)
			{
				return config.HasColumnName("city").IsOptional().IsUnicode(false).HasMaxLength(150);
			}

			public static PropertyMappingConfiguration City(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("city");
			}

			public static string StateId()
			{
				return "stateID";
			}

			public static PrimitivePropertyConfiguration StateId(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("stateID").IsOptional();
			}

			public static PropertyMappingConfiguration StateId(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("stateID");
			}

			public static string Zip()
			{
				return "zip";
			}

			public static StringPropertyConfiguration Zip(StringPropertyConfiguration config)
			{
				return config.HasColumnName("zip").IsOptional().IsUnicode(false).HasMaxLength(50);
			}

			public static PropertyMappingConfiguration Zip(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("zip");
			}

			public static string Phone1()
			{
				return "phone1";
			}

			public static StringPropertyConfiguration Phone1(StringPropertyConfiguration config)
			{
				return config.HasColumnName("phone1").IsOptional().IsUnicode(false).HasMaxLength(50);
			}

			public static PropertyMappingConfiguration Phone1(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("phone1");
			}

			public static string Phone2()
			{
				return "phone2";
			}

			public static StringPropertyConfiguration Phone2(StringPropertyConfiguration config)
			{
				return config.HasColumnName("phone2").IsOptional().IsUnicode(false).HasMaxLength(50);
			}

			public static PropertyMappingConfiguration Phone2(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("phone2");
			}

			public static string Fax()
			{
				return "fax";
			}

			public static StringPropertyConfiguration Fax(StringPropertyConfiguration config)
			{
				return config.HasColumnName("fax").IsOptional().IsUnicode(false).HasMaxLength(50);
			}

			public static PropertyMappingConfiguration Fax(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("fax");
			}

			public static string Email()
			{
				return "email";
			}

			public static StringPropertyConfiguration Email(StringPropertyConfiguration config)
			{
				return config.HasColumnName("email").IsOptional().IsUnicode(false).HasMaxLength(50);
			}

			public static PropertyMappingConfiguration Email(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("email");
			}

			public static string Website()
			{
				return "website";
			}

			public static StringPropertyConfiguration Website(StringPropertyConfiguration config)
			{
				return config.HasColumnName("website").IsOptional().IsUnicode(false).HasMaxLength(100);
			}

			public static PropertyMappingConfiguration Website(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("website");
			}

			public static string Logo()
			{
				return "logo";
			}

			public static StringPropertyConfiguration Logo(StringPropertyConfiguration config)
			{
				return config.HasColumnName("logo").IsOptional().IsUnicode(false).HasMaxLength(100);
			}

			public static PropertyMappingConfiguration Logo(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("logo");
			}

			public static string PeAccess()
			{
				return "PEAccess";
			}

			public static PrimitivePropertyConfiguration PeAccess(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("PEAccess").IsRequired();
			}

			public static PropertyMappingConfiguration PeAccess(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("PEAccess");
			}

			public static string CreateDate()
			{
				return "createDate";
			}

			public static DateTimePropertyConfiguration CreateDate(DateTimePropertyConfiguration config)
			{
				return config.HasColumnName("createDate").IsRequired();
			}

			public static PropertyMappingConfiguration CreateDate(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("createDate");
			}

			public static string UpdateDate()
			{
				return "updateDate";
			}

			public static DateTimePropertyConfiguration UpdateDate(DateTimePropertyConfiguration config)
			{
				return config.HasColumnName("updateDate").IsOptional();
			}

			public static PropertyMappingConfiguration UpdateDate(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("updateDate");
			}

			public static string TimezoneId()
			{
				return "TimezoneID";
			}

			public static PrimitivePropertyConfiguration TimezoneId(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("TimezoneID").IsRequired();
			}

			public static PropertyMappingConfiguration TimezoneId(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("TimezoneID");
			}

			public static string ObservesDst()
			{
				return "ObservesDST";
			}

			public static PrimitivePropertyConfiguration ObservesDst(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("ObservesDST").IsRequired();
			}

			public static PropertyMappingConfiguration ObservesDst(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("ObservesDST");
			}

			public static string GjAdvertising()
			{
				return "GJAdvertising";
			}

			public static PrimitivePropertyConfiguration GjAdvertising(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("GJAdvertising").IsRequired();
			}

			public static PropertyMappingConfiguration GjAdvertising(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("GJAdvertising");
			}

			public static string IsTestAccount()
			{
				return "IsTestAccount";
			}

			public static PrimitivePropertyConfiguration IsTestAccount(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("IsTestAccount").IsRequired();
			}

			public static PropertyMappingConfiguration IsTestAccount(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("IsTestAccount");
			}

			public static string ShareClassSpecData()
			{
				return "shareClassSpecData";
			}

			public static PrimitivePropertyConfiguration ShareClassSpecData(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("shareClassSpecData").IsRequired();
			}

			public static PropertyMappingConfiguration ShareClassSpecData(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("shareClassSpecData");
			}

		}

		public class EmployerEncryptionDetail
		{
	 		public static string SchemaName
			{
				get { return "dbo"; }
			}
	 		

			public static string TableName
			{
				get { return "EmployerEncryptionDetails"; }
			}

			public static string EmployerEncryptionDetailId()
			{
				return "EmployerEncryptionDetailID";
			}

			public static PrimitivePropertyConfiguration EmployerEncryptionDetailId(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("EmployerEncryptionDetailID").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			}

			public static PropertyMappingConfiguration EmployerEncryptionDetailId(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("EmployerEncryptionDetailID");
			}

			public static string EmployerId()
			{
				return "EmployerID";
			}

			public static PrimitivePropertyConfiguration EmployerId(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("EmployerID").IsOptional();
			}

			public static PropertyMappingConfiguration EmployerId(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("EmployerID");
			}

			public static string Passphrase()
			{
				return "Passphrase";
			}

			public static StringPropertyConfiguration Passphrase(StringPropertyConfiguration config)
			{
				return config.HasColumnName("Passphrase").IsOptional().IsUnicode(false).HasMaxLength(500);
			}

			public static PropertyMappingConfiguration Passphrase(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("Passphrase");
			}

			public static string Recipient()
			{
				return "Recipient";
			}

			public static StringPropertyConfiguration Recipient(StringPropertyConfiguration config)
			{
				return config.HasColumnName("Recipient").IsOptional().IsUnicode(false).HasMaxLength(500);
			}

			public static PropertyMappingConfiguration Recipient(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("Recipient");
			}

			public static string UseOpenPgp()
			{
				return "UseOpenPGP";
			}

			public static PrimitivePropertyConfiguration UseOpenPgp(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("UseOpenPGP").IsRequired();
			}

			public static PropertyMappingConfiguration UseOpenPgp(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("UseOpenPGP");
			}

		}

		public class Event
		{
	 		public static string SchemaName
			{
				get { return "dbo"; }
			}
	 		

			public static string TableName
			{
				get { return "Events"; }
			}

			public static string Id()
			{
				return "Id";
			}

			public static PrimitivePropertyConfiguration Id(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("Id").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			}

			public static PropertyMappingConfiguration Id(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("Id");
			}

			public static string ActionType()
			{
				return "ActionType";
			}

			public static StringPropertyConfiguration ActionType(StringPropertyConfiguration config)
			{
				return config.HasColumnName("ActionType").IsRequired().IsUnicode(false).HasMaxLength(100);
			}

			public static PropertyMappingConfiguration ActionType(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("ActionType");
			}

			public static string EntityId()
			{
				return "EntityId";
			}

			public static PrimitivePropertyConfiguration EntityId(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("EntityId").IsRequired();
			}

			public static PropertyMappingConfiguration EntityId(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("EntityId");
			}

			public static string EntityTypeId()
			{
				return "EntityTypeId";
			}

			public static PrimitivePropertyConfiguration EntityTypeId(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("EntityTypeId").IsRequired();
			}

			public static PropertyMappingConfiguration EntityTypeId(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("EntityTypeId");
			}

			public static string EmployerId()
			{
				return "EmployerId";
			}

			public static PrimitivePropertyConfiguration EmployerId(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("EmployerId").IsRequired();
			}

			public static PropertyMappingConfiguration EmployerId(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("EmployerId");
			}

			public static string TableNameColumn()
			{
				return "TableName";
			}

			public static StringPropertyConfiguration TableNameColumn(StringPropertyConfiguration config)
			{
				return config.HasColumnName("TableName").IsRequired().IsUnicode(false).HasMaxLength(100);
			}

			public static PropertyMappingConfiguration TableNameColumn(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("TableName");
			}

			public static string TransactionId()
			{
				return "TransactionId";
			}

			public static StringPropertyConfiguration TransactionId(StringPropertyConfiguration config)
			{
				return config.HasColumnName("TransactionId").IsRequired().IsUnicode(false).HasMaxLength(100);
			}

			public static PropertyMappingConfiguration TransactionId(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("TransactionId");
			}

			public static string CreatedDate()
			{
				return "CreatedDate";
			}

			public static DateTimePropertyConfiguration CreatedDate(DateTimePropertyConfiguration config)
			{
				return config.HasColumnName("CreatedDate").IsRequired();
			}

			public static PropertyMappingConfiguration CreatedDate(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("CreatedDate");
			}

			public static string Data()
			{
				return "Data";
			}

			public static StringPropertyConfiguration Data(StringPropertyConfiguration config)
			{
				return config.HasColumnName("Data").IsOptional().IsUnicode(false).HasMaxLength(500);
			}

			public static PropertyMappingConfiguration Data(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("Data");
			}

		}

		public class events_EventsReadyForCleanup
		{
	 		public static string SchemaName
			{
				get { return "events"; }
			}
	 		

			public static string TableName
			{
				get { return "eventsReadyForCleanup"; }
			}

			public static string Id()
			{
				return "Id";
			}

			public static PrimitivePropertyConfiguration Id(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("Id").IsRequired();
			}

			public static PropertyMappingConfiguration Id(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("Id");
			}

			public static string EmployerId()
			{
				return "EmployerId";
			}

			public static PrimitivePropertyConfiguration EmployerId(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("EmployerId").IsRequired();
			}

			public static PropertyMappingConfiguration EmployerId(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("EmployerId");
			}

			public static string EntityId()
			{
				return "EntityId";
			}

			public static PrimitivePropertyConfiguration EntityId(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("EntityId").IsRequired();
			}

			public static PropertyMappingConfiguration EntityId(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("EntityId");
			}

			public static string EntityTypeId()
			{
				return "EntityTypeId";
			}

			public static PrimitivePropertyConfiguration EntityTypeId(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("EntityTypeId").IsRequired();
			}

			public static PropertyMappingConfiguration EntityTypeId(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("EntityTypeId");
			}

			public static string ActionType()
			{
				return "ActionType";
			}

			public static StringPropertyConfiguration ActionType(StringPropertyConfiguration config)
			{
				return config.HasColumnName("ActionType").IsRequired().IsUnicode(false).HasMaxLength(100);
			}

			public static PropertyMappingConfiguration ActionType(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("ActionType");
			}

			public static string Data()
			{
				return "Data";
			}

			public static StringPropertyConfiguration Data(StringPropertyConfiguration config)
			{
				return config.HasColumnName("Data").IsOptional().IsUnicode(false).HasMaxLength(500);
			}

			public static PropertyMappingConfiguration Data(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("Data");
			}

			public static string CreatedDate()
			{
				return "CreatedDate";
			}

			public static DateTimePropertyConfiguration CreatedDate(DateTimePropertyConfiguration config)
			{
				return config.HasColumnName("CreatedDate").IsRequired();
			}

			public static PropertyMappingConfiguration CreatedDate(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("CreatedDate");
			}

			public static string TableNameColumn()
			{
				return "TableName";
			}

			public static StringPropertyConfiguration TableNameColumn(StringPropertyConfiguration config)
			{
				return config.HasColumnName("TableName").IsRequired().IsUnicode(false).HasMaxLength(100);
			}

			public static PropertyMappingConfiguration TableNameColumn(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("TableName");
			}

			public static string TransactionId()
			{
				return "TransactionId";
			}

			public static StringPropertyConfiguration TransactionId(StringPropertyConfiguration config)
			{
				return config.HasColumnName("TransactionId").IsRequired().IsUnicode(false).HasMaxLength(100);
			}

			public static PropertyMappingConfiguration TransactionId(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("TransactionId");
			}

		}

		public class events_PendingEvent
		{
	 		public static string SchemaName
			{
				get { return "events"; }
			}
	 		

			public static string TableName
			{
				get { return "pendingEvents"; }
			}

			public static string ApplicationCode()
			{
				return "ApplicationCode";
			}

			public static StringPropertyConfiguration ApplicationCode(StringPropertyConfiguration config)
			{
				return config.HasColumnName("ApplicationCode").IsRequired().HasMaxLength(20);
			}

			public static PropertyMappingConfiguration ApplicationCode(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("ApplicationCode");
			}

			public static string Id()
			{
				return "Id";
			}

			public static PrimitivePropertyConfiguration Id(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("Id").IsOptional();
			}

			public static PropertyMappingConfiguration Id(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("Id");
			}

			public static string ActionType()
			{
				return "ActionType";
			}

			public static StringPropertyConfiguration ActionType(StringPropertyConfiguration config)
			{
				return config.HasColumnName("ActionType").IsRequired().IsUnicode(false).HasMaxLength(100);
			}

			public static PropertyMappingConfiguration ActionType(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("ActionType");
			}

			public static string EntityId()
			{
				return "EntityId";
			}

			public static PrimitivePropertyConfiguration EntityId(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("EntityId").IsRequired();
			}

			public static PropertyMappingConfiguration EntityId(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("EntityId");
			}

			public static string EntityTypeId()
			{
				return "EntityTypeId";
			}

			public static PrimitivePropertyConfiguration EntityTypeId(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("EntityTypeId").IsRequired();
			}

			public static PropertyMappingConfiguration EntityTypeId(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("EntityTypeId");
			}

			public static string EmployerId()
			{
				return "EmployerId";
			}

			public static PrimitivePropertyConfiguration EmployerId(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("EmployerId").IsRequired();
			}

			public static PropertyMappingConfiguration EmployerId(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("EmployerId");
			}

			public static string Data()
			{
				return "Data";
			}

			public static StringPropertyConfiguration Data(StringPropertyConfiguration config)
			{
				return config.HasColumnName("Data").IsOptional().IsUnicode(false).HasMaxLength(500);
			}

			public static PropertyMappingConfiguration Data(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("Data");
			}

			public static string TableNameColumn()
			{
				return "TableName";
			}

			public static StringPropertyConfiguration TableNameColumn(StringPropertyConfiguration config)
			{
				return config.HasColumnName("TableName").IsRequired().IsUnicode(false).HasMaxLength(100);
			}

			public static PropertyMappingConfiguration TableNameColumn(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("TableName");
			}

			public static string TransactionId()
			{
				return "TransactionId";
			}

			public static StringPropertyConfiguration TransactionId(StringPropertyConfiguration config)
			{
				return config.HasColumnName("TransactionId").IsRequired().IsUnicode(false).HasMaxLength(100);
			}

			public static PropertyMappingConfiguration TransactionId(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("TransactionId");
			}

		}

		public class events_PendingEventCount
		{
	 		public static string SchemaName
			{
				get { return "events"; }
			}
	 		

			public static string TableName
			{
				get { return "pendingEventCounts"; }
			}

			public static string ApplicationCode()
			{
				return "ApplicationCode";
			}

			public static StringPropertyConfiguration ApplicationCode(StringPropertyConfiguration config)
			{
				return config.HasColumnName("ApplicationCode").IsRequired().HasMaxLength(20);
			}

			public static PropertyMappingConfiguration ApplicationCode(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("ApplicationCode");
			}

			public static string EmployerId()
			{
				return "EmployerId";
			}

			public static PrimitivePropertyConfiguration EmployerId(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("EmployerId").IsRequired();
			}

			public static PropertyMappingConfiguration EmployerId(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("EmployerId");
			}

			public static string NoPendingEvents()
			{
				return "NoPendingEvents";
			}

			public static PrimitivePropertyConfiguration NoPendingEvents(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("NoPendingEvents").IsOptional();
			}

			public static PropertyMappingConfiguration NoPendingEvents(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("NoPendingEvents");
			}

		}

		public class events_RetrialEvent
		{
	 		public static string SchemaName
			{
				get { return "events"; }
			}
	 		

			public static string TableName
			{
				get { return "retrialEvents"; }
			}

			public static string ApplicationCode()
			{
				return "ApplicationCode";
			}

			public static StringPropertyConfiguration ApplicationCode(StringPropertyConfiguration config)
			{
				return config.HasColumnName("ApplicationCode").IsRequired().HasMaxLength(20);
			}

			public static PropertyMappingConfiguration ApplicationCode(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("ApplicationCode");
			}

			public static string Id()
			{
				return "Id";
			}

			public static PrimitivePropertyConfiguration Id(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("Id").IsRequired();
			}

			public static PropertyMappingConfiguration Id(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("Id");
			}

			public static string ActionType()
			{
				return "ActionType";
			}

			public static StringPropertyConfiguration ActionType(StringPropertyConfiguration config)
			{
				return config.HasColumnName("ActionType").IsRequired().IsUnicode(false).HasMaxLength(100);
			}

			public static PropertyMappingConfiguration ActionType(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("ActionType");
			}

			public static string EntityId()
			{
				return "EntityId";
			}

			public static PrimitivePropertyConfiguration EntityId(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("EntityId").IsRequired();
			}

			public static PropertyMappingConfiguration EntityId(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("EntityId");
			}

			public static string EntityTypeId()
			{
				return "EntityTypeId";
			}

			public static PrimitivePropertyConfiguration EntityTypeId(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("EntityTypeId").IsRequired();
			}

			public static PropertyMappingConfiguration EntityTypeId(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("EntityTypeId");
			}

			public static string EmployerId()
			{
				return "EmployerId";
			}

			public static PrimitivePropertyConfiguration EmployerId(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("EmployerId").IsRequired();
			}

			public static PropertyMappingConfiguration EmployerId(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("EmployerId");
			}

			public static string Data()
			{
				return "Data";
			}

			public static StringPropertyConfiguration Data(StringPropertyConfiguration config)
			{
				return config.HasColumnName("Data").IsOptional().IsUnicode(false).HasMaxLength(500);
			}

			public static PropertyMappingConfiguration Data(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("Data");
			}

			public static string TableNameColumn()
			{
				return "TableName";
			}

			public static StringPropertyConfiguration TableNameColumn(StringPropertyConfiguration config)
			{
				return config.HasColumnName("TableName").IsRequired().IsUnicode(false).HasMaxLength(100);
			}

			public static PropertyMappingConfiguration TableNameColumn(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("TableName");
			}

			public static string TransactionId()
			{
				return "TransactionId";
			}

			public static StringPropertyConfiguration TransactionId(StringPropertyConfiguration config)
			{
				return config.HasColumnName("TransactionId").IsRequired().IsUnicode(false).HasMaxLength(100);
			}

			public static PropertyMappingConfiguration TransactionId(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("TransactionId");
			}

			public static string Attempts()
			{
				return "Attempts";
			}

			public static PrimitivePropertyConfiguration Attempts(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("Attempts").IsRequired();
			}

			public static PropertyMappingConfiguration Attempts(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("Attempts");
			}

			public static string LastRetriedOn()
			{
				return "LastRetriedOn";
			}

			public static DateTimePropertyConfiguration LastRetriedOn(DateTimePropertyConfiguration config)
			{
				return config.HasColumnName("LastRetriedOn").IsRequired();
			}

			public static PropertyMappingConfiguration LastRetriedOn(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("LastRetriedOn");
			}

			public static string NextRetrialTime()
			{
				return "NextRetrialTime";
			}

			public static DateTimePropertyConfiguration NextRetrialTime(DateTimePropertyConfiguration config)
			{
				return config.HasColumnName("NextRetrialTime").IsOptional();
			}

			public static PropertyMappingConfiguration NextRetrialTime(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("NextRetrialTime");
			}

			public static string Error()
			{
				return "Error";
			}

			public static StringPropertyConfiguration Error(StringPropertyConfiguration config)
			{
				return config.HasColumnName("Error").IsOptional().IsUnicode(false);
			}

			public static PropertyMappingConfiguration Error(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("Error");
			}

		}

		public class import_StagedClassSpec
		{
	 		public static string SchemaName
			{
				get { return "import"; }
			}
	 		

			public static string TableName
			{
				get { return "StagedClassSpec"; }
			}

			public static string Id()
			{
				return "Id";
			}

			public static PrimitivePropertyConfiguration Id(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("Id").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			}

			public static PropertyMappingConfiguration Id(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("Id");
			}

			public static string EntityTransactionId()
			{
				return "EntityTransactionId";
			}

			public static PrimitivePropertyConfiguration EntityTransactionId(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("EntityTransactionId").IsRequired();
			}

			public static PropertyMappingConfiguration EntityTransactionId(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("EntityTransactionId");
			}

			public static string EmployerId()
			{
				return "EmployerId";
			}

			public static PrimitivePropertyConfiguration EmployerId(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("EmployerId").IsRequired();
			}

			public static PropertyMappingConfiguration EmployerId(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("EmployerId");
			}

			public static string ImportMode()
			{
				return "ImportMode";
			}

			public static PrimitivePropertyConfiguration ImportMode(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("ImportMode").IsRequired();
			}

			public static PropertyMappingConfiguration ImportMode(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("ImportMode");
			}

			public static string ClassSpecCode()
			{
				return "ClassSpecCode";
			}

			public static StringPropertyConfiguration ClassSpecCode(StringPropertyConfiguration config)
			{
				return config.HasColumnName("ClassSpecCode").IsOptional().IsUnicode(false).HasMaxLength(100);
			}

			public static PropertyMappingConfiguration ClassSpecCode(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("ClassSpecCode");
			}

			public static string ClassSpecTitle()
			{
				return "ClassSpecTitle";
			}

			public static StringPropertyConfiguration ClassSpecTitle(StringPropertyConfiguration config)
			{
				return config.HasColumnName("ClassSpecTitle").IsOptional().IsUnicode(false).HasMaxLength(500);
			}

			public static PropertyMappingConfiguration ClassSpecTitle(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("ClassSpecTitle");
			}

			public static string ClassSpecHash()
			{
				return "ClassSpecHash";
			}

			public static BinaryPropertyConfiguration ClassSpecHash(BinaryPropertyConfiguration config)
			{
				return config.HasColumnName("ClassSpecHash").IsOptional().HasMaxLength(8000);
			}

			public static PropertyMappingConfiguration ClassSpecHash(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("ClassSpecHash");
			}

			public static string IsValid()
			{
				return "IsValid";
			}

			public static PrimitivePropertyConfiguration IsValid(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("IsValid").IsRequired();
			}

			public static PropertyMappingConfiguration IsValid(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("IsValid");
			}

			public static string Status()
			{
				return "Status";
			}

			public static PrimitivePropertyConfiguration Status(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("Status").IsRequired();
			}

			public static PropertyMappingConfiguration Status(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("Status");
			}

		}

		public class import_StagedDepartment
		{
	 		public static string SchemaName
			{
				get { return "import"; }
			}
	 		

			public static string TableName
			{
				get { return "StagedDepartment"; }
			}

			public static string Id()
			{
				return "Id";
			}

			public static PrimitivePropertyConfiguration Id(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("Id").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			}

			public static PropertyMappingConfiguration Id(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("Id");
			}

			public static string EntityTransactionId()
			{
				return "EntityTransactionId";
			}

			public static PrimitivePropertyConfiguration EntityTransactionId(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("EntityTransactionId").IsRequired();
			}

			public static PropertyMappingConfiguration EntityTransactionId(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("EntityTransactionId");
			}

			public static string EmployerId()
			{
				return "EmployerId";
			}

			public static PrimitivePropertyConfiguration EmployerId(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("EmployerId").IsRequired();
			}

			public static PropertyMappingConfiguration EmployerId(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("EmployerId");
			}

			public static string ImportMode()
			{
				return "ImportMode";
			}

			public static PrimitivePropertyConfiguration ImportMode(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("ImportMode").IsRequired();
			}

			public static PropertyMappingConfiguration ImportMode(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("ImportMode");
			}

			public static string DepartmentCode()
			{
				return "DepartmentCode";
			}

			public static StringPropertyConfiguration DepartmentCode(StringPropertyConfiguration config)
			{
				return config.HasColumnName("DepartmentCode").IsOptional().IsUnicode(false).HasMaxLength(100);
			}

			public static PropertyMappingConfiguration DepartmentCode(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("DepartmentCode");
			}

			public static string DepartmentTitle()
			{
				return "DepartmentTitle";
			}

			public static StringPropertyConfiguration DepartmentTitle(StringPropertyConfiguration config)
			{
				return config.HasColumnName("DepartmentTitle").IsOptional().IsUnicode(false).HasMaxLength(100);
			}

			public static PropertyMappingConfiguration DepartmentTitle(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("DepartmentTitle");
			}

			public static string DepartmentHash()
			{
				return "DepartmentHash";
			}

			public static BinaryPropertyConfiguration DepartmentHash(BinaryPropertyConfiguration config)
			{
				return config.HasColumnName("DepartmentHash").IsOptional().HasMaxLength(8000);
			}

			public static PropertyMappingConfiguration DepartmentHash(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("DepartmentHash");
			}

			public static string IsValid()
			{
				return "IsValid";
			}

			public static PrimitivePropertyConfiguration IsValid(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("IsValid").IsRequired();
			}

			public static PropertyMappingConfiguration IsValid(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("IsValid");
			}

			public static string Status()
			{
				return "Status";
			}

			public static PrimitivePropertyConfiguration Status(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("Status").IsRequired();
			}

			public static PropertyMappingConfiguration Status(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("Status");
			}

		}

		public class import_StagedDivision
		{
	 		public static string SchemaName
			{
				get { return "import"; }
			}
	 		

			public static string TableName
			{
				get { return "StagedDivision"; }
			}

			public static string Id()
			{
				return "Id";
			}

			public static PrimitivePropertyConfiguration Id(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("Id").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			}

			public static PropertyMappingConfiguration Id(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("Id");
			}

			public static string EntityTransactionId()
			{
				return "EntityTransactionId";
			}

			public static PrimitivePropertyConfiguration EntityTransactionId(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("EntityTransactionId").IsRequired();
			}

			public static PropertyMappingConfiguration EntityTransactionId(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("EntityTransactionId");
			}

			public static string EmployerId()
			{
				return "EmployerId";
			}

			public static PrimitivePropertyConfiguration EmployerId(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("EmployerId").IsRequired();
			}

			public static PropertyMappingConfiguration EmployerId(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("EmployerId");
			}

			public static string ImportMode()
			{
				return "ImportMode";
			}

			public static PrimitivePropertyConfiguration ImportMode(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("ImportMode").IsRequired();
			}

			public static PropertyMappingConfiguration ImportMode(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("ImportMode");
			}

			public static string DivisionCode()
			{
				return "DivisionCode";
			}

			public static StringPropertyConfiguration DivisionCode(StringPropertyConfiguration config)
			{
				return config.HasColumnName("DivisionCode").IsRequired().IsUnicode(false).HasMaxLength(100);
			}

			public static PropertyMappingConfiguration DivisionCode(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("DivisionCode");
			}

			public static string DivisionTitle()
			{
				return "DivisionTitle";
			}

			public static StringPropertyConfiguration DivisionTitle(StringPropertyConfiguration config)
			{
				return config.HasColumnName("DivisionTitle").IsRequired().IsUnicode(false).HasMaxLength(100);
			}

			public static PropertyMappingConfiguration DivisionTitle(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("DivisionTitle");
			}

			public static string StagedDepartmentId()
			{
				return "StagedDepartmentId";
			}

			public static PrimitivePropertyConfiguration StagedDepartmentId(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("StagedDepartmentId").IsOptional();
			}

			public static PropertyMappingConfiguration StagedDepartmentId(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("StagedDepartmentId");
			}

			public static string DivisionHash()
			{
				return "DivisionHash";
			}

			public static StringPropertyConfiguration DivisionHash(StringPropertyConfiguration config)
			{
				return config.HasColumnName("DivisionHash").IsOptional().IsUnicode(false).HasMaxLength(100);
			}

			public static PropertyMappingConfiguration DivisionHash(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("DivisionHash");
			}

			public static string IsValid()
			{
				return "IsValid";
			}

			public static PrimitivePropertyConfiguration IsValid(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("IsValid").IsRequired();
			}

			public static PropertyMappingConfiguration IsValid(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("IsValid");
			}

			public static string Status()
			{
				return "Status";
			}

			public static PrimitivePropertyConfiguration Status(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("Status").IsRequired();
			}

			public static PropertyMappingConfiguration Status(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("Status");
			}

		}

		public class import_StagedEmployee
		{
	 		public static string SchemaName
			{
				get { return "import"; }
			}
	 		

			public static string TableName
			{
				get { return "StagedEmployee"; }
			}

			public static string Id()
			{
				return "Id";
			}

			public static PrimitivePropertyConfiguration Id(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("Id").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			}

			public static PropertyMappingConfiguration Id(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("Id");
			}

			public static string EntityTransactionId()
			{
				return "EntityTransactionId";
			}

			public static PrimitivePropertyConfiguration EntityTransactionId(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("EntityTransactionId").IsRequired();
			}

			public static PropertyMappingConfiguration EntityTransactionId(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("EntityTransactionId");
			}

			public static string EmployerId()
			{
				return "EmployerId";
			}

			public static PrimitivePropertyConfiguration EmployerId(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("EmployerId").IsRequired();
			}

			public static PropertyMappingConfiguration EmployerId(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("EmployerId");
			}

			public static string EmployeeNumber()
			{
				return "EmployeeNumber";
			}

			public static StringPropertyConfiguration EmployeeNumber(StringPropertyConfiguration config)
			{
				return config.HasColumnName("EmployeeNumber").IsOptional().IsUnicode(false).HasMaxLength(100);
			}

			public static PropertyMappingConfiguration EmployeeNumber(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("EmployeeNumber");
			}

			public static string StagedPositionId()
			{
				return "StagedPositionId";
			}

			public static PrimitivePropertyConfiguration StagedPositionId(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("StagedPositionId").IsOptional();
			}

			public static PropertyMappingConfiguration StagedPositionId(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("StagedPositionId");
			}

			public static string Email()
			{
				return "Email";
			}

			public static StringPropertyConfiguration Email(StringPropertyConfiguration config)
			{
				return config.HasColumnName("Email").IsOptional().IsUnicode(false).HasMaxLength(100);
			}

			public static PropertyMappingConfiguration Email(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("Email");
			}

			public static string FirstName()
			{
				return "FirstName";
			}

			public static StringPropertyConfiguration FirstName(StringPropertyConfiguration config)
			{
				return config.HasColumnName("FirstName").IsOptional().IsUnicode(false).HasMaxLength(100);
			}

			public static PropertyMappingConfiguration FirstName(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("FirstName");
			}

			public static string LastName()
			{
				return "LastName";
			}

			public static StringPropertyConfiguration LastName(StringPropertyConfiguration config)
			{
				return config.HasColumnName("LastName").IsOptional().IsUnicode(false).HasMaxLength(100);
			}

			public static PropertyMappingConfiguration LastName(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("LastName");
			}

			public static string Address()
			{
				return "Address";
			}

			public static StringPropertyConfiguration Address(StringPropertyConfiguration config)
			{
				return config.HasColumnName("Address").IsOptional().IsUnicode(false).HasMaxLength(500);
			}

			public static PropertyMappingConfiguration Address(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("Address");
			}

			public static string State()
			{
				return "State";
			}

			public static StringPropertyConfiguration State(StringPropertyConfiguration config)
			{
				return config.HasColumnName("State").IsOptional().IsUnicode(false).HasMaxLength(100);
			}

			public static PropertyMappingConfiguration State(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("State");
			}

			public static string City()
			{
				return "City";
			}

			public static StringPropertyConfiguration City(StringPropertyConfiguration config)
			{
				return config.HasColumnName("City").IsOptional().IsUnicode(false).HasMaxLength(100);
			}

			public static PropertyMappingConfiguration City(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("City");
			}

			public static string ZipCode()
			{
				return "ZipCode";
			}

			public static StringPropertyConfiguration ZipCode(StringPropertyConfiguration config)
			{
				return config.HasColumnName("ZipCode").IsOptional().IsUnicode(false).HasMaxLength(100);
			}

			public static PropertyMappingConfiguration ZipCode(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("ZipCode");
			}

			public static string StartDate()
			{
				return "StartDate";
			}

			public static StringPropertyConfiguration StartDate(StringPropertyConfiguration config)
			{
				return config.HasColumnName("StartDate").IsOptional().IsUnicode(false).HasMaxLength(100);
			}

			public static PropertyMappingConfiguration StartDate(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("StartDate");
			}

			public static string Phone()
			{
				return "Phone";
			}

			public static StringPropertyConfiguration Phone(StringPropertyConfiguration config)
			{
				return config.HasColumnName("Phone").IsOptional().IsUnicode(false).HasMaxLength(100);
			}

			public static PropertyMappingConfiguration Phone(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("Phone");
			}

			public static string StartDateString()
			{
				return "StartDateString";
			}

			public static StringPropertyConfiguration StartDateString(StringPropertyConfiguration config)
			{
				return config.HasColumnName("StartDateString").IsOptional().IsUnicode(false).HasMaxLength(100);
			}

			public static PropertyMappingConfiguration StartDateString(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("StartDateString");
			}

			public static string SeperationDate()
			{
				return "SeperationDate";
			}

			public static StringPropertyConfiguration SeperationDate(StringPropertyConfiguration config)
			{
				return config.HasColumnName("SeperationDate").IsOptional().IsUnicode(false).HasMaxLength(100);
			}

			public static PropertyMappingConfiguration SeperationDate(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("SeperationDate");
			}

			public static string SeperationDateString()
			{
				return "SeperationDateString";
			}

			public static StringPropertyConfiguration SeperationDateString(StringPropertyConfiguration config)
			{
				return config.HasColumnName("SeperationDateString").IsOptional().IsUnicode(false).HasMaxLength(100);
			}

			public static PropertyMappingConfiguration SeperationDateString(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("SeperationDateString");
			}

			public static string ManagerEmployeeNumber()
			{
				return "ManagerEmployeeNumber";
			}

			public static StringPropertyConfiguration ManagerEmployeeNumber(StringPropertyConfiguration config)
			{
				return config.HasColumnName("ManagerEmployeeNumber").IsOptional().IsUnicode(false).HasMaxLength(100);
			}

			public static PropertyMappingConfiguration ManagerEmployeeNumber(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("ManagerEmployeeNumber");
			}

			public static string EmployeeHash()
			{
				return "EmployeeHash";
			}

			public static StringPropertyConfiguration EmployeeHash(StringPropertyConfiguration config)
			{
				return config.HasColumnName("EmployeeHash").IsOptional().IsUnicode(false).HasMaxLength(100);
			}

			public static PropertyMappingConfiguration EmployeeHash(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("EmployeeHash");
			}

			public static string IsActive()
			{
				return "IsActive";
			}

			public static StringPropertyConfiguration IsActive(StringPropertyConfiguration config)
			{
				return config.HasColumnName("IsActive").IsOptional().IsUnicode(false).HasMaxLength(50);
			}

			public static PropertyMappingConfiguration IsActive(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("IsActive");
			}

			public static string IsValid()
			{
				return "IsValid";
			}

			public static PrimitivePropertyConfiguration IsValid(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("IsValid").IsRequired();
			}

			public static PropertyMappingConfiguration IsValid(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("IsValid");
			}

			public static string Status()
			{
				return "Status";
			}

			public static PrimitivePropertyConfiguration Status(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("Status").IsRequired();
			}

			public static PropertyMappingConfiguration Status(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("Status");
			}

		}

		public class import_StagedPosition
		{
	 		public static string SchemaName
			{
				get { return "import"; }
			}
	 		

			public static string TableName
			{
				get { return "StagedPosition"; }
			}

			public static string Id()
			{
				return "Id";
			}

			public static PrimitivePropertyConfiguration Id(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("Id").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			}

			public static PropertyMappingConfiguration Id(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("Id");
			}

			public static string EntityTransactionId()
			{
				return "EntityTransactionId";
			}

			public static PrimitivePropertyConfiguration EntityTransactionId(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("EntityTransactionId").IsRequired();
			}

			public static PropertyMappingConfiguration EntityTransactionId(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("EntityTransactionId");
			}

			public static string EmployerId()
			{
				return "EmployerId";
			}

			public static PrimitivePropertyConfiguration EmployerId(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("EmployerId").IsRequired();
			}

			public static PropertyMappingConfiguration EmployerId(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("EmployerId");
			}

			public static string ImportMode()
			{
				return "ImportMode";
			}

			public static PrimitivePropertyConfiguration ImportMode(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("ImportMode").IsRequired();
			}

			public static PropertyMappingConfiguration ImportMode(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("ImportMode");
			}

			public static string PositionCode()
			{
				return "PositionCode";
			}

			public static StringPropertyConfiguration PositionCode(StringPropertyConfiguration config)
			{
				return config.HasColumnName("PositionCode").IsOptional().IsUnicode(false).HasMaxLength(100);
			}

			public static PropertyMappingConfiguration PositionCode(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("PositionCode");
			}

			public static string PositionTitle()
			{
				return "PositionTitle";
			}

			public static StringPropertyConfiguration PositionTitle(StringPropertyConfiguration config)
			{
				return config.HasColumnName("PositionTitle").IsOptional().IsUnicode(false).HasMaxLength(100);
			}

			public static PropertyMappingConfiguration PositionTitle(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("PositionTitle");
			}

			public static string StagedDepartmentId()
			{
				return "StagedDepartmentId";
			}

			public static PrimitivePropertyConfiguration StagedDepartmentId(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("StagedDepartmentId").IsOptional();
			}

			public static PropertyMappingConfiguration StagedDepartmentId(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("StagedDepartmentId");
			}

			public static string StagedDivisionId()
			{
				return "StagedDivisionId";
			}

			public static PrimitivePropertyConfiguration StagedDivisionId(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("StagedDivisionId").IsOptional();
			}

			public static PropertyMappingConfiguration StagedDivisionId(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("StagedDivisionId");
			}

			public static string StagedClassSpecId()
			{
				return "StagedClassSpecId";
			}

			public static PrimitivePropertyConfiguration StagedClassSpecId(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("StagedClassSpecId").IsOptional();
			}

			public static PropertyMappingConfiguration StagedClassSpecId(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("StagedClassSpecId");
			}

			public static string PositionHash()
			{
				return "PositionHash";
			}

			public static StringPropertyConfiguration PositionHash(StringPropertyConfiguration config)
			{
				return config.HasColumnName("PositionHash").IsOptional().IsUnicode(false).HasMaxLength(100);
			}

			public static PropertyMappingConfiguration PositionHash(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("PositionHash");
			}

			public static string IsValid()
			{
				return "IsValid";
			}

			public static PrimitivePropertyConfiguration IsValid(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("IsValid").IsRequired();
			}

			public static PropertyMappingConfiguration IsValid(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("IsValid");
			}

			public static string Status()
			{
				return "Status";
			}

			public static PrimitivePropertyConfiguration Status(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("Status").IsRequired();
			}

			public static PropertyMappingConfiguration Status(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("Status");
			}

		}

		public class Integration_EmployerModuleSetup
		{
	 		public static string SchemaName
			{
				get { return "Integration"; }
			}
	 		

			public static string TableName
			{
				get { return "EmployerModuleSetup"; }
			}

			public static string EmployerModuleSetupId()
			{
				return "EmployerModuleSetupID";
			}

			public static PrimitivePropertyConfiguration EmployerModuleSetupId(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("EmployerModuleSetupID").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			}

			public static PropertyMappingConfiguration EmployerModuleSetupId(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("EmployerModuleSetupID");
			}

			public static string EmployerModuleId()
			{
				return "EmployerModuleID";
			}

			public static PrimitivePropertyConfiguration EmployerModuleId(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("EmployerModuleID").IsOptional();
			}

			public static PropertyMappingConfiguration EmployerModuleId(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("EmployerModuleID");
			}

			public static string ImportFileLocation()
			{
				return "ImportFileLocation";
			}

			public static StringPropertyConfiguration ImportFileLocation(StringPropertyConfiguration config)
			{
				return config.HasColumnName("ImportFileLocation").IsOptional().IsUnicode(false).HasMaxLength(500);
			}

			public static PropertyMappingConfiguration ImportFileLocation(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("ImportFileLocation");
			}

			public static string ExportFileLocation()
			{
				return "ExportFileLocation";
			}

			public static StringPropertyConfiguration ExportFileLocation(StringPropertyConfiguration config)
			{
				return config.HasColumnName("ExportFileLocation").IsOptional().IsUnicode(false).HasMaxLength(500);
			}

			public static PropertyMappingConfiguration ExportFileLocation(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("ExportFileLocation");
			}

			public static string FileExtension()
			{
				return "FileExtension";
			}

			public static StringPropertyConfiguration FileExtension(StringPropertyConfiguration config)
			{
				return config.HasColumnName("FileExtension").IsOptional().IsUnicode(false).HasMaxLength(20);
			}

			public static PropertyMappingConfiguration FileExtension(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("FileExtension");
			}

			public static string FileDelimiter()
			{
				return "FileDelimiter";
			}

			public static StringPropertyConfiguration FileDelimiter(StringPropertyConfiguration config)
			{
				return config.HasColumnName("FileDelimiter").IsOptional().IsUnicode(false).HasMaxLength(20);
			}

			public static PropertyMappingConfiguration FileDelimiter(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("FileDelimiter");
			}

			public static string FileNamePrefix()
			{
				return "FileNamePrefix";
			}

			public static StringPropertyConfiguration FileNamePrefix(StringPropertyConfiguration config)
			{
				return config.HasColumnName("FileNamePrefix").IsOptional().IsUnicode(false).HasMaxLength(200);
			}

			public static PropertyMappingConfiguration FileNamePrefix(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("FileNamePrefix");
			}

			public static string IsActive()
			{
				return "IsActive";
			}

			public static PrimitivePropertyConfiguration IsActive(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("IsActive").IsOptional();
			}

			public static PropertyMappingConfiguration IsActive(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("IsActive");
			}

			public static string CreateDate()
			{
				return "CreateDate";
			}

			public static DateTimePropertyConfiguration CreateDate(DateTimePropertyConfiguration config)
			{
				return config.HasColumnName("CreateDate").IsRequired();
			}

			public static PropertyMappingConfiguration CreateDate(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("CreateDate");
			}

			public static string UpdateDate()
			{
				return "UpdateDate";
			}

			public static DateTimePropertyConfiguration UpdateDate(DateTimePropertyConfiguration config)
			{
				return config.HasColumnName("UpdateDate").IsRequired();
			}

			public static PropertyMappingConfiguration UpdateDate(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("UpdateDate");
			}

			public static string CreatedBy()
			{
				return "CreatedBy";
			}

			public static PrimitivePropertyConfiguration CreatedBy(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("CreatedBy").IsRequired();
			}

			public static PropertyMappingConfiguration CreatedBy(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("CreatedBy");
			}

			public static string UpdatedBy()
			{
				return "UpdatedBy";
			}

			public static PrimitivePropertyConfiguration UpdatedBy(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("UpdatedBy").IsRequired();
			}

			public static PropertyMappingConfiguration UpdatedBy(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("UpdatedBy");
			}

			public static string ClientAdminEmail()
			{
				return "ClientAdminEmail";
			}

			public static StringPropertyConfiguration ClientAdminEmail(StringPropertyConfiguration config)
			{
				return config.HasColumnName("ClientAdminEmail").IsOptional().IsUnicode(false).HasMaxLength(100);
			}

			public static PropertyMappingConfiguration ClientAdminEmail(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("ClientAdminEmail");
			}

			public static string EmailErrorsAsAttachment()
			{
				return "EmailErrorsAsAttachment";
			}

			public static PrimitivePropertyConfiguration EmailErrorsAsAttachment(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("EmailErrorsAsAttachment").IsOptional();
			}

			public static PropertyMappingConfiguration EmailErrorsAsAttachment(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("EmailErrorsAsAttachment");
			}

			public static string IntegrationType()
			{
				return "IntegrationType";
			}

			public static StringPropertyConfiguration IntegrationType(StringPropertyConfiguration config)
			{
				return config.HasColumnName("IntegrationType").IsOptional().IsUnicode(false).HasMaxLength(100);
			}

			public static PropertyMappingConfiguration IntegrationType(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("IntegrationType");
			}

			public static string RemoveFileFooter()
			{
				return "RemoveFileFooter";
			}

			public static PrimitivePropertyConfiguration RemoveFileFooter(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("RemoveFileFooter").IsOptional();
			}

			public static PropertyMappingConfiguration RemoveFileFooter(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("RemoveFileFooter");
			}

			public static string EncryptedFileExtension()
			{
				return "EncryptedFile_Extension";
			}

			public static StringPropertyConfiguration EncryptedFileExtension(StringPropertyConfiguration config)
			{
				return config.HasColumnName("EncryptedFile_Extension").IsRequired().IsUnicode(false).HasMaxLength(20);
			}

			public static PropertyMappingConfiguration EncryptedFileExtension(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("EncryptedFile_Extension");
			}

			public static string DownloadSsis()
			{
				return "Download_SSIS";
			}

			public static StringPropertyConfiguration DownloadSsis(StringPropertyConfiguration config)
			{
				return config.HasColumnName("Download_SSIS").IsOptional().IsUnicode(false).HasMaxLength(100);
			}

			public static PropertyMappingConfiguration DownloadSsis(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("Download_SSIS");
			}

			public static string FileHeaderCode()
			{
				return "FileHeaderCode";
			}

			public static StringPropertyConfiguration FileHeaderCode(StringPropertyConfiguration config)
			{
				return config.HasColumnName("FileHeaderCode").IsRequired().IsUnicode(false).HasMaxLength(20);
			}

			public static PropertyMappingConfiguration FileHeaderCode(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("FileHeaderCode");
			}

			public static string EmployerId()
			{
				return "EmployerID";
			}

			public static PrimitivePropertyConfiguration EmployerId(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("EmployerID").IsOptional();
			}

			public static PropertyMappingConfiguration EmployerId(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("EmployerID");
			}

			public static string ResultSsis()
			{
				return "Result_SSIS";
			}

			public static StringPropertyConfiguration ResultSsis(StringPropertyConfiguration config)
			{
				return config.HasColumnName("Result_SSIS").IsOptional().IsUnicode(false).HasMaxLength(100);
			}

			public static PropertyMappingConfiguration ResultSsis(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("Result_SSIS");
			}

			public static string VendorId()
			{
				return "VendorID";
			}

			public static PrimitivePropertyConfiguration VendorId(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("VendorID").IsOptional();
			}

			public static PropertyMappingConfiguration VendorId(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("VendorID");
			}

			public static string ExportQuery()
			{
				return "ExportQuery";
			}

			public static StringPropertyConfiguration ExportQuery(StringPropertyConfiguration config)
			{
				return config.HasColumnName("ExportQuery").IsOptional().IsUnicode(false).HasMaxLength(500);
			}

			public static PropertyMappingConfiguration ExportQuery(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("ExportQuery");
			}

			public static string EncryptedExportFileExtension()
			{
				return "EncryptedExportFileExtension";
			}

			public static StringPropertyConfiguration EncryptedExportFileExtension(StringPropertyConfiguration config)
			{
				return config.HasColumnName("EncryptedExportFileExtension").IsOptional().IsUnicode(false).HasMaxLength(20);
			}

			public static PropertyMappingConfiguration EncryptedExportFileExtension(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("EncryptedExportFileExtension");
			}

			public static string ExportHeaderQuery()
			{
				return "exportHeaderQuery";
			}

			public static StringPropertyConfiguration ExportHeaderQuery(StringPropertyConfiguration config)
			{
				return config.HasColumnName("exportHeaderQuery").IsOptional().IsUnicode(false);
			}

			public static PropertyMappingConfiguration ExportHeaderQuery(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("exportHeaderQuery");
			}

		}

		public class LastEventProcessedByApplicationPerAgency
		{
	 		public static string SchemaName
			{
				get { return "dbo"; }
			}
	 		

			public static string TableName
			{
				get { return "LastEventProcessedByApplicationPerAgency"; }
			}

			public static string ApplicationId()
			{
				return "ApplicationId";
			}

			public static PrimitivePropertyConfiguration ApplicationId(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("ApplicationId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
			}

			public static PropertyMappingConfiguration ApplicationId(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("ApplicationId");
			}

			public static string EmployerId()
			{
				return "EmployerId";
			}

			public static PrimitivePropertyConfiguration EmployerId(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("EmployerId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
			}

			public static PropertyMappingConfiguration EmployerId(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("EmployerId");
			}

			public static string EventId()
			{
				return "EventID";
			}

			public static PrimitivePropertyConfiguration EventId(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("EventID").IsRequired();
			}

			public static PropertyMappingConfiguration EventId(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("EventID");
			}

		}

		public class Migration
		{
	 		public static string SchemaName
			{
				get { return "dbo"; }
			}
	 		

			public static string TableName
			{
				get { return "Migrations"; }
			}

			public static string Migration_()
			{
				return "Migration";
			}

			public static StringPropertyConfiguration Migration_(StringPropertyConfiguration config)
			{
				return config.HasColumnName("Migration").IsRequired().HasMaxLength(100).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
			}

			public static PropertyMappingConfiguration Migration_(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("Migration");
			}

			public static string Date()
			{
				return "Date";
			}

			public static DateTimePropertyConfiguration Date(DateTimePropertyConfiguration config)
			{
				return config.HasColumnName("Date").IsRequired();
			}

			public static PropertyMappingConfiguration Date(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("Date");
			}

			public static string Version()
			{
				return "Version";
			}

			public static StringPropertyConfiguration Version(StringPropertyConfiguration config)
			{
				return config.HasColumnName("Version").IsOptional().HasMaxLength(100);
			}

			public static PropertyMappingConfiguration Version(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("Version");
			}

		}

		public class migrations_Baseline
		{
	 		public static string SchemaName
			{
				get { return "migrations"; }
			}
	 		

			public static string TableName
			{
				get { return "Baseline"; }
			}

			public static string Id()
			{
				return "Id";
			}

			public static PrimitivePropertyConfiguration Id(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("Id").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			}

			public static PropertyMappingConfiguration Id(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("Id");
			}

			public static string TableNameColumn()
			{
				return "TableName";
			}

			public static StringPropertyConfiguration TableNameColumn(StringPropertyConfiguration config)
			{
				return config.HasColumnName("TableName").IsRequired().IsUnicode(false).HasMaxLength(500);
			}

			public static PropertyMappingConfiguration TableNameColumn(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("TableName");
			}

			public static string IsCompleted()
			{
				return "IsCompleted";
			}

			public static PrimitivePropertyConfiguration IsCompleted(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("IsCompleted").IsRequired();
			}

			public static PropertyMappingConfiguration IsCompleted(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("IsCompleted");
			}

			public static string Error()
			{
				return "Error";
			}

			public static StringPropertyConfiguration Error(StringPropertyConfiguration config)
			{
				return config.HasColumnName("Error").IsOptional().IsUnicode(false);
			}

			public static PropertyMappingConfiguration Error(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("Error");
			}

			public static string CreatedOn()
			{
				return "CreatedOn";
			}

			public static DateTimePropertyConfiguration CreatedOn(DateTimePropertyConfiguration config)
			{
				return config.HasColumnName("CreatedOn").IsOptional();
			}

			public static PropertyMappingConfiguration CreatedOn(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("CreatedOn");
			}

		}

		public class migrations_Script
		{
	 		public static string SchemaName
			{
				get { return "migrations"; }
			}
	 		

			public static string TableName
			{
				get { return "scripts"; }
			}

			public static string ScriptId()
			{
				return "script_id";
			}

			public static StringPropertyConfiguration ScriptId(StringPropertyConfiguration config)
			{
				return config.HasColumnName("script_id").IsRequired().HasMaxLength(255).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
			}

			public static PropertyMappingConfiguration ScriptId(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("script_id");
			}

			public static string VersionId()
			{
				return "version_id";
			}

			public static PrimitivePropertyConfiguration VersionId(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("version_id").IsOptional();
			}

			public static PropertyMappingConfiguration VersionId(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("version_id");
			}

			public static string ScriptHash()
			{
				return "script_hash";
			}

			public static StringPropertyConfiguration ScriptHash(StringPropertyConfiguration config)
			{
				return config.HasColumnName("script_hash").IsOptional().HasMaxLength(512);
			}

			public static PropertyMappingConfiguration ScriptHash(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("script_hash");
			}

			public static string OneTimeScript()
			{
				return "one_time_script";
			}

			public static PrimitivePropertyConfiguration OneTimeScript(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("one_time_script").IsOptional();
			}

			public static PropertyMappingConfiguration OneTimeScript(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("one_time_script");
			}

			public static string EntryDate()
			{
				return "entry_date";
			}

			public static DateTimePropertyConfiguration EntryDate(DateTimePropertyConfiguration config)
			{
				return config.HasColumnName("entry_date").IsOptional();
			}

			public static PropertyMappingConfiguration EntryDate(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("entry_date");
			}

			public static string ModifiedDate()
			{
				return "modified_date";
			}

			public static DateTimePropertyConfiguration ModifiedDate(DateTimePropertyConfiguration config)
			{
				return config.HasColumnName("modified_date").IsOptional();
			}

			public static PropertyMappingConfiguration ModifiedDate(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("modified_date");
			}

			public static string EnteredBy()
			{
				return "entered_by";
			}

			public static StringPropertyConfiguration EnteredBy(StringPropertyConfiguration config)
			{
				return config.HasColumnName("entered_by").IsOptional().HasMaxLength(50);
			}

			public static PropertyMappingConfiguration EnteredBy(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("entered_by");
			}

			public static string StatusDescription()
			{
				return "status_description";
			}

			public static StringPropertyConfiguration StatusDescription(StringPropertyConfiguration config)
			{
				return config.HasColumnName("status_description").IsOptional();
			}

			public static PropertyMappingConfiguration StatusDescription(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("status_description");
			}

		}

		public class migrations_Version
		{
	 		public static string SchemaName
			{
				get { return "migrations"; }
			}
	 		

			public static string TableName
			{
				get { return "version"; }
			}

			public static string Id()
			{
				return "id";
			}

			public static PrimitivePropertyConfiguration Id(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("id").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			}

			public static PropertyMappingConfiguration Id(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("id");
			}

			public static string RepositoryPath()
			{
				return "repository_path";
			}

			public static StringPropertyConfiguration RepositoryPath(StringPropertyConfiguration config)
			{
				return config.HasColumnName("repository_path").IsOptional().HasMaxLength(255);
			}

			public static PropertyMappingConfiguration RepositoryPath(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("repository_path");
			}

			public static string Version()
			{
				return "version";
			}

			public static StringPropertyConfiguration Version(StringPropertyConfiguration config)
			{
				return config.HasColumnName("version").IsOptional().HasMaxLength(50);
			}

			public static PropertyMappingConfiguration Version(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("version");
			}

			public static string EntryDate()
			{
				return "entry_date";
			}

			public static DateTimePropertyConfiguration EntryDate(DateTimePropertyConfiguration config)
			{
				return config.HasColumnName("entry_date").IsOptional();
			}

			public static PropertyMappingConfiguration EntryDate(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("entry_date");
			}

			public static string ModifiedDate()
			{
				return "modified_date";
			}

			public static DateTimePropertyConfiguration ModifiedDate(DateTimePropertyConfiguration config)
			{
				return config.HasColumnName("modified_date").IsOptional();
			}

			public static PropertyMappingConfiguration ModifiedDate(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("modified_date");
			}

			public static string EnteredBy()
			{
				return "entered_by";
			}

			public static StringPropertyConfiguration EnteredBy(StringPropertyConfiguration config)
			{
				return config.HasColumnName("entered_by").IsOptional().HasMaxLength(50);
			}

			public static PropertyMappingConfiguration EnteredBy(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("entered_by");
			}

		}

		public class PasswordReset
		{
	 		public static string SchemaName
			{
				get { return "dbo"; }
			}
	 		

			public static string TableName
			{
				get { return "PasswordResets"; }
			}

			public static string PasswordResetId()
			{
				return "PasswordResetID";
			}

			public static PrimitivePropertyConfiguration PasswordResetId(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("PasswordResetID").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			}

			public static PropertyMappingConfiguration PasswordResetId(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("PasswordResetID");
			}

			public static string UserId()
			{
				return "UserID";
			}

			public static PrimitivePropertyConfiguration UserId(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("UserID").IsRequired();
			}

			public static PropertyMappingConfiguration UserId(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("UserID");
			}

			public static string UserTypeId()
			{
				return "UserTypeID";
			}

			public static PrimitivePropertyConfiguration UserTypeId(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("UserTypeID").IsOptional();
			}

			public static PropertyMappingConfiguration UserTypeId(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("UserTypeID");
			}

			public static string ResetCode()
			{
				return "ResetCode";
			}

			public static StringPropertyConfiguration ResetCode(StringPropertyConfiguration config)
			{
				return config.HasColumnName("ResetCode").IsRequired().IsUnicode(false).HasMaxLength(100);
			}

			public static PropertyMappingConfiguration ResetCode(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("ResetCode");
			}

			public static string CreateDate()
			{
				return "CreateDate";
			}

			public static DateTimePropertyConfiguration CreateDate(DateTimePropertyConfiguration config)
			{
				return config.HasColumnName("CreateDate").IsRequired();
			}

			public static PropertyMappingConfiguration CreateDate(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("CreateDate");
			}

			public static string ExpireDate()
			{
				return "ExpireDate";
			}

			public static DateTimePropertyConfiguration ExpireDate(DateTimePropertyConfiguration config)
			{
				return config.HasColumnName("ExpireDate").IsRequired();
			}

			public static PropertyMappingConfiguration ExpireDate(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("ExpireDate");
			}

			public static string PasswordResetReasonId()
			{
				return "PasswordResetReasonID";
			}

			public static PrimitivePropertyConfiguration PasswordResetReasonId(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("PasswordResetReasonID").IsRequired();
			}

			public static PropertyMappingConfiguration PasswordResetReasonId(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("PasswordResetReasonID");
			}

		}

		public class PasswordResetReason
		{
	 		public static string SchemaName
			{
				get { return "dbo"; }
			}
	 		

			public static string TableName
			{
				get { return "PasswordResetReasons"; }
			}

			public static string PasswordResetReasonId()
			{
				return "PasswordResetReasonID";
			}

			public static PrimitivePropertyConfiguration PasswordResetReasonId(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("PasswordResetReasonID").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			}

			public static PropertyMappingConfiguration PasswordResetReasonId(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("PasswordResetReasonID");
			}

			public static string Name()
			{
				return "name";
			}

			public static StringPropertyConfiguration Name(StringPropertyConfiguration config)
			{
				return config.HasColumnName("name").IsRequired().IsUnicode(false).HasMaxLength(50);
			}

			public static PropertyMappingConfiguration Name(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("name");
			}

			public static string Code()
			{
				return "code";
			}

			public static StringPropertyConfiguration Code(StringPropertyConfiguration config)
			{
				return config.HasColumnName("code").IsRequired().IsUnicode(false).HasMaxLength(50);
			}

			public static PropertyMappingConfiguration Code(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("code");
			}

		}

		public class Position
		{
	 		public static string SchemaName
			{
				get { return "dbo"; }
			}
	 		

			public static string TableName
			{
				get { return "positions"; }
			}

			public static string PositionId()
			{
				return "positionID";
			}

			public static PrimitivePropertyConfiguration PositionId(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("positionID").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			}

			public static PropertyMappingConfiguration PositionId(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("positionID");
			}

			public static string EmployerId()
			{
				return "employerID";
			}

			public static PrimitivePropertyConfiguration EmployerId(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("employerID").IsRequired();
			}

			public static PropertyMappingConfiguration EmployerId(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("employerID");
			}

			public static string PositionCode()
			{
				return "positionCode";
			}

			public static StringPropertyConfiguration PositionCode(StringPropertyConfiguration config)
			{
				return config.HasColumnName("positionCode").IsRequired().IsUnicode(false).HasMaxLength(50);
			}

			public static PropertyMappingConfiguration PositionCode(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("positionCode");
			}

			public static string PositionTitle()
			{
				return "positionTitle";
			}

			public static StringPropertyConfiguration PositionTitle(StringPropertyConfiguration config)
			{
				return config.HasColumnName("positionTitle").IsRequired().IsUnicode(false).HasMaxLength(100);
			}

			public static PropertyMappingConfiguration PositionTitle(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("positionTitle");
			}

			public static string DepartmentId()
			{
				return "departmentID";
			}

			public static PrimitivePropertyConfiguration DepartmentId(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("departmentID").IsRequired();
			}

			public static PropertyMappingConfiguration DepartmentId(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("departmentID");
			}

			public static string DivisionId()
			{
				return "divisionID";
			}

			public static PrimitivePropertyConfiguration DivisionId(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("divisionID").IsOptional();
			}

			public static PropertyMappingConfiguration DivisionId(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("divisionID");
			}

			public static string ClassSpecId()
			{
				return "classSpecID";
			}

			public static PrimitivePropertyConfiguration ClassSpecId(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("classSpecID").IsOptional();
			}

			public static PropertyMappingConfiguration ClassSpecId(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("classSpecID");
			}

			public static string IsActive()
			{
				return "isActive";
			}

			public static PrimitivePropertyConfiguration IsActive(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("isActive").IsRequired();
			}

			public static PropertyMappingConfiguration IsActive(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("isActive");
			}

			public static string MaxFte()
			{
				return "maxFTE";
			}

			public static DecimalPropertyConfiguration MaxFte(DecimalPropertyConfiguration config)
			{
				return config.HasColumnName("maxFTE").IsOptional().HasPrecision(9,2);
			}

			public static PropertyMappingConfiguration MaxFte(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("maxFTE");
			}

			public static string CurrentFte()
			{
				return "currentFTE";
			}

			public static DecimalPropertyConfiguration CurrentFte(DecimalPropertyConfiguration config)
			{
				return config.HasColumnName("currentFTE").IsOptional().HasPrecision(9,2);
			}

			public static PropertyMappingConfiguration CurrentFte(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("currentFTE");
			}

			public static string CreateDate()
			{
				return "createDate";
			}

			public static DateTimePropertyConfiguration CreateDate(DateTimePropertyConfiguration config)
			{
				return config.HasColumnName("createDate").IsRequired();
			}

			public static PropertyMappingConfiguration CreateDate(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("createDate");
			}

			public static string CreateByUserId()
			{
				return "createByUserID";
			}

			public static PrimitivePropertyConfiguration CreateByUserId(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("createByUserID").IsRequired();
			}

			public static PropertyMappingConfiguration CreateByUserId(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("createByUserID");
			}

			public static string UpdateDate()
			{
				return "updateDate";
			}

			public static DateTimePropertyConfiguration UpdateDate(DateTimePropertyConfiguration config)
			{
				return config.HasColumnName("updateDate").IsRequired();
			}

			public static PropertyMappingConfiguration UpdateDate(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("updateDate");
			}

			public static string UpdateByUserId()
			{
				return "updateByUserID";
			}

			public static PrimitivePropertyConfiguration UpdateByUserId(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("updateByUserID").IsRequired();
			}

			public static PropertyMappingConfiguration UpdateByUserId(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("updateByUserID");
			}

			public static string UniqueId()
			{
				return "uniqueID";
			}

			public static PrimitivePropertyConfiguration UniqueId(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("uniqueID").IsOptional();
			}

			public static PropertyMappingConfiguration UniqueId(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("uniqueID");
			}

			public static string PePositionId()
			{
				return "pePositionID";
			}

			public static PrimitivePropertyConfiguration PePositionId(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("pePositionID").IsOptional();
			}

			public static PropertyMappingConfiguration PePositionId(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("pePositionID");
			}

			public static string DepartmentHead()
			{
				return "DepartmentHead";
			}

			public static PrimitivePropertyConfiguration DepartmentHead(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("DepartmentHead").IsOptional();
			}

			public static PropertyMappingConfiguration DepartmentHead(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("DepartmentHead");
			}

			public static string ClientId()
			{
				return "ClientID";
			}

			public static StringPropertyConfiguration ClientId(StringPropertyConfiguration config)
			{
				return config.HasColumnName("ClientID").IsOptional().IsUnicode(false).HasMaxLength(50);
			}

			public static PropertyMappingConfiguration ClientId(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("ClientID");
			}

		}

		public class RetryEventProcessingQueue
		{
	 		public static string SchemaName
			{
				get { return "dbo"; }
			}
	 		

			public static string TableName
			{
				get { return "RetryEventProcessingQueue"; }
			}

			public static string Id()
			{
				return "Id";
			}

			public static PrimitivePropertyConfiguration Id(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("Id").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
			}

			public static PropertyMappingConfiguration Id(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("Id");
			}

			public static string ApplicationId()
			{
				return "ApplicationId";
			}

			public static PrimitivePropertyConfiguration ApplicationId(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("ApplicationId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
			}

			public static PropertyMappingConfiguration ApplicationId(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("ApplicationId");
			}

			public static string Attempts()
			{
				return "Attempts";
			}

			public static PrimitivePropertyConfiguration Attempts(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("Attempts").IsRequired();
			}

			public static PropertyMappingConfiguration Attempts(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("Attempts");
			}

			public static string LastRetriedOn()
			{
				return "LastRetriedOn";
			}

			public static DateTimePropertyConfiguration LastRetriedOn(DateTimePropertyConfiguration config)
			{
				return config.HasColumnName("LastRetriedOn").IsRequired();
			}

			public static PropertyMappingConfiguration LastRetriedOn(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("LastRetriedOn");
			}

			public static string Error()
			{
				return "Error";
			}

			public static StringPropertyConfiguration Error(StringPropertyConfiguration config)
			{
				return config.HasColumnName("Error").IsOptional().IsUnicode(false);
			}

			public static PropertyMappingConfiguration Error(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("Error");
			}

		}

		public class State
		{
	 		public static string SchemaName
			{
				get { return "dbo"; }
			}
	 		

			public static string TableName
			{
				get { return "States"; }
			}

			public static string StateId()
			{
				return "stateID";
			}

			public static PrimitivePropertyConfiguration StateId(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("stateID").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			}

			public static PropertyMappingConfiguration StateId(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("stateID");
			}

			public static string State_()
			{
				return "state";
			}

			public static StringPropertyConfiguration State_(StringPropertyConfiguration config)
			{
				return config.HasColumnName("state").IsRequired().IsUnicode(false).HasMaxLength(50);
			}

			public static PropertyMappingConfiguration State_(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("state");
			}

			public static string Abbreviation()
			{
				return "abbreviation";
			}

			public static StringPropertyConfiguration Abbreviation(StringPropertyConfiguration config)
			{
				return config.HasColumnName("abbreviation").IsRequired().IsUnicode(false).HasMaxLength(2);
			}

			public static PropertyMappingConfiguration Abbreviation(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("abbreviation");
			}

			public static string Sort()
			{
				return "sort";
			}

			public static PrimitivePropertyConfiguration Sort(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("sort").IsOptional();
			}

			public static PropertyMappingConfiguration Sort(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("sort");
			}

		}

		public class TempUserProdStatus03072014
		{
	 		public static string SchemaName
			{
				get { return "dbo"; }
			}
	 		

			public static string TableName
			{
				get { return "Temp_UserProdStatus_03072014"; }
			}

			public static string UserId()
			{
				return "UserID";
			}

			public static PrimitivePropertyConfiguration UserId(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("UserID").IsRequired();
			}

			public static PropertyMappingConfiguration UserId(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("UserID");
			}

			public static string Email()
			{
				return "email";
			}

			public static StringPropertyConfiguration Email(StringPropertyConfiguration config)
			{
				return config.HasColumnName("email").IsRequired().IsUnicode(false).HasMaxLength(50);
			}

			public static PropertyMappingConfiguration Email(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("email");
			}

			public static string InsightEnable()
			{
				return "InsightEnable";
			}

			public static PrimitivePropertyConfiguration InsightEnable(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("InsightEnable").IsRequired();
			}

			public static PropertyMappingConfiguration InsightEnable(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("InsightEnable");
			}

			public static string OhcEnabled()
			{
				return "OHCEnabled";
			}

			public static PrimitivePropertyConfiguration OhcEnabled(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("OHCEnabled").IsRequired();
			}

			public static PropertyMappingConfiguration OhcEnabled(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("OHCEnabled");
			}

			public static string PlatformEnabled()
			{
				return "PlatformEnabled";
			}

			public static PrimitivePropertyConfiguration PlatformEnabled(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("PlatformEnabled").IsRequired();
			}

			public static PropertyMappingConfiguration PlatformEnabled(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("PlatformEnabled");
			}

			public static string ReqUserId()
			{
				return "ReqUserID";
			}

			public static PrimitivePropertyConfiguration ReqUserId(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("ReqUserID").IsOptional();
			}

			public static PropertyMappingConfiguration ReqUserId(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("ReqUserID");
			}

		}

		public class TimeZoneDef
		{
	 		public static string SchemaName
			{
				get { return "dbo"; }
			}
	 		

			public static string TableName
			{
				get { return "TimeZoneDef"; }
			}

			public static string TimeZoneId()
			{
				return "TimeZoneID";
			}

			public static PrimitivePropertyConfiguration TimeZoneId(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("TimeZoneID").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			}

			public static PropertyMappingConfiguration TimeZoneId(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("TimeZoneID");
			}

			public static string TimeZone()
			{
				return "TimeZone";
			}

			public static StringPropertyConfiguration TimeZone(StringPropertyConfiguration config)
			{
				return config.HasColumnName("TimeZone").IsRequired().IsUnicode(false).HasMaxLength(60);
			}

			public static PropertyMappingConfiguration TimeZone(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("TimeZone");
			}

			public static string UtcOffset()
			{
				return "UTCOffset";
			}

			public static DecimalPropertyConfiguration UtcOffset(DecimalPropertyConfiguration config)
			{
				return config.HasColumnName("UTCOffset").IsRequired().HasPrecision(5,2);
			}

			public static PropertyMappingConfiguration UtcOffset(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("UTCOffset");
			}

			public static string SystemTimeZoneId()
			{
				return "SystemTimeZoneID";
			}

			public static StringPropertyConfiguration SystemTimeZoneId(StringPropertyConfiguration config)
			{
				return config.HasColumnName("SystemTimeZoneID").IsOptional().IsUnicode(false).HasMaxLength(100);
			}

			public static PropertyMappingConfiguration SystemTimeZoneId(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("SystemTimeZoneID");
			}

		}

		public class User
		{
	 		public static string SchemaName
			{
				get { return "dbo"; }
			}
	 		

			public static string TableName
			{
				get { return "Users"; }
			}

			public static string UserId()
			{
				return "UserID";
			}

			public static PrimitivePropertyConfiguration UserId(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("UserID").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			}

			public static PropertyMappingConfiguration UserId(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("UserID");
			}

			public static string EmployerId()
			{
				return "EmployerID";
			}

			public static PrimitivePropertyConfiguration EmployerId(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("EmployerID").IsRequired();
			}

			public static PropertyMappingConfiguration EmployerId(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("EmployerID");
			}

			public static string FirstName()
			{
				return "firstName";
			}

			public static StringPropertyConfiguration FirstName(StringPropertyConfiguration config)
			{
				return config.HasColumnName("firstName").IsOptional().IsUnicode(false).HasMaxLength(50);
			}

			public static PropertyMappingConfiguration FirstName(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("firstName");
			}

			public static string LastName()
			{
				return "lastName";
			}

			public static StringPropertyConfiguration LastName(StringPropertyConfiguration config)
			{
				return config.HasColumnName("lastName").IsOptional().IsUnicode(false).HasMaxLength(50);
			}

			public static PropertyMappingConfiguration LastName(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("lastName");
			}

			public static string Phone()
			{
				return "phone";
			}

			public static StringPropertyConfiguration Phone(StringPropertyConfiguration config)
			{
				return config.HasColumnName("phone").IsOptional().IsUnicode(false).HasMaxLength(50);
			}

			public static PropertyMappingConfiguration Phone(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("phone");
			}

			public static string Email()
			{
				return "email";
			}

			public static StringPropertyConfiguration Email(StringPropertyConfiguration config)
			{
				return config.HasColumnName("email").IsRequired().IsUnicode(false).HasMaxLength(50);
			}

			public static PropertyMappingConfiguration Email(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("email");
			}

			public static string Username()
			{
				return "username";
			}

			public static StringPropertyConfiguration Username(StringPropertyConfiguration config)
			{
				return config.HasColumnName("username").IsRequired().IsUnicode(false).HasMaxLength(50);
			}

			public static PropertyMappingConfiguration Username(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("username");
			}

			public static string Password()
			{
				return "password";
			}

			public static BinaryPropertyConfiguration Password(BinaryPropertyConfiguration config)
			{
				return config.HasColumnName("password").IsRequired();
			}

			public static PropertyMappingConfiguration Password(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("password");
			}

			public static string Oldpassword()
			{
				return "oldpassword";
			}

			public static BinaryPropertyConfiguration Oldpassword(BinaryPropertyConfiguration config)
			{
				return config.HasColumnName("oldpassword").IsOptional();
			}

			public static PropertyMappingConfiguration Oldpassword(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("oldpassword");
			}

			public static string Guid()
			{
				return "guid";
			}

			public static PrimitivePropertyConfiguration Guid(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("guid").IsRequired();
			}

			public static PropertyMappingConfiguration Guid(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("guid");
			}

			public static string FailedLogins()
			{
				return "failedLogins";
			}

			public static PrimitivePropertyConfiguration FailedLogins(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("failedLogins").IsRequired();
			}

			public static PropertyMappingConfiguration FailedLogins(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("failedLogins");
			}

			public static string LastLoginFailure()
			{
				return "lastLoginFailure";
			}

			public static DateTimePropertyConfiguration LastLoginFailure(DateTimePropertyConfiguration config)
			{
				return config.HasColumnName("lastLoginFailure").IsOptional();
			}

			public static PropertyMappingConfiguration LastLoginFailure(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("lastLoginFailure");
			}

			public static string LastLoginSuccess()
			{
				return "lastLoginSuccess";
			}

			public static DateTimePropertyConfiguration LastLoginSuccess(DateTimePropertyConfiguration config)
			{
				return config.HasColumnName("lastLoginSuccess").IsOptional();
			}

			public static PropertyMappingConfiguration LastLoginSuccess(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("lastLoginSuccess");
			}

			public static string LatLoginIpAddress()
			{
				return "latLoginIpAddress";
			}

			public static StringPropertyConfiguration LatLoginIpAddress(StringPropertyConfiguration config)
			{
				return config.HasColumnName("latLoginIpAddress").IsOptional().IsUnicode(false).HasMaxLength(15);
			}

			public static PropertyMappingConfiguration LatLoginIpAddress(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("latLoginIpAddress");
			}

			public static string LastPasswordChange()
			{
				return "lastPasswordChange";
			}

			public static DateTimePropertyConfiguration LastPasswordChange(DateTimePropertyConfiguration config)
			{
				return config.HasColumnName("lastPasswordChange").IsOptional();
			}

			public static PropertyMappingConfiguration LastPasswordChange(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("lastPasswordChange");
			}

			public static string IsActive()
			{
				return "isActive";
			}

			public static PrimitivePropertyConfiguration IsActive(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("isActive").IsRequired();
			}

			public static PropertyMappingConfiguration IsActive(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("isActive");
			}

			public static string IsPendingActivation()
			{
				return "isPendingActivation";
			}

			public static PrimitivePropertyConfiguration IsPendingActivation(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("isPendingActivation").IsRequired();
			}

			public static PropertyMappingConfiguration IsPendingActivation(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("isPendingActivation");
			}

			public static string IsSuperAdmin()
			{
				return "isSuperAdmin";
			}

			public static PrimitivePropertyConfiguration IsSuperAdmin(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("isSuperAdmin").IsRequired();
			}

			public static PropertyMappingConfiguration IsSuperAdmin(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("isSuperAdmin");
			}

			public static string CreateDate()
			{
				return "createDate";
			}

			public static DateTimePropertyConfiguration CreateDate(DateTimePropertyConfiguration config)
			{
				return config.HasColumnName("createDate").IsRequired();
			}

			public static PropertyMappingConfiguration CreateDate(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("createDate");
			}

			public static string UpdateDate()
			{
				return "updateDate";
			}

			public static DateTimePropertyConfiguration UpdateDate(DateTimePropertyConfiguration config)
			{
				return config.HasColumnName("updateDate").IsOptional();
			}

			public static PropertyMappingConfiguration UpdateDate(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("updateDate");
			}

			public static string Uri()
			{
				return "uri";
			}

			public static StringPropertyConfiguration Uri(StringPropertyConfiguration config)
			{
				return config.HasColumnName("uri").IsOptional().IsUnicode(false).HasMaxLength(250);
			}

			public static PropertyMappingConfiguration Uri(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("uri");
			}

			public static string PasswordSalt()
			{
				return "PasswordSalt";
			}

			public static StringPropertyConfiguration PasswordSalt(StringPropertyConfiguration config)
			{
				return config.HasColumnName("PasswordSalt").IsRequired().IsUnicode(false).HasMaxLength(500);
			}

			public static PropertyMappingConfiguration PasswordSalt(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("PasswordSalt");
			}

			public static string ReqUserId()
			{
				return "ReqUserID";
			}

			public static PrimitivePropertyConfiguration ReqUserId(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("ReqUserID").IsOptional();
			}

			public static PropertyMappingConfiguration ReqUserId(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("ReqUserID");
			}

			public static string Photo()
			{
				return "Photo";
			}

			public static StringPropertyConfiguration Photo(StringPropertyConfiguration config)
			{
				return config.HasColumnName("Photo").IsOptional().IsUnicode(false).HasMaxLength(500);
			}

			public static PropertyMappingConfiguration Photo(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("Photo");
			}

			public static string PhotoInternalFileName()
			{
				return "PhotoInternalFileName";
			}

			public static StringPropertyConfiguration PhotoInternalFileName(StringPropertyConfiguration config)
			{
				return config.HasColumnName("PhotoInternalFileName").IsOptional().IsUnicode(false).HasMaxLength(100);
			}

			public static PropertyMappingConfiguration PhotoInternalFileName(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("PhotoInternalFileName");
			}

			public static string PhotoExternalFileName()
			{
				return "PhotoExternalFileName";
			}

			public static StringPropertyConfiguration PhotoExternalFileName(StringPropertyConfiguration config)
			{
				return config.HasColumnName("PhotoExternalFileName").IsOptional().IsUnicode(false).HasMaxLength(300);
			}

			public static PropertyMappingConfiguration PhotoExternalFileName(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("PhotoExternalFileName");
			}

			public static string DontShowPasswordExpirationWarning()
			{
				return "DontShowPasswordExpirationWarning";
			}

			public static PrimitivePropertyConfiguration DontShowPasswordExpirationWarning(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("DontShowPasswordExpirationWarning").IsRequired();
			}

			public static PropertyMappingConfiguration DontShowPasswordExpirationWarning(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("DontShowPasswordExpirationWarning");
			}

			public static string LastActivationSentOn()
			{
				return "LastActivationSentOn";
			}

			public static DateTimePropertyConfiguration LastActivationSentOn(DateTimePropertyConfiguration config)
			{
				return config.HasColumnName("LastActivationSentOn").IsOptional();
			}

			public static PropertyMappingConfiguration LastActivationSentOn(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("LastActivationSentOn");
			}

		}

		public class UserAddress
		{
	 		public static string SchemaName
			{
				get { return "dbo"; }
			}
	 		

			public static string TableName
			{
				get { return "UserAddress"; }
			}

			public static string UserId()
			{
				return "UserID";
			}

			public static PrimitivePropertyConfiguration UserId(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("UserID").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
			}

			public static PropertyMappingConfiguration UserId(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("UserID");
			}

			public static string Address1()
			{
				return "Address1";
			}

			public static StringPropertyConfiguration Address1(StringPropertyConfiguration config)
			{
				return config.HasColumnName("Address1").IsOptional().IsUnicode(false).HasMaxLength(200);
			}

			public static PropertyMappingConfiguration Address1(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("Address1");
			}

			public static string Address2()
			{
				return "Address2";
			}

			public static StringPropertyConfiguration Address2(StringPropertyConfiguration config)
			{
				return config.HasColumnName("Address2").IsOptional().IsUnicode(false).HasMaxLength(200);
			}

			public static PropertyMappingConfiguration Address2(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("Address2");
			}

			public static string StateId()
			{
				return "StateID";
			}

			public static PrimitivePropertyConfiguration StateId(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("StateID").IsOptional();
			}

			public static PropertyMappingConfiguration StateId(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("StateID");
			}

			public static string ZipCode()
			{
				return "ZipCode";
			}

			public static StringPropertyConfiguration ZipCode(StringPropertyConfiguration config)
			{
				return config.HasColumnName("ZipCode").IsOptional().IsUnicode(false).HasMaxLength(10);
			}

			public static PropertyMappingConfiguration ZipCode(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("ZipCode");
			}

			public static string City()
			{
				return "City";
			}

			public static StringPropertyConfiguration City(StringPropertyConfiguration config)
			{
				return config.HasColumnName("City").IsOptional().IsUnicode(false).HasMaxLength(200);
			}

			public static PropertyMappingConfiguration City(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("City");
			}

		}

		public class UserApiKey
		{
	 		public static string SchemaName
			{
				get { return "dbo"; }
			}
	 		

			public static string TableName
			{
				get { return "UserApiKeys"; }
			}

			public static string Id()
			{
				return "ID";
			}

			public static PrimitivePropertyConfiguration Id(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("ID").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			}

			public static PropertyMappingConfiguration Id(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("ID");
			}

			public static string EmployerId()
			{
				return "EmployerID";
			}

			public static PrimitivePropertyConfiguration EmployerId(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("EmployerID").IsRequired();
			}

			public static PropertyMappingConfiguration EmployerId(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("EmployerID");
			}

			public static string UserId()
			{
				return "UserID";
			}

			public static PrimitivePropertyConfiguration UserId(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("UserID").IsRequired();
			}

			public static PropertyMappingConfiguration UserId(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("UserID");
			}

			public static string OfflineApiKey()
			{
				return "OfflineApiKey";
			}

			public static StringPropertyConfiguration OfflineApiKey(StringPropertyConfiguration config)
			{
				return config.HasColumnName("OfflineApiKey").IsRequired().IsUnicode(false).HasMaxLength(200);
			}

			public static PropertyMappingConfiguration OfflineApiKey(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("OfflineApiKey");
			}

		}

		public class UserProductStatu
		{
	 		public static string SchemaName
			{
				get { return "dbo"; }
			}
	 		

			public static string TableName
			{
				get { return "UserProductStatus"; }
			}

			public static string UserId()
			{
				return "UserID";
			}

			public static PrimitivePropertyConfiguration UserId(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("UserID").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
			}

			public static PropertyMappingConfiguration UserId(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("UserID");
			}

			public static string PlatformEnabled()
			{
				return "PlatformEnabled";
			}

			public static PrimitivePropertyConfiguration PlatformEnabled(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("PlatformEnabled").IsRequired();
			}

			public static PropertyMappingConfiguration PlatformEnabled(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("PlatformEnabled");
			}

			public static string InsightEnable()
			{
				return "InsightEnable";
			}

			public static PrimitivePropertyConfiguration InsightEnable(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("InsightEnable").IsRequired();
			}

			public static PropertyMappingConfiguration InsightEnable(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("InsightEnable");
			}

			public static string OhcEnabled()
			{
				return "OHCEnabled";
			}

			public static PrimitivePropertyConfiguration OhcEnabled(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("OHCEnabled").IsRequired();
			}

			public static PropertyMappingConfiguration OhcEnabled(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("OHCEnabled");
			}

		}

		public class UserType
		{
	 		public static string SchemaName
			{
				get { return "dbo"; }
			}
	 		

			public static string TableName
			{
				get { return "UserTypes"; }
			}

			public static string UserTypeId()
			{
				return "UserTypeID";
			}

			public static PrimitivePropertyConfiguration UserTypeId(PrimitivePropertyConfiguration config)
			{
				return config.HasColumnName("UserTypeID").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			}

			public static PropertyMappingConfiguration UserTypeId(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("UserTypeID");
			}

			public static string Name()
			{
				return "Name";
			}

			public static StringPropertyConfiguration Name(StringPropertyConfiguration config)
			{
				return config.HasColumnName("Name").IsRequired().IsUnicode(false).HasMaxLength(50);
			}

			public static PropertyMappingConfiguration Name(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("Name");
			}

			public static string Code()
			{
				return "Code";
			}

			public static StringPropertyConfiguration Code(StringPropertyConfiguration config)
			{
				return config.HasColumnName("Code").IsRequired().IsUnicode(false).HasMaxLength(50);
			}

			public static PropertyMappingConfiguration Code(PropertyMappingConfiguration config)
			{
				return config.HasColumnName("Code");
			}

		}

	}
}


