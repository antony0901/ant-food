﻿using System;
using AntFood.Contracts.Enums;

namespace AntFood.Contracts
{
    public class TableType
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Order { get; set; }

        public int Capacity { get; set; }

        public Status Status { get; set; }
    }
}
