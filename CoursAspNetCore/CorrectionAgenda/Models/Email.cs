using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CorrectionAgenda.Models
{
    public class Email
    {
        private int id;
        private string mail;
        private int contactId;
        private Contact contact;

        [Key]
        public int Id { get => id; set => id = value; }
        public string Mail { get => mail; set => mail = value; }
        public int ContactId { get => contactId; set => contactId = value; }

        [ForeignKey("ContactId")]
        public Contact Contact { get => contact; set => contact = value; }

    }
}
