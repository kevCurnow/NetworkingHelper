﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkingHelper.Models.ConnectionModels
{
    public class ConnectionEditModel
    {
        [Required]
        public int ConnectionID { get; set; }

        [Required]
        public string ConnectionName { get; set; }

        [Required]
        public string Job { get; set; }

        [Required]
        public string Employer { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Notes { get; set; }

        [Required]
        public int EventID { get; set; }

    }
}
