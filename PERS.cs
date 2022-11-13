using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace testovoe
{
    /// <summary>
    /// Класс, содержащий персональные данные пациента
    /// </summary>
    [Serializable]
    [XmlRoot(ElementName = "PERS")]
    public class PERS
    {
        public PERS()
        { }

        public PERS(int id_pers, int n_zap, string id_pac, int w, DateTime dr, string smo, int vpolis, string spolis, string npolis,
                    CONTACTS contacts,int id_c,  int quarter, int month, string lpu1, string depth, string ss_Doc, string ss_Doc_D, int prvs_D, 
                    string ds_D, int place_D, string id_Tfoms, string com)
        {
            Id_pers = id_pers;
            N_zap = n_zap;
            Id_pac = id_pac;
            W = w;
            Dr = dr;
            Smo = smo;
            Vpolis = vpolis;
            Spolis = spolis;
            Npolis = npolis;
            Contacts = contacts;
            id_contacts = id_c;
            Quarter = quarter;
            Month = month;
            Lpu1 = lpu1;
            Depth = depth;
            Ss_Doc = ss_Doc;
            Ss_Doc_D = ss_Doc_D;
            Prvs_D = prvs_D;
            Ds_D = ds_D;
            Place_D = place_D;
            Id_Tfoms = id_Tfoms;
            Comment = com;
        }


        /// <summary>
        /// id пациента
        /// </summary>

        [XmlIgnore]
        public int Id_pers { set; get; }


        /// <summary>
        /// Номер позиции записи
        /// Уникально идентифицирует запись в пределах файла
        /// </summary>
        [XmlElement(ElementName = "N_ZAP")]
        public int N_zap { set; get; }


        /// <summary>
        /// Код записи о застрахованном лице
        /// Идентификатор пациента в медицинской информационной системе
        /// </summary>
        [XmlElement(ElementName = "ID_PAC")]
        public string Id_pac {set; get;}


        /// <summary>
        /// Пол застрахованного лица
        /// Заполняется в соответствии с классификатором V005 
        /// </summary>
        [XmlElement(ElementName = "W")]
        public int W { set; get; }


        /// <summary>
        /// Дата рождения застрахованного лица
        /// </summary>
        [XmlElement(ElementName = "DR")]
        public DateTime Dr { set; get; }


        /// <summary>
        /// Реестровый номер СМО
        /// Заполняется в соответствии со справочником 
        /// </summary>
        [XmlElement(ElementName = "SMO")]
        public string Smo { set; get; }


        /// <summary>
        /// Тип документа, подтверждающего факт страхования по ОМС
        /// Заполняется в соответствии со справочником 
        /// </summary>
        [XmlElement(ElementName = "VPOLIS")]
        public int Vpolis { set; get; }


        /// <summary>
        /// Серия документа, подтверждающего факт страхования по ОМС
        /// </summary>
        [XmlElement(ElementName = "SPOLIS")]
        public string Spolis { set; get; }


        /// <summary>
        /// Номер документа, подтверждающего факт страхования по ОМС
        /// </summary>
        [XmlElement(ElementName = "NPOLIS")]
        public string Npolis { set; get; }

        /// <summary>
        /// Контакты застрахованного лица
        /// </summary>
        [XmlElement(nameof(CONTACTS))]
        public CONTACTS Contacts { set; get; }

        [XmlIgnore]
        public int id_contacts { set; get; }


        /// <summary>
        /// Квартал, в котором планируется проведение профилактических мероприятий
        /// 1 – I квартал; 
        /// 2 - II квартал; 
        /// 3 - III квартал; 
        /// 4 - IV квартал.
        /// Обязательно заполняется в случае направления информации о прохождении профилактических осмотров и диспансеризации (DISP= ДВ1, ДВ3, ОПВ).
        /// </summary>
        [XmlElement(ElementName = "QUARTER")]
        public int Quarter { set; get; }


        /// <summary>
        /// Порядковый номер месяца, в котором планируется проведение профилактических мероприятий
        /// Обязательно заполняется в случае направления информации о диспансерном наблюдении (DISP=ДН).
        /// </summary>
        [XmlElement(ElementName = "MONTH")]
        public int Month { set; get; }


        /// <summary>
        /// Код подразделения, к которому прикреплен застрахованный
        /// </summary>
        [XmlElement(ElementName = "LPU1")]
        public string Lpu1 { set; get; }


        /// <summary>
        /// Код терапевтического участка, к которому прикреплен застрахованный
        /// </summary>
        [XmlElement(ElementName = "DEPTH")]
        public string Depth { set; get; }


        /// <summary>
        /// СНИЛС участкового врача
        /// Указывается без разделителей.
        /// </summary>
        [XmlElement(ElementName = "SS_DOC")]
        public string Ss_Doc { set; get; }


        /// <summary>
        /// СНИЛС врача осуществляющего диспансерное наблюдение
        /// Заполняется только в случае направления информации о диспансерном наблюдении (DISP=ДН). 
        /// Указывается без разделителей.
        /// </summary>
        [XmlElement(ElementName = "SS_DOC_D")]
        public string Ss_Doc_D { set; get; }


        /// <summary>
        /// Специальность врача, осуществляющего диспансерное наблюдение
        /// Заполняется только в случае направления информации о диспансерном наблюдении (DISP=ДН). 
        /// В соответствии со справочником.
        /// </summary>
        [XmlElement(ElementName = "PRVS_D")]
        public int Prvs_D { set; get; }


        /// <summary>
        /// Диагноз заболевания
        /// Заполняется только в случае направления информации о диспансерном наблюдении (DISP=ДН)
        /// </summary>
        [XmlElement(ElementName = "DS_D")]
        public string Ds_D { set; get; }


        /// <summary>
        /// Место проведения диспансерного наблюдения
        /// Заполняется только в случае направления информации о диспансерном наблюдении (DISP=ДН). 
        /// 1 – в медицинской организации;
        /// 2 – на дому.
        /// </summary>
        [XmlElement(ElementName = "PLACE_D")]
        public int Place_D { set; get; }


        /// <summary>
        /// Код застрахованного лица, заполненный ТФОМС при предоставлении списков в СМО
        /// </summary>
        [XmlElement(ElementName = "ID_TFOMS")]
        public string Id_Tfoms { set; get; }

        /// <summary>
        /// Служебное поле
        /// </summary>
        [XmlElement(ElementName = "COMMENT")]
        public string Comment { set; get; }
    }
}
