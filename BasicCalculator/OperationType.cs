using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BasicCalculator
{
    /// <summary>
    /// A type of operation a calculation can perform
    /// </summary>
    public enum OperationType
    {
        /// <summary>
        /// adds 2 values together
        /// </summary>
        Add,    

        /// <summary>
        /// Subtracts one value from another
        /// </summary>
        Minus,   

        /// <summary>
        /// Divides a value with another
        /// </summary>
        Divide,

        /// <summary>
        /// multiplies a value with another
        /// </summary>
        Multiply
    }
}
