﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Sportlance.DAL.Core;

namespace Sportlance.DAL.Entities
{
    public class Sport: IEntityWithId
    {
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        public IReadOnlyCollection<TrainerSports> TrainerSports { get; set; }
    }
}
