using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kursach_1.Classes;
using Microsoft.EntityFrameworkCore;

namespace Kursach_1.Migrations
{
    public partial class Requests
    {
        public string RequestUserString
        {
            get
            {
                Requests req = App.db.Requests.FirstOrDefault();
                App.db.Entry(req).Reference(r => r.Users).Load();
                return req.Users.surname + " " + req.Users.name + " " + req.Users.surname;
            }
        }

        public string RequestTemaString
        {
            get
            {
                Requests req = App.db.Requests.FirstOrDefault();
                App.db.Entry(req).Reference(r => r.Tema).Load();
                return req.Tema.name_tema;
            }
        }

        public string RequestStatusString
        {
            get
            {
                //Requests req = App.db.Requests.FirstOrDefault();
                if (StatusId == 1)
                    return "Отправлена";
                else if (StatusId == 2) 
                    return "В работе";
                else if (StatusId == 3)
                    return "Закрыта";
                else return "";
            }
        }

        public string DateStartRequest
        {
            get
            {
                if (date_start == null)
                {
                    return string.Empty;
                }
                else
                {
                    return date_start.Date.ToShortDateString();
                }
            }
        }

        public string DateFinishRequest
        {
            get
            {
                if (date_finish == null)
                {
                    return string.Empty;
                }
                else
                {
                    return date_finish.Date.ToShortDateString();
                }
            }
        }

        public string BackColor
        {
            get
            {
                if (StatusId == 1) 
                    return "#98FB98";
                else if (StatusId == 2)
                    return "#FFA07A";
                else if (StatusId == 3)
                    return "#CD5C5C";
                else
                    return "white";
            }
        }
    }
}
