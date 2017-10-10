﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using TechJobs.Data;
using TechJobs.Models;

namespace TechJobs.ViewModels
{
    public class NewJobViewModel
    {
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Employer")]
        public int EmployerID { get; set; }

        [Required]
        [Display(Name = "Location")]
        public int Location { get; set; }

        [Required]
        [Display(Name = "CoreCompetencies")]
        public int CoreCompetencies { get; set; }

        [Required]
        [Display(Name = "PositionType")]
        public int PositionType { get; set; }



        // TODO #3 - Included other fields needed to create a job,
        // with correct validation attributes and display names.

        public List<SelectListItem> Job { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> Employers { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> Locations { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> CoreCompetency { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> PositionTypes { get; set; } = new List<SelectListItem>();
        public static object IsValid { get; internal set; }

        public NewJobViewModel()
        {
            JobData jobData = JobData.GetInstance();

            foreach (Job field in jobData.Jobs.ToList())
            {
                Job.Add(new SelectListItem
                {
                    Value = field.ID.ToString(),
                    Text = field.Name
                });
            }
            foreach (Employer field in jobData.Employers.ToList())
            {
                Employers.Add(new SelectListItem {
                    Value = field.ID.ToString(),
                    Text = field.Value
                });
            }
            foreach (Location field in jobData.Locations.ToList())
            {
                Locations.Add(new SelectListItem
                {
                    Value = field.ID.ToString(),
                    Text = field.Value
                });
            }
            foreach (PositionType field in jobData.PositionTypes.ToList())
            {
                PositionTypes.Add(new SelectListItem
                {
                    Value = field.ID.ToString(),
                    Text = field.Value
                });
            }
            foreach (CoreCompetency field in jobData.CoreCompetencies.ToList())
            {
                CoreCompetency.Add(new SelectListItem
                {
                    Value = field.ID.ToString(),
                    Text = field.Value
                });
            }

            // TODO #4 - populate the other List<SelectListItem> 
            // collections needed in the view

        }
    }
}
