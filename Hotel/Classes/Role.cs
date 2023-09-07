using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel
{
    internal class Role
    {
        /// <summary>
        /// Содержит группу пользователя, в которой он находится
        /// </summary>
        public UserGroup UserGroup { get; set; } = UserGroup.Guest;

        /// <summary>
        /// Содержит возможность пользоваителю изменять данные о номере
        /// </summary>
        public bool IsChangeNumbers { get; set; } = false;

        /// <summary>
        /// Содержит возможность изменять описание номера
        /// </summary>
        public bool IsViewNumInfo { get; set; } = false;

        /// <summary>
        /// Содержит возможность добовлять новые услуги
        /// </summary>
        public bool IsAddServise { get; set; } = false;
    }
}
