using AuthServerPractice.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthServerPractice.Data
{
    //Üyelik sistemi ile ilgili de bir context olduğundan dolayı IdentityDbContext kullanıyoruz.
    //IdentiyyRole --> Identity kütüphanesinden geliyor.
    public class AppDbContext:IdentityDbContext<UserApp,IdentityRole,string>
    {
        //DbContextOptions'ı startup.s tarafında dolduruluyoruzzz !11! (Hani Option mesele)
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        //Kullanıcı ile ilgili tüm DbSet'ler IdentityDbContext'ten miras olarak geliyorrr !11! (Token, Roller tutan tablolar vb.)
        //Haricindeki DbSet'leri aşağıda tanımladık.
        public DbSet<Product> Products { get; set; }
        public DbSet<UserRefreshToken> UserRefreshToken { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            //ApplyConfiAssembly: IEntityConfigurat,on implemente etmiş tüm class'ları bulup buraya ekliyor.
            builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            base.OnModelCreating(builder);
        }
    }
}
