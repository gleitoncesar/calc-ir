using CalcIR.Repository;
using Microsoft.EntityFrameworkCore;

namespace CalcIR.Service
{
    public class BaseService
    {
        internal CalcIRContext Context { get; private set; }

        public BaseService()
        {
            var contextOptions = new DbContextOptionsBuilder<CalcIRContext>();
            
            Context = new CalcIRContext(contextOptions.Options);
        }

        public BaseService(CalcIRContext context)
        {
            Context = context;
        }
    }
}