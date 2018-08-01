using SchoolProject.Models;
using SchoolProject.Models.DTO;
using SchoolProject.Repositories;
using SchoolProject.Services;
using System.Data.Entity;
using System.Web.Http;
using Unity;
using Unity.Lifetime;
using Unity.WebApi;

namespace SchoolProject
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<IUnitOfWork, UnitOfWork>();

            container.RegisterType<IGenericRepository<User>, GenericRepository<User>>();
            container.RegisterType<IGenericRepository<Teacher>, GenericRepository<Teacher>>();
            container.RegisterType<IGenericRepository<Subject>, GenericRepository<Subject>>();
            container.RegisterType<IGenericRepository<Student>, GenericRepository<Student>>();
            container.RegisterType<IGenericRepository<Parent>, GenericRepository<Parent>>();
            container.RegisterType<IGenericRepository<Mark>, GenericRepository<Mark>>();
            container.RegisterType<IGenericRepository<Grade>, GenericRepository<Grade>>();
            container.RegisterType<IGenericRepository<Administrator>, GenericRepository<Administrator>>();
            container.RegisterType<IGenericRepository<Semester>, GenericRepository<Semester>>();
            container.RegisterType<IGenericRepository<ClassNumber>,GenericRepository<ClassNumber>>();
            container.RegisterType<IGenericRepository<Role>, GenericRepository<Role>>();
            container.RegisterType<IGenericRepository<Exam>, GenericRepository<Exam>>();
            
            
            

            container.RegisterType<DbContext, DataAccessContext>(new HierarchicalLifetimeManager());

            container.RegisterType<IUserService, UserService>();
            container.RegisterType<ITeacherService, TeacherService>();
            container.RegisterType<IStudentService, StudentService>();
            container.RegisterType<IParentService, ParentService>();
            container.RegisterType<IMarkService, MarkService>();
            container.RegisterType<ISubjectService, SubjectService>();
            container.RegisterType<IAdministratorService, AdministratorService>();
            container.RegisterType<IGradeService, GradeService>();
            container.RegisterType<ISemesterService, SemesterService>();
            container.RegisterType<IClassNumberService, ClassNumberService>();
            container.RegisterType<IRoleService,RoleService > ();
            container.RegisterType<IExamService, ExamService>();

            

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}