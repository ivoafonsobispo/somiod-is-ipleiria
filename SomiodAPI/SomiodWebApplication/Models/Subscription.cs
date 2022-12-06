﻿using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace SomiodWebApplication.Models
{
    public class Subscription
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TypeSmallDateTimeSchemaImporterExtension Creation_dt { get; set; }
        public int Parent { get; set; }
        public string Event { get; set; }
        public string Endpoint { get; set; }
    }
}