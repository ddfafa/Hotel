using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel
{
    internal class Number : IComparable<Number>
    {
        /// <summary>
        /// Содержит стоимость номера
        /// </summary>
        public double Cost { get; set; }

        /// <summary>
        /// Содержит порядковый номер
        /// </summary>
        public double Value { get; set; }

        /// <summary>
        /// Содержит описание номера
        /// </summary>
        public string Discription { get; set; }

        /// <summary>
        /// Содержит название номера
        /// </summary>
        public string Name { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is Number otherUser)
            {
                return Cost == otherUser.Cost &&
                       Value == otherUser.Value &&
                       Name == otherUser.Name;
            }

            return false;
        }

        public int CompareTo(Number other)
        {
            if (other == null)
            {
                return 1;
            }

            return Value.CompareTo(other.Value);
        }
    }
}
