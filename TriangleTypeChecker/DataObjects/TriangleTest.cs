using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleTypeChecker.DataObjects
{
    public class TriangleTest
    {
        #region Construction
        public TriangleTest(int testID, ulong sideA, ulong sideB, ulong sideC, TriangleTypeEnum expectedType)
        {
            TestID = testID;
            TestTriangle = new Triangle(sideA, sideB, sideC);
            ExpectedTriangleType = expectedType;
        }
        #endregion
        #region Public Properties
        public int TestID { get; set; }
        public Triangle TestTriangle { get; set; }
        public TriangleTypeEnum ExpectedTriangleType { get; set; }
        public TriangleTypeEnum ResultTriangleType
        {
            get
            {
                if(TestTriangle == null)
                {
                    return TriangleTypeEnum.NONE;
                }
                return TestTriangle.TriangleType;
            }
        }
        #endregion  
    }
}
