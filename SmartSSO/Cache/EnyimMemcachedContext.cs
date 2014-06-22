// 
// Copyright (c) 2014,SmartBooks
// All rights reserved.
// 
// 文件名称：EnyimMemcachedContext.cs
// 项目名称：WY.DC.Cache
// 摘      要：简要描述本文件的内容
// 
// 当前版本：1.0
// 作      者：ya wang
// 完成日期：2014年04月30日
// 

using System;
using Enyim.Caching;
using Enyim.Caching.Memcached;

namespace SmartSSO.Cache
{
    public sealed class EnyimMemcachedContext : CacheContext
    {
        private readonly MemcachedClient _memcachedClient = new MemcachedClient("SmartBooks/memcached");

        public override void Init()
        {
        }

        public override T Get<T>(string key)
        {
            return _memcachedClient.Get<T>(key);
        }

        public override bool Set<T>(string key, T t)
        {
            return _memcachedClient.Store(StoreMode.Set, key, t);
        }

        public override bool Remove(string key)
        {
            return _memcachedClient.Remove(key);
        }

        public override void Dispose()
        {
            if (_memcachedClient != null)
            {
                _memcachedClient.Dispose();
            }
        }
    }
}