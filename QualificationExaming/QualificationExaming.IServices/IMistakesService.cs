﻿using QualificationExaming.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualificationExaming.IServices
{
    
    public interface IMistakesService
    {
        int AddMistakes(int id);
        List<Mistakes> GetMistakes();
    }
}
