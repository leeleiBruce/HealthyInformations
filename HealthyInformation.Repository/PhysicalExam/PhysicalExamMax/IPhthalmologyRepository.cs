﻿using HealthyInformation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.Repository.PhysicalExam.PhysicalExamMax
{
    public interface IPhthalmologyRepository : IRepository<Phthalmology>
    {
        Phthalmology GetPhthalmologyByYear(int aircrewID, int year);

        Phthalmology GetPhthalmologyByKey(int transactionNumber);
    }
}
