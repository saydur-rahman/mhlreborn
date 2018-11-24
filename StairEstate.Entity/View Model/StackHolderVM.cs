using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StairEstate.Entity.View_Model
{
    public class StackHolderVM
    {
        public StackHolderVM(sales_stack_holder model)
        {
            Id = model.stack_holder_id;
            Name = model.stack_holder_name;
            Email = model.stack_holder_email;
            Father = model.stack_holder_Father_name;
            Mother = model.stack_holder_Father_name;
            ContactPerson = model.stack_holder_contact_person;
            ContactPersonMobileNo = model.stack_holder_contact_person_number;
            AddressPer = model.stack_holder_per_address;
            AddressPre = model.stack_holder_pre_address;
            NId = model.stack_holder_nid_no;
            Dob = model.stack_holder_Dob;
            Country = model.sys_country;
            StackHolderType = model.sales_stack_holder_type;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Father { get; set; }

        public string Mother { get; set; }

        public string ContactPerson { get; set; }

        public string ContactPersonMobileNo { get; set; }

        public string AddressPre { get; set; }

        public string AddressPer { get; set; }

        public string NId { get; set; }

        public DateTime? Dob { get; set; }

        public sys_country Country { get; set; }

        public sales_stack_holder_type StackHolderType { get; set; }
    }
}
