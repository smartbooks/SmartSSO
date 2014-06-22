using System.Data.Entity;

namespace SmartSSO.Entities
{
    /// <summary>
    /// 默认数据上下文
    /// </summary>
    public class DefaultDbContext : DbContext
    {
        /// <summary>
        /// 系统管理用户表
        /// </summary>
        public DbSet<ManageUser> ManageUser { get; set; }

        /// <summary>
        /// 应用用户表
        /// </summary>
        public DbSet<AppUser> AppUser { get; set; }

        /// <summary>
        /// 应用信息
        /// </summary>
        public DbSet<AppInfo> AppInfo { get; set; }

        /// <summary>
        /// 用户授权操作
        /// </summary>
        public DbSet<UserAuthOperate> UserAuthOperate { get; set; }

        /// <summary>
        /// 用户授权会话
        /// </summary>
        public DbSet<UserAuthSession> UserAuthSession { get; set; }
    }
}