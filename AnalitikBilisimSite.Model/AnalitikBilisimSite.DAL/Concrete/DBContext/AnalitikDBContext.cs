using AnalitikBilisimSite.Model.Entities;
using AnalitikBilisimSite.Model.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalitikBilisimSite.DAL.Concrete.DBContext
{
    public class AnalitikDBContext : DbContext
    {
        public AnalitikDBContext() : base("Server=.;Database=AnalitikBilisimDB;Integrated Security=true")
        {
            Database.SetInitializer(new DataBaseDataCreater());
        }

        public DbSet<Common> Common { get; set; }
        public DbSet<About> About { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Referance> Referance { get; set; }
        public DbSet<Services> Services { get; set; }
        public DbSet<Solution> Solution { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<SolutionCategory> SolutionCategory { get; set; }
        public DbSet<ServicesDetail> ServicesDetail { get; set; }
        public DbSet<Visitor> Visitor { get; set; }
        public DbSet<Slider> Slider { get; set; }
        public DbSet<Language> Language { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CommonMapping());
            modelBuilder.Configurations.Add(new ContactMapping());
            modelBuilder.Configurations.Add(new AboutMapping());
            modelBuilder.Configurations.Add(new NewsMapping());
            modelBuilder.Configurations.Add(new ReferanceMapping());
            modelBuilder.Configurations.Add(new ServicesMapping());
            modelBuilder.Configurations.Add(new SolutionMapping());
            modelBuilder.Configurations.Add(new UsersMapping());
            modelBuilder.Configurations.Add(new SolutionCategoryMapping());
            modelBuilder.Configurations.Add(new ServicesDetailMapping());
            modelBuilder.Configurations.Add(new VisitorMapping());
            modelBuilder.Configurations.Add(new SliderMapping());
            modelBuilder.Configurations.Add(new LanguageMapping());
        }
    }

    public class DataBaseDataCreater : DropCreateDatabaseIfModelChanges<AnalitikDBContext>
    {
        protected override void Seed(AnalitikDBContext context)
        {
            Common common = new Common();
            common.Logo = "~/Assets/img/analitik.png";
            common.CompanyName = "Analitik Bilişim";
            common.URL = "http://www.analitikbilisim.com";
            common.CreatedBy = 1;
            common.CreatedDate = DateTime.Now;
            common.IsActive = true;
            context.Common.Add(common);

            Contact contact = new Contact();
            contact.Phone = "02163943949";
            contact.Fax = "02163943981";
            contact.Address = "Değirmen sk. AR Plaza A Blok No:16 Kat:10 D:102 Kozyatağı/Kadıköy/İstanbul";
            contact.Email = "analitikbilisim@gmail.com";
            contact.CreatedBy = 1;
            contact.CreatedDate = DateTime.Now;
            contact.IsActive = true;
            context.Contact.Add(contact);

            About about = new About();
            about.Title = "BİZ KİMİZ";
            about.SmallWriting = "Analitik Bilişim(AB), 2009 yılında uzun yıllar bilişim sektöründe tecrübe kazanmış deneyimli kadrosuyla kurulmuştur.";
            about.BigWriting = "Analitik Bilişim(AB), 2009 yılında uzun yıllar bilişim sektöründe tecrübe kazanmış deneyimli kadrosuyla kurulmuştur. Yılların getirdiği deneyimimizi MS Dynamics Ax'a entegre ederek hızlı, düşük maliyetli, etkin ve yüksek standartlarda çözümler üretiyoruz.</br> AB danışmanları olarak onlarca projede bulunmanın avantajıyla ürettiğimiz güçlü, çevik, esnek ve sade çözümlerimizle katma değer üretiyoruz.MS Dynamics Ax çalışma ortamının avantajlarını, iş süreçlerinizde size özgü ihtiyaçlarınıza analitik çözümler getiriyoruz.";
            about.Image = "~/Assets/img/about1.jpg";
            about.MissionImage = "~/Assets/img/about-mission.jpg";
            about.MissionTitle = "Misyonumuz";
            about.MissionWriting = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean rhoncus, odio a euismod vestibulum, tortor dolor pellentesque orci, vel euismod elit est nec enim. Morbi commodo velit mi, nec fringilla odio luctus eu. Etiam ac magna vel nulla bibendum aliquet. Vivamus et massa ac ex iaculis interdum vel in mi. Suspendisse justo felis, tristique sed rutrum eu, rhoncus ac ligula. Morbi varius sit amet nulla quis maximus. Phasellus egestas velit quis viverra interdum. Pellentesque in odio in odio consectetur malesuada. Curabitur diam mi, tempor ut massa eu, maximus congue turpis.";
            about.PlanImage = "~/Assets/img/about-plan.jpg";
            about.PlanTitle = "Planlarımız";
            about.PlanWriting = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean rhoncus, odio a euismod vestibulum, tortor dolor pellentesque orci, vel euismod elit est nec enim. Morbi commodo velit mi, nec fringilla odio luctus eu. Etiam ac magna vel nulla bibendum aliquet. Vivamus et massa ac ex iaculis interdum vel in mi. Suspendisse justo felis, tristique sed rutrum eu, rhoncus ac ligula. Morbi varius sit amet nulla quis maximus. Phasellus egestas velit quis viverra interdum. Pellentesque in odio in odio consectetur malesuada. Curabitur diam mi, tempor ut massa eu, maximus congue turpis.";
            about.VisionImage = "~/Assets/img/about-vision.jpg";
            about.VisionTitle = "Vizyonumuz";
            about.VisionWriting = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean rhoncus, odio a euismod vestibulum, tortor dolor pellentesque orci, vel euismod elit est nec enim. Morbi commodo velit mi, nec fringilla odio luctus eu. Etiam ac magna vel nulla bibendum aliquet. Vivamus et massa ac ex iaculis interdum vel in mi. Suspendisse justo felis, tristique sed rutrum eu, rhoncus ac ligula. Morbi varius sit amet nulla quis maximus. Phasellus egestas velit quis viverra interdum. Pellentesque in odio in odio consectetur malesuada. Curabitur diam mi, tempor ut massa eu, maximus congue turpis.";
            about.CreatedBy = 1;
            about.CreatedDate = DateTime.Now;
            about.IsActive = true;
            context.About.Add(about);

            Users user = new Users();
            user.UserName = "FurkanT";
            user.FirstName = "Furkan";
            user.LastName = "Türküzel";
            user.Email = "furkan.turkuzel@gmail.com";
            user.Password = "123456";
            user.UserRole = "High";
            user.UserImage = "img/ben.jpg";
            user.CreatedBy = 1;
            user.CreatedDate = DateTime.Now;
            user.IsActive = true;
            context.Users.Add(user);

            context.SaveChanges();
        }
    }
}
