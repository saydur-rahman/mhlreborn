using StairEstate.Entity;
using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;


namespace StairEstate.Data
{
    public class MHLDB : DbContext
    {
        public MHLDB()
            : base("name=MHLDBConnection")
        {
        }


        public virtual DbSet<company> companies { get; set; }
        public virtual DbSet<hr_employee> hr_employee { get; set; }
        public virtual DbSet<hr_employee_type> hr_employee_type { get; set; }
        public virtual DbSet<hr_profession> hr_profession { get; set; }
        public virtual DbSet<lisence> lisences { get; set; }
        public virtual DbSet<prod_brand> prod_brand { get; set; }
        public virtual DbSet<prod_catagory> prod_catagory { get; set; }
        public virtual DbSet<prod_company> prod_company { get; set; }
        public virtual DbSet<prod_current_stock_details> prod_current_stock_details { get; set; }
        public virtual DbSet<prod_current_stock_master> prod_current_stock_master { get; set; }
        public virtual DbSet<prod_product> prod_product { get; set; }
        public virtual DbSet<Prod_type> Prod_type { get; set; }
        public virtual DbSet<proj_block> proj_block { get; set; }
        public virtual DbSet<proj_facing> proj_facing { get; set; }
        public virtual DbSet<proj_plot> proj_plot { get; set; }
        public virtual DbSet<proj_plot_allocation_details> proj_plot_allocation_details { get; set; }
        public virtual DbSet<proj_plot_allocation_master> proj_plot_allocation_master { get; set; }
        public virtual DbSet<proj_project> proj_project { get; set; }
        public virtual DbSet<proj_project_status> proj_project_status { get; set; }
        public virtual DbSet<proj_project_type> proj_project_type { get; set; }
        public virtual DbSet<proj_road> proj_road { get; set; }
        public virtual DbSet<prop_Land> prop_Land { get; set; }
        public virtual DbSet<prop_Land_Contribution> prop_Land_Contribution { get; set; }
        public virtual DbSet<prop_Land_LandOwner> prop_Land_LandOwner { get; set; }
        public virtual DbSet<prop_Land_Media> prop_Land_Media { get; set; }
        public virtual DbSet<prop_unit> prop_unit { get; set; }
        public virtual DbSet<sales_collector> sales_collector { get; set; }
        public virtual DbSet<sales_customer> sales_customer { get; set; }
        public virtual DbSet<sales_nominee> sales_nominee { get; set; }
        public virtual DbSet<sales_nominee_type> sales_nominee_type { get; set; }
        public virtual DbSet<sales_order_plot> sales_order_plot { get; set; }
        public virtual DbSet<sales_order_plot_details> sales_order_plot_details { get; set; }
        public virtual DbSet<sales_plot_sales_details> sales_plot_sales_details { get; set; }
        public virtual DbSet<sales_sales_order_customer> sales_sales_order_customer { get; set; }
        public virtual DbSet<sales_stack_holder> sales_stack_holder { get; set; }
        public virtual DbSet<sales_stack_holder_type> sales_stack_holder_type { get; set; }
        public virtual DbSet<survey_agenda> survey_agenda { get; set; }
        public virtual DbSet<survey_answer> survey_answer { get; set; }
        public virtual DbSet<survey_html> survey_html { get; set; }
        public virtual DbSet<survey_master> survey_master { get; set; }
        public virtual DbSet<survey_question> survey_question { get; set; }
        public virtual DbSet<survey_user_access> survey_user_access { get; set; }
        public virtual DbSet<sys_branch> sys_branch { get; set; }
        public virtual DbSet<sys_country> sys_country { get; set; }
        public virtual DbSet<sys_currency> sys_currency { get; set; }
        public virtual DbSet<sys_district> sys_district { get; set; }
        public virtual DbSet<sys_loginlog> sys_loginlog { get; set; }
        public virtual DbSet<sys_menu> sys_menu { get; set; }
        public virtual DbSet<sys_mouza> sys_mouza { get; set; }
        public virtual DbSet<sys_restrictions> sys_restrictions { get; set; }
        public virtual DbSet<sys_scheduler> sys_scheduler { get; set; }
        public virtual DbSet<sys_scheduler_switch> sys_scheduler_switch { get; set; }
        public virtual DbSet<sys_thana> sys_thana { get; set; }
        public virtual DbSet<sys_user> sys_user { get; set; }
        public virtual DbSet<sys_user_menu_access> sys_user_menu_access { get; set; }
        public virtual DbSet<sys_user_restriction> sys_user_restriction { get; set; }
        public virtual DbSet<sys_user_type> sys_user_type { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<company>()
                .Property(e => e.companyname)
                .IsUnicode(false);

            modelBuilder.Entity<company>()
                .Property(e => e.address)
                .IsUnicode(false);

            modelBuilder.Entity<company>()
                .Property(e => e.TIN)
                .IsUnicode(false);

            modelBuilder.Entity<company>()
                .Property(e => e.BIN)
                .IsUnicode(false);

            modelBuilder.Entity<company>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<company>()
                .Property(e => e.started)
                .IsUnicode(false);

            modelBuilder.Entity<company>()
                .HasMany(e => e.prod_current_stock_master)
                .WithOptional(e => e.company)
                .HasForeignKey(e => e.Company_Id);

            modelBuilder.Entity<hr_employee>()
                .Property(e => e.emp_code)
                .IsUnicode(false);

            modelBuilder.Entity<hr_employee>()
                .Property(e => e.emp_name)
                .IsUnicode(false);

            modelBuilder.Entity<hr_employee>()
                .Property(e => e.emp_email)
                .IsUnicode(false);

            modelBuilder.Entity<hr_employee>()
                .Property(e => e.emp_phone)
                .IsUnicode(false);

            modelBuilder.Entity<hr_employee>()
                .Property(e => e.emp_father_or_husband_name)
                .IsUnicode(false);

            modelBuilder.Entity<hr_employee>()
                .Property(e => e.emp_mother_name)
                .IsUnicode(false);

            modelBuilder.Entity<hr_employee>()
                .Property(e => e.emp_permanent_address)
                .IsUnicode(false);

            modelBuilder.Entity<hr_employee>()
                .Property(e => e.emp_present_address)
                .IsUnicode(false);

            modelBuilder.Entity<hr_employee>()
                .Property(e => e.emp_birth_place)
                .IsUnicode(false);

            modelBuilder.Entity<hr_employee>()
                .Property(e => e.emp_image)
                .IsFixedLength();

            modelBuilder.Entity<hr_employee>()
                .HasMany(e => e.proj_project)
                .WithOptional(e => e.hr_employee)
                .HasForeignKey(e => e.project_manager_id);

            modelBuilder.Entity<hr_employee>()
                .HasMany(e => e.sales_customer)
                .WithOptional(e => e.hr_employee)
                .HasForeignKey(e => e.customer_sales_person_id);

            modelBuilder.Entity<hr_employee>()
                .HasMany(e => e.sales_order_plot)
                .WithOptional(e => e.hr_employee)
                .HasForeignKey(e => e.SalesPersonId);

            modelBuilder.Entity<hr_employee_type>()
                .Property(e => e.emp_type_name)
                .IsUnicode(false);

            modelBuilder.Entity<hr_profession>()
                .Property(e => e.profession_name)
                .IsUnicode(false);

            modelBuilder.Entity<hr_profession>()
                .HasMany(e => e.sales_collector)
                .WithOptional(e => e.hr_profession)
                .HasForeignKey(e => e.collector_profession_id);

            modelBuilder.Entity<hr_profession>()
                .HasMany(e => e.sales_customer)
                .WithOptional(e => e.hr_profession)
                .HasForeignKey(e => e.customer_profession_id);

            modelBuilder.Entity<lisence>()
                .Property(e => e.code)
                .IsUnicode(false);

            modelBuilder.Entity<lisence>()
                .Property(e => e.expires)
                .IsUnicode(false);

            modelBuilder.Entity<prod_brand>()
                .Property(e => e.Brand_name)
                .IsFixedLength();

            modelBuilder.Entity<prod_catagory>()
                .Property(e => e.Catagory_name)
                .IsFixedLength();

            modelBuilder.Entity<prod_catagory>()
                .HasMany(e => e.prod_product)
                .WithOptional(e => e.prod_catagory)
                .HasForeignKey(e => e.Prod_catagory_id);

            modelBuilder.Entity<prod_company>()
                .Property(e => e.Company_name)
                .IsFixedLength();

            modelBuilder.Entity<prod_current_stock_master>()
                .HasMany(e => e.prod_current_stock_details)
                .WithRequired(e => e.prod_current_stock_master)
                .HasForeignKey(e => e.Current_Master_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<prod_product>()
                .HasOptional(e => e.sales_order_plot_details)
                .WithRequired(e => e.prod_product);

            modelBuilder.Entity<prod_product>()
                .HasOptional(e => e.sales_plot_sales_details)
                .WithRequired(e => e.prod_product);

            modelBuilder.Entity<Prod_type>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<Prod_type>()
                .HasMany(e => e.prod_product)
                .WithOptional(e => e.Prod_type)
                .HasForeignKey(e => e.Prod_type_id);

            modelBuilder.Entity<proj_block>()
                .Property(e => e.Block_name)
                .IsFixedLength();

            modelBuilder.Entity<proj_facing>()
                .Property(e => e.Facing_name)
                .IsFixedLength();

            modelBuilder.Entity<proj_plot>()
                .Property(e => e.Plot_desc)
                .IsFixedLength();

            modelBuilder.Entity<proj_plot>()
                .HasMany(e => e.proj_plot_allocation_master)
                .WithOptional(e => e.proj_plot)
                .HasForeignKey(e => e.Product_Id);

            modelBuilder.Entity<proj_plot_allocation_details>()
                .HasMany(e => e.prod_current_stock_details)
                .WithOptional(e => e.proj_plot_allocation_details)
                .HasForeignKey(e => e.Plot_allocation_Details_Id);

            modelBuilder.Entity<proj_plot_allocation_master>()
                .HasMany(e => e.prod_current_stock_master)
                .WithOptional(e => e.proj_plot_allocation_master)
                .HasForeignKey(e => e.Plot_Master_id);

            modelBuilder.Entity<proj_plot_allocation_master>()
                .HasMany(e => e.proj_plot_allocation_details)
                .WithOptional(e => e.proj_plot_allocation_master)
                .HasForeignKey(e => e.Master_Id);

            modelBuilder.Entity<proj_project>()
                .Property(e => e.project_id)
                .IsUnicode(false);

            modelBuilder.Entity<proj_project>()
                .Property(e => e.project_initial)
                .IsUnicode(false);

            modelBuilder.Entity<proj_project>()
                .Property(e => e.project_name)
                .IsUnicode(false);

            modelBuilder.Entity<proj_project>()
                .Property(e => e.project_address)
                .IsUnicode(false);

            modelBuilder.Entity<proj_project>()
                .Property(e => e.project_serial)
                .IsUnicode(false);

            modelBuilder.Entity<proj_project>()
                .Property(e => e.project_image)
                .IsUnicode(false);

            modelBuilder.Entity<proj_project>()
                .HasMany(e => e.prod_current_stock_master)
                .WithOptional(e => e.proj_project)
                .HasForeignKey(e => e.Project_Id);

            modelBuilder.Entity<proj_project>()
                .HasMany(e => e.proj_plot_allocation_master)
                .WithOptional(e => e.proj_project)
                .HasForeignKey(e => e.Project_Id);

            modelBuilder.Entity<proj_project>()
                .HasMany(e => e.prop_Land_Contribution)
                .WithOptional(e => e.proj_project)
                .HasForeignKey(e => e.Land_Con_Project_id);

            modelBuilder.Entity<proj_project>()
                .HasMany(e => e.sales_order_plot)
                .WithOptional(e => e.proj_project)
                .HasForeignKey(e => e.ProjectId);

            modelBuilder.Entity<proj_project_status>()
                .Property(e => e.project_status)
                .IsUnicode(false);

            modelBuilder.Entity<proj_project_status>()
                .HasMany(e => e.proj_project)
                .WithRequired(e => e.proj_project_status)
                .HasForeignKey(e => e.project_status)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<proj_project_type>()
                .Property(e => e.project_type)
                .IsUnicode(false);

            modelBuilder.Entity<proj_road>()
                .Property(e => e.Road_no)
                .IsFixedLength();

            modelBuilder.Entity<prop_Land>()
                .Property(e => e.Land_id_shown)
                .IsUnicode(false);

            modelBuilder.Entity<prop_Land>()
                .Property(e => e.Land_JL_no)
                .IsUnicode(false);

            modelBuilder.Entity<prop_Land>()
                .Property(e => e.Land_Khatian_no)
                .IsUnicode(false);

            modelBuilder.Entity<prop_Land>()
                .Property(e => e.Land_Dag_no)
                .IsUnicode(false);

            modelBuilder.Entity<prop_Land_Contribution>()
                .Property(e => e.Land_Con_Auto_id)
                .IsUnicode(false);

            modelBuilder.Entity<prop_unit>()
                .Property(e => e.Unit_Name)
                .IsUnicode(false);

            modelBuilder.Entity<prop_unit>()
                .HasMany(e => e.proj_plot_allocation_master)
                .WithOptional(e => e.prop_unit)
                .HasForeignKey(e => e.Product_Unit_type_Id);

            modelBuilder.Entity<prop_unit>()
                .HasMany(e => e.prop_Land)
                .WithOptional(e => e.prop_unit)
                .HasForeignKey(e => e.Land_Unit_id);

            modelBuilder.Entity<prop_unit>()
                .HasMany(e => e.sales_order_plot_details)
                .WithOptional(e => e.prop_unit)
                .HasForeignKey(e => e.UnitTypeId);

            modelBuilder.Entity<prop_unit>()
                .HasMany(e => e.sales_plot_sales_details)
                .WithOptional(e => e.prop_unit)
                .HasForeignKey(e => e.UnitId);

            modelBuilder.Entity<sales_collector>()
                .Property(e => e.collector_code)
                .IsUnicode(false);

            modelBuilder.Entity<sales_collector>()
                .Property(e => e.collector_phone)
                .IsUnicode(false);

            modelBuilder.Entity<sales_collector>()
                .Property(e => e.collector_father_or_husband_name)
                .IsUnicode(false);

            modelBuilder.Entity<sales_collector>()
                .Property(e => e.collector_mother_name)
                .IsUnicode(false);

            modelBuilder.Entity<sales_collector>()
                .Property(e => e.collector_parmanent_address)
                .IsUnicode(false);

            modelBuilder.Entity<sales_collector>()
                .Property(e => e.collector_present_address)
                .IsUnicode(false);

            modelBuilder.Entity<sales_collector>()
                .Property(e => e.collector_birth_place)
                .IsUnicode(false);

            modelBuilder.Entity<sales_collector>()
                .Property(e => e.collector_name)
                .IsUnicode(false);

            modelBuilder.Entity<sales_collector>()
                .Property(e => e.collector_image)
                .IsFixedLength();

            modelBuilder.Entity<sales_collector>()
                .HasMany(e => e.sales_customer)
                .WithOptional(e => e.sales_collector)
                .HasForeignKey(e => e.customer_collector_id);

            modelBuilder.Entity<sales_customer>()
                .Property(e => e.customer_code)
                .IsUnicode(false);

            modelBuilder.Entity<sales_customer>()
                .Property(e => e.customer_name)
                .IsUnicode(false);

            modelBuilder.Entity<sales_customer>()
                .Property(e => e.customer_phone)
                .IsUnicode(false);

            modelBuilder.Entity<sales_customer>()
                .Property(e => e.customer_father_or_husband_name)
                .IsUnicode(false);

            modelBuilder.Entity<sales_customer>()
                .Property(e => e.customer_mother_name)
                .IsUnicode(false);

            modelBuilder.Entity<sales_customer>()
                .Property(e => e.customer_permanent_address)
                .IsUnicode(false);

            modelBuilder.Entity<sales_customer>()
                .Property(e => e.customer_present_address)
                .IsUnicode(false);

            modelBuilder.Entity<sales_customer>()
                .Property(e => e.customer_birth_place)
                .IsUnicode(false);

            modelBuilder.Entity<sales_customer>()
                .Property(e => e.customer_image)
                .IsFixedLength();

            modelBuilder.Entity<sales_customer>()
                .HasMany(e => e.sales_nominee)
                .WithOptional(e => e.sales_customer)
                .HasForeignKey(e => e.nominee_customer_id);

            modelBuilder.Entity<sales_customer>()
                .HasMany(e => e.sales_order_plot)
                .WithOptional(e => e.sales_customer)
                .HasForeignKey(e => e.BuyerId);

            modelBuilder.Entity<sales_customer>()
                .HasOptional(e => e.sales_sales_order_customer)
                .WithRequired(e => e.sales_customer);

            modelBuilder.Entity<sales_nominee>()
                .Property(e => e.nominee_name)
                .IsUnicode(false);

            modelBuilder.Entity<sales_nominee>()
                .Property(e => e.nominee_identification_no)
                .IsUnicode(false);

            modelBuilder.Entity<sales_nominee>()
                .Property(e => e.nominee_relation)
                .IsUnicode(false);

            modelBuilder.Entity<sales_nominee>()
                .Property(e => e.nominee_details)
                .IsUnicode(false);

            modelBuilder.Entity<sales_nominee>()
                .Property(e => e.nominee_image)
                .IsUnicode(false);

            modelBuilder.Entity<sales_nominee_type>()
                .Property(e => e.nominee_type_name)
                .IsUnicode(false);

            modelBuilder.Entity<sales_nominee_type>()
                .HasMany(e => e.sales_nominee)
                .WithOptional(e => e.sales_nominee_type)
                .HasForeignKey(e => e.nominee_position_id);

            modelBuilder.Entity<sales_order_plot>()
                .HasMany(e => e.sales_order_plot_details)
                .WithOptional(e => e.sales_order_plot)
                .HasForeignKey(e => e.SalesOrderId);

            modelBuilder.Entity<sales_order_plot>()
                .HasOptional(e => e.sales_sales_order_customer)
                .WithRequired(e => e.sales_order_plot);

            modelBuilder.Entity<sales_stack_holder>()
                .Property(e => e.stack_holder_name)
                .IsUnicode(false);

            modelBuilder.Entity<sales_stack_holder>()
                .Property(e => e.stack_holder_phone)
                .IsUnicode(false);

            modelBuilder.Entity<sales_stack_holder>()
                .Property(e => e.stack_holder_email)
                .IsUnicode(false);

            modelBuilder.Entity<sales_stack_holder>()
                .Property(e => e.stack_holder_Father_name)
                .IsUnicode(false);

            modelBuilder.Entity<sales_stack_holder>()
                .Property(e => e.stack_holder_mother_name)
                .IsUnicode(false);

            modelBuilder.Entity<sales_stack_holder>()
                .Property(e => e.stack_holder_contact_person)
                .IsUnicode(false);

            modelBuilder.Entity<sales_stack_holder>()
                .Property(e => e.stack_holder_contact_person_number)
                .IsUnicode(false);

            modelBuilder.Entity<sales_stack_holder>()
                .Property(e => e.stack_holder_pre_address)
                .IsUnicode(false);

            modelBuilder.Entity<sales_stack_holder>()
                .Property(e => e.stack_holder_per_address)
                .IsUnicode(false);

            modelBuilder.Entity<sales_stack_holder>()
                .Property(e => e.stack_holder_nid_no)
                .IsUnicode(false);

            modelBuilder.Entity<sales_stack_holder>()
                .Property(e => e.stack_holder_image)
                .IsUnicode(false);

            modelBuilder.Entity<sales_stack_holder>()
                .HasMany(e => e.prop_Land_LandOwner)
                .WithOptional(e => e.sales_stack_holder)
                .HasForeignKey(e => e.Land_Owner);

            modelBuilder.Entity<sales_stack_holder>()
                .HasMany(e => e.prop_Land_Media)
                .WithOptional(e => e.sales_stack_holder)
                .HasForeignKey(e => e.Land_media);

            modelBuilder.Entity<sales_stack_holder_type>()
                .Property(e => e.stack_holder_type)
                .IsUnicode(false);

            modelBuilder.Entity<survey_agenda>()
                .HasMany(e => e.survey_master)
                .WithOptional(e => e.survey_agenda)
                .HasForeignKey(e => e.agenda)
                .WillCascadeOnDelete();

            modelBuilder.Entity<survey_agenda>()
                .HasMany(e => e.survey_question)
                .WithOptional(e => e.survey_agenda)
                .HasForeignKey(e => e.agenda);

            modelBuilder.Entity<survey_html>()
                .HasMany(e => e.survey_question)
                .WithOptional(e => e.survey_html)
                .HasForeignKey(e => e.htmlstring);

            modelBuilder.Entity<survey_master>()
                .HasMany(e => e.survey_answer)
                .WithOptional(e => e.survey_master)
                .HasForeignKey(e => e.survey)
                .WillCascadeOnDelete();

            modelBuilder.Entity<survey_question>()
                .HasMany(e => e.survey_answer)
                .WithOptional(e => e.survey_question)
                .HasForeignKey(e => e.question)
                .WillCascadeOnDelete();

            modelBuilder.Entity<sys_branch>()
                .Property(e => e.branch_tin)
                .IsUnicode(false);

            modelBuilder.Entity<sys_branch>()
                .HasMany(e => e.hr_employee)
                .WithOptional(e => e.sys_branch)
                .HasForeignKey(e => e.emp_branch_id);

            modelBuilder.Entity<sys_branch>()
                .HasMany(e => e.proj_project)
                .WithOptional(e => e.sys_branch)
                .HasForeignKey(e => e.project_branch_id);

            modelBuilder.Entity<sys_branch>()
                .HasMany(e => e.prop_Land_Contribution)
                .WithOptional(e => e.sys_branch)
                .HasForeignKey(e => e.Land_Con_branch_Id);

            modelBuilder.Entity<sys_branch>()
                .HasMany(e => e.sales_collector)
                .WithOptional(e => e.sys_branch)
                .HasForeignKey(e => e.collector_branch_id);

            modelBuilder.Entity<sys_branch>()
                .HasMany(e => e.survey_master)
                .WithOptional(e => e.sys_branch)
                .HasForeignKey(e => e.branch);

            modelBuilder.Entity<sys_country>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<sys_country>()
                .HasOptional(e => e.prod_company)
                .WithRequired(e => e.sys_country);

            modelBuilder.Entity<sys_country>()
                .HasMany(e => e.prod_current_stock_master)
                .WithOptional(e => e.sys_country)
                .HasForeignKey(e => e.Country_Id);

            modelBuilder.Entity<sys_country>()
                .HasMany(e => e.sales_order_plot)
                .WithOptional(e => e.sys_country)
                .HasForeignKey(e => e.CountryId);

            modelBuilder.Entity<sys_country>()
                .HasMany(e => e.sales_stack_holder)
                .WithOptional(e => e.sys_country)
                .HasForeignKey(e => e.stack_holder_country_id);

            modelBuilder.Entity<sys_country>()
                .HasMany(e => e.sys_branch)
                .WithOptional(e => e.sys_country)
                .HasForeignKey(e => e.country);

            modelBuilder.Entity<sys_country>()
                .HasMany(e => e.sys_district)
                .WithOptional(e => e.sys_country)
                .HasForeignKey(e => e.District_Country_id);

            modelBuilder.Entity<sys_currency>()
                .Property(e => e.currency_name)
                .IsUnicode(false);

            modelBuilder.Entity<sys_currency>()
                .Property(e => e.shortname)
                .IsUnicode(false);

            modelBuilder.Entity<sys_currency>()
                .HasOptional(e => e.sys_country)
                .WithRequired(e => e.sys_currency);

            modelBuilder.Entity<sys_district>()
                .Property(e => e.District_Name)
                .IsUnicode(false);

            modelBuilder.Entity<sys_district>()
                .HasMany(e => e.sys_thana)
                .WithOptional(e => e.sys_district)
                .HasForeignKey(e => e.Thana_District_id);

            modelBuilder.Entity<sys_loginlog>()
                .Property(e => e.logintime)
                .IsUnicode(false);

            modelBuilder.Entity<sys_loginlog>()
                .Property(e => e.loginuser)
                .IsUnicode(false);

            modelBuilder.Entity<sys_mouza>()
                .Property(e => e.Mouza_name)
                .IsUnicode(false);

            modelBuilder.Entity<sys_mouza>()
                .HasMany(e => e.prop_Land)
                .WithOptional(e => e.sys_mouza)
                .HasForeignKey(e => e.Land_Mouza_id);

            modelBuilder.Entity<sys_restrictions>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<sys_restrictions>()
                .HasMany(e => e.sys_user_restriction)
                .WithOptional(e => e.sys_restrictions)
                .HasForeignKey(e => e.accesscode);

            modelBuilder.Entity<sys_scheduler>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<sys_scheduler>()
                .Property(e => e.detail)
                .IsUnicode(false);

            modelBuilder.Entity<sys_thana>()
                .Property(e => e.Thana_name)
                .IsUnicode(false);

            modelBuilder.Entity<sys_thana>()
                .HasMany(e => e.sys_mouza)
                .WithOptional(e => e.sys_thana)
                .HasForeignKey(e => e.Mouza_Thana_id);

            modelBuilder.Entity<sys_user>()
                .HasMany(e => e.survey_master)
                .WithOptional(e => e.sys_user)
                .HasForeignKey(e => e.userid);

            modelBuilder.Entity<sys_user>()
                .HasMany(e => e.sys_user_restriction)
                .WithOptional(e => e.sys_user)
                .HasForeignKey(e => e.userid);

            modelBuilder.Entity<sys_user_type>()
                .HasMany(e => e.sys_user_menu_access)
                .WithOptional(e => e.sys_user_type)
                .WillCascadeOnDelete();
        }
    }
}
