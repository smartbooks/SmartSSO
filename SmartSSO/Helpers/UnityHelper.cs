// 
// Copyright (c) 2014,SmartBooks
// All rights reserved.
// 
// 文件名称：UnityHelper.cs
// 项目名称：WY.DC
// 摘      要：简要描述本文件的内容
// 
// 当前版本：1.0
// 作      者：ya wang
// 完成日期：2014年05月13日
// 

using System.Configuration;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace SmartSSO.Helpers
{
    public sealed class UnityHelper
    {
        #region 单例

        private static readonly UnityHelper _instance = new UnityHelper();

        public static UnityHelper Instance
        {
            get
            {
                return _instance;
            }
        }

        #endregion

        private readonly IUnityContainer _unityContainer = new UnityContainer();

        public UnityHelper()
        {
            var configuration = ConfigurationManager.GetSection(UnityConfigurationSection.SectionName) as UnityConfigurationSection;
            if (configuration != null)
            {
                configuration.Configure(_unityContainer, "defaultContainer");
            }
        }

        public IUnityContainer Unity
        {
            get { return _unityContainer; }
        }
    }
}