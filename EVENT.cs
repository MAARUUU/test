using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace testovoe
{
    /// <summary>
    /// Класс, описывающий мероприятия
    /// </summary>
    [Serializable]
    [XmlRoot(ElementName = "EVENT")]
    public class EVENT
    {
        public EVENT()
        { }

        public EVENT(int id_event, int num, string disp, int num_m, int num_w, List<PERS> pers)
        {
            Id_event = id_event;
            Num_event = num;
            Disp = disp;
            Num_m = num_m;
            Num_w = num_w;
            Pers = pers;
        }


        public EVENT(int id_event, int num, string disp, int num_m, int num_w)
        {
            Id_event = id_event;
            Num_event = num;
            Disp = disp;
            Num_m = num_m;
            Num_w = num_w;
        }

        /// <summary>
        /// Id мероприятия
        /// </summary>

        [XmlIgnore]
        public int Id_event { set;  get; }


        [XmlIgnore]
        public int Num_event { set; get; }

        /// <summary>
        /// Тип профилактического мероприятия
        /// </summary>
        [XmlElement(ElementName = "DISP")]
        public string Disp { set;  get; }


        /// <summary>
        /// Количество сведений о мужчинах
        /// </summary>
        [XmlElement(ElementName = "KOL_M")]
        public int Num_m { set; get; }


        /// <summary>
        /// Количество сведений о женщинах
        /// </summary>
        [XmlElement(ElementName = "KOL_W")]
        public int Num_w { set; get; }


        /// <summary>
        /// Содержит персональные данные пациента
        /// </summary>
        [XmlElement(nameof(PERS))]
        public List<PERS> Pers { set; get; }
    }
}
