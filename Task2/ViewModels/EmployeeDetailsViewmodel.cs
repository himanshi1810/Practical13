﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Task2.ViewModels
{
	public class EmployeeDetailsViewModel
	{
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string DesignationName { get; set; }
        public DateTime DOB { get; set; }
        public string MobileNumber { get; set; }
        public string Address { get; set; }
        public decimal Salary { get; set; }

    }
}