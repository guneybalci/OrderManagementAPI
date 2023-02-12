using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessResult : Result
    {
        // başarılı olduğunda sadece message vermek istiyorsa
        public SuccessResult(string message):base(true,message)
        {

        }

        // Mesaj vermek istemiyorsa
        public SuccessResult() : base(true)
        {
        }
    }
}
