﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Web.API.LogProvider
{
    public enum LoggingEvents
    {
        GENERATE_ITEMS = 1000,
        LIST_ITEMS = 1001,
        GET_ITEM,
        INSERT_ITEM,
        UPDATE_ITEM,
        DELETE_ITEM
    }
}
