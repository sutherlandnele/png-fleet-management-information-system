using System.Collections.Generic;

namespace FMS.Model
{



    public  class SystemParameterCode
    {

        public int Id { get; set; }


        public string ParameterCode { get; set; }

         public virtual List<SystemParameter> SystemParameters { get; set; }
    }
}
