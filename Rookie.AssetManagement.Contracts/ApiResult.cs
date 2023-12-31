﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rookie.AssetManagement.Contracts
{
    public class ApiResult<T>
    {
        public int StatusCode { get; set; }

        public string Message { get; set; }

        public T Data { get; set; }

        public ApiResult(T resultData)
        {
            Data = resultData;
        }
    }
}
