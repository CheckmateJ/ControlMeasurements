using ControlMeasurements.Data;
using ControlMeasurements.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlMeasurements.ViewModels
{
    public class HomeIndexViewModel
    {
        private MeasurementsContext __context;

        public List<Models.Measurement> Result(MeasurementsContext context)
        {
            __context = context;
            var querry = __context.Measurements.Select(x => x)
                .Where(n => n.MeasurementType == MeasurementType.Water).Take(2).ToList();
            return (querry);
        }
       
    }
        
    
}
