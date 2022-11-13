using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace testovoe
{
    [Serializable, XmlRoot(ElementName = "ZL_LIST")]
    public class ZL__LIST
    {
       // Сведения о лицах, подлежащих профилактическим осмотрам //
        public ZL__LIST()
        { }

        public ZL__LIST(int id_list, List<EVENT> num_event)
        {
            Id_list = id_list;
            Num_event = num_event;
        }

        public ZL__LIST(int id, List<EVENT> num_event, ZGLV num_zglv)
        {
            Id_list = id;
            Num_event = num_event;
            Num_zglv = num_zglv;
        }

        [XmlIgnore]
        public int Id_list { set; get; }

        /// <summary>
        /// Мероприятие
        /// Сведения о профилактических мероприятиях
        /// </summary>
        [XmlElement(nameof(EVENT))]
        public List<EVENT> Num_event { set; get; }


        /// <summary>
        /// Заголовок файла
        /// Информация о передаваемом файле
        /// </summary>
        [XmlElement(nameof(ZGLV))]
        public ZGLV Num_zglv { set; get; }

    }
}
