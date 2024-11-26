﻿using System;

namespace OrganizationalApp.Models
{
    public class AddUsersViewModel
    {
        public int Id { get; set; }             // Maps to INT and primary key (NOT NULL)
        public int Level { get; set; }         // Maps to nullable INT
        public string? PkCode { get; set; }     // Maps to nullable VARCHAR(20)
        public string? FkCode { get; set; }     // Maps to nullable VARCHAR(20)
        public string? Code { get; set; }       // Maps to nullable VARCHAR(20)
        public string? Name { get; set; }       // Maps to nullable VARCHAR(50)
    }
}
