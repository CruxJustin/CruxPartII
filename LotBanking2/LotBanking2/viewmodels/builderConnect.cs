using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using LotBanking2.Models;

namespace LotBanking2.viewmodels
{
    
    public class builderConnect
    {  
        
        public builder builder { get; set; }
        public contact contact { get; set; }
        public  phone phones { get; set; }
        public  email email { get; set; }
        public  address address { get; set; }
        public virtual ICollection<builder_contacts> builder_contacts { get; set; }
        public builder_contacts BC { get; set; }



        public void contactinfo(LotBankEntities db)
        {
            this.BC = new builder_contacts();

            this.contact.date_created = DateTime.Now;
            this.contact.date_modified = DateTime.Now;

            this.contact.phone.date_created = DateTime.Now;
            this.contact.phone.date_modified = DateTime.Now;

            this.contact.email.date_created = DateTime.Now;
            this.contact.email.date_modified = DateTime.Now;

            this.contact.address.date_created = DateTime.Now;
            this.contact.address.date_modified = DateTime.Now;

            this.BC.contact = this.contact;
            this.BC.phone = this.contact.phone;
            this.BC.email = this.contact.email;
            this.BC.address = this.contact.address;

            db.contacts.Add(this.BC.contact);
            db.phones.Add(this.BC.phone);
            db.emails.Add(this.BC.email);
            db.addresses.Add(this.BC.address);
         
        }

        public void fill(LotBankEntities db)
        {
            this.BC = new builder_contacts();
            
            this.builder.date_created = DateTime.Now;
            this.builder.date_modified = DateTime.Now;
            db.builders.Add(builder);

            this.contact.date_created = DateTime.Now;
            this.contact.date_modified = DateTime.Now;

            this.contact.phone.date_created = DateTime.Now;
            this.contact.phone.date_modified = DateTime.Now;

            this.contact.email.date_created = DateTime.Now;
            this.contact.email.date_modified = DateTime.Now;

            this.contact.address.date_created = DateTime.Now;
            this.contact.address.date_modified = DateTime.Now;

            this.BC.contact = this.contact;
            this.BC.builder = this.builder;
            this.BC.phone = this.contact.phone;
            this.BC.email = this.contact.email;
            this.BC.address = this.contact.address;

            db.builder_contacts.Add(this.BC);
            db.contacts.Add(this.BC.contact);
            db.phones.Add(this.BC.phone);
            db.emails.Add(this.BC.email);
            db.addresses.Add(this.BC.address);
        }

        public void findContact(LotBankEntities db, int id = 0)
        {
            this.contact = db.contacts.Find(id);
            this.contact.get(db);
        }

        public void find(LotBankEntities db, int id = 0)
        {
            this.builder = db.builders.Find(id);
            builder_contacts builder_contacts = db.builder_contacts.Where(x => x.builderid == id).First();
            this.contact = builder_contacts.contact;
            this.contact.get(db);
        }

        public void updateContact(LotBankEntities db)
        {
            var contact = db.contacts.Find(this.contact.id);
            var phone = db.phones.Find(this.contact.phone.id);
            var email = db.emails.Find(this.contact.email.id);
            var address = db.addresses.Find(this.contact.address.id);
            this.contact.update(db);

            /* Contact Information */
            contact.date_modified = DateTime.Now;
            contact.company = this.contact.company;
            contact.name = this.contact.name;
            contact.title = this.contact.title;
            /* Contact Information has been updated */

            /* Phone Information */
            phone.date_modified = DateTime.Now;
            phone.type = this.contact.phone.type;
            phone.phone1 = this.contact.phone.phone1;
            phone.contactid = this.contact.id;
            /* Phone Information has been updated */

            /* Email Information */
            email.date_modified = DateTime.Now;
            email.type = this.contact.email.type;
            email.email1 = this.contact.email.email1;
            email.contactid = this.contact.id;
            /* Email Information has been updated */


            /* Address Information */
            address.date_modified = DateTime.Now;
            address.address1 = this.contact.address.address1;
            address.address2 = this.contact.address.address2;
            address.address3 = this.contact.address.address3;
            address.city = this.contact.address.city;
            address.state = this.contact.address.state;
            address.zipcode = this.contact.address.zipcode;
            address.county = this.contact.address.county;
            address.contactid = this.contact.id;
            /* Address Information has been updated */

            db.SaveChanges();

        }

        public void update(LotBankEntities db)
        { 
            var builder = db.builders.Find(this.builder.id);
            var contact = db.contacts.Find(this.contact.id);
            var phone = db.phones.Find(this.contact.phone.id);
            var email = db.emails.Find(this.contact.email.id);
            var address = db.addresses.Find(this.contact.address.id);
            this.contact.update(db);
            
            /* Builder information */
            builder.date_modified = DateTime.Now;
            builder.buildername = this.builder.buildername;
            builder.optioneename = this.builder.optioneename;
            builder.contractorname = this.builder.contractorname;
            builder.website = this.builder.website;
            builder.current_litigation = this.builder.current_litigation;
            builder.current_litigation_abstract = this.builder.current_litigation_abstract;
            builder.past_litigation = this.builder.past_litigation;
            builder.past_litigation_abstract = this.builder.past_litigation_abstract;
            builder.buildercol = this.builder.buildercol;
            /* Builder Information has been updated */

            /* Contact Information */
            contact.date_modified = DateTime.Now;
            contact.company = this.contact.company;
            contact.name = this.contact.name;
            contact.title = this.contact.title;
            /* Contact Information has been updated */

            /* Phone Information */
            phone.date_modified = DateTime.Now;
            phone.type = this.contact.phone.type;
            phone.phone1 = this.contact.phone.phone1;
            phone.contactid = this.contact.id;
            /* Phone Information has been updated */

            /* Email Information */
            email.date_modified = DateTime.Now;
            email.type = this.contact.email.type;
            email.email1 = this.contact.email.email1;
            email.contactid = this.contact.id;
            /* Email Information has been updated */

            
            /* Address Information */
            address.date_modified = DateTime.Now;
            address.address1 = this.contact.address.address1;
            address.address2 = this.contact.address.address2;
            address.address3 = this.contact.address.address3;
            address.city = this.contact.address.city;
            address.state = this.contact.address.state;
            address.zipcode = this.contact.address.zipcode;
            address.county = this.contact.address.county;
            address.contactid = this.contact.id;
            /* Address Information has been updated */

            db.SaveChanges();

        }

    }
}