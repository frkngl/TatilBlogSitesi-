using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TatilSeyahatSitesiMvc5.Models
{
    public class BlogYorum
    {
        public List<TBLBLOG> bloglar { get; set; }
        public List<TBLYORUMLAR> yorumlar { get; set; }
        public List<TBLBLOG> bloglar2 { get; set; }
        public List<TBLYORUMLAR> yorumlar2 { get; set; }

        //-------------------------------------------------
        public List<TBLACIKLAMA> aciklama { get; set; }

        //-------------------------------------------------
        public List<TBLOTELLER> oteller { get; set; }
        public List<TBLOTELYORUM> otelyorumlar { get; set; }
        public List<TBLOTELLER> oteller2 { get; set; }
        public List<TBLOTELYORUM> otelyorumlar2 { get; set; }

        //-------------------------------------------------
        public List<TBLRESTAURANT> restaurant {  get; set; }
        public List<TBLRESTAURANTYORUM> restaurantyorum { get; set; }
        public List<TBLRESTAURANT> restaurant2 { get; set; }
        public List<TBLRESTAURANTYORUM> restaurantyorum2 { get; set; }  

        //--------------------------------------------------
        public List<TBLMUZELER> muzeler { get; set; }
        public List<TBLMUZEYORUM> muzeyorum { get; set; }
        public List<TBLMUZELER> muzeler2 { get; set; }
        public List<TBLMUZEYORUM> muzeyorum2 { get; set; }

        //---------------------------------------------------
    }
}