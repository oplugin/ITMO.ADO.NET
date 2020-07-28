using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Linq;
using System.Data.Linq.Mapping;


namespace _0._2.LINQ_to_Entities
{
    [Table(Name = "Person")]
    public class Person
    {
        private int _PersonID;
        [Column(IsPrimaryKey = true, Storage = "_PersonID")]
        public int PersonID
        {
            get
            {
                return this._PersonID;
            }
            set
            {
                this._PersonID = value;
            }
        }
        private string _LastName;
        [Column(Storage = "_LastName")]
        public string LastName
        {
            get
            {
                return this._LastName;
            }
            set
            {
                this._LastName = value;
            }
        }
        public override string ToString()
        {
            return PersonID + "\t" + LastName;
        }
    }
}
