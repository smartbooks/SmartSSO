// 
// Copyright (c) 2014,SmartBooks
// All rights reserved.
// 
// 文件名称：IPagedResult.cs
// 项目名称：WY.DC.Service
// 摘      要：简要描述本文件的内容
// 
// 当前版本：1.0
// 作      者：ya wang
// 完成日期：2014年05月05日
// 

using System.Collections.Generic;

namespace SmartSSO.Services.Util
{
    public sealed class PagedResult<T> : Paged where T : class
    {
        public IList<T> Result { get; set; }

        public PagedResult()
        {
            Result = new List<T>();
        }
    }
}