using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace testovoe
{
    /// <summary>
    /// Класс, описывающий контакты застрахованного лица
    /// </summary>

    [Serializable]
    [XmlRoot(ElementName = "CONTACTS")]
    public class CONTACTS
    {
        public CONTACTS()
        {}

        public CONTACTS(int id_contacts, string phone_f, string phone_m, string email, string address)
        {
            Id_contacts = id_contacts;
            Phone_f = phone_f;
            Phone_m = phone_m;
            Email = email;
            Address = address;
        }


        /// <summary>
        /// id контакта застрахованного лица
        /// </summary>

        [XmlIgnore]
        public int Id_contacts { set; get; }


        /// <summary>
        /// Номер телефона пациента
        /// </summary>
        [XmlElement(ElementName = "PHONE_F")]
        public string Phone_f { set; get; }


        /// <summary>
        /// Номер мобильного телефона пациента
        /// </summary>
        [XmlElement(ElementName = "PHONE_M")]
        public string Phone_m { set; get; }


        /// <summary>
        /// Адрес электронной почты застрахованного лица
        /// </summary>
        [XmlElement(ElementName = "EMAIL")]
        public string Email { set; get; }


        /// <summary>
        /// Адрес места жительства
        /// </summary>
        [XmlElement(ElementName = "ADDRESS")]
        public string Address { set; get; }

    }
}
