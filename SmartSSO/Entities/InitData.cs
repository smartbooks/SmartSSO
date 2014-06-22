using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSSO.Entities
{
    /// <summary>
    /// 数据库初始化种子
    /// </summary>
    public sealed class InitData : CreateDatabaseIfNotExists<DefaultDbContext>
    {
        protected override void Seed(DefaultDbContext context)
        {
            new List<ManageUser>
            {
                new ManageUser
                {
                    UserName="mr.wangya@qq.com", 
                    UserPwd= "670b14728ad9902aecba32e22fa4f6bd", //000000
                    CreateTime = DateTime.Now,
                    Nick = "王亚",
                }
            }.ForEach(m => context.ManageUser.Add(m));

            new List<AppUser>
            {
                new AppUser
                {
                    UserName="admin@mfniu.com", 
                    UserPwd= "670b14728ad9902aecba32e22fa4f6bd", //000000
                    CreateTime = DateTime.Now,
                    Nick = "通金魔方",
                }
            }.ForEach(m => context.AppUser.Add(m));

            new List<AppInfo>
            {
                new AppInfo
                {
                    AppKey = "670b14728ad9902aecba32e22fa4f6bd",
                    AppSecret = "670b14728ad9902aecba32e22fa4f6bd",
                    Icon = "/Content/img/default-app.png",
                    IsEnable = true,
                    Remark = "豌豆荚豌豆荚豌豆荚豌豆荚豌豆荚豌豆荚",
                    ReturnUrl = "http://localhost:1558",
                    Title = "豌豆荚",
                    CreateTime = DateTime.Now,
                }
            }.ForEach(m => context.AppInfo.Add(m));
        }
    }
}
