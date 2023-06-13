using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionBoard.Infrastructure
{
    public static class DbConnect
    {
        public static InspectionBoardContext InspectionBoardContext;

        static DbConnect()
        {
            InspectionBoardContext = new InspectionBoardContext();
        }
    }
}
