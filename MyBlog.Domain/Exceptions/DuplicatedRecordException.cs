using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Domain.Exceptions
{
    public class DuplicatedRecordException:Exception
    {
        public DuplicatedRecordException(string message):base(message)
        {

        }
    }
}
