using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace testovoe
{
    [Serializable]
    [XmlRoot(ElementName = "ZGLV")]
    public class ZGLV
    {
        /// <summary>
        /// Класс, описывающий заголовок файла
        /// </summary>
        public ZGLV()
        { }

        public ZGLV(int id_zglv, string numversion, DateTime data_Zglv, string filename, int year, string code_mo)
        {
            Id_zglv = id_zglv;
            Numversion = numversion;
            Data_Zglv = data_Zglv;
            Filename = filename;
            Year = year;
            Code_mo = code_mo;
        }

        /// <summary>
        /// Id заголовка файла
        /// </summary>

        [XmlIgnore]
        public int Id_zglv { set; get; }


        /// <summary>
        ///  Версия взаимодействия
        /// </summary>
        [XmlElement(ElementName = "VERSION")]
        public string Numversion { set; get; }


        /// <summary>
        /// Дата
        /// </summary>
        [XmlElement(ElementName = "DATA")]
        public DateTime Data_Zglv { set; get; }


        /// <summary>
        /// Имя файла
        /// </summary>
        [XmlElement(ElementName = "FILENAME")]
        public string Filename { set; get; }


        /// <summary>
        /// Год проведения профилактических мероприятий
        /// </summary>
        [XmlElement(ElementName = "YEAR")]
        public int Year { set; get; }


        /// <summary>
        /// Реестровый номер медицинской организации
        /// </summary>
        [XmlElement(ElementName = "CODE_MO")]
        public string Code_mo { set; get; }
    }
}
