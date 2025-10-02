using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileUploaderDemo.Models
{
    internal static class FileUploaderConstants
    {
        public const int MaxProgress = 10;

        public static class StatusMessages
        {
            public const string InProgress = "In Progress";
            public const string Complete = "Complete";
        }
    }
}
