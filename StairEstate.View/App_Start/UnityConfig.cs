using StairEstate.Data;
using StairEstate.Entity;
using StairEstate.Repo;
using StairEstate.Repo.Generics;
using StairEstate.Repo.Interfaces;
using StairEstate.Service;
using System;
using System.Web.Http;
using System.Web.Mvc;
using Unity;

namespace StaitEstate.View
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your type's mappings here.
            // container.RegisterType<IProductRepository, ProductRepository>();
            //DependencyResolver.SetResolver(new Unity.Mvc5.UnityDependencyResolver(container));

            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);


            //DbContext
            container.RegisterType<MHLDB, MHLDB>();

            //For Menu
            container.RegisterType<IMenuRepository, MenuRepository>();
            container.RegisterType<IMenuService, MenuService>();
            container.RegisterType<IRepository<sys_menu>, Repository<sys_menu>>();

            //For User
            container.RegisterType<IUserService, UserService>();
            container.RegisterType<IUserRepository, UserRepository>();
            container.RegisterType<IRepository<sys_user>, Repository<sys_user>>();


            //For User Type
            container.RegisterType<IUserTypeService, UserTypeService>();
            container.RegisterType<IUserTypeRepository, UserTypeRepository>();
            container.RegisterType<IRepository<sys_user_type>, Repository<sys_user_type>>();


            //For Menu Access
            container.RegisterType<IUserMenuAccessService, UserMenuAccessService>();
            container.RegisterType<IRepository<sys_user_menu_access>, Repository<sys_user_menu_access>>();
            container.RegisterType<IUserMenuPermissionRepository, UserMenuPermissionRepository>();

            //For Branch
            container.RegisterType<IBranchService, BranchService>();
            container.RegisterType<IRepository<sys_branch>, Repository<sys_branch>>();

            //For Country
            container.RegisterType<ICountryService, CountryService>();
            container.RegisterType<IRepository<sys_country>, Repository<sys_country>>();

            //For Employee
            container.RegisterType<IEmployeeService, EmployeeService>();
            container.RegisterType<IRepository<hr_employee>, Repository<hr_employee>>();
            container.RegisterType<IEmployeeRepositoy, EmployeeRepository>();

            //For EmployeeType 
            container.RegisterType<IEmployeeTypeService, EmployeeTypeService>();
            container.RegisterType<IRepository<hr_employee_type>, Repository<hr_employee_type>>();


            //For Collector
            container.RegisterType<ICollectorService, CollectorService>();
            container.RegisterType<IRepository<sales_collector>, Repository<sales_collector>>();



            //For Profession
            container.RegisterType<IProfessionService, ProfessionService>();
            container.RegisterType<IRepository<hr_profession>, Repository<hr_profession>>();

            //For Customer
            container.RegisterType<ICustomerService, CustomerService>();
            container.RegisterType<IRepository<sales_customer>, Repository<sales_customer>>();

            //For Project
            container.RegisterType<IProjectService, ProjectService>();
            container.RegisterType<IRepository<proj_project>, Repository<proj_project>>();

            //For Project Tye
            container.RegisterType<IProjectTypeService, ProjectTypeService>();
            container.RegisterType<IRepository<proj_project_type>, Repository<proj_project_type>>();

            //For Project Status
            container.RegisterType<IProjectStatusService, ProjectStatusService>();
            container.RegisterType<IRepository<proj_project_status>, Repository<proj_project_status>>();

            //For Stack Holder Type
            container.RegisterType<IStackHolderTypeService, StackHolderTypeService>();
            container.RegisterType<IRepository<sales_stack_holder_type>, Repository<sales_stack_holder_type>>();

            //For Stack Holder 
            container.RegisterType<IStackHolderService, StackHolderService>();
            container.RegisterType<IRepository<sales_stack_holder>, Repository<sales_stack_holder>>();

            //For District
            container.RegisterType<IDistrictService, DistrictService>();
            container.RegisterType<IRepository<sys_district>, Repository<sys_district>>();

            //For Thana
            container.RegisterType<IThanaService, ThanaService>();
            container.RegisterType<IRepository<sys_thana>, Repository<sys_thana>>();

            //For Mouza
            container.RegisterType<IMouzaService, MouzaService>();
            container.RegisterType<IRepository<sys_mouza>, Repository<sys_mouza>>();

            //For Land Master
            container.RegisterType<ILandMasterService, LandMasterService>();
            container.RegisterType<IRepository<prop_Land_Contribution>, Repository<prop_Land_Contribution>>();
            container.RegisterType<ILandMasterRepository, LandMasterRepository>();

            //For Unit
            container.RegisterType<IUnitService, UnitService>();
            container.RegisterType<IRepository<prop_unit>, Repository<prop_unit>>();

            //For Land
            container.RegisterType<ILandService, LandService>();
            container.RegisterType<IRepository<prop_Land>, Repository<prop_Land>>();
            

            //For Facing
            container.RegisterType<IFacingService, FacingService>();
            container.RegisterType<IRepository<proj_facing>, Repository<proj_facing>>();

            //For Block
            container.RegisterType<IBlockService, BlockService>();
            container.RegisterType<IRepository<proj_block>, Repository<proj_block>>();

            //for Road
            container.RegisterType<IRoadService, RoadService>();
            container.RegisterType<IRepository<proj_road>, Repository<proj_road>>();

            //For Plot
            container.RegisterType<IPlotService, PlotService>();
            container.RegisterType<IRepository<proj_plot>, Repository<proj_plot>>();

            //For Catagory
            container.RegisterType<ICatagoryService, CatagoryService>();
            container.RegisterType<IRepository<prod_catagory>, Repository<prod_catagory>>();

            //For Brand
            container.RegisterType<IBrandService, BrandService>();
            container.RegisterType<IRepository<prod_brand>, Repository<prod_brand>>();

            //For Product
            container.RegisterType<IProductService, ProductService>();
            container.RegisterType<IRepository<prod_product>, Repository<prod_product>>();

            //For Product Type
            container.RegisterType<IProductTypeService, ProductTypeService>();
            container.RegisterType<IRepository<Prod_type>, Repository<Prod_type>>();

            //For Plot Allocation
            container.RegisterType<IPlotAllocationMasterService, PlotAllocationMasterService>();
            container.RegisterType<IRepository<proj_plot_allocation_master>, Repository<proj_plot_allocation_master>>();

            container.RegisterType<IPlotAllocationDetailsService, PlotAllocationDetailsService>();
            container.RegisterType<IRepository<proj_plot_allocation_details>, Repository<proj_plot_allocation_details>>();

            //For Current Stock
            container.RegisterType<ICurrentStockMasterService, CurrentStockMasterService>();
            container.RegisterType<IRepository<prod_current_stock_master>, Repository<prod_current_stock_master>>();

            container.RegisterType<ICurrentStockDetailsService, CurrentStockDetailsService>();
            container.RegisterType<IRepository<prod_current_stock_details>, Repository<prod_current_stock_details>>();

            //For PlotSalesOrder
            container.RegisterType<IPlotSalesOrderService, PlotSalesOrderService>();
            container.RegisterType<IRepository<sales_order_plot>, Repository<sales_order_plot>>();

            //forPlotSalesOrderDetails
            container.RegisterType<IPlotSalesOrderDetailsService, PlotSalesOrderDetailsService>();
            container.RegisterType<IRepository<sales_order_plot_details>, Repository<sales_order_plot_details>>();

            //for PlotSales
            container.RegisterType<IPlotSalesDetailsService, PlotSalesDetailsService>();
            container.RegisterType<IRepository<sales_plot_sales_details>, Repository<sales_plot_sales_details>>();

            //for Customer and Plot Relation
            container.RegisterType<IPlotCustomerService, PlotCustomerService>();
            container.RegisterType<IRepository<sales_sales_order_customer>, Repository<sales_sales_order_customer>>();

        }
    }
}